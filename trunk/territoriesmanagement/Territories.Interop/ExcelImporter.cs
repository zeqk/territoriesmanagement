using System;
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
        private ImporterConfig _config;

        private DataSet _ds;

        #endregion

        #region Constructors
        public ExcelImporter()
        {
            _ds = new DataSet();
        }

        #endregion

        #region Properties

        public ImporterConfig Configuration
        {
            get { return _config; }
            set { _config = value; }
        }
        #endregion

        #region Methods
        public string SetConnectionString(string[] parameters)
        {
            string connectionString = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=";
            connectionString += parameters[0];
            connectionString += @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
            _config.ConnectionString = connectionString;

            return connectionString;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();

            if (_config.Departments.Load || _config.Cities.Load || _config.Territories.Load || _config.Directions.Load)
            {
                //conection                
                OleDbConnection connection = new OleDbConnection(_config.ConnectionString);

                //tables
                DataTable territoriesDt = new DataTable("Territories");
                DataTable departmentsDt = new DataTable("Departments");
                DataTable citiesDt = new DataTable("Cities");
                DataTable directionsDt = new DataTable("Directions");                

                //commands
                OleDbDataAdapter departmentsDA = null;
                OleDbDataAdapter citiesDA = null;
                OleDbDataAdapter territoriesDA = null;
                OleDbDataAdapter directionsDA = null;

                if (_config.Departments.Load)
                {
                    //query for departments in excel
                    string strCommand = "SELECT " + _config.Departments.Columns +
                        " FROM [" + _config.TableName + "$]" +
                        " GROUP BY " + _config.Departments.Columns;
                    OleDbCommand cmd = new OleDbCommand(strCommand, connection);
                    departmentsDA = new OleDbDataAdapter(cmd);                    
                }

                if (_config.Cities.Load)
                {
                    //query for cities in excel
                    string strCommand = "SELECT " + ListToStr(_config.Departments.Columns) + " " +
                                                    ListToStr(_config.Cities.Columns) +
                        " FROM [" + _config.TableName + "$]" +
                        " GROUP BY " + ListToStr(_config.Departments.Columns) + " " +
                                       ListToStr(_config.Cities.Columns);
                    OleDbCommand cmd = new OleDbCommand(strCommand, connection);
                    citiesDA = new OleDbDataAdapter(cmd);
                }

                if (_config.Territories.Load)
                {
                    string strCommand = "SELECT " + ListToStr(_config.Territories.Columns) + " " +
                    " FROM [" + _config.TableName + "$]" +
                    " GROUP BY " + ListToStr(_config.Territories.Columns);
                    OleDbCommand cmd = new OleDbCommand(strCommand, connection);
                    territoriesDA = new OleDbDataAdapter(cmd);                    
                }

                if (_config.Directions.Load)
                {
                    string strCommand = "SELECT " + ListToStr(_config.Cities.Columns) + " " +
                                            ListToStr(_config.Territories.Columns) + " " +
                                            ListToStr(_config.Directions.Columns) +
                    " FROM [" + _config.TableName + "$]";
                    OleDbCommand cmd = new OleDbCommand(strCommand, connection);
                    directionsDA = new OleDbDataAdapter(cmd);
                } 

                try
                {
                    connection.Open();

                    if (departmentsDA!=null)
                    {
                        departmentsDA.Fill(departmentsDt);
                        ds.Tables.Add(departmentsDt);
                    }

                    if (citiesDA!=null)
                    {
                        citiesDA.Fill(citiesDt);
                        ds.Tables.Add(citiesDt);
                    }

                    if (territoriesDA!=null)
                    {
                        territoriesDA.Fill(territoriesDt);
                        ds.Tables.Add(territoriesDt);
                    }

                    if (directionsDA!=null)
                    {
                        directionsDA.Fill(directionsDt);
                        ds.Tables.Add(directionsDt);
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

        private string ListToStr(IDictionary<string,string> list)
        {                 
            string rv = "";

            foreach (var item in list.ToList())
            {
                rv += item.Value;
            }

            return rv;
        }
        #endregion
    } 
    

}
