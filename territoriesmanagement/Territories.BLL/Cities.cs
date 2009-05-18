using System;
using System.Collections;
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
    public class Cities //: IDataBridge<City>
    {
        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, City, IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, int, IQueryable<City>> _compileLoadCity;

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

        public City Save(City v)
        {
            City rv;
            v.DepartmentReference.Load();
            if (v.IdCity == 0)
                rv = this.Insert(v);
            else
                rv = this.Update(v);
            return rv;
        }

        public City Insert(City v)
        {
            try
            {
                if (this.IsValid(v))
                {
                    _dm.AddToCities(v);
                    _dm.SaveChanges();                 
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
                    _dm.SaveChanges();
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
                _dm.SaveChanges();
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
                //City rv = this._compileLoadCity(_dm, id).FirstOrDefault();
                City rv = _dm.cities_GetById(id).FirstOrDefault();
                rv.DepartmentReference.Load();
                return rv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList Search (string strQuery, params ObjectParameter[] parameters)
        {
            
            try
            {
                if (strQuery == null || strQuery == "")
                {
                    var objectResults = _dm.cities_GetAll();
                    var results = from city in objectResults
                                  select new KeyListItem { Id = city.IdCity, Name = city.Name };
                    return results.ToList() ;                    
                }
                else
                {
                    strQuery = "SELECT VALUE City AS Department FROM TerritoriesDataContext.Cities AS City WHERE " + strQuery;
                    var query = _dm.CreateQuery<City>(strQuery, parameters);
                    var results = from city in query.Execute(MergeOption.AppendOnly)
                                 //orderby city.Name
                                 select new { Id = city.IdCity, Name = city.Name };
                    return results.ToList();                    
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

        public IList All()
        {
            return this.Search("");
        }

        public void SaveChanges()
        {
            try
            {
                _dm.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        public IDictionary LoadRelations(int id)
        {
            try
            {
                IDictionary rv = new Hashtable();
                var queryResults1 = _dm.directions_GetByCity(id);
                var directions = from dir in queryResults1
                             //orderby dir.StreetAndNumber
                             select new { Id = dir.IdDirection, Name = dir.StreetAndNumber };

                var queryResults2 = _dm.publishers_GetByCity(id);
                var publishers = from pub in queryResults2
                                 //orderby pub.Name
                                 select new { Id = pub.IdPublisher, Name = pub.Name };

                rv.Add("Directions", directions.ToList());
                rv.Add("Publishers",publishers.ToList());
                
                return rv;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool nameExist(City v)
        {

            ObjectParameter[] parameters = { new ObjectParameter("Name", v.Name) };

            var results = _compiledSameCity(_dm, v).ToList();

            if (results.Count>0)
                return true;
            else
                return false;
        }

        public IList GetDepartments()
        {
            try
            {                
                var objectResults = _dm.departments_GetAll();
                var results = from dep in objectResults
                                  //orderby dep.Name
                                  select new KeyListItem{ Id = dep.IdDepartment, Name = dep.Name };
                return results.ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }                   
        }


        private void PreCompileQueries()
        {
            this._compiledSameCity = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm,City v) => from city in _dm.Cities
                                where city.Name == v.Name && city.IdCity != v.IdCity
                                select city

                );

            this._compileLoadCity = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm,int id) => from city in _dm.Cities.Include("Department")
                                                           where city.IdCity == id
                                                           select city
                );
        }
    }
}
