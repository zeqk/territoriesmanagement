using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using Territories.Model;
using Territories.Interop;
using My;

namespace Territories.BLL
{    
    public class ImportTool
    {

        TerritoriesDataContext _dm;
        Importer _importer;
        private ImporterConfig _config;

        private string log;

        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdDepartmentByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdCityByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdTerritoryByName;

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;
        private Func<TerritoriesDataContext, City, IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compiledSameTerritory;
        


        public ImporterConfig Config
        {
            get { return _config; }
            set { _config = value; }           
        }



        public ImportTool()
	    {
            
            _dm = new TerritoriesDataContext();
            _importer = new Importer(Enumerators.Provider.MSExcel);
	    }

        public void ExternalDataToModel()
        {
            PreCompileQueries();
            try
            {
                DataSet ds = _importer.GetData();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["Departments"] != null)
                        AddDepartments(ds.Tables["Departments"]);

                    if (ds.Tables["Cities"] != null)
                        AddCities(ds.Tables["Cities"]);

                    if (ds.Tables["Territories"] != null)
                        AddTerritories(ds.Tables["Territories"]);

                    if (ds.Tables["Directions"] != null)
                        AddDirections(ds.Tables["Directions"]);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #region AddEntity Methods

        private bool AddDepartments(DataTable dt)
        {
            bool rv;
            string message = "";
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    
                    Department v = DataRowToDepartment(row);
                    if (DepartmentIsValid(v, ref message))
                    {
                        if (_config.Departments.Fields["IdDepartment"]==null)
                            _dm.AddToDepartments(v);
                        else
                            _dm.departments_AddWithPK(v.IdDepartment, v.Name);

                    }
                        
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                message += "Error: "+ ex.Message+"";
                rv = false;
            }
            finally
            {
                log += "\nADD DEPARTMENTS ERRORS: " + message;
            }

            return rv;
            
        }

        private bool AddCities(DataTable dt)
        {
            bool rv;
            string message = "";
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    City v = DataRowToCity(row);
                    if (CityIsValid(v, ref message))
                        _dm.AddToCities(v);
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                message += "Error: " + ex.Message + " ";
                rv = false;
            }
            finally
            {
                log += "\nADD CITIES ERRORS: " + message;
            }

            return rv;
        }

        private bool AddTerritories(DataTable dt)
        {
            bool rv;
            string message = "";
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Territory v = DataRowToTerritory(row);
                    if (TerritoryIsValid(v, ref message))
                        _dm.AddToTerritories(v);
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                message +=  "Error: "+ ex.Message+ " ";
                rv = false;
            }
            finally
            {
                log += "\nADD TERRITORIES ERRORS: " + message;
            }

