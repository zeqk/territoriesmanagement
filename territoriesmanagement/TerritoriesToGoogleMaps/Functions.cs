using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Globalization;

namespace TerritoriesToGoogleMaps
{
    
    class Functions
    {

        static private List<Double> lats =new List<Double>();
        static private List<Double> lngs =  new List<Double>();

        static public Double MiddleLat;
        static public Double MiddleLng;


        public static DataTable ReadMarks(string pathIn)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("geoposition", typeof(string)));
            table.Columns.Add(new DataColumn("id", typeof(int)));

            XmlDocument rssDoc = new XmlDocument();
            rssDoc.LoadXml(pathIn);

            for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
            {
                
            }


            try
            {
                StreamReader sr = new StreamReader(pathIn);
                using (XmlTextReader xr = new XmlTextReader(sr))
                {
                    
                    while (xr.Read())
                    {
                        DataRow row = table.NewRow();
                        row["geoposition"] = xr.GetAttribute("georss:point");

                        char[] delimiters = { '<', '>' };
                        string[] description = xr.GetAttribute("description").Split(delimiters);

                        int id;
                        if (int.TryParse(description[3].ToString(), out id))
                            row["id"] = id;
                        else
                            row["id"] = 0;

                        table.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return table;
        }


        public static void WriteTerritoriesFiles(string pathOut,DataTable geopositionTable)
        {
            string conStr = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=";
            conStr = conStr + pathOut;
            conStr = conStr + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
            OleDbConnection connection = new OleDbConnection(conStr);
            
            OleDbCommand cmdSelect = new OleDbCommand("SELECT  ID, GEOPOSITION FROM [territorios$]", connection);

            
            OleDbCommand cmdUpdate = new OleDbCommand("INSERT INTO [territorios$](ID,GEOPOSITION) VALUES(@id,@geoposition)",connection);
            cmdUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "ID");
            cmdUpdate.Parameters.Add("@geoposition", OleDbType.VarChar, 22, "GEOPOSITION");

            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmdSelect;
            da.UpdateCommand = cmdUpdate;

            try
            {
                da.Fill(ds);

                foreach (DataRow auxRow in geopositionTable.Rows)
                {
                    ds.Tables[0].Select("ID = " + auxRow["ID"])[0]["GEOPOSITION"] = auxRow["GEOPOSITION"].ToString();
                }
                da.Update(ds);
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
            
        }

        public static void UpdateGeoposition(string xmlFile, string xlsFile)
        {
            DataTable geopositionTable = ReadMarks(xmlFile);
            WriteTerritoriesFiles(xlsFile, geopositionTable);
        }


        static public void WriteMarks(string pathIn, string pathOut)
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
