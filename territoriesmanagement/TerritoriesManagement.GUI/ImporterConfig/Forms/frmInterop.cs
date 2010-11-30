using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using AltosTools.WindowsForms;
using TerritoriesManagement.Export;
using TerritoriesManagement.Import;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    public partial class frmInterop : Form
    {
        string _dataExportEntityName = "";
        string[] _dataExportEntityProperties = { };

        ImportTool _importer;
        bool _isDirty;
        ImporterConfig _config;
        ResourceManager _rm;

        public frmInterop()
        {

            _rm = new ResourceManager(this.GetType());
            _importer = new ImportTool();
            _config = new ImporterConfig();
            _isDirty = false;
            InitializeComponent();

        }

        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

        private void frmInterop_Load(object sender, EventArgs e)
        {
            _importer = new ImportTool();
            _importer.bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportCompleted);
            _importer.bg.ProgressChanged += new ProgressChangedEventHandler(ImportProgressChanged);

            _config = new ImporterConfig();
            _config.LoadConfig();

            txtConnectStr.Text = _config.ConnectionString;
            //_importer.Config.ConnectionString = txtConnectStr.Text;
            //_importer.Config.Provider = _config.Provider;            
            
        }        

        private void frmInterop_FormClosing(object sender, FormClosingEventArgs e)
        {
            _config.SaveConfig();
        }

        #region DataImport

        private void ImportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_importer.SuccessfulImport)
                MessageBox.Show(GetString("The importation has been successful.") + Environment.NewLine + _importer.ImportMessage);
            else
                MessageBox.Show(GetString("The importation has problems. Check the settings and see the log.") + Environment.NewLine + _importer.ImportMessage);

            btnImportFromExternal.Enabled = true;
        }

        private void btnImportFromExternal_Click(object sender, EventArgs e)
        {
            SetConfig();
            try
            {
                _importer.ImportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
            }

            btnImportFromExternal.Enabled = false;
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
                _importer.Config.ConnectionString = txtConnectStr.Text;
                _importer.Config.Provider = _config.Provider; 

                //Departments
                if (_config.Departments.Import)
                {
                    _importer.Config.Departments.TableName = _config.Departments.TableName;

                    _importer.Config.Departments.Fields.Clear();

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

                    _importer.Config.Cities.Fields.Clear();

                    //City.IdCity
                    if (_config.Cities.Id.Import)
                        _importer.Config.Cities.Fields.Add("IdCity", _config.Cities.Id.ColumnName);

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

                    _importer.Config.Territories.Fields.Clear();

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

                    _importer.Config.Addresses.Fields.Clear();

                    //Address.IdAddress
                    if (_config.Addresses.Id.Import)
                        _importer.Config.Addresses.Fields.Add("IdAddress", _config.Addresses.Id.ColumnName);
                    //Address.Street
                    if (_config.Addresses.Street.Import)
                        _importer.Config.Addresses.Fields.Add("Street", _config.Addresses.Street.ColumnName);
                    //Address.Number
                    if (_config.Addresses.Number.Import)
                        _importer.Config.Addresses.Fields.Add("Number", _config.Addresses.Number.ColumnName);
                    //Address.AddressData
                    if (_config.Addresses.AddressData.Import)
                        _importer.Config.Addresses.Fields.Add("AddressData", _config.Addresses.AddressData.ColumnName);
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

        #region DataExport
        private void btnExportToExternal_Click(object sender, EventArgs e)
        {
            sfdDestinationFile.Filter = "Excel files (*.xls)|*.xls";
            if (sfdDestinationFile.ShowDialog() == DialogResult.OK)
            {
                string excelFile = Path.GetFullPath(sfdDestinationFile.FileName);
                bool exported = true;
                ExportTool tool = new ExportTool();
                try
                {
                        if (_dataExportEntityName != "")
                        {
                            switch (_dataExportEntityName)
                            {
                                case "Address":
                                    if (txtExcelTemplate.Text == "")
                                        exported = tool.ExportToExcel<Address>(excelFile, _dataExportEntityProperties, "", null);
                                    else
                                        exported = tool.ExportToExcel<Address>(txtExcelTemplate.Text, excelFile, _dataExportEntityProperties, "", null);
                                    break;
                                case "Territory":
                                    exported = tool.ExportToExcel<Territory>(excelFile, _dataExportEntityProperties, "", null);
                                    break;
                                case "City":
                                    exported = tool.ExportToExcel<City>(excelFile, _dataExportEntityProperties, "", null);
                                    break;
                                case "Department":
                                    exported = tool.ExportToExcel<Department>(excelFile, _dataExportEntityProperties, "", null);
                                    break;
                                default:
                                    break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    exported = false;
                }


                if (exported)
                    MessageBox.Show(GetString("The exportation has been successful.\n"));
                else
                    MessageBox.Show(GetString("The exportation has problems. Check the settings and see the log.\n"));
            }
        }
        #endregion

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

        private void ImportProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbDataImport.Value = e.ProgressPercentage;
        }

        #region ImportData

        private void btnImportData_Click(object sender, EventArgs e)
        {
            ofdSourceFile.Filter = "Territories management exchange file(*.tmx)|*.tmx";
            if (ofdSourceFile.ShowDialog() == DialogResult.OK)
            {
                string importFile = Path.GetFullPath(ofdSourceFile.FileName);
                List<string> list = new List<string>();
                if (chkDepartments.Checked)
                    list.Add("Department");
                if (chkCities.Checked)
                    list.Add("City");
                if (chkPublishers.Checked)
                    list.Add("Publisher");
                if (chkTerritories.Checked)
                    list.Add("Territory");
                if (chkTours.Checked)
                    list.Add("Tuor");
                if (chkAddresses.Checked)
                    list.Add("Address");

                if (list.Count > 0)
                    _importer.ImportExchangeData(importFile, list);
            }
        }

        #endregion
        #region Data exportation
        private void btnExportData_Click(object sender, EventArgs e)
        {
            sfdDestinationFile.Filter = "Territories management exchange file(*.tmx)|*.tmx";
            if (sfdDestinationFile.ShowDialog() == DialogResult.OK)
            {
                string exportFile = Path.GetFullPath(sfdDestinationFile.FileName);
                List<string> list = new List<string>();
                if (chkDepartments.Checked)
                    list.Add("Department");
                if (chkCities.Checked)
                    list.Add("City");
                if (chkPublishers.Checked)
                    list.Add("Publisher");
                if (chkTerritories.Checked)
                    list.Add("Territory");
                if (chkTours.Checked)
                    list.Add("Tour");
                if (chkAddresses.Checked)
                    list.Add("Address");

                if (list.Count > 0)
                {
                    string path = exportFile;
                    ExportTool tool = new ExportTool();
                    tool.ExportData(path, list);
                }
            }
        }
        #endregion

        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            ofdSourceFile.Filter = "XML Spreadsheet 2003(*.xml)|*.xml";
            if (ofdSourceFile.ShowDialog() == DialogResult.OK)
            {
                txtExcelTemplate.Text = Path.GetFullPath(ofdSourceFile.FileName);
            }
        }

        private void prbDataImport_Click(object sender, EventArgs e)
        {

        }

        private void btnConfigTables_Click(object sender, EventArgs e)
        {
            using (frmTablesConfig myForm = new frmTablesConfig())
            {
                myForm.Config = _config;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    _config = myForm.Config;
                    _isDirty = true;
                }
            }
        }

        private void btnConfigEntities_Click(object sender, EventArgs e)
        {
            using (frmEntitiesConfig myForm = new frmEntitiesConfig())
            {
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    _dataExportEntityName = myForm.EntityName;
                    _dataExportEntityProperties = myForm.Properties;
                }
            }
        }
        








    }
}

