using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TerritoriesManagement.Model;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExportToKml();
            }
            catch (Exception ex)
            {


                Console.ReadKey();
            }


            Console.ReadKey();
        }


        static void ExportToXml()
        {
            try
            {

                Console.ReadKey();
                var dm = new TerritoriesDataContext();

                var territories = dm.Territories;

                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                var xTerritories = new XElement("Territories");

                foreach (var t in territories)
                {
                    XElement xt = new XElement("Territory");
                    xt.Add(new XElement("Number", t.Number));
                    xt.Add(new XElement("Geoarea", t.Area));
                    xt.Add(new XElement("Label", t.Name));
                    t.Addresses.Load();

                    var xHouses = new XElement("Houses");

                    foreach (var a in t.Addresses)
                    {
                        XElement xa = new XElement("HouseAddress");
                        a.CityReference.Load();
                        a.City.DepartmentReference.Load();
                        
                        string address = a.Street + " " + a.Number + ", " + a.City.Name + ", " + a.City.Department.Name + ", Buenos Aires, Argentina";
                        xa.Add(new XElement("Address", address));
                        xa.Add(new XElement("Street", a.Street));
                        var note = a.AddressData + Environment.NewLine
                            + "ESQ: " + a.Corner1 + ", " + a.Corner2 + Environment.NewLine
                            + "TEL: " + a.Phone1 + (!string.IsNullOrEmpty(a.Phone2) ? " / " + a.Phone2 : string.Empty) + Environment.NewLine
                            + "DESCRIPCION: " + a.Description;
                        xa.Add(new XElement("Note", note));
                        xa.Add(new XElement("Geoposition", new XElement("Lat", a.Lat), new XElement("Lng", a.Lng)));
                        xa.Add(new XElement("Label", (a.InternalTerritoryNumber.HasValue ? a.InternalTerritoryNumber.Value.ToString() : string.Empty)));

                        xHouses.Add(xa);
                    }

                    xt.Add(xHouses);

                    xTerritories.Add(xt);
                }

                doc.Add(xTerritories);

                doc.Save("C:\\Users\\zeqk\\Desktop\\territories.xml");

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        static void ExportToCVS()
        {
            try
            {
                TerritoriesManagement.Model.TerritoriesDataContext dm = new TerritoriesManagement.Model.TerritoriesDataContext();

                var addresses = dm.Addresses;

                var sb = new StringBuilder();
                sb.AppendLine("HouseMarkerId;CongregationFk;TerritoryFk;Address;Number;StreetName;City;County;PostalCode;State;CountryCode;LatLng;Notes;_cdate;_mdate;_creatorFk;_modifierFk");

                var ci = CultureInfo.GetCultureInfo("en");
                
                var i = 1;
                foreach (var a in addresses)
                {
                    if (a.Lng.HasValue && a.Lng.HasValue)
                    {
                        a.CityReference.Load();
                        a.City.DepartmentReference.Load();

                        var houseMarkerId = i.ToString(); ;
                        var congregationFk = "1275";
                        var territoryFk = "66702";                        
                        string address = a.Street + " " + a.Number + ", " + a.City.Name + ", " + a.City.Department.Name + ", Buenos Aires, Argentina";
                        var number = a.Number;
                        var streetName = a.Street;
                        var city = a.City.Name;
                        string county = "NULL";
                        var postalCode = "";
                        var state = "Buenos Aires";
                        var countryCode = "AR";
                        var latLng = "{\"\"lat\"\":" + a.Lat.Value.ToString(ci.NumberFormat) + ",\"\"lng\"\":" + a.Lng.Value.ToString(ci.NumberFormat) + "}";
                        var note = address
                           + a.AddressData + " | "
                           + "ESQ: " + a.Corner1 + ", " + a.Corner2 + " | "
                           + "TEL: " + a.Phone1 + (!string.IsNullOrEmpty(a.Phone2) ? " / " + a.Phone2 : string.Empty) + " | "
                           + "DESCRIPCION: " + (!string.IsNullOrEmpty(a.Description) ? a.Description.Trim('\n') : string.Empty);
                        var creationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        var modDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        var creatorFk = "11031";
                        var modificatorFk = "11031";

                        var line = new string[] { houseMarkerId, congregationFk, territoryFk, address, number, streetName, city, county, postalCode, state, countryCode, latLng, note, creationDate, modDate, creatorFk, modificatorFk };
                        sb.AppendLine(string.Join(";", line));
                        
                        i++;
                    }
                }



                File.WriteAllText("C:\\Users\\zeqk\\Desktop\\myHouseMarkers.cvs", sb.ToString()); 



                Console.ReadKey();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        static void ExportToKml()
        {
            try
            {

                Console.ReadKey();
                TerritoriesManagement.Model.TerritoriesDataContext dm = new TerritoriesManagement.Model.TerritoriesDataContext();

                var addresses = dm.Addresses;

                Document doc = new Document();
                var i = 0;
                foreach (var a in addresses)
                {
                    if (a.Lng.HasValue && a.Lng.HasValue)
                    {
                        a.CityReference.Load();
                        a.City.DepartmentReference.Load();
                        string address = a.Street + " " + a.Number + ", " + a.City.Name + ", " + a.City.Department.Name + ", Buenos Aires, Argentina";

                        var point = new Point();
                        point.Coordinate = new Vector(a.Lat.Value, a.Lng.Value);

                        // This is the Element we are going to save to the Kml file.
                        var placemark = new Placemark();
                        placemark.Geometry = point;
                        placemark.Name = a.IdAddress.ToString();
                        placemark.Address = address;
                        placemark.Description = new Description();
                        placemark.Description.Text = address;

                        doc.AddFeature(placemark);
                        i++;
                    }
                }

                

                // This allows us to save and Element easily.
                KmlFile kml = KmlFile.Create(doc, false);
                using (var stream = System.IO.File.OpenWrite("C:\\Users\\zeqk\\Desktop\\territories.kml"))
                {
                    kml.Save(stream);
                }
                               


                Console.ReadKey();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static void ImportXML()
        {
            var stream = File.OpenRead("C:\\Users\\zeqk\\Desktop\\territories.xml");
            ImportXML(stream);
        }
        static void ImportXML(Stream stream)
        {
            try
            {
                using(var reader = XmlReader.Create(stream))
	            {
                    var doc = XDocument.Load(reader);
                    var territories = doc.Element("Territories").Elements();
                    foreach (var t in territories)
                    {
                        var label = t.Element("Label").Value;
                        var nuimber = t.Element("Number").Value;
                        var area = t.Element("Geoarea").Value;
                        var houses = t.Element("Houses").Elements();
                        //do something

                        foreach (var h in houses)
                        {
                            var address = h.Element("Address").Value;
                            var street = h.Element("Street").Value;
                            var note = h.Element("Note").Value;
                            var lat = h.Element("Geoposition").Element("Lat").Value;
                            var lng = h.Element("Geoposition").Element("Lng").Value;
                            var hlabel = h.Element("Label").Value;
                            //do something
                        }
                    }
	            }    

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        static void probarXmlDoc()
        {
            try
            {

                XDocument document = XDocument.Load(@"C:\Users\zeqk\Desktop\TERRS PARA IMPRIMIR\REGISTROS\registro.xml", LoadOptions.None);
                var workbook = (XElement)document.FirstNode.NextNode; //Workbook
                var sheet = (XElement)workbook.FirstNode.NextNode.NextNode.NextNode; //Worksheet

                var table = (XElement)sheet.FirstNode; // Table
                //int rowsCount = int.Parse(table.Attribute("ExpandedRowCount").Value);

                XElement row = (XElement)table.FirstNode;
                int count = 0;
                while (row != null)
                {
                    if (row.Name.LocalName == "Row")
                    {
                        XElement cell = (XElement)row.FirstNode;
                        while (cell != null)
                        {
                            XElement cellData = (XElement)cell.FirstNode;
                            if (cellData != null)
                            {
                                if (cellData.Value == "(num)")
                                {
                                    cellData.SetValue(count.ToString());
                                    count++;
                                }
                            }
                            cell = (XElement)cell.NextNode;
                        }
                    }
                    row = (XElement)row.NextNode;
                }
                document.Save(@"C:\Users\zeqk\Desktop\TERRS PARA IMPRIMIR\REGISTROS\registro2.xml");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        static void WriteNames()
        {

            Console.ReadKey();
            var dm = new TerritoriesManagement.Model.TerritoriesDataContext();

            var territories = dm.Territories;

            foreach (var t in territories)
            {
                t.Name = t.Name.Substring(8);
                Console.WriteLine(t.Name);
                dm.ApplyPropertyChanges("Territories", t);

            }
            dm.SaveChanges();
            Console.ReadKey();

        }

        static void probar()
        {
            string hola1 = "1234";
            string hola2 = hola1.Substring(0, 5);
        }

        static void getStatics()
        {
            var dm = new TerritoriesManagement.Model.TerritoriesDataContext();

            int tiene = 0;
            int noTiene = 0;

            var territories = dm.Territories;
            List<string> terrs = new List<string>();

            foreach (var t in territories)
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
            var dm = new TerritoriesManagement.Model.TerritoriesDataContext();

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

            foreach (var t in territories)
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

            var dm = new TerritoriesManagement.Model.TerritoriesDataContext();
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
