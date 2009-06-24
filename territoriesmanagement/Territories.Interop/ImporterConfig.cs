using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My;

namespace Territories.Interop
{
    [Serializable]
    public class ImporterConfig
    {
        #region Fields

        private string _connectionString;
        private string _tableName;
        private Field _departments;
        private Field _cities;
        private Field _territories;
        private Field _directions;
        private Enumerators.Provider _provider;

        #endregion

        #region Constructors
        public ImporterConfig()
        {

        }
        #endregion

        #region Properties

        
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        
        public Field Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        
        public Field Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        
        public Field Territories
        {
            get { return _territories; }
            set { _territories = value; }
        }

        
        public Field Directions
        {
            get { return _directions; }
            set { _directions = value; }
        }

        public Enumerators.Provider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }

        #endregion

    }

    [Serializable]
    public class Field
    {
        private IDictionary<string, string> _columns;
        private IDictionary<string, object> _defaultValues;

        private bool _load;

        
        public IDictionary<string, string> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        public IDictionary<string, object> DefautlValues
        {
            get { return _defaultValues; }
            set { _defaultValues = value; }
        }
        
        public bool Load
        {
            get { return _load; }
            set { _load = value; }
        }

    }
    
}
