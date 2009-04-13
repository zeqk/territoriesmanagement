using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Linq;
using System.Text;
using Territories.DAL;



namespace Territories.BLL.LinqToSQL
{
    internal class CityServer : IGenerics<City>
    {
        TerritoriesDataContext _db;

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public CityServer()
        {
            _db = new TerritoriesDataContext();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">TerritoriesDataContext for use</param>
        public CityServer(TerritoriesDataContext db)
        {
            _db = db;
        }
        #endregion

        #region IGenerics<City> Members
                
        public void Insert(City v)
        {
            try
            {
                _db.Cities.InsertOnSubmit(v);
                
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
                
        public void Update(City v)
        {
            try
            {
                _db.Cities.Attach(v);
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
                _db.Cities.DeleteOnSubmit(v);
            }
            catch (Exception e) 
            {
                
                throw e;
            }
        }

        public City Load(int id)
        {
            return _db.Cities.ElementAt<City>(id);
        }

        public List<City> Search(string query, object[] parameters)
        {
            try
            {
                return _db.Cities.Where(query, parameters).ToList<City>();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public void IsValid(City v)
        {
            if (v.Name=="" || v.Name==null)
            {
                throw new Exception("Enter city name");
            }
            if (v.Department==null)
            {
                throw new Exception("Select any department");
            }
        }

        public City NewObject()
        {
            City rv = new City();
            rv.IdCity = 0;
            rv.Name = "";
            rv.Department = null;            
            return rv;
        }

        #endregion
    }
}
