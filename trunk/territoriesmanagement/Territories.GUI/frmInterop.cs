using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using My;
using Territories.BLL;
using Territories.GUI;
using Territories.GUI.ImporterConfig;


namespace Territories.GUI
{
    public partial class frmInterop : Form
    {

        GeoRssImportTool _geoRssImporter;
        ImportTool _importer;
        bool _isDirty;

        ImporterConfig.ImporterConfig _config;

        public frmInterop()
        {
            _geoRssImporter = new GeoRssImportTool();
            _importer = new ImportTool();
            _config = new Territories.GUI.ImporterConfig.ImporterConfig();
            _isDirty = false;
            InitializeComponent();

        }

        private void btnSelectRssSource_Click(object sender, EventArgs e)
        {
            odfRssSource.ShowDialog();
        }

        private void odfRssSource_FileOk(object sender, CancelEventArgs e)
        {
            txtRssSource.Text = Path.GetFullPath(odfRssSource.FileName);
        }

        private void btnUpdateXls_Click(object sender, EventArgs e)
        {
            if (txtRssSource.Text == "")
            {
                MessageBox.Show("Select source and destiny files");
            }
            else
            {
                try
                {
                    _geoRssImporter.AddPointsToDirections(txtRssSource.Text);                    
                    MessageBox.Show("Xls file updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SetConfig();
            try
            {
                _importer.ExternalDataToModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void SetConfig()
        {
            if (_isDirty)
            {
                _config.Provider = (Enumerators.Provider)cboProvider.SelectedItem;
                _importer.Config.ConnectionString = _config.ConnectionString;
                if (_config.Departments.Load)
                {
                    _importer.Config.Departments.TableName = _config.Departments.TableName;

                    if (_config.Departments.Id.Load)
                        _importer.Config.Departments.Fields.Add("IdDepartment", _config.Departments.Id.ColumnName);

                    if (_config.Departments.Name.Load)
                        _importer.Config.Departments.Fields.Add("Name", _config.Departments.Name.ColumnName);
                }
                else
                    _importer.Config.Departments.Fields = new Dictionary<string, string>();

                if (_config.Cities.Load)
                {
                    _importer.Config.Cities.TableName = _config.Cities.TableName;

                    if (_config.Cities.Id.Load)
                        _importer.Config.Cities.Fields.Add("IdCity", _config.Cities.Name.ColumnName);

                    if (_config.Cities.Name.Load)
                        _importer.Config.Cities.Fields.Add("Name", _config.Cities.Name.ColumnName);

                    if (_config.Cities.Department.Load)
                        _importer.Config.Cities.Fields.Add("Department", _config.Cities.Department.ColumnName);
                }
                else
                {
                    _importer.Config.Cities.Fields = new Dictionary<string, string>();

                }

                if (_config.Territories.Load)
                {
                    _importer.Config.Territories.TableName = _config.Territories.TableName;

                    if (_config.Territories.Id.Load)
                        _importer.Config.Territories.Fields.Add("IdTerritory", _config.Territories.Id.ColumnName);

                    if (_config.Territories.Name.Load)
                        _importer.Config.Territories.Fields.Add("Name", _config.Territories.Name.ColumnName);
                }
                else
                    _importer.Config.Territories.Fields = new Dictionary<string, string>();

                if (_config.Directions.Load)
                {
                    _importer.Config.Directions.TableName = _config.Directions.TableName;

                    if (_config.Directions.Id.Load)
                        _importer.Config.Directions.Fields.Add("IdDirection", _config.Directions.Id.ColumnName);

                    if (_config.Directions.Street.Load)
                        _importer.Config.Directions.Fields.Add("Street", _config.Directions.Street.ColumnName);

                    if (_config.Directions.Number.Load)
                        _importer.Config.Directions.Fields.Add("Number", _config.Directions.Number.ColumnName);

                    if (_config.Directions.Corner1.Load)
                        _importer.Config.Directions.Fields.Add("Corner1", _config.Directions.Corner1.ColumnName);

                    if (_config.Directions.Corner2.Load)
                        _importer.Config.Directions.Fields.Add("Corner2", _config.Directions.Corner2.ColumnName);

                    if (_config.Directions.Phone1.Load)
                        _importer.Config.Directions.Fields.Add("Phone1", _config.Directions.Phone1.ColumnName);

                    if (_config.Directions.Phone2.Load)
                        _importer.Config.Directions.Fields.Add("Phone2", _config.Directions.Phone2.ColumnName);

                    if (_config.Directions.Description.Load)
                        _importer.Config.Directions.Fields.Add("Description", _config.Directions.Description.ColumnName);

                    if (_config.Directions.City.Load)
                        _importer.Config.Directions.Fields.Add("City", _config.Directions.City.ColumnName);

                    if (_config.Directions.Territory.Load)
                        _importer.Config.Directions.Fields.Add("Territory", _config.Directions.Territory.ColumnName);
                }
                else
                    _importer.Config.Directions.Fields = new Dictionary<string, string>();
            }
            
                
        }

        private void frmInterop_Load(object sender, EventArgs e)
        {
            cboProvider.DataSource = Enum.GetValues(typeof(Enumerators.Provider));

            _config = new ImporterConfig.ImporterConfig();
            grdImportConfig.SelectedObject = _config;
        }

        private void btnSetConnectStr_Click(object sender, EventArgs e)
        {
            _config.ConnectionString = txtConnectStr.Text;
        }

        private void btnSelectExcelFile_Click(object sender, EventArgs e)
        {
            ofdFileSource.ShowDialog();
        }

        private void ofdFileSource_FileOk(object sender, CancelEventArgs e)
        {
            if (_config.Provider == Enumerators.Provider.MSExcel)
            {
                string file = Path.GetFullPath(ofdFileSource.FileName);
                txtExcelFile.Text = file;
                string connectStr = _importer.MakeConnectStr(new string[] { file });
                txtConnectStr.Text = connectStr;
                _config.ConnectionString = connectStr;
            }
        }

        private void cboProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvider.SelectedItem!=null)
            {
                
            }
        }

        private void grdImportConfig_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _isDirty = true;
        }

    }
}

