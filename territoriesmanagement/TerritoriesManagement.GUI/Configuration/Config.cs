using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace TerritoriesManagement.GUI.Configuration
{
    [Serializable]
    public class Config
    {
        static private string configFile = AppDomain.CurrentDomain.BaseDirectory + "config.xml";

        static public string Language;

        static public string Region;

        static public string DefaultPlace;

        static public GMap.NET.MapType MapType;

        public Config()
        {
            Language = "English";
            MapType = GMap.NET.MapType.GoogleMap;
        }

        static public void SaveConfig()
        {
            SaveConfig(configFile);
        }

        static public void SaveConfig(string path)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode configNode = doc.CreateElement("Config");

            XmlNode languageNode = doc.CreateElement("Language");
            languageNode.InnerText = Language;
            XmlNode mapTypeNode = doc.CreateElement("MapType");
            mapTypeNode.InnerText = MapType.ToString();
            XmlNode regionNode = doc.CreateElement("Region");
            regionNode.InnerText = Region;
            XmlNode defaultPlace = doc.CreateElement("DefaultPlace");
            defaultPlace.InnerText = DefaultPlace;

            configNode.RemoveAll();
            configNode.AppendChild(languageNode);
            configNode.AppendChild(mapTypeNode);
            configNode.AppendChild(regionNode);
            configNode.AppendChild(defaultPlace);

            doc.AppendChild(configNode);

            doc.Save(path);

        }

        static public void LoadSavedConfig()
        {
            LoadSavedConfig(configFile);
        }

        static public void LoadSavedConfig(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);

                    XmlNode configNode = doc.SelectSingleNode("Config");

                    XmlNode languageNode = configNode.SelectSingleNode("Language");
                    XmlNode mapTypeNode = configNode.SelectSingleNode("MapType");
                    XmlNode regionNode = configNode.SelectSingleNode("Region");
                    XmlNode defaultPlaceNode = configNode.SelectSingleNode("DefaultPlace");

                    Language = languageNode.InnerText;
                    MapType = (GMap.NET.MapType)Enum.Parse(typeof(GMap.NET.MapType), mapTypeNode.InnerText, true);
                    Region = regionNode.InnerText;
                    DefaultPlace = defaultPlaceNode.InnerText;
                }
                else
                    LoadDefaultConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //TODO MOSTRAR MENSAJE BIEN
                LoadDefaultConfig();
            }            
        }

        static private void LoadDefaultConfig()
        {
            Language = "English";
            MapType = GMap.NET.MapType.GoogleMap;            
        }
	
    }
}
