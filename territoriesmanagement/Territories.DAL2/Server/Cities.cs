using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Territories.DAL;


          
namespace Territories.DAL.Server
{                
    public class Cities : IGenerics<City>
    {
        private TerritoriesDataContext _dm;


        #region Constructors
        public Cities()        
        {
            _dm = new TerritoriesDataContext(); 
        }

        public Cities(TerritoriesDataContext dm)
        {
            _dm = dm;

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
                return _dm.Cities.ElementAt<City>(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ObjectResult<City> Search(string query, params ObjectParameter[] parameters)
        {
            
            try
            {
                if (query == null || query == "")
                    return _dm.cities_GetAll();
                else
                {
                    query = "SELECT VALUE City FROM TerritoriesDataContext.Cities AS City WHERE " + query;
                    return _dm.CreateQuery<City>(query, parameters).Execute(MergeOption.AppendOnly);

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
            rv.IdCity = 0;
            rv.Name = "";
            rv.Department = null;
            //rv.Cities = new EntitySet<City>();
            return rv;

        }

        public ObjectResult<City> All()
        {
            return this.Search("");
        }

        #endregion

        private bool nameExist(City v)
        {

            ObjectParameter[] parameters = { new ObjectParameter("Name", v.Name) };

            var results = from c in _dm.Cities
                        where c.Name == v.Name
                        select c.Name;           

            if (results.Count<string>()>0)
                return true;
            else
                return false;
        }

        public ObjectResult<Department> GetDepartments()
        {
            return _dm.departments_GetAll();
        }


        
    }
}
