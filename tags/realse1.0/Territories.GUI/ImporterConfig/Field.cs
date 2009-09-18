using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    [TypeConverter(typeof(FieldConverter))]
    public class Field
    {
        #region Fields
        private string _columnName;

        private string _defaultValue;

        private bool _load;
        #endregion

        #region Contructors
        public Field()
        {

        }

        public Field(bool load, string columnName)
        {
            _load = load;
            _columnName = columnName;
        }

        public Field(string columnName)
        {
            _columnName = columnName;
        }
        #endregion


        #region Properties
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        public bool Load
        {
            get { return _load; }
            set { _load = value; }
        }
        #endregion

    }
}
