using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Territories.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddresses myForm = new frmAddresses();
                myForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCities_Click(object sender, EventArgs e)
        {
            try
            {
                frmCities myForm = new frmCities();
                myForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            try
            {
                frmDepartments myForm = new frmDepartments();
                myForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void bntTerritories_Click(object sender, EventArgs e)
        {
            try
            {
                frmTerritories myForm = new frmTerritories();
                myForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInterop_Click(object sender, EventArgs e)
        {
            try
            {
                frmInterop myForm = new frmInterop();
                myForm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfig myForm = new frmConfig();
                myForm.Show();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            //string dbPath = AppDomain.CurrentDomain.BaseDirectory + "Territories.mdf";
            //string connStr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + dbPath + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string entityConnStr = @"metadata=res://*/TerritoriesModel.csdl|res://*/TerritoriesModel.ssdl|res://*/TerritoriesModel.msl;provider=System.Data.SqlClient;provider connection string='" + connStr + "'";

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            //ConnectionStringSettings set = new ConnectionStringSettings("TerritoriesDataContext", entityConnStr);

            //config.ConnectionStrings.ConnectionStrings.Add(set);

            //config.Save(ConfigurationSaveMode.Modified, true);

            //string hola = config.ConnectionStrings.ConnectionStrings["TerritoriesDataContext"].ConnectionString;
            
        }


    }
}
