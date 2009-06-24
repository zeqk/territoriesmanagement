﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using Territories.Model;
using Territories.Interop;

namespace Territories.BLL
{    
    public class Interoperability
    {

        TerritoriesDataContext _dm;
        ExcelImporter _importer;
        private ExcelImporterConfig _excelConfig;

        private string log;

        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdDepartmentByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdCityByName;
        private Func<TerritoriesDataContext, string, IQueryable<int>> _compiledIdTerritoryByName;

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;
        private Func<TerritoriesDataContext, City, IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compileSameTerritory;
        


        public ExcelImporterConfig ExcelConfig
        {
            get { return _excelConfig; }
            set { _excelConfig = value; }
        }
	
	

        public Interoperability ()
	    {
            _dm = new TerritoriesDataContext();
           _importer = new ExcelImporter();
           _importer.Configuration = _excelConfig;
	    }

        public void ExcelToModel()
        {
            try
            {
                DataSet ds = _importer.ReadExcelFile();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["Departments"] != null)
                        AddDepartments(ds.Tables["Departments"]);

                    if (ds.Tables["Cities"] != null)
                        AddCities(ds.Tables["Cities"]);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            

            
        }

        private bool AddDepartments(DataTable dt)
        {
            bool rv;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Department v = DataRowToDepartment(row);
                    string message = "";
                    if (DepartmentIsValid(v, ref message))
                    {
                        if (!DepartmentExist(v))
                            _dm.AddToDepartments(v);
                        else
                            message += v.Name + "alreadt exist.\n";
                    }
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception)
            {
                rv = false;
            }

            return rv;
            
        }

        private bool AddCities(DataTable dt)
        {
            bool rv;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    City v = DataRowToCity(row);
                    _dm.AddToCities(v);
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception)
            {
                rv = false;
            }

