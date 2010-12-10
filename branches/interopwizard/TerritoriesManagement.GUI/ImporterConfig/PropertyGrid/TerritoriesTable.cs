using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using TerritoriesManagement.GUI.Interop;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [Serializable]
    public class TerritoriesTable : ExternalTable
    {
        #region Fields

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
