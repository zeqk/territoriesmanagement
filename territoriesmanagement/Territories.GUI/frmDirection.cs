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
using Territories.BLL;

namespace Territories.GUI
{
    public partial class frmDirection : Form
    {
        private Directions _server;
        private bool _isDirty;

        private bool _geoPositionIsModified;

        
	

        public Direction Direction
        {
            get 
            {
                Direction rv = (Direction)bsDirection.DataSource;

                rv.City = new City();
                rv.City.IdCity = (int)cboCity.SelectedValue;

                rv.Territory = new Territory();
                rv.Territory.IdTerritory = (int)cboTerritory.SelectedValue;

                
                if (_geoPositionIsModified)
                {
                    rv.GeoPositions.Clear();
                    if (chkHaveGeo.Checked)
                    {
                        GeoPosition geoPos = (GeoPosition)bsGeoposition.DataSource;
                        geoPos.Date = DateTime.Now;
                        rv.GeoPositions.Add(geoPos);
                    }
                        
                    
                }
                return rv;
            }
            set 
            {   
                bsDirection.DataSource = value;

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

                if (value.GeoPositions.Count > 0)
                {
                    chkHaveGeo.Checked = true;                    
                    bsGeoposition.DataSource = value.GeoPositions.First();
                }
                else
                {
                    chkHaveGeo.Checked = false;
                    txtLat.Enabled = false;
                    txtLon.Enabled = false;
                    bsGeoposition.DataSource = _server.NewGeoPosition();
                }

            }
        }
	

        public frmDirection(Directions server)
        {
            _server = server;
            InitializeComponent();
            ConfigureMenus();
        }

        public frmDirection()
        {
            _server = new Directions();
            InitializeComponent(); 
            ConfigureMenus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            this.DialogResult = DialogResult.OK;
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

        private void frmDirection_Load(object sender, EventArgs e)
        {
            _isDirty = false;
            _geoPositionIsModified = false;
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
            _geoPositionIsModified = true;
            _isDirty = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtLat.Clear();
            txtLat.Enabled = false;
            txtLon.Clear();
            txtLon.Enabled = false;
        }

        private void chkHaveGeo_CheckedChanged(object sender, EventArgs e)
        {
            txtLat.Enabled = chkHaveGeo.Checked;
            txtLon.Enabled = chkHaveGeo.Checked;
            _geoPositionIsModified = true;
            _isDirty = true;
        }

        
        
    }
}
