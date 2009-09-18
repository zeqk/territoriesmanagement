using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My;

namespace Territories.BLL
{
    [Serializable]
    public class ImporterConfig
    {
        #region Fields
        private Enumerators.Provider _provider;
        private string _connectionString;	

        private ImportTable _departments;
        private ImportTable _cities;
        private ImportTable _territories;
        private ImportTable _addresses;

        #endregion

        #region Constructors
        public ImporterConfig()
        {
            _departments = new ImportTable();
            _cities = new ImportTable();
            _territories = new ImportTable();
            _addresses = new ImportTable();
        }
        #endregion


        #region Properties

        public Enumerators.Provider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public ImportTable Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        public ImportTable Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        public ImportTable Territories
        {
            get { return _territories; }
            set { _territories = value; }
        }

        public ImportTable Addresses
        {
            get { return _addresses; }
            set { _addresses = value; }
        }

        #endregion



    }

    [Serializable]
    public class ImportTable
    {
        #region Fields
        private string _tableName;

        private Dictionary<string,string> _fields;

        private Dictionary<string,object> _defaultFieldValues;

        #endregion


        #region Constructors
        public ImportTable()
        {
            _fields = new Dictionary<string, string>();
            _defaultFieldValues = new Dictionary<string, object>();
        }
        #endregion

        #region Properties
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public Dictionary<string,string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public Dictionary<string, object> DefaultFieldValues
        {
            get { return _defaultFieldValues; }
            set { _defaultFieldValues = value; }
        }

        #endregion



    }

}
