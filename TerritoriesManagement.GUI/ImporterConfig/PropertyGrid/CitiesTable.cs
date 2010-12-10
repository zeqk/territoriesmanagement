using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(CitiesTableConverter))]
    public class CitiesTable : ITable
    {
        #region Fields
        private bool _import;

        private string _tableName;

        private Field _id;

        private Field _name;

        private Field _departmentName;

        private Field _departmentId;

        #endregion


        public CitiesTable()
        {
            _id = new Field("IdCity");
            _name = new Field("City");
            _departmentName = new Field("Department");
            _departmentId = new Field("IdDepartment");
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

        public Field DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        
        public Field DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        #endregion
    }

}
