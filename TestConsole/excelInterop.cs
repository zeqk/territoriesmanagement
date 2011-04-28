using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerritoriesManagement.Model;
using System.Xml.Linq;

namespace TestConsole
{
    class excelInterop
    {
        void probar()
        {
            TerritoriesDataContext dm = new TerritoriesDataContext();
            var lista = dm.Territories;

            #region row
            XElement row = new XElement(XName.Get("Row", "urn:schemas-microsoft-com:office:spreadsheet"));
            row.Add(CreateNamespaceAttribute(XName.Get("ss", "http://www.w3.org/2000/xmlns/"), XNamespace.Get("urn:schemas-microsoft-com:office:spreadsheet")));
            row.Add(CreateNamespaceAttribute(XName.Get("xmlns", ""), XNamespace.Get("urn:schemas-microsoft-com:office:spreadsheet")));

            #region cell
            XElement cell = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));

            #region data
            XElement data = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            data.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            data.Add("Dato1");
            #endregion

            cell.Add(data);
            #endregion

            row.Add(cell);
            #endregion

            cell = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            data = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            data.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            data.Add("2Dato1");
            cell.Add(data);
            row.Add(cell);

            cell = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            data = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            data.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            data.Add("3Dato1");
            cell.Add(data);
            row.Add(cell);

