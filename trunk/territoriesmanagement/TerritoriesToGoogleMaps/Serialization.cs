using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace TerritoriesToGoogleMaps
{
    
    class Serialization
    {
        public const string path = @"D:\direcciones.xml";

        static private List<Double> lats =new List<Double>();
        static private List<Double> lngs =  new List<Double>();

        static public Double MiddleLat;
        static public Double MiddleLng;

        static public void WriteMarks()
        {         
            
            StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8,512);
            using(XmlTextWriter xw = new XmlTextWriter(sw))
	        {
                xw.Formatting = Formatting.Indented;
                xw.QuoteChar = char.Parse("'");
                xw.WriteStartElement("markers");
                DataTable dt = ReadTerritoriesFile();
                int llenos = 0;
                int vacios = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["GEOPOSITION"].ToString() != null && row["GEOPOSITION"].ToString() != "")
                    {
                        xw.WriteStartElement("marker");

                        xw.WriteAttributeString("direccion", row["DIRECCION"].ToString());

                        char[] delimiters = { ' ', '/' };
                        string[] position = row["GEOPOSITION"].ToString().Split(delimiters);
                        xw.WriteAttributeString("lat", position[0]);
                        lats.Add(Double.Parse(position[0]));
                        xw.WriteAttributeString("lng", position[1]);
                        lngs.Add(Double.Parse(position[1]));
                        
                        

                        xw.WriteAttributeString("id", row["ID"].ToString());
                        xw.WriteEndElement();
                        llenos = llenos + 1;
                    }
                    else
                        vacios = vacios + 1;

                }
                xw.WriteEndElement();
                string hola = sw.ToString();
	        }
            CalculateMiddlePoint();
           
        }

        static public  DataTable ReadTerritoriesFile()
        {
            string stringConnection = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=D:\TERRITORIO.xls;Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
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

        static public void CalculateMiddlePoint()
        {
            double latDistance = lats.Max() - lats.Min();
            double auxLat = latDistance / 2;
            MiddleLat = lats.Min() + auxLat;

            double lngDistance = lngs.Max() - lngs.Min();
            double auxLng = lngDistance / 2;
            MiddleLng = lats.Min() + auxLng;
                

        }
        
    }
}
