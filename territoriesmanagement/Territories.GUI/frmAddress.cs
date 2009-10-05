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

namespace Territories.GUI
{
    public partial class frmAddress : Form
    {
        private Addresses _server;
        private bool _isDirty;

        public Address Address
        {
            get 
            {
                Address rv = (Address)bsAddress.DataSource;

                rv.City = new City();
                if (cboCity.SelectedItem != null)
                    rv.City.IdCity = (int)cboCity.SelectedValue;
                else
                    rv.City.IdCity = 0;

                rv.Territory = new Territory();
                if (cboTerritory.SelectedItem != null)
                    rv.Territory.IdTerritory = (int)cboTerritory.SelectedValue;
                else
                    rv.Territory.IdTerritory = 0;

                if (chkHaveGeoPos.Checked)
                    rv.Geoposition = txtLat.Text + " " + txtLon.Text;
                else 
                    rv.Geoposition = null;

                return rv;
            }
            set 
            {   
                bsAddress.DataSource = value;

                if (value.Territory != null)
                    cboTerritory.SelectedValue = value.Territory.IdTerritory;
                else
                    cboTerritory.SelectedItem = null;

                if (value.City != null)
                {
                    cboDepartment.SelectedValue = value.City.Department.IdDepartment;
                    cboCity.SelectedValue = value.City.IdCity;
                }
                else
                    cboDepartment.SelectedItem = null;

                if (!string.IsNullOrEmpty(value.Geoposition))
                {
                    string[] geoPosition = value.Geoposition.Split(' ');

                    txtLat.Text = geoPosition[0];
                    txtLon.Text = geoPosition[1];
                    chkHaveGeoPos.Checked = true;
                }
                else
                {
                    txtLat.Enabled = chkHaveGeoPos.Checked;
                    txtLon.Enabled = chkHaveGeoPos.Checked;
                    chkHaveGeoPos.Checked = false;
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
            if (_isDirty == true)
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
                cboCity.SelectedItem = null;
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

        private void btnSearchGeoPos_Click(object sender, EventArgs e)
        {
            using (frmGeoPoint myForm = new frmGeoPoint())
            {
                Address a = (Address) bsAddress.DataSource;
                if (!string.IsNullOrEmpty(a.Geoposition))
                {
                    myForm.GeoPosition = a.Geoposition;
                }

                myForm.Address = a.Street + a.Number + ", " + a.City.Name + ", " + GetDepartmentName();

                myForm.ShowDialog();

            }
        }

        private string GetDepartmentName()
        {
            string rv = cboDepartment.SelectedItem.GetType().GetProperty("Name").GetValue(cboDepartment.SelectedItem, null).ToString();

            return rv;
        }

        
        
    }
}
