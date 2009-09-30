using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Territories.BLL.Import
{
    [Serializable]
    public class ImportTable
    {
        #region Fields
        private string _tableName;

        private Dictionary<string, string> _fields;

        private Dictionary<string, object> _defaultFieldValues;

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

        public Dictionary<string, string> Fields
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
