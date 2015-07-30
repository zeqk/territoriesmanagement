using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.Export
{
    public class ExportTool
    {        
        public BackgroundWorker bg;
        int rowCounter = 0;
        int tablesTotal = 0;
        int tablesCounter = 0;

        public ExportTool()
        {
            bg = new BackgroundWorker();
            bg.WorkerSupportsCancellation = true;
            bg.WorkerReportsProgress = true;
        }

        #region Export to Excel

        /// <summary>
        /// Export a entity set to a excel file
        /// </summary>
        /// <param name="path">Excel spreadsheet path</param>
        /// <param name="template">Excel template path</param>
        /// <param name="entity">Entity name</param>
        /// <param name="properties">Array of properties name</param>
        /// <param name="where">Query string</param>
        /// <param name="aync">Execute in aync mode</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        public void ExportToExcel(string path, string template, string entityName, string[] properties, string where, bool async, params ObjectParameter[] parameters)
        {
            if (async)
            {
                Hashtable argument = new Hashtable();
                argument.Add("path", path);
                argument.Add("template", template);
                argument.Add("entityName", entityName);
                argument.Add("properties", properties);
                argument.Add("where", where);
                argument.Add("parameters", parameters);

                bg.DoWork += new DoWorkEventHandler(bg_ExportToExcel);
                bg.RunWorkerAsync(argument);
            }
            else
            {
                this.ExportToExcel(path, template, entityName, properties, where, parameters);
            }
        }

        private void bg_ExportToExcel(object sender, DoWorkEventArgs e)
        {
            Hashtable argument = (Hashtable)e.Argument;
            string path = (string)argument["path"];
            string template = (string)argument["template"];
            string entityName = (string)argument["entityName"];
            string[] properties =(string[])argument["properties"];
            string where = (string)argument["where"];
            ObjectParameter[] parameters = (ObjectParameter[])argument["parameters"];

            this.ExportToExcel(path, template, entityName, properties, where, parameters);
        }

        public bool ExportToExcel(string path, IList entities, string[] properties)
        {
            bool rv = false;
            try
            {
                DataTable table = RecordsToDataTable(entities, properties.ToList());

                WriteExcel(table, path);
                rv = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rv;
        }

        private bool ExportToExcel(string path, string template, string entityName, string[] properties, string where, params ObjectParameter[] parameters)
        {
            bool rv = true;
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
                IList entities = Helper.GetEntities(dm, entityName, where, parameters);

                if (properties == null || properties.Length == 0)
                {
                    properties = Helper.GetPropertyListByType(entityName).Select(p => p.Name).ToArray();
                }

                DataTable table = RecordsToDataTable(entities, properties.ToList());

                

                if (template == null || template == "")
                    WriteExcel(table, path);
                else
                    WriteExcel(table, path, template);
            }
            catch (Exception ex)
            {
                rv = false;
                throw ex;
            }

            return rv;
        }

        void WriteExcel(DataTable dt,string path)
        {
            DataGrid grid = new DataGrid();
            grid.HeaderStyle.Font.Bold = true;
            grid.DataSource = dt;
            grid.DataBind();

            // render the DataGrid control to a file

            using (StreamWriter sw = new StreamWriter(path))
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grid.RenderControl(hw);
                }
            }
            bg.ReportProgress(100);
        }

        void WriteExcel(DataTable dt, string path, string template)
        {
            XDocument document = XDocument.Load(template, LoadOptions.None);
            var workbook = (XElement)document.FirstNode.NextNode; //Workbook
            var sheet = (XElement)workbook.FirstNode.NextNode.NextNode.NextNode; //Worksheet

            var table = (XElement)sheet.FirstNode; // Table

            XElement row = (XElement)table.FirstNode;

            int rowsTotal = dt.Rows.Count;

            while (row != null)
            {
                if (row.Name.LocalName == "Row")
                {
                    XElement cell = (XElement)row.FirstNode;
                    while (cell != null)
                    {
                        XElement cellData = (XElement)cell.FirstNode;
                        if (cellData != null)
                        {

                            cellData = getCellData(cellData, dt);
                        }
                        cell = (XElement)cell.NextNode;
                    }
                }
                row = (XElement)row.NextNode;
                rowCounter++;
                bg.ReportProgress((100 / rowsTotal) * rowCounter);
            }
            bg.ReportProgress(100);
            document.Save(path);
        }        

        private XElement getCellData(XElement cellData, DataTable dataTable)
        {
            if(cellData.Value != "" && cellData.Value.Contains('{'))
            {
                string[] fields = cellData.Value.Split('+');
                if (fields.Length > 0)
                {
                    string value = "";
                    for (int i = 0; i < fields.Length; i++)
                    {
                        string field = fields[i];
                        field = field.Trim();
                        field = field.Trim('{', '}');
                        field = field.Trim();
                        try
                        {
                            var valueObj = dataTable.Rows[rowCounter][field];
                            if (valueObj != null)
                            {
                                if (value != "")
                                    value += " ";
                                value += (string)valueObj;
                            }
                        }
                        catch (Exception ex)
                        {           
                        }
                        
                    }
                    cellData.SetValue(value);
                }

            }

            return cellData;
        }

        #endregion

        #region ExportToExchangeData

        public void ExportToExchangeData(string path, List<string> entityList, bool async)
        {
            if (async)
            {
                Hashtable argument = new Hashtable();
                argument.Add("path",path);
                argument.Add("entityList",entityList);

                bg.DoWork += new DoWorkEventHandler(bg_ExportToExchangeData);
                bg.RunWorkerAsync(argument);
            }
            else
            {
                this.ExportToExchangeData(path, entityList);
            }
        }

        private void bg_ExportToExchangeData(object sender, DoWorkEventArgs e)
        {
            Hashtable argument = (Hashtable)e.Argument;
            this.ExportToExchangeData((string)argument["path"],(List<string>)argument["entityList"]);
        }

        private void ExportToExchangeData(string path, List<string> entityList)
        {
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
                DataSet ds = new DataSet("TerritoriesManagementExchangeFile");

                tablesTotal = entityList.Count;                
                foreach (var entityName in entityList)
                {
                    string entitySetName = Helper.GetEntitySetNameByEntityName(dm,entityName);
                    IList records = Helper.GetEntities(dm, entityName, "");

                    List<Property> propLst = Helper.GetPropertyListByType(entityName);
                    DataTable dt = RecordsToDataTable(records, propLst);
                    dt.TableName = entitySetName;
                    ds.Tables.Add(dt);
                    tablesCounter++;
                    bg.ReportProgress((100 / tablesTotal) * tablesCounter);
                }

                ds.WriteXml(path, XmlWriteMode.WriteSchema);
                bg.ReportProgress(100);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ExportToExchangeData(string path, string entity, bool includeReferences, string where, params ObjectParameter[] parameters)
        {

        }

        private DataTable RecordsToDataTable(IList records, List<Property> propLst)
        {
            DataTable dt = new DataTable();
            int i = 0;
            if (records.Count > 0)
            {
                foreach (Property item in propLst)
                {
                    if (!Helper.IsNullableType(item.Type))
                        dt.Columns.Add(item.Name,item.Type);
                    else
                        dt.Columns.Add(item.Name, Helper.NullableToType(item.Type));
                }

                foreach (object item in records)
                {
                    dt.NewRow();
                    dt.Rows.Add(ObjToDataRow(item, dt.NewRow()));
                    i++;
                    int tableProgress = (100 / tablesTotal) * tablesCounter;
                    int recordProgress = ((100 / tablesTotal) / records.Count) * i;
                    bg.ReportProgress(tableProgress + recordProgress);
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
                object value = Helper.GetPropertyValue(obj, column.ColumnName);
                row.SetField(column, value);
            }

            return row;
        }
        #endregion

    }
}
