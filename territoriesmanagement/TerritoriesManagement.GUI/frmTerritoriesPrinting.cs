using Localizer;
using System;
using System.Linq;
using System.Windows.Forms;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Reporting;

namespace TerritoriesManagement.GUI
{
    public partial class frmTerritoriesPrinting : Form
    {
        public frmTerritoriesPrinting()
        {
            InitializeComponent();
            this.chklstTerritories.DisplayMember = "Text";

            Globalization.RefreshUI(this);
        }

        private string GetString(string text)
        {
            return Globalization.GetString(text);
        }

        private void frmTerritoriesPrinting_Load(object sender, EventArgs e)
        {
            try
            {
                this.chkSingleFile.Checked = true;
                this.chkImages.Checked = false;
                this.chkImages.Visible = false;
                this.LoadTerritories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadTerritories()
        {
            this.chklstTerritories.Items.Clear();
            var bridge = new Territories();
            var list = bridge.SearchSimpleObject(string.Empty, this.chkHasAddresses.Checked);
            this.chklstTerritories.Items.AddRange(list.ToArray());            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkSingleFile.Checked)
                {
                    var myForm = new SaveFileDialog();
                    myForm.Filter = "PDF Files (*.pdf)|*.pdf";
                    myForm.FileName = DateTime.Today.ToString("yyyy.MM.dd dddd") + ".pdf";
                    if (myForm.ShowDialog() == DialogResult.OK)
                    {
                        generateTerritoriesReports(myForm.FileName, true, false);
                        MessageBox.Show("El archivo " + myForm.FileName + " se generó exitosamente");
                    }
                }
                else
                {
                    var myForm = new FolderBrowserDialog();
                    if(myForm.ShowDialog() == DialogResult.OK)
                    {
                        generateTerritoriesReports(myForm.SelectedPath, false, this.chkImages.Checked);
                        MessageBox.Show("Los archivos se generaron exitosamente en la carpeta " + myForm.SelectedPath);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void generateTerritoriesReports(string path, bool singleFile, bool images)
        {
            var items = this.chklstTerritories.CheckedItems.OfType<SimpleObject>().ToList();

            var ids = items.Select(i => Convert.ToInt32(i.Value)).ToList();

            ReportsHelper.GenerateMultipleTerritoriesReport(ids, path, singleFile, images);
        }

        private void chkHasAddresses_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadTerritories();
        }

        private void chkSingleFile_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkSingleFile.Checked)
            {
                this.chkImages.Visible = false;
                this.chkImages.Checked = false;
            }
            else
            {
                this.chkImages.Visible = true;
            }
        }
    }
}
