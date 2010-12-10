using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [TypeConverter(typeof(FieldConverter))]
    public class Field
    {
        #region Fields
        private string _columnName;

        private string _defaultValue;

        private bool _import;

        private string _relatedProperty;
        #endregion

        #region Contructors
        public Field()
        {

        }

        public Field(bool import, string columnName, string relatedProperty)
        {
            _import = import;
            _columnName = columnName;
            _relatedProperty = relatedProperty;
        }

        public Field(string columnName, string relatedProperty)
        {
            _columnName = columnName;
            _relatedProperty = relatedProperty;
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

        public bool Import
        {
            get { return _import; }
            set { _import = value; }
        }

        [ReadOnly(true)]
        public string RelatedProperty
        {
            get { return _relatedProperty; }
            set { _relatedProperty = value; }
        }
        #endregion

    }
}
