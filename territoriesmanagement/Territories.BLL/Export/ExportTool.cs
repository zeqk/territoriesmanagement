using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Common;
using CarlosAg.ExcelXmlWriter;
using Territories.Model;

namespace Territories.BLL.Export
{
    public class ExportTool
    {
        public bool ExportToExcel(string path,string entity,string entitySet, string[] properties)
        {
            Workbook book = new Workbook();
            book.Worksheets.Add("territorios");

            string strQuery = "SELECT VALUE " + entity + " FROM TerritoriesDataContext." + entitySet;


            TerritoriesDataContext dm = new TerritoriesDataContext();

            var res = dm.CreateQuery<typeof(Address)>(strQuery).Execute(System.Data.Objects.MergeOption.AppendOnly);

            //foreach (var item in res)
            //{
            //    item.
            //}

            book.Save(path);

            return true;
        }

    }
}
