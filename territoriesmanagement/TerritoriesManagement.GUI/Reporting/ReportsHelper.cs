using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.GUI.Maps;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.Reporting
{
    public class ReportFormats
    {
        public static readonly string PDF = "PDF";
        public static readonly string Excel = "Excel";
        public static readonly string Word = "Word";
        public static readonly string Image = "Image";
    }

    static public class ReportsHelper
    {

        public static void GenerateMultipleTerritoriesReport(Expression<Func<Territory,bool>> whereExp, string path, bool singleFile)
        {
            var bridge = new Territories();
            var territories = bridge.Search(whereExp);

            if (territories.Count > 0)
            {
                
                var folder = path;
                if (singleFile)
                {
                    var tempFolder = Path.Combine(Path.GetTempPath(), "TerritoriesManagement");
                    if (Directory.Exists(tempFolder))
                        Directory.Delete(tempFolder, true);
                    Directory.CreateDirectory(tempFolder);
                    folder = tempFolder;
                }
                var extension = ".pdf";
                var format = ReportFormats.PDF;
                
                var files = new List<string>();

                foreach (var t in territories)
                {
                    var name = (t.Number.HasValue ? t.Number.Value.ToString() : string.Empty) + " - " + t.Name;
                    var file = Path.Combine(folder, name + extension);
                    GenerateTerritoryReport(t, file, format);
                    files.Add(file);
                }

                if(singleFile)
                    MergePdfsToSingle(files, path);
            }
        }

		public static bool GenerateTerritoriesImages(Expression<Func<Territory, bool>> whereExp, string path, bool singleFile)
		{
			var rv = false;
            var bridge = new Territories();
            var territories = bridge.Search(whereExp);
            if (!singleFile)
            {
                foreach (var territory in territories)
                {
                    var name = (territory.Number.HasValue ? territory.Number.Value.ToString() : string.Empty) + " - " + territory.Name;
                    var file = Path.Combine(path, name + ".png");

                    GenerateTerritoryReport(territory, file, ReportFormats.Image);
                }
            }
            else
            {
                var ms = MapsHelper.GenerateTerritoriesImage(territories);
                var bmp = new Bitmap(ms);
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

			return rv;
		}

        public static void GenerateTerritoryReport(Territory territory, string fileName, string format)
        {
            var image = MapsHelper.GenerateTerritoryImage(territory);
            var territoryName = (territory.Number.HasValue ? territory.Number.Value.ToString() + " - " : string.Empty) + territory.Name;
            var imageBase64 = ConvertImageStreamToBase64(image);

            var parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("TerritoryName", territoryName));
            parameters.Add(new ReportParameter("Map", imageBase64));

            ReportsHelper.GenerateReport(fileName, format, "TerritoriesManagement.dll", "TerritoriesManagement.Reports.Territory.rdlc", "AddressesDataSet", territory.Addresses.OrderBy(a => a.InternalTerritoryNumber), parameters);
        }

        public static void GenerateTerritoriesListReport(Expression<Func<Territory,bool>> exp, string fileName)
        {

            var bridge = new Territories();
            var territories = bridge.SearchItem1(exp);

            var parameters = new List<ReportParameter>();

            ReportsHelper.GenerateReport(fileName, ReportFormats.Excel, "TerritoriesManagement.dll", "TerritoriesManagement.Reports.TerritoriesList.rdlc", "TerritoryItem1DS", territories, parameters);
        }

        public static void GenerateAddressesListReport(IList<AddressItem1> addresses, string fileName)
        {
            var parameters = new List<ReportParameter>();

            ReportsHelper.GenerateReport(fileName, ReportFormats.Excel, "TerritoriesManagement.dll", "TerritoriesManagement.Reports.Addresses.rdlc", "AddressItem1DS", addresses, parameters);
        }

        static string ConvertImageStreamToBase64(MemoryStream stream)
        {
            byte[] imageArray;
            imageArray = stream.ToArray();

            return Convert.ToBase64String(imageArray);
        }

        

        public static void GenerateReport(string filePath, string format, string assemblyFile, string reportPath, string sourceName, IEnumerable records, IList<ReportParameter> parameters)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(assemblyFile);
                Stream stream = assembly.GetManifestResourceStream(reportPath);

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(stream);

                report.DataSources.Add(new ReportDataSource(sourceName, records));

                foreach (var item in parameters)
                {
                    report.SetParameters(item);
                }

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;


                byte[] bytes = report.Render(format, null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

                if (format.ToUpper() != "IMAGE")
                {

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                else
                {                    
                    using (var ms = new MemoryStream(bytes))
                    {
                        var bmp = new Bitmap(ms);
                        bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void MergePdfsToSingle(IList<string> inputFiles, string outputFile)
        {
            //Step 1: Create a Docuement-Object
            Document document = new Document();
            try
            {
                //Step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create));

                //Step 3: Open the document
                document.Open();

                PdfContentByte cb = writer.DirectContent;

                var i = 0;
                foreach (var file in inputFiles)
                {
                    var reader = new PdfReader(file);
                    if(i == 0)
                        document.SetPageSize(PageSize.A4.Rotate());

                    if (!IsOdd(i))
                    {
                        document.NewPage();    
                    }
                    var page = writer.GetImportedPage(reader, 1);

                    if (!IsOdd(i))
                    {
                        cb.AddTemplate(page, 0, 0);
                        cb.MoveTo(document.PageSize.Width / 2, 0);
                        cb.LineTo(document.PageSize.Width / 2, document.PageSize.Height);
                        cb.Stroke();
                    }
                    else
                        cb.AddTemplate(page, reader.GetPageSize(1).Width, 0);
                    i++;
                }
            }
            catch (Exception e) { throw e; }
            finally { document.Close(); }
        }

        /// <summary>
        /// Es impar
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