            return rv;

        }

        private bool AddDirections(DataTable dt)
        {
            bool rv;
            string message = "";
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Direction v = DataRowToDirection(row);
                    if (DirectionIsValid(v, ref message))
                        _dm.AddToDirections(v);
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                message += "Error: " + ex.Message + " ";
                rv = false;
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
            if (!string.IsNullOrEmpty(_config.Departments.Fields["IdDepartment"]))
            {
                string idColumn = _config.Departments.Fields["IdDepartment"];
                int id = 0;
                if (int.TryParse(row[idColumn].ToString(), out id))
                    rv.IdDepartment = id;
            }
            //
            //Department.Name
            string name = "";
            if (!string.IsNullOrEmpty(_config.Departments.Fields["Name"]))
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
            if (!string.IsNullOrEmpty(_config.Cities.Fields["IdCity"]))
            {
                string idColumn = _config.Cities.Fields["IdCity"];
                int id = 0;
                if (int.TryParse(row[idColumn].ToString(), out id))
                    rv.IdCity = id;
            }
            //
            //City.Name
            string name = "";
            if (!string.IsNullOrEmpty(_config.Cities.Fields["Name"]))
            {
                string nameColumn = _config.Cities.Fields["Name"];
                name = row[nameColumn].ToString();
            }
            rv.Name = name;
            //
            //City.Department
            int idDepartment = 0;
            if (!string.IsNullOrEmpty(_config.Cities.Fields["Department"]))
            {
                string nameColumn = _config.Cities.Fields["Department"];
                string departmentName = row[nameColumn].ToString();

                idDepartment = _compiledIdDepartmentByName(_dm, departmentName).First();                
            }
            //else //TODO: DEFAULT VALUE
            //{
            //    if (_config.Cities.DefaultFieldValues["Department"] != null)
            //    {
            //        string departmentName = _config.Cities.DefaultFieldValues["Department"].ToString();
            //        idDepartment = _compiledIdDepartmentByName(_dm, departmentName).First();  
            //    }
            //}

            rv.DepartmentReference.EntityKey = new EntityKey("TerritoriesDataContext.Departments", "IdDepartment", idDepartment);
            //
            return rv;
        }

        private Territory DataRowToTerritory(DataRow row)
        {
            Territory rv = new Territory();
            //Territory.IdTerritory
            if (!string.IsNullOrEmpty(_config.Territories.Fields["IdTerritory"]))
            {
                string idColumn = _config.Territories.Fields["IdTerritory"];
                int id = 0;
                if(int.TryParse(row[idColumn].ToString(),out id))
                    rv.IdTerritory = id;
            }
            //Territory.Name
            if (!string.IsNullOrEmpty(_config.Territories.Fields["Name"]))
            {
                string nameColumn = _config.Territories.Fields["Name"];
                rv.Name = row[nameColumn].ToString();
            } 
            //
            //Territory.Number
            if (!string.IsNullOrEmpty(_config.Territories.Fields["Number"]))
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
            if (!string.IsNullOrEmpty(_config.Directions.Fields["IdDirection"]))
            {
                string idColumn = _config.Directions.Fields["IdDirection"];
                int id = 0;
                if(int.TryParse(row[idColumn].ToString(),out id))
                    rv.IdDirection = id;
            }
            //Direction.Street
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Street"]))
            {
                string streetColumn = _config.Directions.Fields["Street"];
                rv.Street = row[streetColumn].ToString();
            }            
            //Direction.Number
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Number"]))
            {
                string columnName = _config.Directions.Fields["Number"];
                rv.Number = row[columnName].ToString();
            }
            //Direction.Corener1
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Corner1"]))
            {
                string columnName = _config.Directions.Fields["Corner1"];
                rv.Corner1 = row[columnName].ToString();
            }
            //Direction.Corner2
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Corner2"]))
            {
                string columnName = _config.Directions.Fields["Corner2"];
                rv.Corner2 = row[columnName].ToString();
            }
            //Direction.Phone1
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Phone1"]))
            {
                string columnName = _config.Directions.Fields["Phone1"];
                rv.Phone1 = row[columnName].ToString();
            }
            //Direction.Phone2
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Phone2"]))
            {
                string columnName = _config.Directions.Fields["Phone2"];
                rv.Phone2 = row[columnName].ToString();
            }
            //Direction.Description
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Description"]))
            {
                string columnName = _config.Directions.Fields["Description"];
                rv.Description = row[columnName].ToString();
            }
            //Direction.Map1
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Map1"]))
            {
                string columnName = _config.Directions.Fields["Map1"];
                rv.Map1 = row[columnName].ToString();
            }
            //Direction.Map2
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Map2"]))
            {
                string columnName = _config.Directions.Fields["Map2"];
                rv.Map2 = row[columnName].ToString();
            }
            //Direction.City
            int idCity = 0;
            if (!string.IsNullOrEmpty(_config.Directions.Fields["City"]))
            {
                string nameColumn = _config.Directions.Fields["City"];
                string cityName = row[nameColumn].ToString();

                idCity = _compiledIdCityByName(_dm, cityName).First();
            }
            //else //TODO: Defautl Value
            //{
            //    if (_config.Directions.DefaultFieldValues["City"] != null)
            //    {
            //        string cityName = _config.Directions.DefaultFieldValues["City"].ToString();
            //        idCity = _compiledIdCityByName(_dm, cityName).First();
            //    }
            //}

            rv.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Directions", "IdCity", idCity);
            //

            //Direction.Territory
            int idTerritory = 0;
            if (!string.IsNullOrEmpty(_config.Directions.Fields["Territory"]))
            {
                string nameColumn = _config.Directions.Fields["Territory"];
                string terrName = row[nameColumn].ToString();

                idTerritory = _compiledIdTerritoryByName(_dm, terrName).First();
            }
            //else //TODO: Default Value
            //{
            //    if (_config.Directions.DefaultFieldValues["Territory"] != null)
            //    {
            //        string terrName = _config.Directions.DefaultFieldValues["Territory"].ToString();
            //        idTerritory = _compiledIdTerritoryByName(_dm, terrName).First();
            //    }
            //}            

            rv.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);
            //

            //Direction.Geopositions
            if (!string.IsNullOrEmpty(_config.Directions.Fields["GeoPosition"]))
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
            if (string.IsNullOrEmpty(v.Name))
            {
                message +=  "Name is blank or null. ";
                rv = false;
            }
            if (DepartmentExist(v))
            {                
                message += "Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n" + v.IdDepartment + " " + v.Name + " invalid: " + message;
            }

            return rv;
        }

        public bool CityIsValid(City v, ref string message)
        {
            bool rv = true;
            if (!string.IsNullOrEmpty(v.Name))
            {
                message += "Name is blank or null. ";
                rv = false;
            }
            if (v.Department == null || v.Department.IdDepartment == 0)
            {
                message += "Haven't department. ";
                rv = false;
            }
            if (CityExist(v))
            {
                message += "Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n" + v.IdCity + " " + v.Name + " invalid: " + message;
            }

            return rv;
        }

        private bool TerritoryIsValid(Territory v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += "Name is blank or null. ";
                rv = false;
            }
            if (TerritoryExist(v))
            {
                message += "Already exist. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n" + v.IdTerritory + " " + v.Name + " invalid: " + message;
            }

            return rv;
        }

        private bool DirectionIsValid(Direction v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Street))
            {
                message += "The street name is blank or null. ";
                rv = false;
            }
            if (v.Territory == null || v.Territory.IdTerritory == 0)
            {
                message += "Haven't territory. ";
                rv = false;
            }
            if (v.City == null || v.City.IdCity == 0)
            {
                message += "Haven't city. ";
                rv = false;
            }

            if (!rv)
            {
                message = "\n" + v.IdDirection + " " + v.Street + " invalid: " + message;
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
            var found = _compiledSameCity(_dm, v).ToList();

            return (found.Count > 0);
        }

        private bool TerritoryExist(Territory v)
        {
            var found = _compiledSameTerritory(_dm, v).ToList();

            return (found.Count > 0);
        }
        #endregion        


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
                    (TerritoriesDataContext dm, City v) => from c in dm.Cities
                                                           where (c.Name == v.Name && c.Department.IdDepartment == v.Department.IdDepartment) ||
                                                                    c.IdCity == v.IdCity
                                                           select c
                );
            this._compiledSameTerritory = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Territory v) => from t in dm.Territories
                                                                where t.Name == v.Name ||
                                                                      t.Number == v.Number ||
                                                                      t.IdTerritory == v.IdTerritory
                                                                select t
                );
        }



    }
}
