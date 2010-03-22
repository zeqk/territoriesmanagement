using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Common;
using CarlosAg.ExcelXmlWriter;
using TerritoriesManagement.Model;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Globalization;
using GMap.NET;
using System.Data.Objects;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TerritoriesManagement.Export
{
    public class ExportTool
    {
        /// <summary>
        /// Export a entity set to a excel file
        /// </summary>
        /// <param name="path">Excel file path</param>
        /// <param name="entity">Entity name</param>
        /// <param name="entitySet">Entity set name</param>
        /// <param name="properties">Array of properties name</param>
        /// <param name="where">Query string</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        static public bool ExportToExcel(string path,string entity,string entitySet, string[] properties, string where, params ObjectParameter[] parameters)
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
                IList entities = Functions.GetEntities(entity, entitySet, where, parameters);

                WorksheetRow firstRow = book.Worksheets[entitySet].Table.Rows.Add();

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
                        string strValue = Functions.GetPropertyValue(item, propName).ToString();

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

        public void ExportToGMap(string path, string where, params ObjectParameter[] parameters)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8, 512);
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
                List<ZeqkTools.GeoPoint> points = addressList.Where(a => a.Lat.HasValue && a.Lng.HasValue)
                                                      .Select(a => new ZeqkTools.GeoPoint(a.Lat.Value, a.Lng.Value)).ToList();

               
                var aux = ZeqkTools.Functions.CalculateMiddlePoint(points);
                PointLatLng point = new PointLatLng(aux.Lat, aux.Lng);
                xw.WriteStartElement("centerPoint");
                xw.WriteAttributeString("lat", point.Lat.ToString(new CultureInfo("en-US")));
                xw.WriteAttributeString("lng", point.Lng.ToString(new CultureInfo("en-US")));
                xw.WriteEndElement();

                xw.WriteEndElement(); //close MARKERS

                sw.Close();
            }

        }

        static public void ExportData(string path, List<string> entityList)
        {
            try
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;                    
                XmlWriter xtw = XmlTextWriter.Create(path, setting);
                XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateDictionaryWriter(xtw);
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<Hashtable>));

                foreach (var entityName in entityList)
                {
                    string entitySetName = Functions.GetEntitySetNameByEntityName(entityName);

                    IList records = Functions.GetEntities(entityName,entitySetName,"");
                    
                    IList tmxLst = RecordsToTmxFormat(records);
                    dcs.WriteObject(xdw, tmxLst);
                    xtw.Close();
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private IList RecordsToTmxFormat(IList records)
        {
            IList rv = new List<Hashtable>();

            foreach (object item in records)
            {
                rv.Add(ObjToTmxFormat(item));
            }

            return rv;
        }


        static private Hashtable ObjToTmxFormat(object obj)
        {
            Hashtable rv = new Hashtable();

            List<string> propLst = Functions.GetPropertyListByType(obj.GetType());

            foreach (string propName in propLst)
            {
                object value = Functions.GetPropertyValue(obj, propName);
                rv.Add(propName, value);
            }


            return rv;
        }
        

    }
}
