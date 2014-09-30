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
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HPSF;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                getStatics();
            }
            catch (Exception ex)
            {


                Console.ReadKey();
            }


            Console.ReadKey();
        }


        #region NPOI
        static void ProbarNPOI()
        {
            var hssfworkbook = InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.GetSheet("Sheet1");
            //create cell on rows, since rows do already exist,it's not necessary to create rows again.
            ///sheet1.GetRow(0).GetCell(0).StringCellValue;
            sheet1.GetRow(1).GetCell(1).SetCellValue(200200);
            sheet1.GetRow(2).GetCell(1).SetCellValue(300);
            sheet1.GetRow(3).GetCell(1).SetCellValue(500050);
            sheet1.GetRow(4).GetCell(1).SetCellValue(8000);
            sheet1.GetRow(5).GetCell(1).SetCellValue(110);
            sheet1.GetRow(6).GetCell(1).SetCellValue(100);
            sheet1.GetRow(7).GetCell(1).SetCellValue(200);
            sheet1.GetRow(8).GetCell(1).SetCellValue(210);
            sheet1.GetRow(9).GetCell(1).SetCellValue(2300);
            sheet1.GetRow(10).GetCell(1).SetCellValue(240);
            sheet1.GetRow(11).GetCell(1).SetCellValue(180123);
            sheet1.GetRow(12).GetCell(1).SetCellValue(150);
            var myRow = sheet1.GetRow(1);
            
            for (int i = 0; i <= sheet1.LastRowNum; i++)
            {
                var row = sheet1.GetRow(i);
                for (int x = 0; x <= row.LastCellNum; x++)
                {
                    var cell = row.GetCell(x);

                    if (cell.StringCellValue.Contains("@"))
                    {
                        var value = Regex.Match(cell.StringCellValue, @"\@*.?\ ", RegexOptions.Compiled).Value;
#warning terminar
                    }

                    if (Regex.IsMatch(cell.StringCellValue, @"\{(*.?)\}"))
                    {

                    }
                }
                
            }

            //Force excel to recalculate all the formula while open
            sheet1.ForceFormulaRecalculation = true;
        }

        static bool IsRecordRow(IRow row)
        {
            var rv = false;

            if (row.Cells.Count(c => Regex.IsMatch(c.StringCellValue, @"\{(*.?)\}")) > 0)
                rv = true;

            return rv;
        }

        static HSSFWorkbook InitializeWorkbook()
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            FileStream file = new FileStream(@"template/book1.xls", FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);

            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;

            return hssfworkbook;
        }

        #endregion


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

        static void probar()
        {
            string hola1 = "1234";
            string hola2 = hola1.Substring(0, 5);
        }

        static void getStatics()
        {
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
