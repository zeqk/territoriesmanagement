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

namespace Territories.BLL.Export
{
    public class ExportTool
    {
        public bool ExportToExcel(string path,string entity,string entitySet, string[] properties)
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
                IList entities = GetEntities(entity, entitySet);

                WorksheetRow firstRow = book.Worksheets[entitySet].Table.Rows.Add();
                foreach (var propName in properties)
                {
                    firstRow.Cells.Add(propName,DataType.String,"header");
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

        private IList GetEntities(string entity, string entitySet)
        {
            IList rv = null;
            string strQuery = "SELECT VALUE " + entity + " FROM TerritoriesDataContext." + entitySet + " AS " + entity;
            TerritoriesDataContext dm = new TerritoriesDataContext();


            if (entitySet.Equals("Addresses"))
            {
                var res = dm.CreateQuery<Address>(strQuery).Include("Territory")
                                                           .Include("City")
                                                           .Execute(System.Data.Objects.MergeOption.AppendOnly);
                
                rv = res.ToList();
            }

            if (entitySet.Equals("Territories"))
            {
                var res = dm.CreateQuery<Territory>(strQuery).Execute(System.Data.Objects.MergeOption.AppendOnly);
                rv = res.ToList();
            }

            if (entitySet.Equals("Cities"))
            {
                var res = dm.CreateQuery<City>(strQuery).Include("Department")
                                                        .Execute(System.Data.Objects.MergeOption.AppendOnly);
                rv = res.ToList();
            }

            if (entitySet.Equals("Departments"))
            {
                var res = dm.CreateQuery<Department>(strQuery).Execute(System.Data.Objects.MergeOption.AppendOnly);
                rv = res.ToList();
            }

            return rv;

            
        }

    }
}
