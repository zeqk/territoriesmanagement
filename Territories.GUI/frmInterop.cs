﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Territories.BLL.Import;
using Territories.GUI;
using Territories.GUI.ImporterConfig;
using ZeqkTools.Query.Enumerators;

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

        private void frmInterop_Load(object sender, EventArgs e)
        {
            cboProvider.DataSource = Enum.GetValues(typeof(DataProviders));

            _config = new ImporterConfig.ImporterConfig();

            _config.LoadConfig(_configFile);

            grdImportConfig.SelectedObject = _config;


            

            LoadExportCheckList();
            
        }

        

        private void frmInterop_FormClosing(object sender, FormClosingEventArgs e)
        {
            _config.SaveConfig(_configFile);
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
            if (_config.Provider == DataProviders.MSExcel)
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

        private void SetConfig()
        {
            if (_isDirty)
            {
                _config.Provider = (DataProviders)cboProvider.SelectedItem;
                _importer = new ImportTool();
                _importer.Config.ConnectionString = _config.ConnectionString;
                if (_config.Departments.Import)
                {
                    _importer.Config.Departments.TableName = _config.Departments.TableName;

                    if (_config.Departments.Id.Import)
                        _importer.Config.Departments.Fields.Add("IdDepartment", _config.Departments.Id.ColumnName);

                    if (_config.Departments.Name.Import)
                        _importer.Config.Departments.Fields.Add("Name", _config.Departments.Name.ColumnName);

                }
                else
                    _importer.Config.Departments.Fields = new Dictionary<string, string>();

                if (_config.Cities.Import)
                {
                    _importer.Config.Cities.TableName = _config.Cities.TableName;

                    if (_config.Cities.Id.Import)
                        _importer.Config.Cities.Fields.Add("IdCity", _config.Cities.Name.ColumnName);

                    if (_config.Cities.Name.Import)
                        _importer.Config.Cities.Fields.Add("Name", _config.Cities.Name.ColumnName);

                    //Department
                    //Si valor para el id del department se busca si existe valor para el nombre
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

                if (_config.Territories.Import)
                {
                    _importer.Config.Territories.TableName = _config.Territories.TableName;

                    if (_config.Territories.Id.Import)
                        _importer.Config.Territories.Fields.Add("IdTerritory", _config.Territories.Id.ColumnName);

                    if (_config.Territories.Name.Import)
                        _importer.Config.Territories.Fields.Add("Name", _config.Territories.Name.ColumnName);
                }
                else
                    _importer.Config.Territories.Fields = new Dictionary<string, string>();

                if (_config.Addresses.Import)
                {
                    _importer.Config.Addresses.TableName = _config.Addresses.TableName;

                    if (_config.Addresses.Id.Import)
                        _importer.Config.Addresses.Fields.Add("IdAddress", _config.Addresses.Id.ColumnName);

                    if (_config.Addresses.Street.Import)
                        _importer.Config.Addresses.Fields.Add("Street", _config.Addresses.Street.ColumnName);

                    if (_config.Addresses.Number.Import)
                        _importer.Config.Addresses.Fields.Add("Number", _config.Addresses.Number.ColumnName);

                    if (_config.Addresses.Corner1.Import)
                        _importer.Config.Addresses.Fields.Add("Corner1", _config.Addresses.Corner1.ColumnName);

                    if (_config.Addresses.Corner2.Import)
                        _importer.Config.Addresses.Fields.Add("Corner2", _config.Addresses.Corner2.ColumnName);

                    if (_config.Addresses.Description.Import)
                        _importer.Config.Addresses.Fields.Add("Description", _config.Addresses.Description.ColumnName);

                    if (_config.Addresses.CustomField1.Import)
                        _importer.Config.Addresses.Fields.Add("CustomField1", _config.Addresses.CustomField1.ColumnName);

                    if (_config.Addresses.CustomField2.Import)
                        _importer.Config.Addresses.Fields.Add("CustomField2", _config.Addresses.CustomField2.ColumnName);

                    if (_config.Addresses.Phone1.Import)
                        _importer.Config.Addresses.Fields.Add("Phone1", _config.Addresses.Phone1.ColumnName);

                    if (_config.Addresses.Phone2.Import)
                        _importer.Config.Addresses.Fields.Add("Phone2", _config.Addresses.Phone2.ColumnName);

                    if (_config.Addresses.Map1.Import)
                        _importer.Config.Addresses.Fields.Add("Map1", _config.Addresses.Map1.ColumnName);

                    if (_config.Addresses.Map2.Import)
                        _importer.Config.Addresses.Fields.Add("Map2", _config.Addresses.Map2.ColumnName);

                    if (_config.Addresses.GeoPosition.Import)
                        _importer.Config.Addresses.Fields.Add("Geoposition", _config.Addresses.GeoPosition.ColumnName);


                    //City
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


                    //Territory
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

        private void SetTabValuesConfig(ImporterConfig.ImporterConfig config)
        {
            cboProvider.SelectedItem = _config.Provider;
            switch (config.Provider)
            {
                case DataProviders.MSExcel:
                    txtConnectStr.Text = _config.ConnectionString;
                    break;
                default: break;
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

            BLL.Export.ExportTool tool = new Territories.BLL.Export.ExportTool();
            if (rdoAddresses.Checked)
            {

                string[] properties = chkListAddresses.CheckedItems.Cast<string>().ToArray();

                exported = tool.ExportToExcel(txtExcelDestiny.Text, "Address", "Addresses", properties);
            }


            if (rdoTerritories.Checked)
            {
                string[] properties = chkListTerritories.CheckedItems.Cast<string>().ToArray();

                exported = tool.ExportToExcel(txtExcelDestiny.Text, "Territory", "Territories", properties);
            }

            if (rdoCities.Checked)
            {
                string[] properties = chkListCities.CheckedItems.Cast<string>().ToArray();

                exported = tool.ExportToExcel(txtExcelDestiny.Text, "City", "Cities", properties);
            }

            if (rdoDepartments.Checked)
            {
                string[] properties = chkListDepartments.CheckedItems.Cast<string>().ToArray();

                exported = tool.ExportToExcel(txtExcelDestiny.Text, "Department", "Departments", properties);
            }

            if (exported)
                MessageBox.Show("The exportation has been successful.\n");
            else
                MessageBox.Show("The exportation have problems. Check the settings and see the log.\n");
        }

        private void LoadExportCheckList()
        {
            //Export
            BLL.DataBridge.Addresses address = new Territories.BLL.DataBridge.Addresses();
            chkListAddresses.Items.AddRange(address.GetPropertyList().ToArray());

            BLL.DataBridge.Territories territories = new Territories.BLL.DataBridge.Territories();
            chkListTerritories.Items.AddRange(territories.GetPropertyList().ToArray());

            BLL.DataBridge.Cities cities = new Territories.BLL.DataBridge.Cities();
            chkListCities.Items.AddRange(cities.GetPropertyList().ToArray());

            BLL.DataBridge.Departments departments = new Territories.BLL.DataBridge.Departments();
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

        




    }
}
