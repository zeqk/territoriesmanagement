using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.EntityClient;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.Resources;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using ZeqkTools.Data;
using ZeqkTools.Query.Enumerators;
using TerritoriesManagement.Model;


namespace TerritoriesManagement.Import
{    
    public class ImportTool
    {

        TerritoriesDataContext _dm;
        Extractor _importer;
        private ImporterConfig _config;

        public BackgroundWorker bg;
        double _progressPercentage;        
	

        double _conversionProgressUnit;
        double _saveChangesProgressUnit;
        public string ImportMessage;
        public bool SuccessfulImport;

        private string _log;

        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdDepartmentByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdCityByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdTerritoryByName;

        private Func<TerritoriesDataContext, TerritoriesManagement.Model.Department, IQueryable<TerritoriesManagement.Model.Department>> _compiledSameDepartment;
        private Func<TerritoriesDataContext, City, int,IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compiledSameTerritory;

        ResourceManager _rm;

        public ImportTool()
	    {
            _log = "";
            _dm = new TerritoriesDataContext();
            _importer = new Extractor(DataProviders.OleDb);           

            _config = new ImporterConfig();

            bg = new BackgroundWorker();
            bg.WorkerSupportsCancellation = true;
            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
	    }


        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

        private string GetString(string text,params object[] parameters)
        {
            
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return string.Format(text,parameters);
        }


        public ImporterConfig Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public string Log
        {
            get { return _log; }
            set { _log = value; }
        }


        public void ImportData()
        {
            bg.RunWorkerAsync();
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            SuccessfulImport = true;
            SetConfig();

            PreCompileQueries();
            try
            {
                DataSet ds = _importer.GetData();
                CalculateProcess(ds);
                ReportDataGetting();

                if (ds.Tables.Count > 0)
                {
                    bool departmentsImported = true;
                    string departments = _config.Departments.TableName;
                    if (ds.Tables[departments] != null)
                    {
                        int count = AddDepartments(ds.Tables[departments]);

                        departmentsImported = count > 0;
                        if (departmentsImported)
                        {
                            ImportMessage += Environment.NewLine + GetString("{0} departments have been imported.", count) + Environment.NewLine;
                            if (ds.Tables[departments].Rows.Count>count)
                            {
                                ImportMessage += GetString("Some departments have not been imported successfully.") +Environment.NewLine;
                            }
                        }
                        else
                            ImportMessage += Environment.NewLine + GetString("No department has been imported.") + Environment.NewLine;
                    }

                    bool citiesImported = true;
                    string cities = _config.Cities.TableName;
                    if (ds.Tables[cities] != null)
                    {
                        int count = AddCities(ds.Tables[cities]);
                        citiesImported = count > 0;
                        if (citiesImported)
                        {
                            ImportMessage += Environment.NewLine + GetString("{0} cities has been imported.", count) + Environment.NewLine;
                            if (ds.Tables[cities].Rows.Count > count)
                            {
                                ImportMessage += Environment.NewLine + GetString("Some cities have not been imported successfully.") + Environment.NewLine;
                            }
                        }
                        else
                            ImportMessage += Environment.NewLine + GetString("No city has been imported.") + Environment.NewLine;
                    }

                    bool territoriesImported = true;
                    string territories = _config.Territories.TableName;
                    if (ds.Tables[territories] != null)
                    {
                        int count = AddTerritories(ds.Tables[territories]);
                        territoriesImported = count > 0;
                        if (territoriesImported)
                        {
                            ImportMessage += Environment.NewLine + GetString("{0} territories has been imported.", count) + Environment.NewLine;
                            if (ds.Tables[territories].Rows.Count > count)
                            {
                                ImportMessage += Environment.NewLine + GetString("Some territories have not been imported successfully.") + Environment.NewLine;
                            }
                        }
                        else
                            ImportMessage += Environment.NewLine + GetString("No territory has been imported.") + Environment.NewLine;
                    }

                    bool addressesImported = true;
                    string addresses = _config.Addresses.TableName;
                    if (ds.Tables[addresses] != null)
                    {
                        int count = AddAddresses(ds.Tables[addresses]);
                        addressesImported =  count > 0;
                        if (addressesImported)
                        {
                            ImportMessage += Environment.NewLine + GetString("{0} addresses has been imported.", count) + Environment.NewLine;
                            if (ds.Tables[addresses].Rows.Count > count)
                            {
                                ImportMessage += GetString("Some addresses have not been imported successfully.") + Environment.NewLine;
                            }
                        }
                        else
                            ImportMessage += Environment.NewLine + GetString("No address has been imported.") + Environment.NewLine;
                    }

                    SuccessfulImport = departmentsImported && citiesImported && territoriesImported && addressesImported;
                }
                else
                    SuccessfulImport = false;

                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            SaveLog();
        }

        private void CalculateProcess(DataSet ds)
        {
            int tablesCount = ds.Tables.Count;
            int rowsCount = 0;
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    rowsCount++;
                }
            }

