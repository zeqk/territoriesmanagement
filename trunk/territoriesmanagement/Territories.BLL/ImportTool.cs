﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.EntityClient;
using System.IO;
using Territories.Model;
using Territories.Interop;
using My;

namespace Territories.BLL
{    
    public class ImportTool
    {

        TerritoriesDataContext _dm;
        Interop.Importer _importer;
        private ImporterConfig _config;

        private string _log;

        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdDepartmentByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdCityByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdTerritoryByName;

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;
        private Func<TerritoriesDataContext, City, int,IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compiledSameTerritory;

        public ImportTool()
	    {
            
            _dm = new TerritoriesDataContext();
            _importer = new Interop.Importer(Enumerators.Provider.MSExcel);
            _config = new ImporterConfig();
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


        public bool ExternalDataToModel(ref string importationMessage)
        {
            bool rv = true;
            SetConfig();

            PreCompileQueries();
            try
            {
                DataSet ds = _importer.GetData();
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
                            importationMessage += "\n" + count + " departments has been imported.\n";
                            if (ds.Tables[departments].Rows.Count>count)
                            {
                                //TODO
                            }
                        }
                        else
                            importationMessage += "\nNo department has been imported.\n";
                    }

                    bool citiesImported = true;
                    string cities = _config.Cities.TableName;
                    if (ds.Tables[cities] != null)
                    {
                        int count = AddCities(ds.Tables[cities]);
                        citiesImported = count > 0;
                        if (citiesImported)
                            importationMessage += "\n" + count + " cities has been imported.\n";
                        else
                            importationMessage += "\nNo city has been imported.\n";
                    }

                    bool territoriesImported = true;
                    string territories = _config.Territories.TableName;
                    if (ds.Tables[territories] != null)
                    {
                        int count = AddTerritories(ds.Tables[territories]);
                        territoriesImported = count > 0;
                        if (territoriesImported)
                            importationMessage += "\n" + count + " territories has been imported.\n";
                        else
                            importationMessage += "\nNo territory has been imported.\n";
                    }

                    bool addressesImported = true;
                    string addresses = _config.Addresses.TableName;
                    if (ds.Tables[addresses] != null)
                    {
                        int count = AddAddresses(ds.Tables[addresses]);
                        addressesImported =  count > 0;
                        if (addressesImported)
                            importationMessage += "\n" + count + " addresses has been imported.\n";
                        else
                            importationMessage += "\nNo address has been imported.\n";
                    }

                    rv = departmentsImported && citiesImported && territoriesImported && addressesImported;
                }
                else
                    rv = false;

                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            SaveLog();
            return rv;
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

