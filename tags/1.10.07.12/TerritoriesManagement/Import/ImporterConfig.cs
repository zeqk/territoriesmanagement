using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltosTools.Data;

namespace TerritoriesManagement.Import
{
    [Serializable]
    public class ImporterConfig
    {
        #region Fields
        private DataProviders _provider;
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

        public DataProviders Provider
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

}
