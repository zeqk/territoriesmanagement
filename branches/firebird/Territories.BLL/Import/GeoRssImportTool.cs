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
using System.Globalization;

namespace Territories.BLL.Import
{
    public class GeoRssImportTool
    {

        TerritoriesDataContext _dm;

        private Func<TerritoriesDataContext, int, IQueryable<Address>> _compiledLoadAddressById;
        private Func<TerritoriesDataContext, int, IQueryable<Territory>> _compiledLoadTerritoryById;

        string log;

        public GeoRssImportTool()
        {
            _dm = new TerritoriesDataContext();

        }

        public bool ImportGeoRss(string path, ref string importMessage,bool departments, bool cities, bool territories, bool address)
        {
            bool rv = true;    
            List<IGeoRssItem> geoRssItems = ReadMarks(path);

            PreCompileQueries();

            if (territories)
            {
                List<Polygon> polygons = geoRssItems.Where(item => item.GetType() == typeof(Polygon)).Cast<Polygon>().ToList();
                AddPolygonsToTerritories(polygons);
            }

            if (address)
            {
                List<Point> points = geoRssItems.Where(item => item.GetType() == typeof(Point)).Cast<Point>().ToList();
                AddPointsToAddresses(points);
            }

            return rv;
        }

        #region AddGeoRssItemsToModel

        public void AddPointsToAddresses(List<Point> geoItems)
        {            
            string message ="";
            foreach (Point point in geoItems)
            {
                int id = 0;
                try
                {
                    if (TryExtractId(point.Description, out id))
                    {
                        var results = _dm.addresses_GetById(id).ToList();
                        
                        if (results.Count>0)
                        {
                            Address v = results.First();
                            v.Lat = point.Coordinates.Latitude;
                            v.Lng = point.Coordinates.Longitude;                            
                        }
                        else
                            message += "\nMark: " + point.Guid + " address id " + id + " dont't exist.";

                    }
                    else
                        message += "\nMark: " + point.Guid + " " + point.Description + " " + " haven't address id.";
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

                                v.Area = "";

                                foreach (Coordinates coord in polygon.Coordinates)
                                {
                                    if (!string.IsNullOrEmpty(v.Area))
                                        v.Area += "\n";

                                    v.Area += coord.Latitude.ToString(new CultureInfo("en-US")) + " " + coord.Longitude.ToString(new CultureInfo("en-US"));
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

            this._compiledLoadAddressById = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from a in dm.Addresses
                                                           where a.IdAddress == id
                                                           select a
                );

            this._compiledLoadTerritoryById = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from t in dm.Territories
                                                           where t.IdTerritory == id
                                                           select t
                                                                
                );


        }

        private void SaveLog()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            using (StreamWriter sr = new StreamWriter(path, false))
            {
                string[] strArray = log.Split('\n');
                foreach (string item in strArray)
                {
                    sr.WriteLine(item);
                }
            }
        }

    }
}
