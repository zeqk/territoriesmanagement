﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(TerritoriesTableConverter))]
    public class TerritoriesTable
    {
        #region Fields
        private bool _load;

        private string _tableName;

        private Field _id;

        private Field _name;

        private Field _number;

        #endregion

        public TerritoriesTable()
        {
            _id = new Field("Id");
            _name = new Field("Territorio");
            _number = new Field("Numero");
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

        public Field Number
        {
            get { return _number; }
            set { _number = value; }
        }

        #endregion

    }
}
