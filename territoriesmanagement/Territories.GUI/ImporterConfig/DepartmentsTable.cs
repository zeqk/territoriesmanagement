using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(DepartmentsTableConverter))]
    public class DepartmentsTable
    {
        #region Fields
        private bool _load;

        private string _tableName;

        private Field _id;

        private Field _name;

        #endregion

        public DepartmentsTable()
        {
            _id = new Field("Id");
            _name = new Field("Department");
        }
        #region Properties

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public bool Load
        {
            get { return _load; }
            set { _load = value; }
        }

        public Field Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Field Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

    }
}
