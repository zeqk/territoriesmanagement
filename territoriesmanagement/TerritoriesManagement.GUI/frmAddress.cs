using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Localizer;
using System;
using System.Windows.Forms;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.GUI.Configuration;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.GUI
{
    public partial class frmAddress : Form
    {
        private Addresses server;
        private bool isDirty;
        private string customField2;

        public Address Address
        {
            get 
            {
                Address rv = new Address();
                rv.IdAddress = int.Parse(this.txtId.Text);
                rv.AddressData = this.txtAddressData.Text;
                rv.Corner1 = this.txtCorner1.Text;
                rv.Corner2 = this.txtCorner2.Text;
                rv.CustomField1 = this.txtField1.Text;
                rv.CustomField2 = this.customField2;
                rv.Description = this.txtDescription.Text;
                rv.InternalTerritoryNumber = !string.IsNullOrEmpty(this.txtInternalNumber.Text) ? (int?)int.Parse(this.txtInternalNumber.Text) : null;
                rv.Map1 = this.txtMap1.Text;
                rv.Map2 = this.txtMap2.Text;
                rv.Number = this.txtNumber.Text;
                rv.Phone1 = this.txtPhone1.Text;
                rv.Phone2 = this.txtPhone2.Text;
                rv.Street = this.txtStreet.Text;
                

                if (cboCity.SelectedItem != null)
                {
                    rv.City = new City();
                    rv.City.IdCity = (int)cboCity.SelectedValue;
                }

                if (cboTerritory.SelectedItem != null)
                {
                    rv.Territory = new Territory();
                    rv.Territory.IdTerritory = (int)cboTerritory.SelectedValue;
                }

                if (!chkHaveGeoPos.Checked)
                {
                    rv.Lat = null;
                    rv.Lng = null;
                }
                else
                {
                    rv.Lat = !string.IsNullOrEmpty(this.txtLat.Text) ? (double?)double.Parse(this.txtLat.Text) : null;
                    rv.Lng = !string.IsNullOrEmpty(this.txtLon.Text) ? (double?)double.Parse(this.txtLon.Text) : null;
                }

                return rv;
            }
            set 
            {
                this.txtId.Text = value.IdAddress.ToString();
                this.txtAddressData.Text = value.AddressData;
                this.txtCorner1.Text = value.Corner1;
                this.txtCorner2.Text = value.Corner2;
                this.txtField1.Text = value.CustomField1;
                this.customField2 = value.CustomField2;
                this.txtDescription.Text = value.Description;
                this.txtInternalNumber.Text = value.InternalTerritoryNumber.HasValue ? value.InternalTerritoryNumber.Value.ToString() : string.Empty;
                this.txtMap1.Text = value.Map1;
                this.txtMap2.Text = value.Map2;
                this.txtNumber.Text = value.Number;
                this.txtPhone1.Text = value.Phone1;
                this.txtPhone2.Text = value.Phone2;
                this.txtStreet.Text = value.Street;

                if (value.City != null && value.City.Department != null)
                {
                    cboDepartment.SelectedValue = value.City.Department.IdDepartment;
                    cboCity.SelectedValue = value.City.IdCity;
                }
                else
                {
                    cboDepartment.SelectedItem = null;
                    cboCity.SelectedItem = null;
                }

                if (value.Territory != null && value.Territory != null)
                {
                    cboTerritory.SelectedValue = value.Territory.IdTerritory;
                }
                else
                {
                    cboTerritory.SelectedItem = null;
                }

                this.txtLat.Text = value.Lat.HasValue ? value.Lat.ToString() : string.Empty;
                this.txtLon.Text = value.Lng.HasValue ? value.Lng.ToString() : string.Empty;
                if (value.Lat != null && value.Lng != null)
                {                    
                    chkHaveGeoPos.Checked = true;
                }
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
            map.MapProvider = Config.MapProvider;
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
                marker = new GMarkerGoogle(new PointLatLng(lat.Value, lng.Value), GMarkerGoogleType.red);
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
