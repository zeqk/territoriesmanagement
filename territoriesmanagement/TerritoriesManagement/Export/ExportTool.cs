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
using System.Data.Objects;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using GMap.NET;

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
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
                IList entities = Functions.GetEntities(dm, entity, entitySet, where, parameters);

                DataTable table = RecordsToDataTable(entities, properties.ToList());

                DataGrid grid = new DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = table;
                grid.DataBind();

                // render the DataGrid control to a file

                using (StreamWriter sw = new StreamWriter("c:\\test.xls"))
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        grid.RenderControl(hw);
                    }
                }
            }
            catch (Exception ex)
            {
                rv = false;
                throw ex;
            }

            return rv;
        }


        static public void ToExcel(IList list, List<string> propertyList)
        {
            // create the DataGrid and perform the databinding

            System.Web.UI.WebControls.DataGrid grid =
                        new System.Web.UI.WebControls.DataGrid();
            grid.HeaderStyle.Font.Bold = true;
            grid.DataSource = list;

            grid.DataBind();

            // render the DataGrid control to a file

            using (StreamWriter sw = new StreamWriter("c:\\test.xls"))
            {
                using (System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw))
                {
                    
                    grid.RenderControl(hw);
                }
            }
        }
        public void ExportToGMap(string path, string where, params ObjectParameter[] parameters)
        {
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
            
                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8, 512);
                using (XmlTextWriter xw = new XmlTextWriter(sw))
                {
                    xw.Formatting = Formatting.Indented;
                    xw.QuoteChar = char.Parse("'");
                    xw.WriteStartElement("markers");//open MARKERS
                    IList addresses = Functions.GetEntities(dm, "Address", "Addresses", where, parameters);


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
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #region ExportData
        static public void ExportData(string path, List<string> entityList)
        {
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
                DataSet ds = new DataSet("TerritoriesManagementExchangeFile");
                
                foreach (var entityName in entityList)
                {
                    string entitySetName = Functions.GetEntitySetNameByEntityName(entityName);

                    IList records = Functions.GetEntities(dm, entityName,entitySetName,"");
                    List<Property> propLst = Functions.GetPropertyListByType(records[0].GetType());
                    DataTable dt = RecordsToDataTable(records, propLst);
                    dt.TableName = entitySetName;
                    ds.Tables.Add(dt);
                }

                ds.WriteXml(path, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private DataTable RecordsToDataTable(IList records, List<Property> propLst)
        {
            DataTable dt = new DataTable();
            
            if (records.Count > 0)
            {
                foreach (Property item in propLst)
                {
                    if (!Functions.IsNullableType(item.Type))
                        dt.Columns.Add(item.Name,item.Type);
                    else
                        dt.Columns.Add(item.Name, Functions.NullableToType(item.Type));
                }

                foreach (object item in records)
                {
                    dt.NewRow();
                    dt.Rows.Add(ObjToDataRow(item, dt.NewRow()));
                }
            }

            return dt;
        }

        static private DataTable RecordsToDataTable(IList records, List<string> propLst)
        {
            DataTable dt = new DataTable();

            if (records.Count > 0)
            {
                foreach (string item in propLst)
                {
                    dt.Columns.Add(item);
                }

                foreach (object item in records)
                {
                    dt.NewRow();
                    dt.Rows.Add(ObjToDataRow(item, dt.NewRow()));
                }
            }

            return dt;
        }

        static private DataRow ObjToDataRow(object obj, DataRow row)
        {
            foreach (DataColumn column in row.Table.Columns)
            {
                object value = Functions.GetPropertyValue(obj, column.ColumnName);
                row.SetField(column, value);
            }

            return row;
        }
        #endregion

    }
}
