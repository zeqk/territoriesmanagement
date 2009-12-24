using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TerritoriesManagement.Import;
using TerritoriesManagement.GUI;
using TerritoriesManagement.GUI.ImporterConfig;
using ZeqkTools.Data;
using ZeqkTools.WindowsForms;
using TerritoriesManagement.Export;
using TerritoriesManagement.DataBridge;

namespace TerritoriesManagement.GUI
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
            _config = new TerritoriesManagement.GUI.ImporterConfig.ImporterConfig();
            _isDirty = false;
            InitializeComponent();

        }

        private void frmInterop_Load(object sender, EventArgs e)
        {
            _importer = new ImportTool();

            _config = new ImporterConfig.ImporterConfig();
            _config.LoadConfig();

            txtConnectStr.Text = _config.ConnectionString;
            _importer.Config.ConnectionString = txtConnectStr.Text;
            _importer.Config.Provider = _config.Provider;
            grdImportConfig.SelectedObject = _config;

            LoadExportCheckList();
            
        }

        

        private void frmInterop_FormClosing(object sender, FormClosingEventArgs e)
        {
            _config.SaveConfig();
        }

        #region DataImport
        private void btnImport_Click(object sender, EventArgs e)
        {
            SetConfig();
            try
            {
                string importationMessage = "";
                bool ok = _importer.ExternalDataToModel(ref importationMessage);
                if (ok)
                    MessageBox.Show("The importation has been successful.\n" + importationMessage);
                else
                    MessageBox.Show("The importation have problems. Check the settings and see the log.\n" + importationMessage);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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

        private void SetConfig()
        {
            if (_isDirty)
            {
                //Departments
                if (_config.Departments.Import)
                {
                    _importer.Config.Departments.TableName = _config.Departments.TableName;

                    //Department.IdDepartment
                    if (_config.Departments.Id.Import)
                        _importer.Config.Departments.Fields.Add("IdDepartment", _config.Departments.Id.ColumnName);
                    //Department.Name
                    if (_config.Departments.Name.Import)
                        _importer.Config.Departments.Fields.Add("Name", _config.Departments.Name.ColumnName);

                }
                else
                    _importer.Config.Departments.Fields = new Dictionary<string, string>();

                //Cities
                if (_config.Cities.Import)
                {
                    _importer.Config.Cities.TableName = _config.Cities.TableName;

                    //City.IdCity
                    if (_config.Cities.Id.Import)
                        _importer.Config.Cities.Fields.Add("IdCity", _config.Cities.Name.ColumnName);

                    //City.Name
                    if (_config.Cities.Name.Import)
                        _importer.Config.Cities.Fields.Add("Name", _config.Cities.Name.ColumnName);

                    //City.Department
                    //Si la relación con Department se importa por ID, el Department ya existe en el sistema y tiene el mismo id
                    //Si la relación no se importa por ID, debe existir un partido con el mismo Name en el sistema
                    if (_config.Cities.DepartmentId.Import)
                    {
                        if (!string.IsNullOrEmpty(_config.Cities.DepartmentId.ColumnName))
                            _importer.Config.Cities.Fields.Add("DepartmentId", _config.Cities.DepartmentId.ColumnName);
                        if (!string.IsNullOrEmpty(_config.Cities.DepartmentId.DefaultValue))
                            _importer.Config.Cities.DefaultFieldValues.Add("DepartmentId", _config.Cities.DepartmentId.DefaultValue);

                    }
                    else
                    {
                        if (_config.Cities.DepartmentName.Import)
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

                //Territories
                if (_config.Territories.Import)
                {
                    _importer.Config.Territories.TableName = _config.Territories.TableName;

                    //Territory.IdTerritory
                    if (_config.Territories.Id.Import)
                        _importer.Config.Territories.Fields.Add("IdTerritory", _config.Territories.Id.ColumnName);

                    //Territory.Name
                    if (_config.Territories.Name.Import)
                        _importer.Config.Territories.Fields.Add("Name", _config.Territories.Name.ColumnName);

                    //Territory.Number
                    if (_config.Territories.Number.Import)
                        _importer.Config.Territories.Fields.Add("Number", _config.Territories.Number.ColumnName);
                    //TODO: comentar
                    if (!string.IsNullOrEmpty(_config.Territories.Number.DefaultValue))
                            _importer.Config.Territories.DefaultFieldValues.Add("Number", _config.Territories.Number.DefaultValue);
                }
                else
                    _importer.Config.Territories.Fields = new Dictionary<string, string>();

                //Addresses
                if (_config.Addresses.Import)
                {
                    _importer.Config.Addresses.TableName = _config.Addresses.TableName;
                    //Address.IdAddress
                    if (_config.Addresses.Id.Import)
                        _importer.Config.Addresses.Fields.Add("IdAddress", _config.Addresses.Id.ColumnName);
                    //Address.Street
                    if (_config.Addresses.Street.Import)
                        _importer.Config.Addresses.Fields.Add("Street", _config.Addresses.Street.ColumnName);
                    //Address.Number
                    if (_config.Addresses.Number.Import)
                        _importer.Config.Addresses.Fields.Add("Number", _config.Addresses.Number.ColumnName);
                    //Address.Corner1
                    if (_config.Addresses.Corner1.Import)
                        _importer.Config.Addresses.Fields.Add("Corner1", _config.Addresses.Corner1.ColumnName);
                    //Address.Corner2
                    if (_config.Addresses.Corner2.Import)
                        _importer.Config.Addresses.Fields.Add("Corner2", _config.Addresses.Corner2.ColumnName);
                    //Address.Description
                    if (_config.Addresses.Description.Import)
                        _importer.Config.Addresses.Fields.Add("Description", _config.Addresses.Description.ColumnName);
                    //Address.CustomField1
                    if (_config.Addresses.CustomField1.Import)
                        _importer.Config.Addresses.Fields.Add("CustomField1", _config.Addresses.CustomField1.ColumnName);
                    //Address.CustomField2
                    if (_config.Addresses.CustomField2.Import)
                        _importer.Config.Addresses.Fields.Add("CustomField2", _config.Addresses.CustomField2.ColumnName);
                    //Address.Phone1
                    if (_config.Addresses.Phone1.Import)
                        _importer.Config.Addresses.Fields.Add("Phone1", _config.Addresses.Phone1.ColumnName);
                    //Address.Phone2
                    if (_config.Addresses.Phone2.Import)
                        _importer.Config.Addresses.Fields.Add("Phone2", _config.Addresses.Phone2.ColumnName);
                    //Address.Map1
                    if (_config.Addresses.Map1.Import)
                        _importer.Config.Addresses.Fields.Add("Map1", _config.Addresses.Map1.ColumnName);
                    //Address.Map2
                    if (_config.Addresses.Map2.Import)
                        _importer.Config.Addresses.Fields.Add("Map2", _config.Addresses.Map2.ColumnName);
                    //Address.Geoposition
                    if (_config.Addresses.GeoPosition.Import)
                        _importer.Config.Addresses.Fields.Add("Geoposition", _config.Addresses.GeoPosition.ColumnName);


                    //Address.City
                    if (_config.Addresses.CityId.Import)
                    {
                        if (!string.IsNullOrEmpty(_config.Addresses.CityId.ColumnName))
                            _importer.Config.Addresses.Fields.Add("CityId", _config.Addresses.CityId.ColumnName);
                        if (!string.IsNullOrEmpty(_config.Addresses.CityId.DefaultValue))
                            _importer.Config.Addresses.DefaultFieldValues.Add("CityId", _config.Addresses.CityId.DefaultValue);

                    }
                    else
                    {
                        if (_config.Addresses.CityName.Import)
                        {
                            if (!string.IsNullOrEmpty(_config.Addresses.CityName.ColumnName))
                                _importer.Config.Addresses.Fields.Add("CityName", _config.Addresses.CityName.ColumnName);
                            if (!string.IsNullOrEmpty(_config.Addresses.CityName.DefaultValue))
                                _importer.Config.Addresses.DefaultFieldValues.Add("CityName", _config.Addresses.CityName.DefaultValue);
                        }
                    }
                    //


                    //Address.Territory
                    if (_config.Addresses.TerritoryId.Import)
                    {
                        if (!string.IsNullOrEmpty(_config.Addresses.TerritoryId.ColumnName))
                            _importer.Config.Addresses.Fields.Add("TerritoryId", _config.Addresses.TerritoryId.ColumnName);
                        if (!string.IsNullOrEmpty(_config.Addresses.TerritoryId.DefaultValue))
                            _importer.Config.Addresses.DefaultFieldValues.Add("TerritoryId", _config.Addresses.TerritoryId.DefaultValue);
                        
                    }
                    else
                    {
                        if (_config.Addresses.TerritoryName.Import)
                        {
                            if (!string.IsNullOrEmpty(_config.Addresses.TerritoryName.ColumnName))
                                _importer.Config.Addresses.Fields.Add("TerritoryName", _config.Addresses.TerritoryName.ColumnName);
                            if (!string.IsNullOrEmpty(_config.Addresses.TerritoryName.DefaultValue))
                                _importer.Config.Addresses.DefaultFieldValues.Add("TerritoryName", _config.Addresses.TerritoryName.DefaultValue);
                        }
                    }
                    //


                }
                else
                    _importer.Config.Addresses.Fields = new Dictionary<string, string>();

                _isDirty = false;
            }


        }

        #endregion

        #region GeoRSS Import

        private void btnSelectRssSource_Click(object sender, EventArgs e)
        {
            odfRssSource.ShowDialog();
        }

        private void odfRssSource_FileOk(object sender, CancelEventArgs e)
        {
            txtRssSource.Text = Path.GetFullPath(odfRssSource.FileName);
        }

        private void btnImportGeoRss_Click(object sender, EventArgs e)
        {
            if (txtRssSource.Text == "")
            {
                MessageBox.Show("Select source and destiny files. ");
            }
            else
            {
                try
                {
                    string importMessage = "";
                    _geoRssImporter.ImportGeoRss(txtRssSource.Text, ref importMessage, false, false, true, false);
                    MessageBox.Show("Geo data has been imported.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion            

        #region DataExport
        private void btnExport_Click(object sender, EventArgs e)
        {
            bool exported = true;
            if (rdoAddresses.Checked)
            {

                string[] properties = chkListAddresses.CheckedItems.Cast<string>().ToArray();

                exported = ExportTool.ExportToExcel(txtExcelDestiny.Text, "Address", "Addresses",properties, "", null);
            }


            if (rdoTerritories.Checked)
            {
                string[] properties = chkListTerritories.CheckedItems.Cast<string>().ToArray();

                exported = ExportTool.ExportToExcel(txtExcelDestiny.Text, "Territory", "Territories",properties, "",null);
            }

            if (rdoCities.Checked)
            {
                string[] properties = chkListCities.CheckedItems.Cast<string>().ToArray();

                exported = ExportTool.ExportToExcel(txtExcelDestiny.Text, "City", "Cities",properties, "", null);
            }

            if (rdoDepartments.Checked)
            {
                string[] properties = chkListDepartments.CheckedItems.Cast<string>().ToArray();

                exported = ExportTool.ExportToExcel(txtExcelDestiny.Text, "Department", "Departments", properties, "", null);
            }

            if (exported)
                MessageBox.Show("The exportation has been successful.\n");
            else
                MessageBox.Show("The exportation have problems. Check the settings and see the log.\n");
        }

        private void LoadExportCheckList()
        {
            //Export
            Addresses address = new Addresses();
            chkListAddresses.Items.AddRange(address.GetPropertyList().ToArray());

            Territories territories = new Territories();
            chkListTerritories.Items.AddRange(territories.GetPropertyList().ToArray());

            Cities cities = new Cities();
            chkListCities.Items.AddRange(cities.GetPropertyList().ToArray());

            Departments departments = new Departments();
            chkListDepartments.Items.AddRange(departments.GetPropertyList().ToArray());
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            chkListAddresses.Enabled = rdoAddresses.Checked;
            chkListCities.Enabled = rdoCities.Checked;
            chkListTerritories.Enabled = rdoTerritories.Checked;
            chkListDepartments.Enabled = rdoDepartments.Checked;
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            sfdExcelDestiny.ShowDialog();
        }

        private void sfdExcelDestiny_FileOk(object sender, CancelEventArgs e)
        {
            txtExcelDestiny.Text = Path.GetFullPath(sfdExcelDestiny.FileName);
        }

        #endregion

        private void btnSaveToGMaps_Click(object sender, EventArgs e)
        {
            sfdGMaps.ShowDialog();
        }

        private void btnExportToGmaps_Click(object sender, EventArgs e)
        {        
            ExportTool tool = new ExportTool();
            tool.ExportToGMap(txtXmlDestiny.Text, "");
        }

        private void sfdGMaps_FileOk(object sender, CancelEventArgs e)
        {
            txtXmlDestiny.Text = Path.GetFullPath(sfdGMaps.FileName);
        }

        private void btnConfigureConnection_Click(object sender, EventArgs e)
        {
            using (ConnectionStringMaker myForm = new ConnectionStringMaker())
            {
                myForm.ConnectionString = _config.ConnectionString;
                myForm.DataProvider = _config.Provider;

                myForm.ShowDialog();
                if (myForm.DialogResult == DialogResult.OK)
                {
                    txtConnectStr.Text = myForm.ConnectionString;
                    _config.ConnectionString = txtConnectStr.Text;
                    _config.Provider = myForm.DataProvider;
                }
            }
        }

        




    }
}

