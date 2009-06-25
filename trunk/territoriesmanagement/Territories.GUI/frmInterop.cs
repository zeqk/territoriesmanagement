using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Territories.BLL;

namespace Territories.GUI
{
    public partial class frmInterop : Form
    {

        GeoRssImportTool _geoRssImporter;
        public frmInterop()
        {
            _geoRssImporter = new GeoRssImportTool();

            InitializeComponent();

        }

        private void btnSelectRssSource_Click(object sender, EventArgs e)
        {
            odfRssSource.ShowDialog();
        }

        private void odfRssSource_FileOk(object sender, CancelEventArgs e)
        {
            txtRssSource.Text = Path.GetFullPath(odfRssSource.FileName);
        }

        private void btnUpdateXls_Click(object sender, EventArgs e)
        {
            if (txtRssSource.Text == "")
            {
                MessageBox.Show("Select source and destiny files");
            }
            else
            {
                try
                {
                    _geoRssImporter.AddPointsToDirections(txtRssSource.Text);                    
                    MessageBox.Show("Xls file updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
