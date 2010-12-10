using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using TerritoriesManagement.GUI.Interop;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [Serializable]
    public class DepartmentsTable : ExternalTable
    {
        #region Fields

        private Field _id;

        private Field _name;

        #endregion

        public DepartmentsTable()
        {
            _id = new Field("ID");
            _name = new Field("PARTIDO");
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
        #endregion

    }
}
