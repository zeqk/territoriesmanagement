using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TerritoriesManagement.GUI.Config
{
    [Serializable]
    public class Config
    {
        private string configFile = AppDomain.CurrentDomain.BaseDirectory + "config.xml";

        public string CultureTag;

        public string Place;

        public GMap.NET.MapType MapType;

        public Config()
        {
            CultureTag = "en-US";
            MapType = GMap.NET.MapType.GoogleMap;
        }

        public void SaveConfig()
        {
            SaveConfig(configFile);
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
            LoadSavedConfig(configFile);
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
            this.Place = config.Place;
        }
	
    }
}
