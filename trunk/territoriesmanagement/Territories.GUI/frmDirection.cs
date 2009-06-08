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

        public Direction Direction
        {
            get 
            {
                Direction rv = (Direction)bsDepartment.DataSource;

                rv.City = new City();
                rv.City.IdCity = (int)cboCities.SelectedValue;

                rv.Territory = new Territory();
                rv.Territory.IdTerritory = (int)cboTerritory.SelectedValue;

                GeoPosition geoPos = new GeoPosition();
                geoPos.Date = DateTime.Now;

                long lat = 0;
                long lon = 0;
                try
                {
                    lat = long.Parse(txtLat.Text);
                    lon = long.Parse(txtLon.Text);
                }
                finally
                {
                    geoPos.Latitude = lat;
                    geoPos.Longitude = lon;
                }

                rv.GeoPosition = geoPos;

                return rv; 
            }
            set 
            {   
                bsDepartment.DataSource = value;

                if (value.Territory != null)
                    cboTerritory.SelectedValue = value.Territory.IdTerritory;
                else
                    cboTerritory.SelectedValue = null;

                if (value.City != null)
                {
                    if (value.City.Department!=null)
                    {
                        cboDepartment.SelectedValue = value.City.Department.IdDepartment;
                        cboCities.SelectedValue = value.City.IdCity;
                    }
                    else
                        cboDepartment.SelectedValue = null;
                }
                else
                    cboDepartment.SelectedValue = null;

                if (value.GeoPosition!=null)
                {
                    txtLat.Text = value.GeoPosition.Latitude.ToString();
                    txtLon.Text = value.GeoPosition.Longitude.ToString();
                }

            }
        }
	

        public frmDirection(Directions server)
        {
            _server = server;
            InitializeComponent();
            _isDirty = false;
        }

        public frmDirection()
        {
            _server = new Directions();
            InitializeComponent();
            _isDirty = false;
        }

        private void bsDepartment_CurrentChanged(object sender, EventArgs e)
        {

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
                int idDepartment = (int)((ComboBox)sender).SelectedValue;
                cboCities.DataSource = _server.GetCitiesByDepartment(idDepartment);
            }
            else
                cboCities.DataSource = null;
            
        }

        private void HaveChanges(object sender, EventArgs e)
        {
            _isDirty = true;
        }
        
    }
}
