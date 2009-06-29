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
        ImportTool _importer;

        ImporterConfig _config;

        public frmInterop()
        {
            _geoRssImporter = new GeoRssImportTool();
            _importer = new ImportTool();
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

        private void chkDepartments_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in grpDepartments.Controls)
            {
                item.Enabled = chkDepartments.Checked;
            }

            chkDepartments.Enabled = true;

            
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void Import()
        {
            
        }

        private void dataRepeater1_CurrentItemIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmInterop_Load(object sender, EventArgs e)
        {
            _config = new ImporterConfig();
            _config.Departments.Enabled = true;
            propertyGrid1.SelectedObject = _config;
        }
    }
}
