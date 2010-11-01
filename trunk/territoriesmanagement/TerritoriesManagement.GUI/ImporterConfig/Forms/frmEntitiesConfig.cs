using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    public partial class frmEntitiesConfig : Form
    {

        private string _entityName;

        public string[] Properties
        {
            get 
            {
                string[] properties = { };

                if(rdoAddresses.Checked)
                    properties = chkListAddresses.CheckedItems.Cast<Property>().Select(p => p.Name).ToArray();
                if (rdoTerritories.Checked)
                    properties = chkListTerritories.CheckedItems.Cast<Property>().Select(p => p.Name).ToArray();
                if (rdoCities.Checked)
                    properties = chkListCities.CheckedItems.Cast<Property>().Select(p => p.Name).ToArray();
                if (rdoDepartments.Checked)
                    properties = chkListDepartments.CheckedItems.Cast<Property>().Select(p => p.Name).ToArray();

                return properties;
            }
        }

        public string EntityName
        {
            get
            {
                string entityName = "";

                if (rdoAddresses.Checked)
                    entityName = "Address";
                if (rdoTerritories.Checked)
                    entityName = "Territory";
                if (rdoCities.Checked)
                    entityName = "City";
                if (rdoDepartments.Checked)
                    entityName = "Department";

                return entityName;
            }
        }

        public frmEntitiesConfig()
        {
            InitializeComponent();
        }



        private void LoadExportCheckList()
        {
            //Export
            chkListAddresses.DisplayMember = "Name";
            chkListAddresses.Items.AddRange(Helper.GetPropertyListByType("Address").ToArray());

            chkListTerritories.DisplayMember = "Name";
            chkListTerritories.Items.AddRange(Helper.GetPropertyListByType("Territory").ToArray());

            chkListCities.DisplayMember = "Name";
            chkListCities.Items.AddRange(Helper.GetPropertyListByType("City").ToArray());

            chkListDepartments.DisplayMember = "Name";
            chkListDepartments.Items.AddRange(Helper.GetPropertyListByType("Department").ToArray());
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            chkListAddresses.Enabled = rdoAddresses.Checked;
            chkListCities.Enabled = rdoCities.Checked;
            chkListTerritories.Enabled = rdoTerritories.Checked;
            chkListDepartments.Enabled = rdoDepartments.Checked;
        }

        private void frmEntitiesConfig_Load(object sender, EventArgs e)
        {
            LoadExportCheckList();
        }
    }
}
