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
            if (txtExcelSource.Text == "" || txtXmlDestiny.Text == "")
            {
                MessageBox.Show("Select source and destiny files");
            }
            else
            {
                Functions.WriteMarks(txtExcelSource.Text, txtXmlDestiny.Text);
                MessageBox.Show("Xml generado exitosamente");
            }
        }

        private void sfdXml_FileOk(object sender, CancelEventArgs e)
        {
            txtXmlDestiny.Text = Path.GetFullPath(sfdXmlDestiny.FileName);
        }

        private void frmToGoogleMaps_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateXls_Click(object sender, EventArgs e)
        {
            if (txtGMSource.Text == "" || txtXlsDestiny.Text == "")
            {
                MessageBox.Show("Select source and destiny files");
            }
            else
            {
                Functions.UpdateGeoposition(txtGMSource.Text, txtXlsDestiny.Text);
                MessageBox.Show("Xls file updated successfully");
            }

        }

        private void btnSelectExcelSource_Click(object sender, EventArgs e)
        {
            ofdExcelSource.ShowDialog();
        }

        private void btnSelectGMSource_Click(object sender, EventArgs e)
        {
            odfGMSource.ShowDialog();
        }

        private void grpGoogleMapsToExcel_Enter(object sender, EventArgs e)
        {

        }

        private void btnSelectXlsDestiny_Click(object sender, EventArgs e)
        {
            ofdXlsDestiny.ShowDialog();
        }

        private void odfGMSource_FileOk(object sender, CancelEventArgs e)
        {
            txtGMSource.Text = Path.GetFullPath(odfGMSource.FileName);
        }

        private void sfdXlsDestiny_FileOk(object sender, CancelEventArgs e)
        {
            txtXlsDestiny.Text = Path.GetFullPath(sfdXmlDestiny.FileName);
        }

        private void opfXlsDestiny_FileOk(object sender, CancelEventArgs e)
        {
            txtXlsDestiny.Text = Path.GetFullPath(ofdXlsDestiny.FileName);
        }
    }
}
