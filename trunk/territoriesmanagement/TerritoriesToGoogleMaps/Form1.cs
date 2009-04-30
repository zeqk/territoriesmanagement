using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace TerritoriesToGoogleMaps
{
    public partial class frmToGoogleMaps : Form
    {
        string fileIn;
        string fileOut;
        public frmToGoogleMaps()
        {
            InitializeComponent();
        }

        private void ofdTerritoriesSheet_FileOk(object sender, CancelEventArgs e)
        {

            txtExcelSource.Text = Path.GetFullPath(ofdExcelSource.FileName);
        }

        private void btnSelectDestiny_Click(object sender, EventArgs e)
        {
            sfdXmlDestiny.ShowDialog();
        }

        private void btnConvertToXml_Click(object sender, EventArgs e)
        {
            Functions.WriteMarks(txtExcelSource.Text, txtXmlDestiny.Text);
            MessageBox.Show("Xml generado exitosamente");
        }

        private void sfdXml_FileOk(object sender, CancelEventArgs e)
        {
            txtXmlDestiny.Text = Path.GetFullPath(sfdXmlDestiny.FileName);
        }

        private void frmToGoogleMaps_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculeMiddlePoint_Click(object sender, EventArgs e)
        {
            double lat = 0;
            double lon = 0;
            Functions.CalculateMiddlePoint(ref lat, ref lon);
            txtLatitude.Text = lat.ToString(new CultureInfo("en-US"));
            txtLongitude.Text = lon.ToString(new CultureInfo("en-US"));

        }

        private void btnSelectExcelSource_Click(object sender, EventArgs e)
        {
            ofdExcelSource.ShowDialog();
        }

        private void btnSelectXmlSource_Click(object sender, EventArgs e)
        {
            txtXmlSource.Text = Path.GetFullPath(ofdXmlSource.FileName);
        }
    }
}
