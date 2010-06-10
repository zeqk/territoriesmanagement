using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Localizer;
using TerritoriesManagement.DataBridge;

namespace TerritoriesManagement.GUI
{
    public partial class frmConfig : Form
    {
        private Config.Config _config;

        public Config.Config Config
        {
            get { return _config; }
            set { _config = value; }
        }
	

        public frmConfig()
        {
            InitializeComponent();
            _config = new TerritoriesManagement.GUI.Config.Config();
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

            _config.LoadSavedConfig();

            //cultures
            List<string> cultures = Globalization.LanguagesList;

            cmbCulture.DataSource = cultures;

            if(cultures.Contains( _config.Language))
                cmbCulture.SelectedText = _config.Language;

            txtPlace.Text = _config.Place;


            //maps
            cboMapType.DataSource = Enum.GetValues(typeof(GMap.NET.MapType));
            cboMapType.SelectedItem = _config.MapType;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyCultureChange();
            ApplyMapsChange();
            _config.SaveConfig();
        }

        private void ApplyCultureChange()
        {
            if (cmbCulture.SelectedValue != null)
            {
                _config.Language = (string) cmbCulture.SelectedItem;
            }

            if (!string.IsNullOrEmpty(txtPlace.Text))
                _config.Place = txtPlace.Text;
        }

        private void ApplyMapsChange()
        {
            _config.MapType = (GMap.NET.MapType)cboMapType.SelectedValue;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
