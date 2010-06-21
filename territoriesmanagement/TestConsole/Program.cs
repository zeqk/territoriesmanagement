using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data.Entity;
using TerritoriesManagement.Model;
using TerritoriesManagement;
using GMap.NET;
using System.Globalization;
using System.Xml.Linq;
using System.Xml;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            prueba3();
        }

        static void WriteNames()
        {
            Console.ReadKey();
            TerritoriesDataContext dm = new TerritoriesDataContext();

            var territories = dm.Territories;

            foreach (Territory t in territories)
            {
                t.Name = t.Name.Substring(8);
                Console.WriteLine(t.Name);
                dm.ApplyPropertyChanges("Territories", t);
                
            }
            dm.SaveChanges();
            Console.ReadKey();

        }

        static void getStatics()
        {
            Console.ReadKey();
            TerritoriesDataContext dm = new TerritoriesDataContext();

            int tiene = 0;
            int noTiene = 0;

            var territories = dm.Territories;
            List<string> terrs = new List<string>();

            foreach (Territory t in territories)
            {
                t.Addresses.Load();
                if (t.Addresses.Count > 0)
                    tiene++;
                else
                {
                    noTiene++;
                    terrs.Add(t.Name);
                }
            }

            Console.WriteLine("Terrtorios con direcciones: {0}", tiene);
            Console.WriteLine("Terrtorios sin direcciones: {0}", noTiene);

            foreach (string item in terrs)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        #region rss
        static void prueba1()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rssNode = doc.CreateElement("rss");
            
            XmlNode channelNode = doc.CreateElement("channel");

            XmlNode channelLink = doc.CreateElement("link");
            channelLink.InnerText = "http://maps.google.com";

            XmlNode channelTitle = doc.CreateElement("title");
            channelTitle.InnerText = "Territories";

            XmlNode channelDesc = doc.CreateElement("description");

           
            channelNode.RemoveAll();
            channelNode.AppendChild(channelLink);
            channelNode.AppendChild(channelTitle);

            rssNode.RemoveAll();
            rssNode.AppendChild(channelNode);

            doc.AppendChild(rssNode);

            doc.Save(@"D:\prueba.xml");
        }

        static void  prueba2()
        {
            TerritoriesManagement.Model.TerritoriesDataContext dm = new TerritoriesDataContext();

            var territories = dm.Territories;

            XmlNamespaceManager xmlNSManager = new XmlNamespaceManager(new System.Xml.NameTable());
            xmlNSManager.AddNamespace("georss", "http://www.georss.org/georss");
            xmlNSManager.AddNamespace("gml", "http://www.opengis.net/gml");

            XmlDocument doc = new XmlDocument();


            XmlNode rssNode = doc.CreateElement("rss");
            //XmlAttribute georssNS = doc.CreateAttribute("georss","", "http://www.georss.org/georss");
            
            //rssNode.Attributes.Append(georssNS);

            XmlNode channelNode = doc.CreateElement("channel");

            XmlNode channelLink = doc.CreateElement("link");
            channelLink.InnerText = "http://maps.google.com";

            XmlNode channelTitle = doc.CreateElement("title");
            channelTitle.InnerText = "Territories";

            XmlNode channelDesc = doc.CreateElement("description");                  
            
            channelNode.RemoveAll();
            channelNode.AppendChild(channelLink);
            channelNode.AppendChild(channelTitle);

            foreach (Territory t in territories)
            {
                if (t.Area != null)
                {
                    XmlNode item = doc.CreateElement("item");

                    XmlNode itemGuid = doc.CreateElement("guid");
                    itemGuid.InnerText = "00046ebeb50abb48ada9e";
                    XmlNode itemPubDate = doc.CreateElement("pubDate");
                    itemPubDate.InnerText = DateTime.Now.ToShortDateString();

                    XmlNode itemTitle = doc.CreateElement("title");
                    itemTitle.InnerText = t.Name;

                    XmlNode itemDesc = doc.CreateElement("description");
                    XmlNode itemAuthor = doc.CreateElement("author");
                    itemAuthor.InnerText = "zeqk.net";

                    XmlNode lineString = doc.CreateElement("gml:LineString");

                    XmlNode posList = doc.CreateElement("gml:posList");
                    
                    posList.InnerText = t.Area;
                    
                    lineString.RemoveAll();
                    lineString.AppendChild(posList);

                    item.RemoveAll();
                    item.AppendChild(itemGuid);
                    item.AppendChild(itemPubDate);
                    item.AppendChild(itemTitle);
                    item.AppendChild(itemDesc);
                    item.AppendChild(itemAuthor);
                    item.AppendChild(lineString);

                    channelNode.AppendChild(item);

                }
            }

            rssNode.RemoveAll();
            rssNode.AppendChild(channelNode);

            doc.AppendChild(rssNode);

            doc.Save(@"D:\prueba.xml");
        }

        static void prueba3()
        {

            TerritoriesDataContext dm = new TerritoriesDataContext();
            var territories = dm.Territories;

            XNamespace nsGeorss = "http://www.georss.org/georss";
            XNamespace nsGml = "http://www.opengis.net/gml";

            XElement channel = new XElement("channel",
                new XElement("title", "Club Events Feed"),
                new XElement("link", "www.google.com.ar"),
                new XElement("description", "Events coming up..."));

            XElement xmlFeed = new XElement("rss",
                new XAttribute("version", 2.0),
                new XAttribute(XNamespace.Xmlns + "georss", nsGeorss),
                new XAttribute(XNamespace.Xmlns + "gml", nsGml),
                channel);

            foreach (var t in territories)
            {
                XElement polygon = new XElement(nsGml + "Polygon",
                    new XElement(nsGml + "exterior",
                        new XElement(nsGml + "LinearRing",
                            new XElement(nsGml + "posList", t.Area)
                            )
                        )
                    );

                XElement element = new XElement("item",
                    new XElement("title", t.Name),
                    new XElement("link", new XAttribute("rel", "via"), new XAttribute("href", "www.google.com")),
                    new XElement("description", t.Name),
                    new XElement("content",t.Name),
                    new XElement("author", "zeqk"),
                    polygon
                    );

                channel.Add(element);
            }

            xmlFeed.Save(@"D:\prueba.xml");

        }

        #endregion

    }
}
