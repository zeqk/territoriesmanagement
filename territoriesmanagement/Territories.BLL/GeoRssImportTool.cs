using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.Objects;
using System.IO;
using GeoRSSLibrary;
using GeoRSSLibrary.GeoRssItems;
using Territories.Model;

namespace Territories.BLL
{
    public class GeoRssImportTool
    {

        TerritoriesDataContext _dm;

        private Func<TerritoriesDataContext, int, IQueryable<Direction>> _compiledLoadDirectionById;
        private Func<TerritoriesDataContext, int, IQueryable<Territory>> _compiledLoadTerritoryById;

        string log;

        public GeoRssImportTool()
        {
            _dm = new TerritoriesDataContext();

        }

        public bool ImportGeoRss(string path, ref string importMessage,bool departments, bool cities, bool territories, bool directions)
        {
            bool rv = true;    
            List<IGeoRssItem> geoRssItems = ReadMarks(path);

            PreCompileQueries();

            if (territories)
            {
                List<Polygon> polygons = geoRssItems.Where(item => item.GetType() == typeof(Polygon)).Cast<Polygon>().ToList();
                AddPolygonsToTerritories(polygons);
            }

            if (directions)
            {
                List<Point> points = geoRssItems.Where(item => item.GetType() == typeof(Point)).Cast<Point>().ToList();
                AddPointsToDirections(points);
            }

            DeleteNoUseGeoPositions();

            return rv;
        }

        #region AddGeoRssItemsToModel

        public void AddPointsToDirections(List<Point> geoItems)
        {            
            string message ="";
            foreach (Point point in geoItems)
            {
                int id = 0;
                try
                {
                    if (TryExtractId(point.Description, out id))
                    {
                        var results = _dm.directions_GetById(id).ToList();
                        
                        if (results.Count>0)
                        {
                            Direction v = results.First();
                            v.GeoPositions.Load();

                            if (v.GeoPositions.Count > 0)
                            {                                
                                GeoPosition originalGeoPos = v.GeoPositions.First();
                                if (originalGeoPos.Latitude!=point.Coordinates.Latitude || 
                                    originalGeoPos.Longitude!=point.Coordinates.Longitude)
                                {
                                    GeoPosition nGeoPos = originalGeoPos;
                                    nGeoPos.Date = DateTime.Now;
                                    nGeoPos.Latitude = point.Coordinates.Latitude;
                                    nGeoPos.Longitude = point.Coordinates.Longitude;
                                    _dm.ApplyPropertyChanges("GeoPositions", nGeoPos);
                                }
                            }
                            else
                            {
                                GeoPosition nGeoPos = new GeoPosition();
                                nGeoPos.Date = DateTime.Now;
                                nGeoPos.Latitude = point.Coordinates.Latitude;
                                nGeoPos.Longitude = point.Coordinates.Longitude;
                                _dm.AddToGeoPositions(nGeoPos);
                                v.GeoPositions.Add(nGeoPos);
                            }
                            
                        }
                        else
                            message += "\nMark: " + point.Guid + " direction id " + id + " dont't exist.";

                    }
                    else
                        message += "\nMark: " + point.Guid + " " + point.Description + " " + " haven't direction id.";
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }//end foreach

            _dm.SaveChanges();
            log += message;
            SaveLog();
            
        }

        public void AddPolygonsToTerritories(List<Polygon> geoItems)
        {
            string message = "";
            foreach (Polygon polygon in geoItems)
            {
                int id = 0;
                try
                {
                    if (polygon.Description.Contains("territory"))
                    {
                        if (TryExtractId(polygon.Description, out id))
                        {
                            var results = _dm.territories_GetById(id).ToList();
                            if (results.Count > 0)
                            {
                                Territory v = results.First();
                                v.GeoPositions.Load();

                                if (v.GeoPositions.Count == 0 || (v.GeoPositions.Count!=polygon.Coordinates.Count))
                                {
                                    v.GeoPositions.Clear();
                                    foreach (Coordinates coord in polygon.Coordinates)
                                    {
                                        GeoPosition newPos = new GeoPosition();
                                        newPos.Latitude = coord.Latitude;
                                        newPos.Longitude = coord.Longitude;
                                        newPos.Date = DateTime.Now;
                                        _dm.AddToGeoPositions(newPos);
                                        v.GeoPositions.Add(newPos);
                                    }
                                }
                            }
                            else
                                message += "\nMark: " + polygon.Guid + " territory id " + id + " dont't exist.";

                        }
                        else
                            message += "\nMark: " + polygon.Guid + " " + polygon.Description + " " + " haven't territory id";
                    }
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }//end foreach
            _dm.SaveChanges();

            log += message;
            SaveLog();

        }

        public void DeleteNoUseGeoPositions()
        {
            try
            {
                IQueryable<GeoPosition> list = _dm.GeoPositions.Where(g => g.Departments.Count < 1 &&
                g.Cities.Count < 1 &&
                g.Territories.Count < 1 &&
                g.Directions.Count < 1);

                foreach (GeoPosition g in list)
                {
                    _dm.DeleteObject(g);
                }
                _dm.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }           

        }

        #endregion

        private List<IGeoRssItem> ReadMarks(string pathIn)
        {
            List<IGeoRssItem> items;
            try
            {
                GeoRssFeed feed = new GeoRssFeed(pathIn);
                GeoRssChannel channel = feed.MainChannel;
                items = channel.Items;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return items;
        }

        private bool TryExtractId(string html, out int id)
        {
            bool rv = false;
            html = Regex.Replace(html, "<br>", "\n");
            html = Regex.Replace(html, @"<(.|\n)*?>", " ");
            string[] arrayDesc = html.Split('\n');

            if (int.TryParse(arrayDesc[0],out id))
                rv = true;
            return rv;
        }

        private bool IsTerritory(string html)
        {
            bool rv = false;
            if (html.Contains("territory"))
                rv = true;
            return rv;
        }

        private void PreCompileQueries()
        {

            this._compiledLoadDirectionById = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from d in dm.Directions
                                                               .Include("GeoPositions")
                                                           where d.IdDirection == id
                                                           select d
                );

            this._compiledLoadTerritoryById = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from t in dm.Territories.Include("GeoPositions")
                                                           where t.IdTerritory == id
                                                           select t
                                                                
                );


        }

        private void SaveLog()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            using (StreamWriter sr = new StreamWriter(path, false))
            {
                sr.Write(log);
            }
        }

    }
}
