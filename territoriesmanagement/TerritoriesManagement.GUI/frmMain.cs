using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AltosTools.WindowsForms;
using Localizer;
using TerritoriesManagement.GUI.Configuration;

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
            Config.LoadSavedConfig();
            Globalization.SetCurrentLanguage(Config.Language);
            Globalization.RefreshUI();
            TestConnection();
        }

        private void TestConnection()
        {
            try
            {
                DateTime lastModification = Helper.GetLastModDate();
                CultureInfo info = CultureInfo.GetCultureInfo(Globalization.CurrentAssociatedCulture);
                lblConnectionStatusValue.Text = GetString("OK. Last modification date: ") + lastModification.ToString(info.DateTimeFormat);
                lblConnectionStatusValue.ForeColor = Color.Green;
                
            }
            catch (Exception ex)
            {
                lblConnectionStatusValue.Text = GetString("Error. ") + ex.Message;
                lblConnectionStatusValue.ForeColor = Color.Red;
            }
            

        }

        private string GetString(string text)
        {
            return Globalization.GetString(text);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            
            AboutBox ab = new AboutBox();
            ab.Text = "About Territories Management " + Application.ProductVersion;
            ab.AppTitle = "Territories Management";
            ab.AppDescription = "A program for organizing special territories";
            ab.AppVersion = Application.ProductVersion;
            ab.AppCopyright = "GNU GPL 2014 Zeqk";
            ab.AppMoreInfo = Properties.Resources.credits;
            ab.AppMoreInfo += "\n\n";
            ab.AppMoreInfo += Properties.Resources.Short_License_EN;
            
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

        private void menuInteropWizard_Click(object sender, EventArgs e)
        {
            TerritoriesManagement.GUI.Interop.InteropWizard.RunInteropWizard();
        }


    }
}
