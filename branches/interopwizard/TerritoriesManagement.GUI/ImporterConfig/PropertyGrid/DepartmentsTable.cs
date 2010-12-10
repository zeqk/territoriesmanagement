﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(DepartmentsTableConverter))]
    public class DepartmentsTable : ITable
    {
        #region Fields
        private bool _import;

        private string _tableName;

        private Field _id;

        private Field _name;

        #endregion

        public DepartmentsTable()
        {
            _id = new Field("ID");
            _name = new Field("PARTIDO");
        }
        #region Properties

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public bool Import
        {
            get { return _import; }
            set { _import = value; }
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