                        Department v = DataRowToDepartment(row);

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
                    }
                    _dm.SaveChanges();
                    rv = count;
                }
            }
            catch (Exception ex)
            {
                message += "Error: "+ ex.Message+"";
            }
            finally
            {
                _log += "\nIMPORT DEPARTMENTS ERRORS: " + message;
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
                    
                    City v = DataRowToCity(row);
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
                }
                _dm.SaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message += "\n-Error: " + ex.Message + " ";
            }
            finally
            {
                _log += "\nIMPORT CITIES ERRORS: " + message;
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
                    Territory v = DataRowToTerritory(row);
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
                }
                _dm.SaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message +=  "\n-Error: "+ ex.Message+ " ";
            }
            finally
            {
                _log += "\nIMPORT TERRITORIES ERRORS: " + message;
            }

            return rv;
        }

        private int AddAddresses(DataTable dt)
        {
            int rv = 0;
            string message = "";
            Address v2;
            DataRow r;
            try
            {
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    r = row;
                    if (row[0].ToString() == "ABRAHAM MENDELEVICH (835)")
                    {
                        Console.WriteLine();
                    }
                    Address v = DataRowToAddress(row);
                    v2 = v;
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
                }
                _dm.SaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message += "\n-Error: " + ex.Message + " ";
            }
            finally
            {
                _log += "\nIMPORT ADDRESSES ERRORS:" + message;
            }            

            return rv;
        }

        #endregion

        #region DataRowToEntity Methods


        private Department DataRowToDepartment(DataRow row)
        {
            Department rv = new Department();
            //Department.IdDepartment
            
            if (_config.Departments.Fields.ContainsKey("IdDepartment"))
            {
                string idColumn = _config.Departments.Fields["IdDepartment"];
                int id = 0;
                if (int.TryParse(row[idColumn].ToString(), out id))
                    rv.IdDepartment = id;
            }
            //
            //Department.Name
            string name = "";
            if (_config.Departments.Fields.ContainsKey("Name"))
            {
                string nameColumn = _config.Departments.Fields["Name"];
                name= row[nameColumn].ToString();
            }
            rv.Name = name;
            //
            return rv;
        }

        private City DataRowToCity(DataRow row)
        {
            City rv = new City();
            //City.IdCity
            if (_config.Cities.Fields.ContainsKey("IdCity"))
            {
                string idColumn = _config.Cities.Fields["IdCity"];
                int id = 0;
                if (int.TryParse(row[idColumn].ToString(), out id))
                    rv.IdCity = id;
            }
            //
            //City.Name
            string name = "";
            if (_config.Cities.Fields.ContainsKey("Name"))
            {
                string nameColumn = _config.Cities.Fields["Name"];
                name = row[nameColumn].ToString();
            }
            rv.Name = name;
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
                else
                    idDepartment = Convert.ToInt32(_config.Cities.DefaultFieldValues["DepartmentId"]);
            }
            //sólo si el id no está indicado se tratará de buscar por el nombre, si es que está indicado
            if (idDepartment==0 && (_config.Cities.Fields.ContainsKey("DepartmentName") || _config.Cities.DefaultFieldValues.ContainsKey("DepartmentName"))) 
            {
                string departmentName="";
                if (_config.Cities.Fields.ContainsKey("DepartmentName"))
                {
                    string nameColumn = _config.Cities.Fields["DepartmentName"];
                    departmentName = row[nameColumn].ToString();                    
                }
                else
                    departmentName = _config.Cities.DefaultFieldValues["DepartmentName"].ToString();

                idDepartment = _compiledIdDepartmentByName(_dm, departmentName).First();
            }            

            rv.DepartmentReference.EntityKey = new EntityKey("TerritoriesDataContext.Departments", "IdDepartment", idDepartment);
            //
            return rv;
        }

        private Territory DataRowToTerritory(DataRow row)
        {
            Territory rv = new Territory();
            //Territory.IdTerritory
            if (_config.Territories.Fields.ContainsKey("IdTerritory"))
            {
                string idColumn = _config.Territories.Fields["IdTerritory"];
                int id = 0;
                if(int.TryParse(row[idColumn].ToString(),out id))
                    rv.IdTerritory = id;
            }
            //Territory.Name
            if (_config.Territories.Fields.ContainsKey("Name"))
            {
                string nameColumn = _config.Territories.Fields["Name"];
                rv.Name = row[nameColumn].ToString();
            } 
            //
            //Territory.Number
            if (_config.Territories.Fields.ContainsKey("Number"))
            {
                string numColumn = _config.Territories.Fields["Number"];
                rv.Number = int.Parse(row[numColumn].ToString());
            }
            //
            return rv;
        }

        private Address DataRowToAddress(DataRow row)
        {
            Address rv = new Address();

            //Address.IdAddress
            if (_config.Addresses.Fields.ContainsKey("IdAddress"))
            {
                string idColumn = _config.Addresses.Fields["IdAddress"];
                int id = 0;
                if(int.TryParse(row[idColumn].ToString(),out id))
                    rv.IdAddresses = id;
            }
            //Address.Street
            if (_config.Addresses.Fields.ContainsKey("Street"))
            {
                string streetColumn = _config.Addresses.Fields["Street"];
                rv.Street = row[streetColumn].ToString();
            }            
            //Address.Number
            if (_config.Addresses.Fields.ContainsKey("Number"))
            {
                string columnName = _config.Addresses.Fields["Number"];
                rv.Number = row[columnName].ToString();
            }
            //Address.Corner1
            if (_config.Addresses.Fields.ContainsKey("Corner1"))
            {
                string columnName = _config.Addresses.Fields["Corner1"];
                rv.Corner1 = row[columnName].ToString();
            }
            //Address.Corner2
            if (_config.Addresses.Fields.ContainsKey("Corner2"))
            {
                string columnName = _config.Addresses.Fields["Corner2"];
                rv.Corner2 = row[columnName].ToString();
            }
            //Address.Phone1
            if (_config.Addresses.Fields.ContainsKey("Phone1"))
            {
                string columnName = _config.Addresses.Fields["Phone1"];
                rv.Phone1 = row[columnName].ToString();
            }
            //Address.Phone2
            if (_config.Addresses.Fields.ContainsKey("Phone2"))
            {
                string columnName = _config.Addresses.Fields["Phone2"];
                rv.Phone2 = row[columnName].ToString();
            }
            //Address.Description
            if (_config.Addresses.Fields.ContainsKey("Description"))
            {
                string columnName = _config.Addresses.Fields["Description"];
                rv.Description = row[columnName].ToString();
            }

            //Address.CustomField1
            if (_config.Addresses.Fields.ContainsKey("CustomField1"))
            {
                string columnName = _config.Addresses.Fields["CustomField1"];
                rv.CustomField1 = row[columnName].ToString();
            }

            //Address.CustomField2
            if (_config.Addresses.Fields.ContainsKey("CustomField2"))
            {
                string columnName = _config.Addresses.Fields["CustomField2"];
                rv.CustomField2 = row[columnName].ToString();
            }

            //Address.Map1
            if (_config.Addresses.Fields.ContainsKey("Map1"))
            {
                string columnName = _config.Addresses.Fields["Map1"];
                rv.Map1 = row[columnName].ToString();
            }
            //Address.Map2
            if (_config.Addresses.Fields.ContainsKey("Map2"))
            {
                string columnName = _config.Addresses.Fields["Map2"];
                rv.Map2 = row[columnName].ToString();
            }

            //Address.Geoposition
            if (_config.Addresses.Fields.ContainsKey("Geoposition"))
            {
                string columnName = _config.Addresses.Fields["Geoposition"];
                rv.Geoposition = row[columnName].ToString();
            }


            //Address.City
            int idCity = 0;
            if (_config.Addresses.Fields.ContainsKey("CityId")|| _config.Addresses.DefaultFieldValues.ContainsKey("CityId"))
            {
                if (_config.Addresses.Fields.ContainsKey("CityId"))
                {
                    string idColumn = _config.Addresses.Fields["CityId"];
                    idCity = Convert.ToInt32(row[idColumn].ToString());
                }
                else
                    idCity = Convert.ToInt32(_config.Addresses.DefaultFieldValues["CityId"]);
            }

            if (idCity==0 && (_config.Addresses.Fields.ContainsKey("CityName")||_config.Addresses.DefaultFieldValues.ContainsKey("CityName")))
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

            rv.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Cities", "IdCity", idCity);
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

                if(!string.IsNullOrEmpty(territoryName))
                    idTerritory = _compiledIdTerritoryByName(_dm, territoryName).First();
            }         

            if(idTerritory!=0)
                rv.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);
            //

            return rv;
        }

        #endregion

        #region IsValid Methods

        public bool DepartmentIsValid(Department v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg +=  "\n  -Name is blank or null. ";
                rv = false;
            }
            if (DepartmentExist(v))
            {
                msg += "\n  -Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message += "\n-\"" + v.IdDepartment + " " + v.Name + "\" is invalid: " + msg;
            }

            return rv;
        }

        public bool CityIsValid(City v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg += "\n  -Name is blank or null. ";
                rv = false;
            }

            
            if (v.DepartmentReference.EntityKey == null ||
                (int) v.DepartmentReference.EntityKey.EntityKeyValues[0].Value == 0 )
            {
                msg += "\n  -Haven't department. ";
                rv = false;
            }
            else
            {
                int idDepartment = (int)v.DepartmentReference.EntityKey.EntityKeyValues[0].Value;
                if (!DepartmentExist(idDepartment))
                {
                    msg += "\n  -Department don't exist. ";
                    rv = false;
                    
                }                
                else if(CityExist(v))
                {
                    msg += "\n  -Already exist. ";
                    rv = false;
                }
            }

            

            if (!rv)
            {
                message += "\n-\"" + v.IdCity + " " + v.Name + "\" is invalid: " + msg;
            }

            return rv;
        }

        private bool TerritoryIsValid(Territory v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg += "\n  -Name is blank or null. ";
                rv = false;
            }
            if (TerritoryExist(v))
            {
                msg += "\n  -Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message += "\n-\"" + v.IdTerritory + " " + v.Name + "\" is invalid: " + msg;
            }

            return rv;
        }

        private bool AddressIsValid(Address v, ref string message)
        {
            bool rv = true;
            string msg  = "";            

            if (string.IsNullOrEmpty(v.Street))
            {
                msg += "\n  -The street is blank or null. ";
                rv = false;
            }
            if (v.CityReference.EntityKey==null ||
                (int)v.CityReference.EntityKey.EntityKeyValues[0].Value==0)
            {
                msg += "\n  -Haven't city. ";
                rv = false;
            }
            else
            {
                int idCity = (int)v.CityReference.EntityKey.EntityKeyValues[0].Value;
                if (!CityExist(idCity))
                {
                    msg += "\n  -City don't exist. ";
                    rv = false;

                }
            }


            //if (v.TerritoryReference.EntityKey == null ||
            //    (int)v.TerritoryReference.EntityKey.EntityKeyValues[0].Value == 0)
            //{
            //    msg += "\n  -Haven't territory. ";
            //    rv = false;
            //}
            //else
            //{
            //    int idTerritory = (int)v.TerritoryReference.EntityKey.EntityKeyValues[0].Value;
            //    if (!TerritoryExist(idTerritory))
            //    {
            //        msg += "\n  -Territory don't exist. ";
            //        rv = false;

            //    }
            //}

            if (AddressExist(v.IdAddresses))
            {
                msg += "\n  -Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message += "\n-\"" + v.IdAddresses + " " + v.Street + "\" is invalid: " + msg;
            }

            return rv;

        }       


        #endregion

        #region EntityExist Methods
        private bool DepartmentExist(Department v)
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
                found = _dm.address_GetById(id).Count();
            }

            return found > 0;
        }

        #endregion        


        private void SetConfig()
        {
            _importer.ConnectStr = _config.ConnectionString;

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

        public string MakeConnectStr(string[] parameters)
        {
            return  _importer.MakeConnectStr(parameters);
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
                    (TerritoriesDataContext dm, Department v) => from d in dm.Departments
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



    }
}
