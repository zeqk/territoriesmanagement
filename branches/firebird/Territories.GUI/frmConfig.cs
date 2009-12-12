using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Territories.BLL.DataBridge;
using System.Globalization;
using System.Threading;

namespace Territories.GUI
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
            _config = new Territories.GUI.Config.Config();
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
                BLL.DataBridge.Territories server = new BLL.DataBridge.Territories();
                server.DeleteAll();
            }
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {

            _config.LoadSavedConfig();

            //cultures
            string[] cultures = { "en-US", "es-AR" };

            cmbCulture.DataSource = cultures;

            cmbCulture.SelectedText = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;


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
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cmbCulture.SelectedValue.ToString());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cmbCulture.SelectedValue.ToString());
                _config.CultureTag = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            }
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
