using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Common;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Data.Objects;
using System.Data;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.UI;
using GMap.NET;
using TerritoriesManagement.Model;

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
        public bool ExportToExcel(string path,string entity,string entitySet, string[] properties, string where, params ObjectParameter[] parameters)
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

                using (StreamWriter sw = new StreamWriter(path))
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


        #region ExportData
        public void ExportData(string path, List<string> entityList)
        {
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
                DataSet ds = new DataSet("TerritoriesManagementExchangeFile");
                
                foreach (var entityName in entityList)
                {
                    string entitySetName = Functions.GetEntitySetNameByEntityName(entityName);                    
                    IList records = Functions.GetEntities(dm, entityName, entitySetName, "");
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

        private DataTable RecordsToDataTable(IList records, List<Property> propLst)
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

        private DataTable RecordsToDataTable(IList records, List<string> propLst)
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

        private DataRow ObjToDataRow(object obj, DataRow row)
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