            _conversionProgressUnit = 73.5 / rowsCount;

            _saveChangesProgressUnit = 24.5 / tablesCount;           
            
        }

        private void ReportAConversion()
        {
            _progressPercentage += _conversionProgressUnit;
            bg.ReportProgress((int)_progressPercentage);
        }

        private void ReportASaveChanges()
        {
            _progressPercentage += _saveChangesProgressUnit;
            bg.ReportProgress((int)_progressPercentage);
        }

        private void ReportDataGetting()
        {
            bg.ReportProgress(2);
        }

        #region AddEntity Methods

        private int AddDepartments(DataTable dt)
        {
            int rv = 0;
            string message = "";
            try
            {
                if (dt.Rows.Count>0)
                {
                    int count = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        Model.Department v;
                        if (DataRowToDepartment(row, out v, ref message))
                        {
                            if (DepartmentIsValid(v, ref message))
                            {
                                if (!_config.Departments.Fields.ContainsKey("IdDepartment"))
                                {
                                    _dm.AddToDepartments(v);
                                    count++;
                                }
                                else
                                {
                                    _dm.departments_AddWithPK(v);
                                    count++;
                                }
                            }
                            ReportAConversion();
                        }
                    }
                    _dm.SaveChanges();
                    ReportASaveChanges();
                    rv = count;
                }
            }
            catch (Exception ex)
            {
                message += "Error: "+ ex.Message+"";
            }
            finally
            {
                _log += Environment.NewLine + GetString("IMPORT DEPARTMENTS ERRORS: ") + message;
            }

