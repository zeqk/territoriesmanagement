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

        private ImportTable _departments;
        private ImportTable _cities;
        private ImportTable _territories;
        private ImportTable _directions;

        #endregion

        #region Properties

        public Enumerators.Provider Provider
        {
            get { return _provider; }
            set { _provider = value; }
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

        public ImportTable Directions
        {
            get { return _directions; }
            set { _directions = value; }
        }

        #endregion




    }

    [Serializable]
    public class ImportTable
    {
        #region Fields
        private string _name;

        private Dictionary<string,string> _fields;

        private Dictionary<string,object> _defaultFieldValues;

        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
