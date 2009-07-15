using System;
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

        private string log;

        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdDepartmentByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdCityByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdTerritoryByName;

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;
        private Func<TerritoriesDataContext, City, int,IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compiledSameTerritory;
        


        public ImporterConfig Config
        {
            get { return _config; }
            set { _config = value; }           
        }



        public ImportTool()
	    {
            
            _dm = new TerritoriesDataContext();
            _importer = new Interop.Importer(Enumerators.Provider.MSExcel);
            _config = new ImporterConfig();
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
                            importationMessage += count + " departments has ben imported.\n";
                        else
                            importationMessage += "No department has ben imported.\n";
                    }

                    bool citiesImported = true;
                    string cities = _config.Cities.TableName;
                    if (ds.Tables[cities] != null)
                    {
                        int count = AddCities(ds.Tables[cities]);
                        citiesImported = count > 0;
                        if (citiesImported)
                            importationMessage += count + "cities has ben imported.\n";
                        else
                            importationMessage += "No city has ben imported.\n";
                    }

                    bool territoriesImported = true;
                    string territories = _config.Territories.TableName;
                    if (ds.Tables[territories] != null)
                    {
                        int count = AddTerritories(ds.Tables[territories]);
                        territoriesImported = count > 0;
                        if (territoriesImported)
                            importationMessage += count + "territories has ben imported.\n";
                        else
                            importationMessage += "No territory has ben imported.\n";
                    }

                    bool directionsImported = true;
                    string directions = _config.Directions.TableName;
                    if (ds.Tables[directions] != null)
                    {
                        int count = AddDirections(ds.Tables[directions]);
                        directionsImported =  count > 0;
                        if (directionsImported)
                            importationMessage += count + "directions has ben imported.\n";
                        else
                            importationMessage += "No direction has ben imported.\n";
                    }

                    rv = departmentsImported && citiesImported && territoriesImported && directionsImported;
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
                log += "\nADD DEPARTMENTS ERRORS: " + message;
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
                        if (_config.Cities.DefaultFieldValues.ContainsKey("IdCity"))
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
                message += "Error: " + ex.Message + " ";
            }
            finally
            {
                log += "\nADD CITIES ERRORS: " + message;
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
                message +=  "Error: "+ ex.Message+ " ";
            }
            finally
            {
                log += "\nADD TERRITORIES ERRORS: " + message;
            }

            return rv;
        }

        private int AddDirections(DataTable dt)
        {
            int rv = 0;
            string message = "";
            try
            {
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    Direction v = DataRowToDirection(row);
                    if (DirectionIsValid(v, ref message))
                    {
                        if (!_config.Directions.Fields.ContainsKey("IdDirection"))
                        {
                            _dm.AddToDirections(v);
                            count++;
                        }
                        else
                        {
                            _dm.directions_AddWithPK(v);
                            count++;
                        }
                    }
                }
                _dm.SaveChanges();
                rv = count;
            }
            catch (Exception ex)
            {
                message += "Error: " + ex.Message + " ";
            }
            finally
            {
                log += "\nADD DIRECTIONS ERRORS:" + message;
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

        private Direction DataRowToDirection(DataRow row)
        {            
            Direction rv = new Direction();

            //Direction.IdDirection
            if (_config.Directions.Fields.ContainsKey("IdDirection"))
            {
                string idColumn = _config.Directions.Fields["IdDirection"];
                int id = 0;
                if(int.TryParse(row[idColumn].ToString(),out id))
                    rv.IdDirection = id;
            }
            //Direction.Street
            if (_config.Directions.Fields.ContainsKey("Street"))
            {
                string streetColumn = _config.Directions.Fields["Street"];
                rv.Street = row[streetColumn].ToString();
            }            
            //Direction.Number
            if (_config.Directions.Fields.ContainsKey("Number"))
            {
                string columnName = _config.Directions.Fields["Number"];
                rv.Number = row[columnName].ToString();
            }
            //Direction.Corener1
            if (_config.Directions.Fields.ContainsKey("Corner1"))
            {
                string columnName = _config.Directions.Fields["Corner1"];
                rv.Corner1 = row[columnName].ToString();
            }
            //Direction.Corner2
            if (_config.Directions.Fields.ContainsKey("Corner2"))
            {
                string columnName = _config.Directions.Fields["Corner2"];
                rv.Corner2 = row[columnName].ToString();
            }
            //Direction.Phone1
            if (_config.Directions.Fields.ContainsKey("Phone1"))
            {
                string columnName = _config.Directions.Fields["Phone1"];
                rv.Phone1 = row[columnName].ToString();
            }
            //Direction.Phone2
            if (_config.Directions.Fields.ContainsKey("Phone2"))
            {
                string columnName = _config.Directions.Fields["Phone2"];
                rv.Phone2 = row[columnName].ToString();
            }
            //Direction.Description
            if (_config.Directions.Fields.ContainsKey("Description"))
            {
                string columnName = _config.Directions.Fields["Description"];
                rv.Description = row[columnName].ToString();
            }
            //Direction.Map1
            if (_config.Directions.Fields.ContainsKey("Map1"))
            {
                string columnName = _config.Directions.Fields["Map1"];
                rv.Map1 = row[columnName].ToString();
            }
            //Direction.Map2
            if (_config.Directions.Fields.ContainsKey("Map2"))
            {
                string columnName = _config.Directions.Fields["Map2"];
                rv.Map2 = row[columnName].ToString();
            }
            //Direction.City
            int idCity = 0;
            if (_config.Directions.Fields.ContainsKey("CityId")|| _config.Directions.DefaultFieldValues.ContainsKey("CityId"))
            {
                if (_config.Directions.Fields.ContainsKey("CityId"))
                {
                    string idColumn = _config.Directions.Fields["CityId"];
                    idCity = Convert.ToInt32(row[idColumn].ToString());
                }
                else
                    idCity = Convert.ToInt32(_config.Directions.DefaultFieldValues["CityId"]);
            }

            if (idCity==0 && (_config.Directions.Fields.ContainsKey("CityName")||_config.Directions.DefaultFieldValues.ContainsKey("CityName")))
            {
                string cityName = "";
                if (_config.Directions.Fields.ContainsKey("CityName"))
                {
                    string nameColumn = _config.Directions.Fields["CityName"];
                    cityName = row[nameColumn].ToString();
                }
                else
                    cityName = _config.Directions.DefaultFieldValues["CityName"].ToString();

                idCity = _compiledIdCityByName(_dm, cityName).First();
            }

            rv.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Directions", "IdCity", idCity);
            //

            //Direction.Territory
            int idTerritory = 0;
            if (_config.Directions.Fields.ContainsKey("TerritoryId") || _config.Directions.DefaultFieldValues.ContainsKey("TerritoryId"))
            {
                if (_config.Directions.Fields.ContainsKey("TerritoryId"))
                {
                    string idColumn = _config.Directions.Fields["TerritoryId"];
                    idTerritory = Convert.ToInt32((row[idColumn].ToString()));
                }
                else
                    idTerritory = Convert.ToInt32(_config.Directions.DefaultFieldValues["TerritoryId"]);
            }

            if (idTerritory == 0 && (_config.Directions.Fields.ContainsKey("TerritoryName") || _config.Directions.DefaultFieldValues.ContainsKey("TerritoryName")))
            {
                string territoryName = "";
                if (_config.Directions.Fields.ContainsKey("TerritoryName"))
                {
                    string nameColumn = _config.Directions.Fields["TerritoryName"];
                    territoryName = row[nameColumn].ToString();
                }
                else
                    territoryName = _config.Directions.DefaultFieldValues["TerritoryName"].ToString();

                idTerritory = _compiledIdTerritoryByName(_dm, territoryName).First();
            }         

            rv.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);
            //

            //Direction.Geopositions
            if (_config.Directions.Fields.ContainsKey("GeoPosition"))
            {
                string columnName = _config.Directions.Fields["GeoPosition"];
                string[] strGeopos = row[columnName].ToString().Split(' ');

                if (!string.IsNullOrEmpty(strGeopos[0]) && !string.IsNullOrEmpty(strGeopos[1]))
                {
                    GeoPosition geopos = new GeoPosition();
                    geopos.Latitude = long.Parse(strGeopos[0]);
                    geopos.Longitude = long.Parse(strGeopos[1]);
                    geopos.Date = DateTime.Now;
                    _dm.AddToGeoPositions(geopos);
                    rv.GeoPositions.Add(geopos);
                }
            }

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
                msg +=  "Name is blank or null. ";
                rv = false;
            }
            if (DepartmentExist(v))
            {
                msg += "Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n \"" + v.IdDepartment + " " + v.Name + "\" invalid: " + msg;
            }

            return rv;
        }

        public bool CityIsValid(City v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg += "Name is blank or null. ";
                rv = false;
            }
            if (v.DepartmentReference.EntityKey==null)
            {
                msg += "Haven't department. ";
                rv = false;
            }
            else
                if (CityExist(v))
                {
                    msg += "Already exist. ";
                    rv = false;
                }

            if (!rv)
            {
                message = "\n \"" + v.IdCity + " " + v.Name + "\" invalid: " + msg;
            }

            return rv;
        }

        private bool TerritoryIsValid(Territory v, ref string message)
        {
            bool rv = true;
            string msg = "";
            if (string.IsNullOrEmpty(v.Name))
            {
                msg += "Name is blank or null. ";
                rv = false;
            }
            if (TerritoryExist(v))
            {
                msg += "Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n \"" + v.IdTerritory + " " + v.Name + "\" invalid: " + msg;
            }

            return rv;
        }

        private bool DirectionIsValid(Direction v, ref string message)
        {
            bool rv = true;
            string msg  = "";
            if (string.IsNullOrEmpty(v.Street))
            {
                msg += "The street name is blank or null. ";
                rv = false;
            }
            if (v.TerritoryReference.EntityKey==null)
            {
                msg += "Haven't territory. ";
                rv = false;
            }
            if (v.TerritoryReference.EntityKey==null)
            {
                msg += "Haven't city. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n \"" + v.IdDirection + " " + v.Street + "\" invalid: " + msg;
            }

            return rv;

        }

        #endregion

        #region EntityExist Methods
        private bool DepartmentExist(Department v)
        {
            var found = _compiledSameDepartment(_dm, v).ToList();
            return (found.Count > 0);
        }

        private bool CityExist(City v)
        {
            int idDepartment = (int)v.DepartmentReference.EntityKey.EntityKeyValues[0].Value;
            var found = _compiledSameCity(_dm, v,idDepartment).ToList();            

            return (found.Count > 0);
        }

        private bool TerritoryExist(Territory v)
        {
            var found = _compiledSameTerritory(_dm, v).ToList();
            //var found = from t in _dm.Territories
            //            where t.Name == v.Name ||
            //                  (t.Number == v.Number && v.Number != null) ||
            //                  t.IdTerritory == v.IdTerritory
            //            select t;

            return (found.Count > 0);
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

            if (_config.Directions.Fields.Count > 0)
            {
                Table table = new Table(_config.Directions.TableName);
                foreach (var item in _config.Directions.Fields)
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
                sr.Write(log);
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
