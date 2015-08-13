using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TerritoriesManagement.GUI.Maps;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.Reporting
{
    static public class ReportsHelper
    {

        public static void GenerateTerritoryReport(Territory territory, string fileName)
        {
            var image = MapsHelper.GenerateTerritoryImage(territory);
            var territoryName = (territory.Number.HasValue ? territory.Number.Value.ToString() + " - " : string.Empty) + territory.Name;
            var imageBase64 = ConvertImageStreamToBase64(image);

            var parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("TerritoryName", territoryName));
            parameters.Add(new ReportParameter("Map", imageBase64));

            ReportsHelper.GenerateReport(fileName, "PDF", "TerritoriesManagement.dll", "TerritoriesManagement.Reports.Territory.rdlc", "AddressesDataSet", territory.Addresses.OrderBy(a => a.InternalTerritoryNumber), parameters);
        }

        static string ConvertImageStreamToBase64(MemoryStream stream)
        {
            byte[] imageArray;
            imageArray = stream.ToArray();

            return Convert.ToBase64String(imageArray);
        }

        public static void GenerateReport(string filePath, string format, string assembblyFile, string reportPath, string sourceName, IEnumerable records, IList<ReportParameter> parameters)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(assembblyFile);
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

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
