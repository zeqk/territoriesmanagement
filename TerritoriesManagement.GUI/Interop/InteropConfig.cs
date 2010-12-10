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

        private List<TerritoriesManagement.GUI.ImporterConfig.ExternalTable> _tables;

        #endregion

        private InteropConfig()
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

        public List<TerritoriesManagement.GUI.ImporterConfig.ExternalTable> Tables
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
                else
                {
                    InteropConfig.GetInstance().SetDefaultConfig();
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        private void SetConfig(InteropConfig config)
        {
            _connectionString = config.ConnectionString;
            _provider = config.Provider;
            _tables = config.Tables;
        }

        private void SetDefaultConfig()
        {
            //Department
            ExternalTable departmentTable = new ExternalTable();
            departmentTable.ExternalTableName = "(TABLE NAME)";
            departmentTable.RelatedEntitySet = EntitiesEnum.Departments;
            departmentTable.Fields.Add(new Field("(COLUMN NAME)", "id"));
            departmentTable.Fields.Add(new Field("(COLUMN NAME)", "name"));

            _tables.Add(departmentTable);
        }

        #endregion



    }
    

   


    
    

    
}
