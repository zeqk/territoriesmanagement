using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.Objects;
using GeoRSSLibrary;
using Territories.Model;

namespace Territories.BLL
{
    public class GeoRssImportTool
    {

        TerritoriesDataContext _dm;

        private Func<TerritoriesDataContext, int, IQueryable<Direction>> _compiledLoadDirection;

        string log;

        public GeoRssImportTool()
        {
            _dm = new TerritoriesDataContext();
        }

        public void AddPointsToDirections(string path)
        {
            List<GeoRssItem> geoItems = ReadMarks(path);
            string message ="";
            foreach (GeoRssItem item in geoItems)
            {
                if (item.Type == GeoRssItemType.Point)
                {
                    int id = 0;
                    try
                    {
                        if (TryExtractId(item.Description, out id))
                        {
                            ObjectResult<Direction> results = _dm.directions_GetByCity(id);
                            //Direction v = _compiledLoadDirection(_dm, id).First();
                            if (results.Count()>0)
                            {
                                Direction v = results.First();
                                GeoPosition originalGeoPos = v.GeoPositions.First();
                                if (DateTime.Compare(item.PubDate, originalGeoPos.Date) > 0)
                                {
                                    GeoPosition nGeoPos = originalGeoPos;
                                    nGeoPos.Date = item.PubDate;
                                    nGeoPos.Latitude = (long)item.FirstCoordinates.Latitude;
                                    nGeoPos.Longitude = (long)item.FirstCoordinates.Longitude;
                                    _dm.ApplyPropertyChanges("GeoPositions", nGeoPos);
                                }
                            }
                            message += "\nMark: " + item.Guid + " Direction Id " + id + " dont't exist.";

                        }
                        else
                            message += "\nMark: " + item.Guid + " " + item.Description + " " + " haven't direction id";
                    }
                    catch (Exception ex)
                    {
                        
                        throw ex;
                    }                   

                }

            }//end foreach
            
        }      

        private List<GeoRssItem> ReadMarks(string pathIn)
        {
            List<GeoRssItem> items;
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

        private void PreCompileQueries()
        {

            this._compiledLoadDirection = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from d in dm.Directions
                                                               .Include("GeoPositions")
                                                           where d.IdDirection == id
                                                           select d
                );


        }

    }
}
