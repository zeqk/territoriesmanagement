using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace Territories.GUI.Config
{
    [Serializable]
    public class Config
    {
        
        public string CultureTag;

        public Config()
        {
            CultureTag = "en-US";
        }

        public void SaveConfig()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
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
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
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
        }
	
    }
}
