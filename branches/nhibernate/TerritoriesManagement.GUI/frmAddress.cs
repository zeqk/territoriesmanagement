using System;
using System.Windows.Forms;
using GMap.NET;
using Localizer;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.GUI.Configuration;
using TerritoriesManagement.Model;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace TerritoriesManagement.GUI
{
    public partial class frmAddress : Form
    {
        private Addresses server;
        private bool isDirty;
        private bool hasntTerritory;
        Configuration.Config config;

        public Address Address
        {
            get 
            {
                Address rv = (Address)bsAddress.DataSource;

                if (hasntTerritory && cboTerritory.SelectedItem != null)
                {
                    rv.Territory = new Territory();
                    rv.Territory.IdTerritory = (int)cboTerritory.SelectedValue;
                }

                if (!chkHaveGeoPos.Checked)
                {
                    rv.Lat = null;
                    rv.Lng = null;
                }

                return rv;
            }
            set 
            {   
                bsAddress.DataSource = value;

                if (value.City != null && value.City.Department != null)
                    cboDepartment.SelectedValue = value.City.Department.IdDepartment;
                else
                    cboDepartment.SelectedItem = null;

                if (value.Territory == null)
                {
                    //cboTerritory.SelectedItem = null;
                    hasntTerritory = true;
                }
                else
                    hasntTerritory = false;

                if (value.Lat != null && value.Lng != null)
                    chkHaveGeoPos.Checked = true;
                else
                {
                    chkHaveGeoPos.Checked = false;
                    txtLat.Enabled = false;
                    txtLon.Enabled = false;
                }


            }
        }	

        public frmAddress(Addresses server)
        {
            this.server = server;
            Config.LoadSavedConfig();

            InitializeComponent();
            ConfigureMenus();

            Globalization.RefreshUI(this);
        }

        public frmAddress()
        {
            this.server = new Addresses();

            Config.LoadSavedConfig();

            InitializeComponent(); 
            ConfigureMenus();

            Globalization.RefreshUI(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {                
                try
                {
                    server.Save(this.Address);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
                this.DialogResult = DialogResult.None;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedValue != null)
            {
                int idDepartment = (int)cboDepartment.SelectedValue;
                cboCity.DataSource = server.GetCitiesByDepartment(idDepartment);
                //cboCity.SelectedValue = 0;
            }
            else
                cboCity.DataSource = null;
            
        }

        private void frmAddress_Load(object sender, EventArgs e)
        {
            isDirty = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtLat.Clear();
            txtLat.Enabled = false;
            txtLon.Clear();
            txtLon.Enabled = false;
        }

        private void chkHasGeoPos_CheckedChanged(object sender, EventArgs e)
        {
            txtLat.Enabled = chkHaveGeoPos.Checked;
            txtLon.Enabled = chkHaveGeoPos.Checked;
            isDirty = true;
        }

        private void ConfigureMenus()
        {
            cboDepartment.DisplayMember = "Name";            
            cboDepartment.ValueMember = "Id";
            cboDepartment.DataSource = server.GetDepartments();            
            cboDepartment.SelectedItem = null;

            cboCity.DisplayMember = "Name";
            cboCity.ValueMember = "Id";

            cboTerritory.DisplayMember = "Name";
            cboTerritory.ValueMember = "Id";
            cboTerritory.DataSource = server.GetTerritories();
            cboTerritory.SelectedItem = null;
        }

        private void HasChanges(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void GeoPositionHasChanges(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void btnSearchGeoPos_Click(object sender, EventArgs e)
        {
            var map = frmMap.GetInstance();
            map.Clear();
            map.MapType = Config.MapType;
            map.MapMode = MapModeEnum.EditPoint;
            
            GMapMarker marker = GetMarker(this.Address.Lat, this.Address.Lng);

            map.MainMarker = marker;

            map.Address = this.Address.Street + " " + this.Address.Number + ", " + this.Address.City.Name + ", " + GetDepartmentName() + ", " + Config.Region;

            map.ShowDialog();

            if (map.DialogResult == DialogResult.OK)
            {
                chkHaveGeoPos.Checked = true;

                txtLat.Text = map.MainMarker.Position.Lat.ToString();
                txtLon.Text = map.MainMarker.Position.Lng.ToString();
            }
        }

        private GMapMarker GetMarker(double? lat, double? lng)
        {            
            GMapMarker marker = null;
            if (lat.HasValue && lng.HasValue)
                marker = new GMapMarkerGoogleRed(new PointLatLng(lat.Value, lng.Value));
            return marker;
        }

        private string GetDepartmentName()
        {
            string rv = "";
            if(cboDepartment.SelectedItem != null)
                rv = cboDepartment.SelectedItem.GetType().GetProperty("Name").GetValue(cboDepartment.SelectedItem, null).ToString();

            return rv;
        }

        private void btnAutoselectTerritory_Click(object sender, EventArgs e)
        {
            if (this.Address.Lat.HasValue && this.Address.Lng.HasValue)
            {
                PointLatLng point = new PointLatLng(this.Address.Lat.Value, this.Address.Lng.Value);
                Territory terr = server.FindTerritory(point);
                if(terr != null)
                    cboTerritory.SelectedValue = terr.IdTerritory;
            }
        }

        
        
    }
}
