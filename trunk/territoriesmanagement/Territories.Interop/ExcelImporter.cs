﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Objects.DataClasses;
using Territories.Model;

namespace Territories.Interop
{
    internal class ExcelImporter : IImporter
    {
        #region Fields

        List<Table> _tables;

        string _connectionStr;        

        private DataSet _ds;

        #endregion

        #region Constructors
        public ExcelImporter()
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
        public string MakeConnectStr(string[] parameters)
        {
            string connectionString = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=";
            connectionString += parameters[0];
            connectionString += @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
            return connectionString;
        }

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
                        " FROM " + table.TableName +
                        " GROUP BY " + strFields;

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
                        i++;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return ds;
        }

        private string DicToStr(IDictionary<string,string> list)
        {                 
            string rv = "";

            foreach (var item in list.ToList())
            {
                rv += item.Value;
            }

            return rv;
        }

        private string ListToStr(List<string> list)
        {
            string rv = "";

            foreach (string item in list)
            {
                rv += " " + item;
            }

            return rv;
        }


        
        #endregion
    } 

}