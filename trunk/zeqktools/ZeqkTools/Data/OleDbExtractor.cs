using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ZeqkTools.Data
{
    class OleDbExtractor : IExtractor
    {
        #region Fields

        List<Table> _tables;

        string _connectionStr;        

        private DataSet _ds;

        #endregion

        #region Constructors
        public OleDbExtractor()
        {
            _ds = new DataSet();
            _tables = new List<Table>();
        }

        #endregion

        #region Properties        

        public List<Table> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }       

        public string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

        #endregion

        #region Methods

        public DataSet GetData()
        {
            DataSet ds = new DataSet();

            if (_tables.Count > 0)
            {
                List<OleDbDataAdapter> das = new List<OleDbDataAdapter>();

                OleDbConnection connection = new OleDbConnection(_connectionStr);

                foreach (Table table in _tables)
                {
                    string strFields = ListToStr(table.Fields);
                    string strCommand = "SELECT" + strFields +
                        " FROM [" + table.TableName + "$]" 
                        + " GROUP BY " + strFields;

                    OleDbDataAdapter da = new OleDbDataAdapter(strCommand, connection);

                    das.Add(da);

                }

                try
                {
                    connection.Open();
                    int i = 0;
                    foreach (OleDbDataAdapter da in das)
                    {
                        string tableName = _tables[i].TableName;
                        DataTable dt = new DataTable(tableName);
                        da.Fill(dt);
                        ds.Tables.Add(dt);
                        i++;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    switch (((OleDbException)ex).ErrorCode)
                    {
                        case -2147467259 : throw new Exception("Enter the table name.", ex);
                            break;
                        case -2147217904: throw new Exception("The name of a column is incorrect.", ex);
                            break;
                        default: throw ex;
                            break;
                    }
                }
            }

            return ds;
        }

        private string ListToStr(List<string> list)
        {
            string rv = "";
            bool first = true;

            foreach (string item in list)
            {
                if (!first)
                    rv += ",";
                else
                    first = false;

                rv += " " + item;
            }

            return rv;
        }


        
        #endregion
    } 

}
