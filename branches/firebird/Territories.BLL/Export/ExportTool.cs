using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Common;
using CarlosAg.ExcelXmlWriter;
using Territories.Model;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Globalization;
using GMap.NET;
using System.Data.Objects;

namespace Territories.BLL.Export
{
    public class ExportTool
    {
        static public bool ExportToExcel(string path,string entity,string entitySet, string where, ObjectParameter[] parameters, string[] properties)
        {
            bool rv = true;
            Workbook book = new Workbook();
            book.Worksheets.Add(entitySet);

            

            WorksheetStyle headerStyle = new WorksheetStyle("header");
            headerStyle.Font.Bold = true;
            headerStyle.Interior.Color = ColorTranslator.ToHtml(Color.Gray);
            book.Styles.Add(headerStyle);


            try
            {
                IList entities = Functions.GetEntities(entity, entitySet,where,parameters);

                WorksheetRow firstRow = book.Worksheets[entitySet].Table.Rows.Add();

                if (properties.Count() < 1 || properties == null)
                    properties = entities[0].GetType().GetProperties().Select(p => p.Name).ToArray();

                foreach (var propName in properties)
                {
                    firstRow.Cells.Add(propName, CarlosAg.ExcelXmlWriter.DataType.String, "header");
                }

                foreach (var item in entities)
                {
                    WorksheetRow row = book.Worksheets[entitySet].Table.Rows.Add();
                    row.AutoFitHeight = true;
                    

                    foreach (var propName in properties)
                    {
                        string strValue = "";
                        if (!propName.Contains('.'))
                            strValue = item.GetType().GetProperty(propName).GetValue(item, null).ToString();
                        else
                        {
                            string[] subProperty = propName.Split('.');
                            object refProperty = item.GetType().GetProperty(subProperty[0]).GetValue(item, null);
                            strValue = refProperty.GetType().GetProperty(subProperty[1]).GetValue(refProperty, null).ToString();
                        }

                        WorksheetCell cell = row.Cells.Add(strValue);
                    }
                }

                book.Save(path);
            }
            catch (Exception ex)
            {
                rv = false;
                throw ex;
            }

            return rv;
        }

        static public void ExportToGMap(string pathOut, string where, params ObjectParameter[] parameters)
        {
            StreamWriter sw = new StreamWriter(pathOut, false, Encoding.UTF8, 512);
            using (XmlTextWriter xw = new XmlTextWriter(sw))
            {
                xw.Formatting = Formatting.Indented;
                xw.QuoteChar = char.Parse("'");
                xw.WriteStartElement("markers");//open MARKERS
                IList addresses = Functions.GetEntities("Address", "Addresses", where, parameters);


                List<Address> addressList = (List<Address>)addresses;

                int llenos = 0;
                int vacios = 0;

                CultureInfo culture = new CultureInfo("en-US");

                foreach (var a in addressList)
                {
                    if (a.Lat.HasValue && a.Lng.HasValue)
                    {
                        xw.WriteStartElement("marker");//open MARKER

                        xw.WriteAttributeString("address", a.Street + a.Number);

                        xw.WriteAttributeString("lat", a.Lat.Value.ToString(culture));
                        xw.WriteAttributeString("lng", a.Lng.Value.ToString(culture));

                        xw.WriteAttributeString("id", a.IdAddress.ToString());

                        xw.WriteEndElement();//close MARKER
                        llenos++;
                    }
                    else
                        vacios++;

                }
                List<PointLatLng> points = addressList.Select(a => new PointLatLng(a.Lat.Value, a.Lng.Value)).ToList();

                PointLatLng point = Functions.CalculateMiddlePoint(points);

                xw.WriteStartElement("centerPoint");
                xw.WriteAttributeString("lat", point.Lat.ToString(new CultureInfo("en-US")));
                xw.WriteAttributeString("lng", point.Lng.ToString(new CultureInfo("en-US")));
                xw.WriteEndElement();

                xw.WriteEndElement(); //close MARKERS

                sw.Close();
            }

        }
        

    }
}
