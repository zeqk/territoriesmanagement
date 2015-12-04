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
    public partial class frmTerritoriesExportation : Form
    {

        enum FileTypes
        {
            Imagen,
            PDF,
            Excel,
            KML
        }

        public frmTerritoriesExportation()
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
                    string filter = "";
                    string extension = "";
                    switch (type)
                    {
                        case FileTypes.Imagen:
                            filter = "PNG Files (*.png)|*.png";
                            extension = ".png";
                            break;
                        case FileTypes.PDF:
                            filter = "PDF Files (*.pdf)|*.pdf";
                            extension = ".pdf";
                            break;
                        case FileTypes.Excel:
                            break;
                        case FileTypes.KML:
                            filter = "KML Files (*.kml)|*.kml";
                            extension = ".kml";
                            break;
                        default:
                            break;
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
                    if (this.exportTerritories(path, type, chkSingleFile.Checked))
                    {
                        if (chkSingleFile.Checked)
                            MessageBox.Show("El archivo " + path + " se generó exitosamente");
                        else
                            MessageBox.Show("Los archivos se generaron exitosamente en la carpeta " + path);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        bool exportTerritories(string path, FileTypes type, bool singleFile)
        {
            var rv = false;
            var items = this.chklstTerritories.CheckedItems.OfType<SimpleObject>().ToList();

            if (items.Count > 0)
            {
                var ids = items.Select(i => Convert.ToInt32(i.Value)).ToList();
                Expression<Func<Territory, bool>> whereExp = t => ids.Contains(t.IdTerritory);

                switch (type)
                {
                    case FileTypes.Imagen:
                        ReportsHelper.GenerateTerritoriesImages(whereExp, path, singleFile);
                        break;
                    case FileTypes.PDF:                        
                        ReportsHelper.GenerateMultipleTerritoriesReport(whereExp, path, singleFile);
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
                rv = true;
            }
            else
                MessageBox.Show("Debe seleccionar algún territorio");
            return rv;
            
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
                if (type == FileTypes.PDF || type == FileTypes.KML || type == FileTypes.Imagen)
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
