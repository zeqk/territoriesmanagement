using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using AltosTools.Data;
using TerritoriesManagement.GUI.Interop.Import;

namespace TerritoriesManagement.GUI.Interop
{
    [Serializable]
    public class ImportSettings
    {
        static private string configFile = AppDomain.CurrentDomain.BaseDirectory + "importSettings.xml";

        private static ImportSettings Instance = null;
        static readonly object padlock = new object();

        #region Fields

        private DataProviders? _provider;

        private string _connectionString;

        private List<ExternalTable> _tables;

        #endregion

        private ImportSettings()
        {
            _tables = new List<ExternalTable>();
            _provider = null;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            lock (padlock)
            {
                if (Instance == null)
                {
                    Instance = new ImportSettings();                    
                }
            }
        }

        public static ImportSettings GetInstance()
        {
            if (Instance == null) CreateInstance();
            return Instance;
        }



        #region Properties        

        public List<ExternalTable> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }
        
        public DataProviders? Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        
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
                XmlSerializer ser = new XmlSerializer(typeof(ImportSettings));
                ser.Serialize(sw, ImportSettings.GetInstance());
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
                        XmlSerializer ser = new XmlSerializer(typeof(ImportSettings));
                        var aux = (ImportSettings)ser.Deserialize(sr);
                        ImportSettings.GetInstance().SetConfig(aux);
                    }
                }
                else
                {
                    ImportSettings.GetInstance().SetDefaultConfig();
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        void SetConfig(ImportSettings config)
        {
            _connectionString = config.ConnectionString;
            _provider = config.Provider;
            _tables = config.Tables;
        }

        void SetDefaultConfig()
        {
            _connectionString = "";
            _provider = null;
            //Department
            ExternalTable departmentTable = new ExternalTable();
            departmentTable.ExternalTableName = "(TABLE NAME)";
            departmentTable.RelatedEntitySet = EntitiesEnum.Departments;
            departmentTable.Fields.Add(new Field("(COLUMN NAME)", "Id"));
            departmentTable.Fields.Add(new Field("(COLUMN NAME)", "Name"));

            //City
            ExternalTable cityTable = new ExternalTable();
            cityTable.ExternalTableName = "(TABLE NAME)";
            cityTable.RelatedEntitySet = EntitiesEnum.Cities;
            cityTable.Fields.Add(new Field("(COLUMN NAME)", "Id"));
            cityTable.Fields.Add(new Field("(COLUMN NAME)", "Name"));
            cityTable.Fields.Add(new Field("(COLUMN NAME)", "DepartmentName"));
            cityTable.Fields.Add(new Field("(COLUMN NAME)", "DepartmentId"));

            //Territory
            ExternalTable territoryTable = new ExternalTable();
            territoryTable.ExternalTableName = "(TABLE NAME)";
            territoryTable.RelatedEntitySet = EntitiesEnum.Territories;
            territoryTable.Fields.Add(new Field("(COLUMN NAME)", "Id"));
            territoryTable.Fields.Add(new Field("(COLUMN NAME)", "Name"));
            territoryTable.Fields.Add(new Field("(COLUMN NAME)", "Number"));

            //Address
            ExternalTable addressTable = new ExternalTable();
            addressTable.ExternalTableName = "(TABLE NAME)";
            addressTable.RelatedEntitySet = EntitiesEnum.Addresses;
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Id"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Street"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "AddressData"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Corner1"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Corner2"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Description"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "CustomField1"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "CustomField2"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Phone1"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Phone2"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Map1"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Map2"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Lat"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "Lng"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "TerritoryName"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "TerritoryId"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "CityName"));
            addressTable.Fields.Add(new Field("(COLUMN NAME)", "CityId"));

            _tables.Add(departmentTable);
            _tables.Add(cityTable);
            _tables.Add(territoryTable);
            _tables.Add(addressTable);
        }

        #endregion



    }
    

   


    
    

    
}