            return rv;
            
        }

        private int AddCities(DataTable dt)
        {
            int rv = 0;
            string message = "";
            try
            {
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    
                    City v;
                    if (DataRowToCity(row, out v, ref message))
                    {
                        if (CityIsValid(v, ref message))
                        {
                            if (!_config.Cities.Fields.ContainsKey("IdCity"))
                            {
                                _dm.AddToCities(v);
                                count++;
                            }
                            else
                            {
                                _dm.cities_AddWithPK(v);
                                count++;
                            }
                        }
                        ReportAConversion();
                    }
                }
                _dm.SaveChanges();
                ReportASaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message += Environment.NewLine + GetString("-Error: ") + ex.Message + " ";
            }
            finally
            {
                _log += Environment.NewLine + GetString("IMPORT CITIES ERRORS: ") + message;
            }

            return rv;
        }

        private int AddTerritories(DataTable dt)
        {
            int rv =0;
            string message = "";
            try
            {
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    Territory v;
                    if (DataRowToTerritory(row, out v, ref message))
                        if (!string.IsNullOrEmpty(v.Name)) //hay registros que no tienen territorio
                        {
                            if (TerritoryIsValid(v, ref message))
                            {
                                if (!_config.Territories.Fields.ContainsKey("IdTerritory"))
                                {
                                    _dm.AddToTerritories(v);
                                    count++;
                                }
                                else
                                {
                                    _dm.territories_AddWithPK(v);
                                    count++;
                                }
                            }
                            ReportAConversion();
                        }
                }
                _dm.SaveChanges();
                ReportASaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message +=  Environment.NewLine + GetString("-Error: ") + ex.Message+ " ";
            }
            finally
            {
                _log += Environment.NewLine + GetString("IMPORT TERRITORIES ERRORS: ") + message;
            }

            return rv;
        }

        private int AddAddresses(DataTable dt)
        {
            Address v;
            int rv = 0;
            string message = "";
            try
            {
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {

                    if (DataRowToAddress(row, out v, ref message))
                    {
                        if (AddressIsValid(v, ref message))
                        {
                            if (!_config.Addresses.Fields.ContainsKey("IdAddress"))
                            {
                                _dm.AddToAddresses(v);
                                count++;
                            }
                            else
                            {
                                _dm.addresses_AddWithPK(v);
                                count++;
                            }
                        }
                        ReportAConversion();
                    }
                }
                _dm.SaveChanges();
                ReportASaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message += Environment.NewLine + GetString("-Error: ") + ex.Message + " ";
            }
            finally
            {
                _log += Environment.NewLine + GetString("IMPORT ADDRESSES ERRORS: ") + message;
            }            

            return rv;
        }

        #endregion

        #region DataRowToEntity Methods


        private bool DataRowToDepartment(DataRow row, out TerritoriesManagement.Model.Department dep, ref string errorMsg)
        {
            bool rv = true;
            dep = new Model.Department();
            try
            {
                //Department.IdDepartment
                if (_config.Departments.Fields.ContainsKey("IdDepartment"))
                {
                    string idColumn = _config.Departments.Fields["IdDepartment"];
                    dep.IdDepartment = int.Parse(row[idColumn].ToString());                    
                }
                //
                //Department.Name
                if (_config.Departments.Fields.ContainsKey("Name"))
                {
                    string nameColumn = _config.Departments.Fields["Name"];
                    dep.Name = row[nameColumn].ToString();
                }
                //
            }
            catch (Exception)
            {
                rv = false;
                int index = row.Table.Rows.IndexOf(row);
                errorMsg += Environment.NewLine + GetString("-Conversion error. (Row values: {0})", RowToStr(row));
            }
            
            return rv;
        }

        private bool DataRowToCity(DataRow row, out City c, ref string errorMsg)
        {
            bool rv = true;
            c = new City();
            try 
	        {  
                //City.IdCity            
                if (_config.Cities.Fields.ContainsKey("IdCity"))
                {
                    string idColumn = _config.Cities.Fields["IdCity"];                
                    c.IdCity = int.Parse(row[idColumn].ToString());                
                }
                //
                //City.Name
                if (_config.Cities.Fields.ContainsKey("Name"))
                {
                    string nameColumn = _config.Cities.Fields["Name"];
                    c.Name = row[nameColumn].ToString();
                }
                //
                //City.Department
                int idDepartment = 0;

                if (_config.Cities.Fields.ContainsKey("DepartmentId") || _config.Cities.DefaultFieldValues.ContainsKey("DepartmentId"))
                {
                    if (_config.Cities.Fields.ContainsKey("DepartmentId"))
                    {
                        string idColumn = _config.Cities.Fields["DepartmentId"];
                        idDepartment = Convert.ToInt32(row[idColumn].ToString());
                    }
                    else //valor por defecto
                        idDepartment = Convert.ToInt32(_config.Cities.DefaultFieldValues["DepartmentId"]);
                }
                //sólo si el id no está indicado se tratará de buscar por el nombre, si es que está indicado
                if (idDepartment == 0 && 
                    (_config.Cities.Fields.ContainsKey("DepartmentName") || _config.Cities.DefaultFieldValues.ContainsKey("DepartmentName"))) 
                {
                    string departmentName="";
                    if (_config.Cities.Fields.ContainsKey("DepartmentName"))
                    {
                        string nameColumn = _config.Cities.Fields["DepartmentName"];
                        departmentName = row[nameColumn].ToString();                    
                    }
                    else //valor por defecto
                        departmentName = _config.Cities.DefaultFieldValues["DepartmentName"].ToString();

                    idDepartment = _compiledIdDepartmentByName(_dm, departmentName).First();
                }            

                c.DepartmentReference.EntityKey = new EntityKey("TerritoriesDataContext.Departments", "IdDepartment", idDepartment);
                //
	        }
	        catch (Exception)
	        {
        		rv = false;
                int index = row.Table.Rows.IndexOf(row);
                errorMsg += Environment.NewLine + GetString("-Conversion error. (Row values: {0})", RowToStr(row));
	        }
            return rv;
        }

        private bool DataRowToTerritory(DataRow row,out Territory t, ref string errorMsg)
        {
            bool rv = true;
            t = new Territory();
            try
            {                
                //Territory.IdTerritory
                if (_config.Territories.Fields.ContainsKey("IdTerritory"))
                {
                    string idColumn = _config.Territories.Fields["IdTerritory"];
                    t.IdTerritory = int.Parse(row[idColumn].ToString());
                }
                //Territory.Name
                if (_config.Territories.Fields.ContainsKey("Name"))
                {
                    string nameColumn = _config.Territories.Fields["Name"];
                    t.Name = row[nameColumn].ToString();
                } 
                //
                //Territory.Number
                if (_config.Territories.Fields.ContainsKey("Number"))
                {
                    string numColumn = _config.Territories.Fields["Number"];
                    t.Number = int.Parse(row[numColumn].ToString());
                }
                else //default value. TODO: comentar
                    if (_config.Territories.DefaultFieldValues.ContainsKey("Number"))
                        t.Number = int.Parse(_config.Territories.DefaultFieldValues["Number"].ToString());
                //
            }
            catch (Exception)
            {
                rv = false;
                int index = row.Table.Rows.IndexOf(row);
                errorMsg += Environment.NewLine + GetString("-Conversion error. (Row values: {0})", RowToStr(row));
            }
            return rv;
        }

        private bool DataRowToAddress(DataRow row,out Address a, ref string errorMsg)
        {
            bool rv = true;
            a = new Address();
            try
            {
                //Address.IdAddress
                if (_config.Addresses.Fields.ContainsKey("IdAddress"))
                {
                    string idColumn = _config.Addresses.Fields["IdAddress"];
                    a.IdAddress = int.Parse(row[idColumn].ToString());
                }
                //Address.Street
                if (_config.Addresses.Fields.ContainsKey("Street"))
                {
                    string streetColumn = _config.Addresses.Fields["Street"];
                    a.Street = row[streetColumn].ToString();
                }
                //Address.Number
                if (_config.Addresses.Fields.ContainsKey("Number"))
                {
                    string columnName = _config.Addresses.Fields["Number"];
                    a.Number = row[columnName].ToString();
                }
                //Address.Corner1
                if (_config.Addresses.Fields.ContainsKey("Corner1"))
                {
                    string columnName = _config.Addresses.Fields["Corner1"];
                    a.Corner1 = row[columnName].ToString();
                }
                //Address.Corner2
                if (_config.Addresses.Fields.ContainsKey("Corner2"))
                {
                    string columnName = _config.Addresses.Fields["Corner2"];
                    a.Corner2 = row[columnName].ToString();
                }
                //Address.Phone1
                if (_config.Addresses.Fields.ContainsKey("Phone1"))
                {
                    string columnName = _config.Addresses.Fields["Phone1"];
                    a.Phone1 = row[columnName].ToString();
                }
                //Address.Phone2
                if (_config.Addresses.Fields.ContainsKey("Phone2"))
                {
                    string columnName = _config.Addresses.Fields["Phone2"];
                    a.Phone2 = row[columnName].ToString();
                }
                //Address.Description
                if (_config.Addresses.Fields.ContainsKey("Description"))
                {
                    string columnName = _config.Addresses.Fields["Description"];
                    a.Description = row[columnName].ToString();
                }

                //Address.CustomField1
                if (_config.Addresses.Fields.ContainsKey("CustomField1"))
                {
                    string columnName = _config.Addresses.Fields["CustomField1"];
                    a.CustomField1 = row[columnName].ToString();
                }

                //Address.CustomField2
                if (_config.Addresses.Fields.ContainsKey("CustomField2"))
                {
                    string columnName = _config.Addresses.Fields["CustomField2"];
                    a.CustomField2 = row[columnName].ToString();
                }

                //Address.Map1
                if (_config.Addresses.Fields.ContainsKey("Map1"))
                {
                    string columnName = _config.Addresses.Fields["Map1"];
                    a.Map1 = row[columnName].ToString();
                }
                //Address.Map2
                if (_config.Addresses.Fields.ContainsKey("Map2"))
                {
                    string columnName = _config.Addresses.Fields["Map2"];
                    a.Map2 = row[columnName].ToString();
                }
                //Address.Lat and Address.Lng
                if (_config.Addresses.Fields.ContainsKey("Geoposition"))
                {
                    string columnName = _config.Addresses.Fields["Geoposition"];
                    string geoPos = row[columnName].ToString();
                    if (!string.IsNullOrEmpty(geoPos))
                    {
                        string[] strArray = geoPos.Split(' ');
                        if (strArray.Count<string>() != 0)
                        {
                            bool validGeoPosition = true;
                            double lat = 0;
                            if(!double.TryParse(strArray[0],NumberStyles.Any,new CultureInfo("en-US"),out lat))
                                validGeoPosition = false;

                            double lng = 0;
                            if (!double.TryParse(strArray[1], NumberStyles.Any, new CultureInfo("en-US"), out lng))
                                validGeoPosition = false;

                            if (validGeoPosition)
                            {
                                a.Lat = lat;
                                a.Lng = lng;
                            }
                        }
                    }
                }


                //Address.Lat
                if (_config.Addresses.Fields.ContainsKey("Lat"))
                {
                    string columnName = _config.Addresses.Fields["Lat"];
                    double lat = 0;
                    if(double.TryParse(row[columnName].ToString(),NumberStyles.Any, new CultureInfo("en-US"),out lat))
                        a.Lat = lat;
                }

                //Address.Lng
                if (_config.Addresses.Fields.ContainsKey("Lng"))
                {
                    string columnName = _config.Addresses.Fields["Lng"];
                    double lng = 0;
                    if (double.TryParse(row[columnName].ToString(), NumberStyles.Any, new CultureInfo("en-US"), out lng))
                        a.Lng = lng; ;
                }

                //Address.City
                int idCity = 0;
                if (_config.Addresses.Fields.ContainsKey("CityId") || _config.Addresses.DefaultFieldValues.ContainsKey("CityId"))
                {
                    if (_config.Addresses.Fields.ContainsKey("CityId"))
                    {
                        string idColumn = _config.Addresses.Fields["CityId"];
                        idCity = Convert.ToInt32(row[idColumn].ToString());
                    }
                    else
                        idCity = Convert.ToInt32(_config.Addresses.DefaultFieldValues["CityId"]);
                }

                if (idCity == 0 && (_config.Addresses.Fields.ContainsKey("CityName") || _config.Addresses.DefaultFieldValues.ContainsKey("CityName")))
                {
                    string cityName = "";
                    if (_config.Addresses.Fields.ContainsKey("CityName"))
                    {
                        string nameColumn = _config.Addresses.Fields["CityName"];
                        cityName = row[nameColumn].ToString();
                    }
                    else
                        cityName = _config.Addresses.DefaultFieldValues["CityName"].ToString();

                    idCity = _compiledIdCityByName(_dm, cityName).First();
                }

                a.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Cities", "IdCity", idCity);
                //

                //Address.Territory
                int idTerritory = 0;
                if (_config.Addresses.Fields.ContainsKey("TerritoryId") || _config.Addresses.DefaultFieldValues.ContainsKey("TerritoryId"))
                {
                    if (_config.Addresses.Fields.ContainsKey("TerritoryId"))
                    {
                        string idColumn = _config.Addresses.Fields["TerritoryId"];
                        idTerritory = Convert.ToInt32((row[idColumn].ToString()));
                    }
                    else
                        idTerritory = Convert.ToInt32(_config.Addresses.DefaultFieldValues["TerritoryId"]);
                }

                if (idTerritory == 0 && (_config.Addresses.Fields.ContainsKey("TerritoryName") || _config.Addresses.DefaultFieldValues.ContainsKey("TerritoryName")))
                {
                    string territoryName = "";
                    if (_config.Addresses.Fields.ContainsKey("TerritoryName"))
                    {
                        string nameColumn = _config.Addresses.Fields["TerritoryName"];
                        territoryName = row[nameColumn].ToString();
                    }
                    else
                        territoryName = _config.Addresses.DefaultFieldValues["TerritoryName"].ToString();

                    if (!string.IsNullOrEmpty(territoryName))
                        idTerritory = _compiledIdTerritoryByName(_dm, territoryName).First();
                }

                if (idTerritory != 0)
                    a.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);
                //
            }
            catch (Exception)
            {
                rv = false;
                int index = row.Table.Rows.IndexOf(row);
                errorMsg += Environment.NewLine + GetString("-Conversion error. (Row values: {0})", RowToStr(row));
            }
            return rv;
        }

        #endregion

        #region IsValid Methods

        public bool DepartmentIsValid(TerritoriesManagement.Model.Department v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg +=  Environment.NewLine + GetString("  -Name is blank or null. ");
                rv = false;
            }
            if (DepartmentExist(v))
            {
                msg += Environment.NewLine + GetString("  -Already exists. ");
                rv = false;
            }

            //lenght validation
            if (v.Name.Length > 80)
            {
                msg += Environment.NewLine + GetString("  -Name lenght exceeds the allowed length ({0}). ", 80);
                rv = false;
            }

            if (!rv)
            {
                message += Environment.NewLine + GetString("-\"{0} {1}\" is invalid: ",v.IdDepartment,v.Name) + msg;
            }

            return rv;
        }

        public bool CityIsValid(City v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg += Environment.NewLine + GetString("  -Name is blank or null. ");
                rv = false;
            }

            
            if (v.DepartmentReference.EntityKey == null ||
                (int) v.DepartmentReference.EntityKey.EntityKeyValues[0].Value == 0 )
            {
                msg += Environment.NewLine + GetString("  -Haven't department. ");
                rv = false;
            }
            else
            {
                int idDepartment = (int)v.DepartmentReference.EntityKey.EntityKeyValues[0].Value;
                if (!DepartmentExist(idDepartment))
                {
                    msg += Environment.NewLine + GetString("  -Department doesn't exist. ");
                    rv = false;
                    
                }                
                else if(CityExist(v))
                {
                    msg += Environment.NewLine + GetString("  -Already exists. ");
                    rv = false;
                }
            }

            //lenght validation
            if(v.Name.Length > 80)
            {
                msg += Environment.NewLine + GetString("  -Name lenght exceeds the allowed length ({0}). ", 80);
                rv = false;
            }

            if (!rv)
            {
                message += Environment.NewLine + GetString("-\"{0} {1}\" is invalid: ",v.IdCity, v.Name) + msg;
            }

            return rv;
        }

        private bool TerritoryIsValid(Territory v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg += Environment.NewLine + GetString("  -Name is blank or null. ");
                rv = false;
            }
            if (TerritoryExist(v))
            {
                msg += Environment.NewLine + GetString("  -Already exists. ");
                rv = false;
            }

            //lenght validation
            if (v.Name.Length > 80)
            {
                msg += Environment.NewLine + GetString("  -Name lenght exceeds the allowed length ({0}). ", 80);
                rv = false;
            }

            if (!rv)
            {
                message += Environment.NewLine + GetString("-\"{0} {1}\" is invalid: ", v.IdTerritory, v.Name) + msg;
            }

            return rv;
        }

        private bool AddressIsValid(Address v, ref string message)
        {
            bool rv = true;
            string msg  = "";            

            if (string.IsNullOrEmpty(v.Street))
            {
                msg += Environment.NewLine + GetString("  -The street is blank or null. ");
                rv = false;
            }
            if (v.CityReference.EntityKey==null ||
                (int)v.CityReference.EntityKey.EntityKeyValues[0].Value==0)
            {
                msg += Environment.NewLine + GetString("  -Haven't city. ");
                rv = false;
            }
            else
            {
                int idCity = (int)v.CityReference.EntityKey.EntityKeyValues[0].Value;
                if (!CityExist(idCity))
                {
                    msg += Environment.NewLine + GetString("  -City doesn't exist. ");
                    rv = false;

                }
            }
            if (AddressExist(v.IdAddress))
            {
                msg += Environment.NewLine + GetString("  -Already exists. ");
                rv = false;
            }

            //length validation
            if (!string.IsNullOrEmpty(v.AddressData) && v.AddressData.Length > 50)
            {
                msg += Environment.NewLine + GetString("  -Address data lenght exceeds the allowed length ({0}). ", 50);
                rv = false;
            }

            if ((!string.IsNullOrEmpty(v.Corner1) && v.Corner1.Length > 80) ||
                (!string.IsNullOrEmpty(v.Corner2) && v.Corner2.Length > 80))
            {
                msg += Environment.NewLine + GetString("  -Corners lenght exceeds the allowed length ({0}). ", 80);
                rv = false;
            }

            if((!string.IsNullOrEmpty(v.CustomField1) && v.CustomField1.Length > 200)
                || (!string.IsNullOrEmpty(v.CustomField2) && v.CustomField2.Length > 200))
            {
                msg += Environment.NewLine + GetString("  -Custom fields lenght exceeds the allowed length ({0}). ", 200);
                rv = false;
            }

            if (!string.IsNullOrEmpty(v.Description) && v.Description.Length > 200)
            {
                msg += Environment.NewLine + GetString("  -Description lenght exceeds the allowed length ({0}). ", 200);
                rv = false;
            }

            if ((!string.IsNullOrEmpty(v.Map1) && v.Map1.Length > 30) ||
                (!string.IsNullOrEmpty(v.Map2) && v.Map2.Length > 30))
            {
                msg += Environment.NewLine + GetString("  -Maps lenght exceeds the allowed length ({0}). ", 30);
                rv = false;
            }

            if (!string.IsNullOrEmpty(v.Number) && v.Number.Length > 50)
            {
                msg += Environment.NewLine + GetString("  -Number lenght exceeds the allowed length ({0}). ", 50);
                rv = false;
            }

            if ((!string.IsNullOrEmpty(v.Phone1) && v.Phone1.Length > 15) || 
                (!string.IsNullOrEmpty(v.Phone2) && v.Phone2.Length > 15))
            {
                msg += Environment.NewLine + GetString("  -Phone numbers lenght exceeds the allowed length ({0}). ", 15);
                rv = false;
            }

            if (v.Street.Length > 80)
            {
                msg += Environment.NewLine + GetString("  -Street lenght exceeds the allowed length ({0}). ", 80);
                rv = false;
            }
            //length validation end

            if (!rv)
            {
                message += Environment.NewLine + GetString("-\"{0} {1}\" is invalid: ", v.IdAddress, v.Street) + msg;
            }            

            return rv;

        }       


        #endregion

        #region EntityExist Methods
        private bool DepartmentExist(TerritoriesManagement.Model.Department v)
        {
            int found = _compiledSameDepartment(_dm, v).Count();
            return (found > 0);
        }

        private bool DepartmentExist(int id)
        {
            int found = 0;
            if (id != 0)
            {
                found = _dm.departments_GetById(id).Count();
            }

            return found > 0;
        }

        private bool CityExist(City v)
        {
            int idDepartment = (int)v.DepartmentReference.EntityKey.EntityKeyValues[0].Value;
            int found = _compiledSameCity(_dm, v,idDepartment).Count();            

            return (found > 0);
        }

        private bool CityExist(int id)
        {
            int found = 0;
            if (id != 0)
            {
                found = _dm.cities_GetById(id).Count();
            }

            return found > 0;
        }

        private bool TerritoryExist(Territory v)
        {
            int found = _compiledSameTerritory(_dm, v).Count();

            return (found > 0);
        }

        private bool TerritoryExist(int id)
        {
            int found = 0;
            if (id != 0)
            {
                found = _dm.territories_GetById(id).Count();
            }

            return found > 0;
        }

        private bool AddressExist(int id)
        {
            int found = 0;
            if (id!=0)
            {
                found = _dm.addresses_GetById(id).Count();
            }

            return found > 0;
        }

        #endregion        


        private void SetConfig()
        {
            _importer.ConnectStr = _config.ConnectionString;

            _progressPercentage = 0;

            _importer.Tables = new List<Table>();

            if (_config.Departments.Fields.Count>0)
            {
                Table table = new Table(_config.Departments.TableName);
                foreach (var item in _config.Departments.Fields)
                {
                    table.Fields.Add(item.Value);
                }

                _importer.Tables.Add(table);
            }   

            if (_config.Cities.Fields.Count>0)
            {
                Table table = new Table(_config.Cities.TableName);
                foreach (var item in _config.Cities.Fields)
                {
                    table.Fields.Add(item.Value);
                }

                _importer.Tables.Add(table);
            }

            if (_config.Territories.Fields.Count > 0)
            {
                Table table = new Table(_config.Territories.TableName);
                foreach (var item in _config.Territories.Fields)
                {
                    table.Fields.Add(item.Value);
                }

                _importer.Tables.Add(table);
            }

            if (_config.Addresses.Fields.Count > 0)
            {
                Table table = new Table(_config.Addresses.TableName);
                foreach (var item in _config.Addresses.Fields)
                {
                    table.Fields.Add(item.Value);
                }

                _importer.Tables.Add(table);
            }
        }

        private void SaveLog()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            using (StreamWriter sr = new StreamWriter(path,false))
            {
                string[] strArray = _log.Split('\n');
                foreach (string item in strArray)
                {
                    sr.WriteLine(item);
                }
            }
        }

        private string RowToStr(DataRow row)
        {
            string rv = "";

            for (int i = 0; i < row.ItemArray.Count(); i++)
            {
                if (!string.IsNullOrEmpty(rv))
                    rv = " ";
                rv += row[i].ToString();
            }

            return rv;
        }

        private void PreCompileQueries()
        {
            this._compiledIdDepartmentByName = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm,string name) => from v in dm.Departments
                                                               where v.Name == name
                                                               select v.IdDepartment
                );

            this._compiledIdCityByName = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, string name) => from v in dm.Cities
                                                                where v.Name == name
                                                                select v.IdCity
                );

            this._compiledIdTerritoryByName = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, string name) => from v in dm.Territories
                                                                where v.Name == name
                                                                select v.IdTerritory
                );

            this._compiledSameDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Model.Department v) => from d in dm.Departments
                                                                 where d.Name == v.Name ||
                                                                       d.IdDepartment == v.IdDepartment
                                                                 select d

                );

            this._compiledSameCity = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, City v,int idDepartment) => from c in dm.Cities
                                                           where (c.Name == v.Name && c.Department.IdDepartment == idDepartment) ||
                                                                    c.IdCity == v.IdCity
                                                           select c
                );
            this._compiledSameTerritory = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Territory v) => from t in dm.Territories
                                                                where t.Name == v.Name ||
                                                                      (v.Number != null && t.Number == v.Number) ||
                                                                      t.IdTerritory == v.IdTerritory
                                                                select t
                );
        }

        #region Export data
        public int ImportExchangeData(string path, List<string> entityList)
        {
            int count = 0;
            try
            {
                PreCompileQueries();

                DataSet ds = new DataSet();
                ds.ReadXml(path);

                foreach (var entityName in entityList)
                {
                    Type entityType = Functions.GetEntityTypeByEntityName(entityName);
                    string entitySetName = Functions.GetEntitySetNameByEntityName(entityName);
                    string keyProperty = "Id" + entityName;

                    DataTable dt = ds.Tables[entitySetName];

                    foreach (DataRow row in dt.Rows)
                    {
                        object recordObj = DataRowToObject(row, entityType);
                        _dm.AddObject(entitySetName, recordObj);
                        count++;
                    }

                }
                _dm.SaveChanges();               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return count;
        }


        private Object DataRowToObject(DataRow row, Type entityType)
        {
            object entityObj = Activator.CreateInstance(entityType);

            foreach (DataColumn column in row.Table.Columns)
            {
                if (!row.IsNull(column))
                {
                    if (!column.ColumnName.Contains("."))
                    {
                        if (column.ColumnName.StartsWith("Id"))
                            entityType.GetProperty(column.ColumnName).SetValue(entityObj, 0, null);
                        else
                        {
                            object value = row[column];
                            entityType.GetProperty(column.ColumnName).SetValue(entityObj, value, null);
                        }
                    }
                    else
                    {
                        //manejo de la referencias
                        if (column.ColumnName.Contains("City.Name"))
                        {
                            int id = _compiledIdCityByName(_dm, row[column].ToString()).First();
                            EntityKey key = new EntityKey("TerritoriesDataContext.Cities", "IdCity", id);
                            object reference = entityType.GetProperty("CityReference").GetValue(entityObj, null);
                            reference.GetType().GetProperty("EntityKey").SetValue(reference, key, null);

                        }

                        if (column.ColumnName.Contains("Department.Name"))
                        {
                            int id = _compiledIdDepartmentByName(_dm, row[column].ToString()).First();
                            EntityKey key = new EntityKey("TerritoriesDataContext.Departments", "IdDepartment", id);
                            object reference = entityType.GetProperty("DepartmentReference").GetValue(entityObj, null);
                            reference.GetType().GetProperty("EntityKey").SetValue(reference, key, null);
                        }

                        if (column.ColumnName.Contains("Territory.Name"))
                        {
                            if (row[column] != null)
                            {
                                int id = _compiledIdTerritoryByName(_dm, row[column].ToString()).First();
                                EntityKey key = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", id);
                                object reference = entityType.GetProperty("TerritoryReference").GetValue(entityObj, null);
                                reference.GetType().GetProperty("EntityKey").SetValue(reference, key, null);
                            }
                        }

                    }
                }
            }
            return entityObj;

        }

        
        
        #endregion

    }
}
