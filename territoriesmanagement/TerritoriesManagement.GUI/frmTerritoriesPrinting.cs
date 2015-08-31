using Localizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.KML;
using TerritoriesManagement.Model;
using TerritoriesManagement.Reporting;

namespace TerritoriesManagement.GUI
{
    public partial class frmTerritoriesPrinting : Form
    {

        enum FileTypes
        {
            Imagen,
            PDF,
            Excel,
            KML
        }

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
                this.LoadTerritories();
                var options = Enum.GetNames(typeof(FileTypes));

                cboReportType.DataSource = options;
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

            var checkedButton = groupFilter.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            Expression<Func<Territory, bool>> where;
            if (checkedButton == rdoFilterWithAddresses)
                where = t => t.Addresses.Count > 0;
            else if (checkedButton == rdoFilterWithoutAddresses)
                where = t => t.Addresses.Count < 1;
            else
                where = t => true;


            var list = bridge.SearchSimpleObject(where);
            this.chklstTerritories.Items.AddRange(list.ToArray());            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                var type = (FileTypes)Enum.Parse(typeof(FileTypes), cboReportType.SelectedValue.ToString());

                var goOn = false;
                var path = string.Empty;
                if (chkSingleFile.Checked)
                {
                    var filter = "PDF Files (*.pdf)|*.pdf";
                    var extension = ".pdf";
                    if(type == FileTypes.KML)
                    {
                        filter = "KML Files (*.kml)|*.kml";
                        extension = ".kml";
                    }

                    var myForm = new SaveFileDialog();
                    myForm.Filter = filter;
                    myForm.FileName = DateTime.Today.ToString("yyyy.MM.dd dddd") + extension;
                    goOn = myForm.ShowDialog() == DialogResult.OK;
                    path = myForm.FileName;
                }
                else
                {
                    var myForm = new FolderBrowserDialog();
                    goOn = myForm.ShowDialog() == DialogResult.OK;
                    path = myForm.SelectedPath;

                }

                if (goOn)
                {
                    this.exportTerritories(path, type, chkSingleFile.Checked);
                    if (chkSingleFile.Checked)
                        MessageBox.Show("El archivo " + path + " se generó exitosamente");
                    else
                        MessageBox.Show("Los archivos se generaron exitosamente en la carpeta " + path);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        void exportTerritories(string path, FileTypes type, bool singleFile)
        {
            var items = this.chklstTerritories.CheckedItems.OfType<SimpleObject>().ToList();

            var ids = items.Select(i => Convert.ToInt32(i.Value)).ToList();
            Expression<Func<Territory, bool>> whereExp = t => ids.Contains(t.IdTerritory);
                        
            switch (type)
            {
                case FileTypes.Imagen:
                case FileTypes.PDF:
                    var imagen = type == FileTypes.Imagen;
                    ReportsHelper.GenerateMultipleTerritoriesReport(whereExp, path, singleFile, imagen);
                    break;
                case FileTypes.Excel:
                    ReportsHelper.GenerateTerritoriesListReport(whereExp, path);
                    break;
                case FileTypes.KML:
                    KMLHelper.ExportTerritoriesToKml(whereExp, path, singleFile);
                    break;
                default:
                    break;
            }

            
        }

        private void chkHasAddresses_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadTerritories();
        }


        private void toolStripMenuItemSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                var items = chklstTerritories.Items.OfType<object>().ToList();
                foreach (var item in items)
                {
                    var index = chklstTerritories.Items.IndexOf(item);
                    chklstTerritories.SetItemChecked(index, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItemDeselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                var items = chklstTerritories.Items.OfType<object>().ToList();
                foreach (var item in items)
                {
                    var index = chklstTerritories.Items.IndexOf(item);
                    chklstTerritories.SetItemChecked(index, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var type = (FileTypes)Enum.Parse(typeof(FileTypes),cboReportType.SelectedValue.ToString());

                chkSingleFile.Checked = false;
                if (type == FileTypes.PDF || type == FileTypes.KML)
                {
                    chkSingleFile.Visible = true;
                }
                else
                {
                    chkSingleFile.Visible = false;

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void rdoFilterWithAddresses_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                LoadTerritories();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
