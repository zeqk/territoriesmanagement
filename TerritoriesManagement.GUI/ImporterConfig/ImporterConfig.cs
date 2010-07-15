using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using AltosTools.Data;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [Serializable]
    public class ImporterConfig
    {
        private string configFile = AppDomain.CurrentDomain.BaseDirectory + "importConfig.xml";

        #region Fields

        private DataProviders _provider;

        private string _connectionString;

        private DepartmentsTable _departments;

        private CitiesTable _cities;

        private TerritoriesTable _territories;

        private AddressesTable _addresses;

        #endregion

        public ImporterConfig()
        {
            _departments = new DepartmentsTable();
            _cities = new CitiesTable();
            _territories = new TerritoriesTable();
            _addresses = new AddressesTable();
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
        public AddressesTable Addresses
        {
            get { return _addresses; }
            set { _addresses = value; }
        }
        [Category("Import tables"), ReadOnly(false)]
        public TerritoriesTable Territories
        {
            get { return _territories; }
            set { _territories = value; }
        }

        [Category("Connection propeties"), ReadOnly(true), Browsable(false)]
        public DataProviders Provider
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

        public void SaveConfig()
        {
            SaveConfig(configFile);
        }

        public void SaveConfig(string path)
        {
            using(StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8))
	        {
                XmlSerializer ser = new XmlSerializer(this.GetType());
                ser.Serialize(sw, this);
	        }
            
        }

        public void LoadConfig()
        {
            LoadConfig(configFile);
        }

        public void LoadConfig(string path)
        {
            try
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
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        private void SetConfig(ImporterConfig config)
        {
            this.ConnectionString = config.ConnectionString;
            this.Departments = config.Departments;
            this.Cities = config.Cities;
            this.Territories = config.Territories;
            this.Addresses = config.Addresses;
        }

        #endregion



    }
    

   


    
    

    
}
