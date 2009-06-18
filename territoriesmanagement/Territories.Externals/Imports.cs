using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Objects.DataClasses;

namespace Territories.Externals
{
    class Imports
    {

        private void DataTableToModel<T>(DataTable dt,EntityCollection<T> entitySet, string[] properties)
        {
            
        }




        private DataTable ReadTerritoriesFile(string pathIn,string sheetName)
        {

            string stringConnection = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=";
            stringConnection = stringConnection + pathIn;
            stringConnection = stringConnection + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
            OleDbConnection connection = new OleDbConnection(stringConnection);

            string strCommand = "SELECT * FROM [" + sheetName + "$]";
            OleDbCommand cmd = new OleDbCommand(strCommand, connection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            return dt;

        }
    }
}
