using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace TerritoriesManagement.GUI.Config
{
    [Serializable]
    public class Config
    {
        
        public string CultureTag;

        public GMap.NET.MapType MapType;

        public Config()
        {
            CultureTag = "en-US";
            MapType = GMap.NET.MapType.GoogleMap;
        }

        public void SaveConfig()
        {
            string configFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Territories Management\";
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);
            string path = configFolder + "config.xml";
            SaveConfig(path);
        }

        public void SaveConfig(string path)
        {

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer(this.GetType());
                ser.Serialize(sw, this);
            }

        }

        public void LoadSavedConfig()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Territories Management\config.xml";

            LoadSavedConfig(path);
        }

        public void LoadSavedConfig(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        XmlSerializer ser = new XmlSerializer(this.GetType());
                        this.SetConfig((Config)ser.Deserialize(sr));
                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        private void SetConfig(Config config)
        {
            this.CultureTag = config.CultureTag;
            this.MapType = config.MapType;
        }
	
    }
}
