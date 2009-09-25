using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Common;
using CarlosAg.ExcelXmlWriter;
using Territories.Model;

namespace Territories.BLL
{
    public class ExportTool
    {
        public bool ExportToExcel(string path,string entity,string entitySet, string[] properties)
        {
            Workbook book = new Workbook();
            book.Worksheets.Add("territorios");

            string strQuery = "SELECT VALUE " + entity + " FROM TerritoriesDataContext." + entitySet;

            EntityCommand cmd = new EntityCommand(strQuery);

            EntityDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                WorksheetRow row = book.Worksheets[0].Table.Rows.Add();
                foreach (string item in properties)
                {
                    row.Cells.Add(r[item].ToString());
                }
            }

            book.Save(path);

            return true;
        }

    }
}
