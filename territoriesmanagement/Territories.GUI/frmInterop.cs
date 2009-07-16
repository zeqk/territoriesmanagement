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
        string _configFile;
        bool _isDirty;
        ImporterConfig.ImporterConfig _config;

        public frmInterop()
        {
            _geoRssImporter = new GeoRssImportTool();
            _importer = new ImportTool();
            _config = new Territories.GUI.ImporterConfig.ImporterConfig();
            _isDirty = false;
            InitializeComponent();

            _configFile = AppDomain.CurrentDomain.BaseDirectory + "importConfig.xml";

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
                MessageBox.Show("Select source and destiny files. ");
            }
            else
            {
                try
                {
                    string importMessage ="";
                    _geoRssImporter.ImportGeoRss(txtRssSource.Text, ref importMessage, false, false, true, false);                    
                    MessageBox.Show("Geo data has been imported.");
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
                string importationMessage = "";
                bool ok = _importer.ExternalDataToModel(ref importationMessage);
                if (ok)
                    MessageBox.Show("The importation has been successful.\n"+importationMessage);
                else
                    MessageBox.Show("The importation have problems. Check the settings and see the log.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }        

        private void frmInterop_Load(object sender, EventArgs e)
        {
            cboProvider.DataSource = Enum.GetValues(typeof(Enumerators.Provider));

            _config = new ImporterConfig.ImporterConfig();

            _config.LoadConfig(_configFile);
            
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

        private void grdImportConfig_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _isDirty = true;
        }

        private void txtConnectStr_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void frmInterop_FormClosing(object sender, FormClosingEventArgs e)
        {
            _config.SaveConfig(_configFile);
        }

        private void SetConfig()
        {
            if (_isDirty)
            {
                _config.Provider = (Enumerators.Provider)cboProvider.SelectedItem;
                _importer = new ImportTool();
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

                    //Department
                    //Si valor para el id del department se busca si existe valor para el nombre
                    if (_config.Cities.DepartmentId.Load)
                    {
                        if (!string.IsNullOrEmpty(_config.Cities.DepartmentId.ColumnName))
                            _importer.Config.Cities.Fields.Add("DepartmentId", _config.Cities.DepartmentId.ColumnName);
                        if (!string.IsNullOrEmpty(_config.Cities.DepartmentId.DefaultValue))
                            _importer.Config.Cities.DefaultFieldValues.Add("DepartmentId", _config.Cities.DepartmentId.DefaultValue);

                    }
                    else
                    {
                        if (_config.Cities.DepartmentName.Load)
                        {
                            if (!string.IsNullOrEmpty(_config.Cities.DepartmentName.ColumnName))
                                _importer.Config.Cities.Fields.Add("DepartmentName", _config.Cities.DepartmentName.ColumnName);
                            if (!string.IsNullOrEmpty(_config.Cities.DepartmentName.DefaultValue))
                                _importer.Config.Cities.DefaultFieldValues.Add("DepartmentName", _config.Cities.DepartmentName.DefaultValue);
                        }
                    }
                    //
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

                    //City
                    if (_config.Directions.CityId.Load)
                    {
                        if (!string.IsNullOrEmpty(_config.Directions.CityId.ColumnName))
                            _importer.Config.Directions.Fields.Add("CityId", _config.Directions.CityId.ColumnName);
                        if (!string.IsNullOrEmpty(_config.Directions.CityId.DefaultValue))
                            _importer.Config.Directions.DefaultFieldValues.Add("CityId", _config.Directions.CityId.DefaultValue);

                    }
                    else
                    {
                        if (_config.Directions.CityName.Load)
                        {
                            if (!string.IsNullOrEmpty(_config.Directions.CityName.ColumnName))
                                _importer.Config.Directions.Fields.Add("CityName", _config.Directions.CityName.ColumnName);
                            if (!string.IsNullOrEmpty(_config.Directions.CityName.DefaultValue))
                                _importer.Config.Directions.DefaultFieldValues.Add("CityName", _config.Directions.CityName.DefaultValue);
                        }
                    }
                   //


                    //Territory
                    if (_config.Directions.TerritoryId.Load)
                    {
                        if (!string.IsNullOrEmpty(_config.Directions.TerritoryId.ColumnName))
                            _importer.Config.Directions.Fields.Add("TerritoryId", _config.Directions.TerritoryId.ColumnName);
                        if (!string.IsNullOrEmpty(_config.Directions.TerritoryId.DefaultValue))
                            _importer.Config.Directions.DefaultFieldValues.Add("TerritoryId", _config.Directions.TerritoryId.DefaultValue);

                    }
                    else
                    {
                        if (_config.Directions.TerritoryName.Load)
                        {
                            if (!string.IsNullOrEmpty(_config.Directions.TerritoryName.ColumnName))
                                _importer.Config.Directions.Fields.Add("TerritoryName", _config.Directions.TerritoryName.ColumnName);
                            if (!string.IsNullOrEmpty(_config.Directions.TerritoryName.DefaultValue))
                                _importer.Config.Directions.DefaultFieldValues.Add("TerritoryName", _config.Directions.TerritoryName.DefaultValue);
                        }
                    }
                    //

                    
                }
                else
                    _importer.Config.Directions.Fields = new Dictionary<string, string>();

                _isDirty = false;
            }


        }

        private void SetTabValuesConfig(ImporterConfig.ImporterConfig config)
        {
            cboProvider.SelectedItem = _config.Provider;
            switch (config.Provider)
            {
                case Enumerators.Provider.MSExcel:
                    txtConnectStr.Text = _config.ConnectionString;
                    break;
                default: break;
            }
        }

    }
}

