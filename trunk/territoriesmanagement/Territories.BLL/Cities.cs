using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Linq;
using System.Text;
using Territories.DAL2;

namespace Territories.BLL.EntityFramework
{
    internal class CitiesServer : IGenerics<City>
    {
        TerritoriesDataContext _dm;

        //#region Constructors
        ///// <summary>
        ///// Default constructor
        ///// </summary>
        //public Cities()
        //{
        //    _dm = new TerritoriesDataContext();
        //}

        ///// <summary>
        ///// Constructor
        ///// </summary>
        ///// <param name="db">TerritoriesDataContext for use</param>
        //public Cities(TerritoriesDataContext db)
        //{
        //    _dm = db;
        //}
        //#endregion

        #region IGenerics<City> Members
                
        public void Insert(City v)
        {
            try
            {
                _dm.Cities.InsertOnSubmit(v);
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
                _dm.Cities.Attach(v);
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
                _dm.Cities.DeleteOnSubmit(v);
            }
            catch (Exception e) 
            {
                
                throw e;
            }
        }

        public City Load(int id)
        {
            return _dm.Cities.ElementAt<City>(id);
        }

        public List<City> Search(string query, object[] parameters)
        {
            try
            {
                return _dm.Cities.Where(query, parameters).ToList<City>();
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
                throw new Exception("Enter a city name.");
            }
            if (v.Department == null) 
            {
                throw new Exception("Select any department.");
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
