using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using AltosTools.Data;
using TerritoriesManagement.GUI.ImporterConfig;
using System.Runtime.CompilerServices;

namespace TerritoriesManagement.GUI.Interop
{
    [Serializable]
    public class InteropConfig
    {
        static private string configFile = AppDomain.CurrentDomain.BaseDirectory + "interopConfig.xml";

        private static InteropConfig Instance = null;
        static readonly object padlock = new object();

        #region Fields

        private DataProviders? _provider;

        private string _connectionString;

        private DepartmentsTable _departments;

        private CitiesTable _cities;

        private TerritoriesTable _territories;

        private AddressesTable _addresses;

        #endregion

        private InteropConfig()
        {
            _departments = new DepartmentsTable();
            _cities = new CitiesTable();
            _territories = new TerritoriesTable();
            _addresses = new AddressesTable();
            _provider = null;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            lock (padlock)
            {
                if (Instance == null)
                {
                    Instance = new InteropConfig();                    
                }
            }
        }

        public static InteropConfig GetInstance()
        {
            if (Instance == null) CreateInstance();
            return Instance;
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
        public DataProviders? Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        [Category("Connection propeties"), ReadOnly(true), Browsable(false)]
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        #endregion

        #region Serialization methods

        static public void SaveConfig()
        {
            SaveConfig(configFile);
        }

        static public void SaveConfig(string path)
        {
            using(StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8))
	        {
                XmlSerializer ser = new XmlSerializer(typeof(InteropConfig));
                ser.Serialize(sw, InteropConfig.GetInstance());
	        }
            
        }

        static public void LoadConfig()
        {
            LoadConfig(configFile);
        }

        static public void LoadConfig(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(InteropConfig));
                        var aux = (InteropConfig)ser.Deserialize(sr); 
                        InteropConfig.GetInstance().SetConfig(aux);
                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        private void SetConfig(InteropConfig config)
        {
            this.ConnectionString = config.ConnectionString;
            this.Provider = config.Provider;
            this.Departments = config.Departments;
            this.Cities = config.Cities;
            this.Territories = config.Territories;
            this.Addresses = config.Addresses;
        }

        #endregion



    }
    

   


    
    

    
}
