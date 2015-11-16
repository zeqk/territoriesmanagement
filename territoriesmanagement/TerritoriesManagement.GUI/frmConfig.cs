using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using Localizer;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.GUI.Configuration;

namespace TerritoriesManagement.GUI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (chkAddresses.Checked)
            {
                Addresses server = new Addresses();
                server.DeleteAll();                
            }

            if (chkCities.Checked)
            {
                Cities server = new Cities();
                server.DeleteAll();
            }

            if (chkDepartments.Checked)
            {
                Departments server = new Departments();
                server.DeleteAll();
            }

            if (chkTours.Checked)
            {
                //TODO
            }

            if (chkTerritories.Checked)
            {
                Territories server = new Territories();
                server.DeleteAll();
            }
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            //cultures
            List<string> cultures = Globalization.LanguagesList;

            cmbCulture.DataSource = cultures;
            if (cultures.Contains(Config.Language))
                cmbCulture.SelectedItem = Config.Language;

            txtPlace.Text = Config.Region;
            txtDefaultPlace.Text = Config.DefaultPlace;

            //maps
            cboMapType.DataSource = GMapProviders.List;
            cboMapType.DisplayMember = "Name";
            cboMapType.SelectedItem = Config.MapProvider;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyCultureChange();
            ApplyMapsChange();
            Config.SaveConfig();
        }

        private void ApplyCultureChange()
        {
            if (cmbCulture.SelectedValue != null)
            {
                Config.Language = (string)cmbCulture.SelectedItem;
                Globalization.SetCurrentLanguage(Config.Language);
                Globalization.RefreshUI();
            }

            if (!string.IsNullOrEmpty(txtPlace.Text))
                Config.Region = txtPlace.Text;

            if (!string.IsNullOrEmpty(txtDefaultPlace.Text))
                Config.DefaultPlace = txtDefaultPlace.Text;
        }

        private void ApplyMapsChange()
        {
            Config.MapProvider = (GMapProvider)cboMapType.SelectedItem;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnApply.PerformClick();
            this.Close();
        }

        private void btnGeoLocateAll_Click(object sender, EventArgs e)
        {
            try
            {
                int count = new Addresses().GeoLocateAddresses(Config.Region);
                MessageBox.Show(string.Format("{0} addresses were geolocated", count));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

		private void btnRenumberTerritories_Click(object sender, EventArgs e)
		{
			try
			{
				var bridge = new Territories();
				bridge.RenumberTerritories();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
    }
}