            cell = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            data = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            data.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            data.Add("4Dato1");
            cell.Add(data);
            row.Add(cell);

        }

        public static XAttribute CreateNamespaceAttribute(XName name, XNamespace ns)
        {
            XAttribute a = new XAttribute(name, ns.NamespaceName);
            a.AddAnnotation(ns);
            return a;
        }


        void CreateDoc()
        {
            XDocument document = new XDocument(


            XDocument document = XDocument.Load("C:\file.xml",LoadOptions.None);
            document.Element("Workbook").Element("Worksheet");

            //document.Add(new XProcessingInstruction("mso-application", "progid=\"Excel.Sheet\""));
            //XElement workbook = new XElement(XName.Get("Workbook", "urn:schemas-microsoft-com:office:spreadsheet"));
            //workbook.Add(CreateNamespaceAttribute(XName.Get("html", "http://www.w3.org/2000/xmlns/"), XNamespace.Get("http://www.w3.org/TR/REC-html40")));
            //workbook.Add(CreateNamespaceAttribute(XName.Get("ss", "http://www.w3.org/2000/xmlns/"), XNamespace.Get("urn:schemas-microsoft-com:office:spreadsheet")));
            //workbook.Add(CreateNamespaceAttribute(XName.Get("x", "http://www.w3.org/2000/xmlns/"), XNamespace.Get("urn:schemas-microsoft-com:office:excel")));
            //workbook.Add(CreateNamespaceAttribute(XName.Get("o", "http://www.w3.org/2000/xmlns/"), XNamespace.Get("urn:schemas-microsoft-com:office:office")));
            //workbook.Add(CreateNamespaceAttribute(XName.Get("xmlns", ""), XNamespace.Get("urn:schemas-microsoft-com:office:spreadsheet")));
            //XElement docProps = new XElement(XName.Get("DocumentProperties", "urn:schemas-microsoft-com:office:office"));
            //docProps.Add(new XAttribute(XName.Get("xmlns", ""), "urn:schemas-microsoft-com:office:office"));
            //XElement prop = new XElement(XName.Get("Author", "urn:schemas-microsoft-com:office:office"));
            //prop.Add("MSADMIN");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("LastAuthor", "urn:schemas-microsoft-com:office:office"));
            //prop.Add("MSADMIN");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("Created", "urn:schemas-microsoft-com:office:office"));
            //prop.Add("2007-10-23T23:40:11Z");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("Company", "urn:schemas-microsoft-com:office:office"));
            //prop.Add("Microsoft");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("Version", "urn:schemas-microsoft-com:office:office"));
            //prop.Add("12.00");
            //docProps.Add(prop);
            //workbook.Add(docProps);
            //docProps = new XElement(XName.Get("ExcelWorkbook", "urn:schemas-microsoft-com:office:excel"));
            //docProps.Add(new XAttribute(XName.Get("xmlns", ""), "urn:schemas-microsoft-com:office:excel"));
            //prop = new XElement(XName.Get("WindowHeight", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add("6600");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("WindowWidth", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add("12255");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("WindowTopX", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add("0");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("WindowTopY", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add("60");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("ProtectStructure", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add("False");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("ProtectWindows", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add("False");
            //docProps.Add(prop);
            //workbook.Add(docProps);
            //docProps = new XElement(XName.Get("Styles", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop = new XElement(XName.Get("Style", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(new XAttribute(XName.Get("ID", "urn:schemas-microsoft-com:office:spreadsheet"), "Default"));
            //prop.Add(new XAttribute(XName.Get("Name", "urn:schemas-microsoft-com:office:spreadsheet"), "Normal"));
            //XElement prop2 = new XElement(XName.Get("Alignment", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop2.Add(new XAttribute(XName.Get("Vertical", "urn:schemas-microsoft-com:office:spreadsheet"), "Bottom"));
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Borders", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Font", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop2.Add(new XAttribute(XName.Get("FontName", "urn:schemas-microsoft-com:office:spreadsheet"), "Calibri"));
            //prop2.Add(new XAttribute(XName.Get("Family", "urn:schemas-microsoft-com:office:excel"), "Swiss"));
            //prop2.Add(new XAttribute(XName.Get("Size", "urn:schemas-microsoft-com:office:spreadsheet"), "11"));
            //prop2.Add(new XAttribute(XName.Get("Color", "urn:schemas-microsoft-com:office:spreadsheet"), "#000000"));
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Interior", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("NumberFormat", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Protection", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(prop2);
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("Style", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(new XAttribute(XName.Get("ID", "urn:schemas-microsoft-com:office:spreadsheet"), "s62"));
            //prop2 = new XElement(XName.Get("Font", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop2.Add(new XAttribute(XName.Get("FontName", "urn:schemas-microsoft-com:office:spreadsheet"), "Calibri"));
            //prop2.Add(new XAttribute(XName.Get("Family", "urn:schemas-microsoft-com:office:excel"), "Swiss"));
            //prop2.Add(new XAttribute(XName.Get("Size", "urn:schemas-microsoft-com:office:spreadsheet"), "11"));
            //prop2.Add(new XAttribute(XName.Get("Color", "urn:schemas-microsoft-com:office:spreadsheet"), "#000000"));
            //prop2.Add(new XAttribute(XName.Get("Bold", "urn:schemas-microsoft-com:office:spreadsheet"), "1"));
            //prop.Add(prop2);
            //docProps.Add(prop);
            //workbook.Add(docProps);
            //docProps = new XElement(XName.Get("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet"));
            //docProps.Add(new XAttribute(XName.Get("Name", "urn:schemas-microsoft-com:office:spreadsheet"), "Sheet1"));
            //prop = new XElement(XName.Get("Table", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(new XAttribute(XName.Get("ExpandedColumnCount", "urn:schemas-microsoft-com:office:spreadsheet"), "4"));
            //prop.Add(InternalXmlHelper.CreateAttribute(XName.Get("ExpandedRowCount", "urn:schemas-microsoft-com:office:spreadsheet"), customers.Count<XElement>() + 1));
            //prop.Add(new XAttribute(XName.Get("FullColumns", "urn:schemas-microsoft-com:office:excel"), "1"));
            //prop.Add(new XAttribute(XName.Get("FullRows", "urn:schemas-microsoft-com:office:excel"), "1"));
            //prop.Add(new XAttribute(XName.Get("DefaultRowHeight", "urn:schemas-microsoft-com:office:spreadsheet"), "15"));
            //prop2 = new XElement(XName.Get("Row", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop2.Add(new XAttribute(XName.Get("StyleID", "urn:schemas-microsoft-com:office:spreadsheet"), "s62"));
            //XElement prop3 = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            //XElement prop4 = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            //prop4.Add("Abbrev");
            //prop3.Add(prop4);
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4 = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            //prop4.Add("Name");
            //prop3.Add(prop4);
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4 = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            //prop4.Add("Phone");
            //prop3.Add(prop4);
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("Cell", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4 = new XElement(XName.Get("Data", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop4.Add(new XAttribute(XName.Get("Type", "urn:schemas-microsoft-com:office:spreadsheet"), "String"));
            //prop4.Add("Country");
            //prop3.Add(prop4);
            //prop2.Add(prop3);
            //prop.Add(prop2);
            //prop.Add(InternalXmlHelper.RemoveNamespaceAttributes(VB$t_array$L0, VB$t_array$L2, VB$t_ref$L7, (IEnumerable) customers));
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("WorksheetOptions", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add(new XAttribute(XName.Get("xmlns", ""), "urn:schemas-microsoft-com:office:excel"));
            //prop2 = new XElement(XName.Get("PageSetup", "urn:schemas-microsoft-com:office:excel"));
            //prop3 = new XElement(XName.Get("Header", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Margin", "urn:schemas-microsoft-com:office:excel"), "0.3"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("Footer", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Margin", "urn:schemas-microsoft-com:office:excel"), "0.3"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("PageMargins", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Bottom", "urn:schemas-microsoft-com:office:excel"), "0.75"));
            //prop3.Add(new XAttribute(XName.Get("Left", "urn:schemas-microsoft-com:office:excel"), "0.7"));
            //prop3.Add(new XAttribute(XName.Get("Right", "urn:schemas-microsoft-com:office:excel"), "0.7"));
            //prop3.Add(new XAttribute(XName.Get("Top", "urn:schemas-microsoft-com:office:excel"), "0.75"));
            //prop2.Add(prop3);
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Print", "urn:schemas-microsoft-com:office:excel"));
            //prop3 = new XElement(XName.Get("ValidPrinterInfo", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("HorizontalResolution", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add("300");
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("VerticalResolution", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add("300");
            //prop2.Add(prop3);
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Selected", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("Panes", "urn:schemas-microsoft-com:office:excel"));
            //prop3 = new XElement(XName.Get("Pane", "urn:schemas-microsoft-com:office:excel"));
            //prop4 = new XElement(XName.Get("Number", "urn:schemas-microsoft-com:office:excel"));
            //prop4.Add("3");
            //prop3.Add(prop4);
            //prop4 = new XElement(XName.Get("ActiveCol", "urn:schemas-microsoft-com:office:excel"));
            //prop4.Add("2");
            //prop3.Add(prop4);
            //prop2.Add(prop3);
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("ProtectObjects", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add("False");
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("ProtectScenarios", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add("False");
            //prop.Add(prop2);
            //docProps.Add(prop);
            //workbook.Add(docProps);
            //docProps = new XElement(XName.Get("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet"));
            //docProps.Add(new XAttribute(XName.Get("Name", "urn:schemas-microsoft-com:office:spreadsheet"), "Sheet2"));
            //prop = new XElement(XName.Get("Table", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(new XAttribute(XName.Get("ExpandedColumnCount", "urn:schemas-microsoft-com:office:spreadsheet"), "1"));
            //prop.Add(new XAttribute(XName.Get("ExpandedRowCount", "urn:schemas-microsoft-com:office:spreadsheet"), "1"));
            //prop.Add(new XAttribute(XName.Get("FullColumns", "urn:schemas-microsoft-com:office:excel"), "1"));
            //prop.Add(new XAttribute(XName.Get("FullRows", "urn:schemas-microsoft-com:office:excel"), "1"));
            //prop.Add(new XAttribute(XName.Get("DefaultRowHeight", "urn:schemas-microsoft-com:office:spreadsheet"), "15"));
            //prop.Add("");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("WorksheetOptions", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add(new XAttribute(XName.Get("xmlns", ""), "urn:schemas-microsoft-com:office:excel"));
            //prop2 = new XElement(XName.Get("PageSetup", "urn:schemas-microsoft-com:office:excel"));
            //prop3 = new XElement(XName.Get("Header", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Margin", "urn:schemas-microsoft-com:office:excel"), "0.3"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("Footer", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Margin", "urn:schemas-microsoft-com:office:excel"), "0.3"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("PageMargins", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Bottom", "urn:schemas-microsoft-com:office:excel"), "0.75"));
            //prop3.Add(new XAttribute(XName.Get("Left", "urn:schemas-microsoft-com:office:excel"), "0.7"));
            //prop3.Add(new XAttribute(XName.Get("Right", "urn:schemas-microsoft-com:office:excel"), "0.7"));
            //prop3.Add(new XAttribute(XName.Get("Top", "urn:schemas-microsoft-com:office:excel"), "0.75"));
            //prop2.Add(prop3);
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("ProtectObjects", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add("False");
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("ProtectScenarios", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add("False");
            //prop.Add(prop2);
            //docProps.Add(prop);
            //workbook.Add(docProps);
            //docProps = new XElement(XName.Get("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet"));
            //docProps.Add(new XAttribute(XName.Get("Name", "urn:schemas-microsoft-com:office:spreadsheet"), "Sheet3"));
            //prop = new XElement(XName.Get("Table", "urn:schemas-microsoft-com:office:spreadsheet"));
            //prop.Add(new XAttribute(XName.Get("ExpandedColumnCount", "urn:schemas-microsoft-com:office:spreadsheet"), "1"));
            //prop.Add(new XAttribute(XName.Get("ExpandedRowCount", "urn:schemas-microsoft-com:office:spreadsheet"), "1"));
            //prop.Add(new XAttribute(XName.Get("FullColumns", "urn:schemas-microsoft-com:office:excel"), "1"));
            //prop.Add(new XAttribute(XName.Get("FullRows", "urn:schemas-microsoft-com:office:excel"), "1"));
            //prop.Add(new XAttribute(XName.Get("DefaultRowHeight", "urn:schemas-microsoft-com:office:spreadsheet"), "15"));
            //prop.Add("");
            //docProps.Add(prop);
            //prop = new XElement(XName.Get("WorksheetOptions", "urn:schemas-microsoft-com:office:excel"));
            //prop.Add(new XAttribute(XName.Get("xmlns", ""), "urn:schemas-microsoft-com:office:excel"));
            //prop2 = new XElement(XName.Get("PageSetup", "urn:schemas-microsoft-com:office:excel"));
            //prop3 = new XElement(XName.Get("Header", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Margin", "urn:schemas-microsoft-com:office:excel"), "0.3"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("Footer", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Margin", "urn:schemas-microsoft-com:office:excel"), "0.3"));
            //prop2.Add(prop3);
            //prop3 = new XElement(XName.Get("PageMargins", "urn:schemas-microsoft-com:office:excel"));
            //prop3.Add(new XAttribute(XName.Get("Bottom", "urn:schemas-microsoft-com:office:excel"), "0.75"));
            //prop3.Add(new XAttribute(XName.Get("Left", "urn:schemas-microsoft-com:office:excel"), "0.7"));
            //prop3.Add(new XAttribute(XName.Get("Right", "urn:schemas-microsoft-com:office:excel"), "0.7"));
            //prop3.Add(new XAttribute(XName.Get("Top", "urn:schemas-microsoft-com:office:excel"), "0.75"));
            //prop2.Add(prop3);
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("ProtectObjects", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add("False");
            //prop.Add(prop2);
            //prop2 = new XElement(XName.Get("ProtectScenarios", "urn:schemas-microsoft-com:office:excel"));
            //prop2.Add("False");
            //prop.Add(prop2);
            //docProps.Add(prop);
            //workbook.Add(docProps);
            //workbook.Add(VB$t_ref$L7);
            //document.Add(workbook);
            //VB$t_ref$S0.Save(this.FileName);

        }



    }
}