            return rv;

        }

        private bool AddTerritories(DataTable dt)
        {
            bool rv;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Territory v = new Territory();
                    string nameColumn = _excelConfig.Territories.Columns["Name"];
                    v.Name = row[nameColumn].ToString();

                    if (!string.IsNullOrEmpty(_excelConfig.Territories.Columns["Number"]))
                    {
                        string numColumn = _excelConfig.Territories.Columns["Number"];
                        v.Number = int.Parse(row[numColumn].ToString());
                    }

                    _dm.AddToTerritories(v);
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception)
            {
                rv = false;
            }

            return rv;

        }

        private bool AddDirections(DataTable dt)
        {
            bool rv;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Direction v = new Direction();

                    string streetColumn = _excelConfig.Territories.Columns["Street"];
                    v.Street = row[streetColumn].ToString();

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Number"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Number"];
                        v.Number = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Corner1"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Corner1"];
                        v.Corner1 = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Corner2"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Corner2"];
                        v.Corner2 = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Phone1"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Phone1"];
                        v.Phone1 = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Phone2"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Phone2"];
                        v.Phone2 = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Description"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Description"];
                        v.Description = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Map1"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Map1"];
                        v.Map1 = row[columnName].ToString();
                    }

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["Map2"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["Map2"];
                        v.Map2 = row[columnName].ToString();
                    }

                    string cityColumn = _excelConfig.Directions.Columns["City"];
                    string strCity = row[cityColumn].ToString();
                    int idCity = _compiledIdCityByName(_dm, strCity).First();

                    string terrColumn = _excelConfig.Directions.Columns["City"];
                    string strTerr = row[terrColumn].ToString();
                    int idTerritory = _compiledIdCityByName(_dm, strCity).First();

                    v.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Cities", "IdCity", idCity);
                    v.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);

                    if (!string.IsNullOrEmpty(_excelConfig.Directions.Columns["GeoPosition"]))
                    {
                        string columnName = _excelConfig.Territories.Columns["GeoPosition"];
                        string[] strGeopos = row[columnName].ToString().Split(' ');

                        if (!string.IsNullOrEmpty(strGeopos[0]) && !string.IsNullOrEmpty(strGeopos[1]))
                        {
                            GeoPosition geopos = new GeoPosition();
                            geopos.Latitude = long.Parse(strGeopos[0]);
                            geopos.Longitude = long.Parse(strGeopos[1]);
                            geopos.Date = DateTime.Now;
                            _dm.AddToGeoPositions(geopos);
                            v.GeoPositions.Add(geopos);
                        }
                    }

                    _dm.AddToDirections(v);
                }
                _dm.SaveChanges();
                rv = true;
            }
            catch (Exception ex)
            {
                rv = false;
            }

            return rv;

        }


        #region DataRowToEntity Methods



        private Department DataRowToDepartment(DataRow row)
        {
            Department rv = new Department();
            if (!string.IsNullOrEmpty(_excelConfig.Departments.Columns["Name"]))
            {
                string nameColumn = _excelConfig.Departments.Columns["Name"];
                rv.Name = row[nameColumn].ToString();
            }
            return rv;
        }

        private City DataRowToCity(DataRow row)
        {
            City rv = new City();

            if (!string.IsNullOrEmpty(_excelConfig.Cities.Columns["Name"]))
            {
                string nameColumn = _excelConfig.Cities.Columns["Name"];
                rv.Name = row[nameColumn].ToString();
            }

            if (!string.IsNullOrEmpty(_excelConfig.Cities.Columns["Department"]))
            {
                string nameColumn = _excelConfig.Cities.Columns["Department"];
                string departmentName = row[nameColumn].ToString();

                int idDepartment = _compiledIdDepartmentByName(_dm, departmentName).First();
                rv.DepartmentReference.EntityKey = new EntityKey("TerritoriesDataContext.Departments", "IdDepartment", idDepartment);
            }

            return rv;
        }

        private Territory DataRowToTerritory(DataRow row)
        {
            Territory rv = new Territory();

            return rv;
        }

        #endregion


        #region IsValid Methods

        public bool DepartmentIsValid(Department v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += "Department name is blank or null.";
                rv = false;
            }
            return rv;
        }

        public bool CityIsValid(City v, ref string message)
        {
            bool rv = true;
            if (!string.IsNullOrEmpty(v.Name))
            {
                message += "City name is blank or null.";
                rv = false;
            }

            if (v.Department == null || v.Department.IdDepartment == 0)
            {
                if (!rv)
                    message += "\n";
                message += "Haven't department.";
                rv = false;
            }
            return rv;
        }

        private bool TerritoryIsValid(Territory v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += "Territory name is blank or null.";
                rv = false;
            }
            return rv;
        }

        private bool DirectionIsValid(Direction v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Street))
            {
                message += "The street name is blank or null.";
                rv = false;
            }

            if (v.Territory == null || v.Territory.IdTerritory == 0)
            {
                if (!rv)
                    message += "\n";
                message += "Haven't territory.";
                rv = false;
            }

            if (v.City == null || v.City.IdCity == 0)
            {
                if (!rv)
                    message += "\n";
                message += "Haven't city.";
                rv = false;
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
            var found = _compileSameTerritory(_dm, v).ToList();

            return (found.Count > 0);
        }
        #endregion

        private void PreCompileQueries()
        {
            this._compiledIdDepartmentByName = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm,string name) => from dep in dm.Departments
                                                               where dep.Name == name
                                                               select dep.IdDepartment
                );

            this._compiledIdCityByName = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, string name) => from city in dm.Cities
                                                                where city.Name == name
                                                                select city.IdCity
                );

            this._compiledIdTerritoryByName = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, string name) => from terr in dm.Territories
                                                                where terr.Name == name
                                                                select terr.IdTerritory
                );

            this._compiledSameDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Department v) => from dep in dm.Departments
                                                                 where dep.Name == v.Name && dep.IdDepartment != v.IdDepartment
                                                                 select dep

                );
        }



    }
}
