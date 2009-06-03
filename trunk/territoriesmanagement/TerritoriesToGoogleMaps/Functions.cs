using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using GeoRSSLibrary;

namespace TerritoriesToGoogleMaps
{
    
    class Functions
    {

        static private List<Double> lats =new List<Double>();
        static private List<Double> lngs =  new List<Double>();

        static public Double MiddleLat;
        static public Double MiddleLng;


        public static List<GeoRssItem> ReadMarks(string pathIn)
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

        static private int ExtractId(string html)
        {
            html = Regex.Replace(html, "<br>", "\n");
            html = Regex.Replace(html, @"<(.|\n)*?>", " ");
            string[] arrayDesc = html.Split('\n');
            return int.Parse(arrayDesc[0]);
        }


        public static void WriteTerritoriesFiles(string pathOut, List<GeoRssItem> geoItems)
        {
            string conStr = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=";
            conStr = conStr + pathOut;
            conStr = conStr + @";Extended Properties=""Excel 8.0;HDR=Yes""";
            OleDbConnection connection = new OleDbConnection(conStr);
            
            OleDbCommand cmdSelect = new OleDbCommand("SELECT  * FROM [territorios$]", connection);

            
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE [territorios$] SET GEOPOSITION=@geoposition",connection);
            cmdUpdate.Parameters.Add("@id", OleDbType.Integer, 0, "ID");
            cmdUpdate.Parameters.Add("@geoposition", OleDbType.VarChar, 22, "GEOPOSITION");

            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmdSelect;
            da.UpdateCommand = cmdUpdate;

            int id = 0;
            try
            {
                
                da.Fill(ds);
                int count1 = ds.Tables[0].Rows.Count;
                int count2 = geoItems.Count;

                foreach (var item in geoItems)
                {
                    if (item.Type == GeoRssItemType.Point)
                    {                        
                        id = ExtractId(item.Description);
                        ds.Tables[0].Select("ID = " + id)[0]["GEOPOSITION"] = ((GeoRssItem)item).Coordinates.First().ToString();
                    }
                }
                ds.Tables[0].WriteXml(pathOut + ".xml");                                
            }
            catch (Exception ex)
            {
                if (ex.Message=="Index was outside the bounds of the array.")
                    throw new Exception("El ID" + id + " existe en Google Maps pero no existe en la planilla de Excel", ex);
                else
                    throw ex;
            }            
            
        }

        public static void UpdateGeoposition(string xmlFile, string xlsFile)
        {
            List<GeoRssItem> geopositions = ReadMarks(xmlFile);
            WriteTerritoriesFiles(xlsFile, geopositions);
        }


        static public void WriteXml(string pathIn, string pathOut)
        {
            StreamWriter sw = new StreamWriter(pathOut, false, Encoding.UTF8, 512);
            using(XmlTextWriter xw = new XmlTextWriter(sw))
	        {
                xw.Formatting = Formatting.Indented;
                xw.QuoteChar = char.Parse("'");
                xw.WriteStartElement("markers");//open MARKERS
                DataTable dt = ReadTerritoriesFile(pathIn);
                int llenos = 0;
                int vacios = 0;

                CultureInfo culture = new CultureInfo("en-US");
                
                foreach (DataRow row in dt.Rows)
                {
                    if (row["GEOPOSITION"].ToString() != null && row["GEOPOSITION"].ToString() != "")
                    {
                        xw.WriteStartElement("marker");//open MARKER

                        xw.WriteAttributeString("direccion", row["DIRECCION"].ToString());

                        char[] delimiters = { ' ', '/' };
                        string[] position = row["GEOPOSITION"].ToString().Split(delimiters);

                        xw.WriteAttributeString("lat", position[0]);
                        lats.Add(Double.Parse(position[0],culture));
                        xw.WriteAttributeString("lng", position[1]);
                        lngs.Add(Double.Parse(position[1],culture));

                        xw.WriteAttributeString("id", row["ID"].ToString());

                        xw.WriteEndElement();//close MARKER
                        llenos = llenos + 1;
                    }
                    else
                        vacios = vacios + 1;

                }
                double lat = 0;
                double lng = 0;
                CalculateMiddlePoint(ref lat, ref lng);

                xw.WriteStartElement("centerPoint");               
                xw.WriteAttributeString("lat",lat.ToString(new CultureInfo("en-US")));
                xw.WriteAttributeString("lng", lng.ToString(new CultureInfo("en-US")));
                xw.WriteEndElement();

                xw.WriteEndElement(); //close MARKERS

                
	        }
           
        }

        static public void WriteJson(string pathIn, string pathOut)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(string));
            
        }


        

        static public  DataTable ReadTerritoriesFile(string pathIn)
        {

            string stringConnection = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=";
            stringConnection = stringConnection + pathIn;
            stringConnection = stringConnection + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
            OleDbConnection connection = new OleDbConnection(stringConnection);            
            
            string strCommand = "SELECT  ID, DIRECCION, GEOPOSITION FROM [territorios$]";
            OleDbCommand cmd = new OleDbCommand(strCommand,connection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            return dt;

        }

        static public void CalculateMiddlePoint(ref double lat, ref double lon)
        {
            double latDistance = lats.Max() - lats.Min();
            double auxLat = latDistance / 2;
            lat = lats.Min() + auxLat;

            double lngDistance = lngs.Max() - lngs.Min();
            double auxLng = lngDistance / 2;
            lon = lngs.Min() + auxLng;
                

        }

       
        
    }
}
