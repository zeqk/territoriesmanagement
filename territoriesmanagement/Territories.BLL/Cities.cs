using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Territories.Model;
using Territories.DAL;


namespace Territories.BLL
{                
    public class Cities : IDataBridge<City>
    {
        private TerritoriesDataContext _dm;
        private CommandExecutor _dal;

        private Func<TerritoriesDataContext, int, IQueryable<City>> _compiledLoadCity;
        private Func<TerritoriesDataContext, IQueryable<KeyListItem>> _compiledAllCities;
        private Func<TerritoriesDataContext, City, IQueryable<City>> _compiledSameCity;

        #region Constructors
        public Cities()        
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Cities(EntityConnection conection)
        {
            _dm = new TerritoriesDataContext(conection);
            PreCompileQueries();

        }
        #endregion

        #region IGenericServer<City> Members

        public City Insert(City v)
        {
            try
            {
                if (this.IsValid(v))
                {
                    _dm.AddToCities(v);                                     
                }

                return v;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public City Update(City v)
        {
            try
            {
                if (this.IsValid(v))
                {
                    _dm.ApplyPropertyChanges("Cities", v);
                }
                return v;
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(City v)
        {
            try                
            {
                _dm.DeleteObject(v);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public City Load(int id)
        {
            try
            {
                City rv = _dal.ExecuteFirstOrDefault<City>(_compiledLoadCity(_dm,id));
                return rv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<KeyListItem> Search (string strQuery, params ObjectParameter[] parameters)
        {
            
            try
            {
                if (strQuery == null || strQuery == "")
                {
                    var results = _dal.ExecuteList<KeyListItem>(_compiledAllCities(_dm),MergeOption.PreserveChanges);
                    return results;                    
                }
                else
                {
                    strQuery = "SELECT VALUE City AS Department FROM TerritoriesDataContext.Cities AS City WHERE " + strQuery;
                    ObjectQuery<City> query = _dm.CreateQuery<City>(strQuery, parameters);
                    var results = from city in _dal.ExecuteList<City>(query)
                                 orderby city.Name
                                 select new KeyListItem { Id = city.IdCity, Name = city.Name };
                    return results.ToList<KeyListItem>();
                    
                }
               
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool IsValid(City v)
        {
            if (v.Name == "" || v.Name == null)
            {
                throw new Exception("The city name is invalid. Correct and retrieve.");
            }
            if (nameExist(v))
            {
                throw new Exception("The city already exist. Correct and retrieve.");
            }


            return true;
        }

        public City NewObject()
        {
            City rv = new City();
            //rv.IdCity = 0;
            //rv.Name = "";
            //rv.Department = null;
            //rv.Cities = new EntitySet<City>();
            return rv;

        }

        public List<KeyListItem> All()
        {
            return this.Search("");
        }

        public void SaveChanges()
        {
            try
            {
                _dal.SaveChanges(_dm);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        private bool nameExist(City v)
        {

            ObjectParameter[] parameters = { new ObjectParameter("Name", v.Name) };

            var results = _dal.ExecuteList<City>(_compiledSameCity(_dm,v),MergeOption.PreserveChanges);          

            if (results.Count>0)
                return true;
            else
                return false;
        }

        public ObjectResult<Department> GetDepartments()
        {
            return _dm.departments_GetAll();
        }


        private void PreCompileQueries()
        {
            this._compiledLoadCity = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm,int id) => from city in _dm.Cities.Include("Directions").Include("Publishers")
                                where city.IdCity == id
                                select city

                );
            this._compiledAllCities = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm) => from city in _dm.Cities
                          orderby city.Name
                          select new KeyListItem { Id = city.IdCity, Name = city.Name }
                );

            this._compiledSameCity = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm,City v) => from city in _dm.Cities
                                where city.Name == v.Name && city.IdCity != v.IdCity
                                select city

                );

        }
    }
}
