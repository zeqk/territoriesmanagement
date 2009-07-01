using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using My;

namespace Territories.GUI.ImporterConfig
{
    [Serializable]
    public class ImporterConfig
    {

        #region Fields

        private Enumerators.Provider _provider;

        private string _connectionString;

        private DepartmentsTable _departments;

        private CitiesTable _cities;

        private TerritoriesTable _territories;

        private DirectionsTable _directions;

        #endregion



        public ImporterConfig()
        {
            _departments = new DepartmentsTable();
            _cities = new CitiesTable();
            _territories = new TerritoriesTable();
            _directions = new DirectionsTable();
        }

        #region Properties

        [Category("Import tables"), ReadOnly(false)]
        public DepartmentsTable Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        [Category("Import tables"), ReadOnly(false)]
        public CitiesTable Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        [Category("Import tables"), ReadOnly(false)]
        public DirectionsTable Directions
        {
            get { return _directions; }
            set { _directions = value; }
        }
        [Category("Import tables"), ReadOnly(false)]
        public TerritoriesTable Territories
        {
            get { return _territories; }
            set { _territories = value; }
        }

        [Category("Connection propeties"), ReadOnly(true), Browsable(false)]
        public Enumerators.Provider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        [Category("Connection propeties"),ReadOnly(true),Browsable(false)]
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        #endregion



    }
    

   


    
    

    
}
