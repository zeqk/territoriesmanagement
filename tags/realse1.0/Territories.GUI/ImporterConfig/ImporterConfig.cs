using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
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

        #region Serialization methods

        public void SaveConfig(string path)
        {
            using(StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8))
	        {
                XmlSerializer ser = new XmlSerializer(this.GetType());
                ser.Serialize(sw, this);
	        }
            
        }

        public void LoadConfig(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(this.GetType());
                    this.SetConfig((ImporterConfig)ser.Deserialize(sr));
                }
            }
        }

        private void SetConfig(ImporterConfig config)
        {
            this.ConnectionString = config.ConnectionString;
            this.Departments = config.Departments;
            this.Cities = config.Cities;
            this.Territories = config.Territories;
            this.Directions = config.Directions;
        }

        #endregion



    }
    

   


    
    

    
}
