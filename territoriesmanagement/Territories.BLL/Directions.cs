using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Objects;
using Territories.Model;

namespace Territories.BLL
{
    public class Directions : IDataBridge<Direction>
    {
        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, int, IQueryable<Direction>> _compileLoadDirection;
        private Func<TerritoriesDataContext, IQueryable<Direction>> _compileGetAllDirections;

        #region Contructors
        public Directions()
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Directions(EntityConnection connection)
        {
            _dm = new TerritoriesDataContext(connection);
            PreCompileQueries();
        }

        #endregion

        #region IDataBridge<Direction> Members

        public Direction Save(Direction v)
        {
            
            string invalidMessage ="";
            if (IsValid(v, ref invalidMessage))
            {
                Direction rv;
                if (v.IdDirection == 0)
                    rv = Insert(v);
                else
                    rv = Update(v);
                return rv;  
            }
            else
                throw new Exception(invalidMessage);           
                              
        }

        public Direction Insert(Direction v)
        {
            try
            {                
                v.City = _dm.cities_GetById(v.City.IdCity).FirstOrDefault();
                v.Territory = _dm.territories_GetById(v.Territory.IdTerritory).FirstOrDefault();
                _dm.AddToDirections(v);
                _dm.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return v;
        }

        public Direction Update(Direction v)
        {
            try
            {
                int idCity = v.City.IdCity;
                int idTerr = v.Territory.IdTerritory;
                _dm.ApplyPropertyChanges("Directions", v);

                _dm.Directions.MergeOption = MergeOption.AppendOnly;
                Direction d = _compileLoadDirection(_dm, v.IdDirection).FirstOrDefault();
                d.City = _dm.cities_GetById(idCity).FirstOrDefault();
                d.Territory = _dm.territories_GetById(idTerr).FirstOrDefault();

                _dm.SaveChanges();

                return v;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Direction d = _dm.directions_GetByCity(id).First();
                _dm.DeleteObject(d);
                _dm.SaveChanges();
            }
            catch (Exception ex) 
            {                
                throw ex;
            }
        }

        public Direction Load(int id)
        {
            try
            {
                _dm.Directions.MergeOption = MergeOption.NoTracking;
                Direction rv = _compileLoadDirection(_dm, id).First();
                return rv;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public IList Search(string strCriteria, params ObjectParameter[] parameters)
        {
            try
            {
                ObjectResult<Direction> objectResults;
                string strQuery = "SELECT VALUE Direction FROM TerritoriesDataContext.Directions AS Direction";

                if (string.IsNullOrEmpty(strCriteria))
                    strCriteria += " WHERE " + strCriteria;

                var query = _dm.CreateQuery<Direction>(strQuery, parameters);
                objectResults = query.Execute(MergeOption.AppendOnly);
                var results = from d in objectResults
                              orderby d.StreetAndNumber, d.City.Name
                              select new
                              {
                                  Id = d.IdDirection,
                                  DepartmentName = d.City.Department.Name,
                                  CityName = d.City.Name,
                                  TerritoryNumber = d.Territory.Number,
                                  TerritoryName = d.Territory.Name,
                                  Street = d.StreetAndNumber,
                                  Corner1 = d.Corner1,
                                  Corner2 = d.Corner2,
                                  Description = d.Description
                              };
                return results.ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Direction NewObject()
        {
            Direction rv = new Direction();
            return rv;
        }

        #endregion

        private bool IsValid(Direction v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.StreetAndNumber))
            {
                message += "Enter the street and the number.";
                rv = false;
            }

            if (v.Territory == null || v.Territory.IdTerritory == 0)
            {
                if (!rv)
                    message += "\n";
                message += "Select any territory.";
                rv = false;
            }

            if (v.City == null || v.City.IdCity == 0)
            {
                if (!rv)
                    message += "\n";
                message += "Select any city.";
                rv = false;
            }

            return rv;

        }

        public IList GetDepartments()
        {
            try
            {
                var objectResults = _dm.departments_GetAll();
                var results = from dep in objectResults
                              orderby dep.Name
                              select new { Id = dep.IdDepartment, Name = dep.Name };
                return results.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetCitiesByDepartment(int idDepartment)
        {
            try
            {
                var objectResults = _dm.cities_GetByDepartment(idDepartment);
                var results = from c in objectResults
                              orderby c.Name
                              select new { Id = c.IdCity, Name = c.Name };
                return results.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetTerritories()
        {
            try
            {
                var objectResults = _dm.territories_GetAll();
                var results = from t in objectResults
                              orderby t.Name
                              select new { Id = t.IdTerritory, Name = t.Name };
                return results.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreCompileQueries()
        {

            this._compileLoadDirection = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from d in dm.Directions.Include("City").Include("Territory")
                                                           where d.IdDirection == id
                                                           select d
                );

            this._compileGetAllDirections = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm) => dm.Directions.Include("City").Include("Territory").AsQueryable()
                );


        }
    }
}
