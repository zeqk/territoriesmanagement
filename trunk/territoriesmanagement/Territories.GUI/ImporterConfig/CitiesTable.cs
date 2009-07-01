using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(CitiesTableConverter))]
    public class CitiesTable
    {
        #region Fields
        private bool _load;

        private string _tableName;

        private Field _id;

        private Field _name;

        private Field _department;

        #endregion


        public CitiesTable()
        {
            _id = new Field("IdCity");
            _name = new Field("City");
            _department = new Field("Department");
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
        
        public Field Department
        {
            get { return _department; }
            set { _department = value; }
        }



        #endregion
    }

}
