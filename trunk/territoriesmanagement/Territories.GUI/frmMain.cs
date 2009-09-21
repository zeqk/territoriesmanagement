using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                frmConfgurations myForm = new frmConfgurations();
                myForm.Show();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
