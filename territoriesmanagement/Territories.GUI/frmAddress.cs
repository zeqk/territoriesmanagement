using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects.DataClasses;
using Territories.Model;
using Territories.BLL.DataBridge;
using System.Globalization;

namespace Territories.GUI
{
    public partial class frmAddress : Form
    {
        private Addresses _server;
        private bool _isDirty;
        private bool _haventTerritory;

        public Address Address
        {
            get 
            {
                Address rv = (Address)bsAddress.DataSource;

                if (_haventTerritory && cboTerritory.SelectedItem != null)
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
                    _haventTerritory = true;
                }
                else
                    _haventTerritory = false;

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
            _server = server;            
            InitializeComponent();
            ConfigureMenus();
        }

        public frmAddress()
        {
            _server = new Addresses();
            InitializeComponent(); 
            ConfigureMenus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isDirty)
            {                
                try
                {
                    _server.Save(this.Address);
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
                cboCity.DataSource = _server.GetCitiesByDepartment(idDepartment);
                //cboCity.SelectedValue = 0;
            }
            else
                cboCity.DataSource = null;
            
        }

        private void frmAddress_Load(object sender, EventArgs e)
        {
            _isDirty = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtLat.Clear();
            txtLat.Enabled = false;
            txtLon.Clear();
            txtLon.Enabled = false;
        }

        private void chkHaveGeoPos_CheckedChanged(object sender, EventArgs e)
        {
            txtLat.Enabled = chkHaveGeoPos.Checked;
            txtLon.Enabled = chkHaveGeoPos.Checked;
            _isDirty = true;
        }

        private void ConfigureMenus()
        {
            cboDepartment.DisplayMember = "Name";            
            cboDepartment.ValueMember = "Id";
            cboDepartment.DataSource = _server.GetDepartments();            
            cboDepartment.SelectedItem = null;

            cboCity.DisplayMember = "Name";
            cboCity.ValueMember = "Id";

            cboTerritory.DisplayMember = "Name";
            cboTerritory.ValueMember = "Id";
            cboTerritory.DataSource = _server.GetTerritories();
            cboTerritory.SelectedItem = null;
        }

        private void HaveChanges(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void GeoPositionHaveChanges(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void btnSearchGeoPos_Click(object sender, EventArgs e)
        {
            using (frmGeoPoint myForm = new frmGeoPoint())
            {
                Address a = this.Address;
                if (a.Lat.HasValue && a.Lng.HasValue)
                {
                    myForm.GeoPosition = new GMap.NET.PointLatLng(a.Lat.Value, a.Lng.Value);
                }

                myForm.Address = a.Street + " " + a.Number + ", " + a.City.Name + ", " + GetDepartmentName();

                myForm.ShowDialog();

                if (myForm.DialogResult == DialogResult.OK)
                {
                    chkHaveGeoPos.Checked = true;

                    txtLat.Text = myForm.GeoPosition.Lat.ToString();
                    txtLon.Text = myForm.GeoPosition.Lng.ToString();
                }

            }
        }

        private string GetDepartmentName()
        {
            string rv = "";
            if(cboDepartment.SelectedItem != null)
                rv = cboDepartment.SelectedItem.GetType().GetProperty("Name").GetValue(cboDepartment.SelectedItem, null).ToString();

            return rv;
        }

        
        
    }
}
