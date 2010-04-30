using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ZeqkTools.WindowsForms;

namespace TerritoriesManagement.GUI
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadConfig();
            TestConnection();
        }

        private void TestConnection()
        {
            try
            {
                if (Functions.TestConnection())
                {
                    lblConnectionStatusValue.Text = "OK";
                    lblConnectionStatusValue.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblConnectionStatusValue.Text = "Error. " + ex.Message;
                lblConnectionStatusValue.ForeColor = Color.Red;
            }
            

        }


        private void LoadConfig()
        {
            Config.Config config = new TerritoriesManagement.GUI.Config.Config();
            config.LoadSavedConfig();
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(config.CultureTag);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(config.CultureTag);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Text = "About Territories Management " + Application.ProductVersion;
            ab.AppTitle = "Territories Management";
            ab.AppDescription = "A program for organizing special territories";
            ab.AppVersion = Application.ProductVersion;
            ab.AppCopyright = "GNU GPL 2010  Zeqk";
            ab.AppMoreInfo = "Web site: http://sites.google.com/site/territoriesmanagement \n\n";
            ab.AppMoreInfo += "This program uses GMap.NET (http://greatmaps.codeplex.com/) and ";            
            ab.AppMoreInfo += "DotNetFirebird (http://www.firebirdsql.org/dotnetfirebird/).\n\n";
            ab.AppMoreInfo += "This program is free software: you can redistribute it and/or modify ";
            ab.AppMoreInfo += "it under the terms of the GNU General Public License as published by ";
            ab.AppMoreInfo += "the Free Software Foundation, either version 3 of the License, or ";
            ab.AppMoreInfo += "(at your option) any later version.\n\n";

            ab.AppMoreInfo += "This program is distributed in the hope that it will be useful, ";
            ab.AppMoreInfo += "but WITHOUT ANY WARRANTY; without even the implied warranty of ";
            ab.AppMoreInfo += "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the ";
            ab.AppMoreInfo += "GNU General Public License for more details.\n\n";

            ab.AppMoreInfo += "You should have received a copy of the GNU General Public License ";
            ab.AppMoreInfo += "along with this program.  If not, see <http://www.gnu.org/licenses/>.";
            
            ab.AppDetailsButton = false;
            ab.ShowDialog(this);
        }

        private void menuConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfig myForm = new frmConfig();
                myForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void menuInteroperabilty_Click(object sender, EventArgs e)
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


    }
}
