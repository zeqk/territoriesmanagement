﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using Territories.Model;

namespace Territories.BLL.DataBridge
{
    public class Addresses : IDataBridge<Address>
    {
        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, int, IQueryable<Address>> _compiledLoadAddress;
        private Func<TerritoriesDataContext, IQueryable<Address>> _compiledGetAllAddresses;

        #region Contructors
        public Addresses()
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Addresses(EntityConnection connection)
        {
            _dm = new TerritoriesDataContext(connection);
            PreCompileQueries();
        }

        #endregion

        #region IDataBridge<Address> Members

        public Address Save(Address v)
        {
            
            string invalidMessage ="";
            if (IsValid(v, ref invalidMessage))
            {
                Address rv;
                if (v.IdAddresses == 0)
                    rv = Insert(v);
                else
                    rv = Update(v);
                return rv;  
            }
            else
                throw new Exception(invalidMessage);           
                              
        }

        public Address Insert(Address v)
        {
            try
            {
                int idCity = v.City.IdCity;
                int idTerritory = v.Territory.IdTerritory;

                v.City = null;
                v.Territory = null;

                v.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Cities", "IdCity", idCity);                
                if(idTerritory!=0)
                    v.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);

                _dm.AddToAddresses(v);
                _dm.SaveChanges();
                
            }
            catch (Exception ex)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Addresses);
                throw ex;
            }

            return v;
        }

        public Address Update(Address v)
        {
            try
            {
                //copio las propiedades de navegación
                int idCity = v.City.IdCity;
                int idTerritory = 0;
                if(v.Territory != null)
                    idTerritory = v.Territory.IdTerritory;

                //aplico las propiedades escalares
                _dm.ApplyPropertyChanges("Addresses", v);

                //cargo el objecto original
                _dm.Addresses.MergeOption = MergeOption.AppendOnly;
                Address original = _compiledLoadAddress(_dm, v.IdAddresses).FirstOrDefault();
                               

                //aplico las propiedades de referencia
                original.City = null;
                original.Territory = null;
                original.CityReference.EntityKey = new EntityKey("TerritoriesDataContext.Cities", "IdCity", idCity);
                if(idTerritory != 0)
                    original.TerritoryReference.EntityKey = new EntityKey("TerritoriesDataContext.Territories", "IdTerritory", idTerritory);                                

                _dm.SaveChanges();

                return v;
            }
            catch (Exception ex)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Addresses);
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Address d = _dm.address_GetById(id).First();
                _dm.DeleteObject(d);
                _dm.SaveChanges();
            }
            catch (Exception ex) 
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Addresses);
                throw ex;
            }
        }

        public Address Load(int id)
        {
            try
            {
                _dm.Addresses.MergeOption = MergeOption.NoTracking;
                Address rv = _compiledLoadAddress(_dm, id).First();
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
                ObjectResult<Address> objectResults;
                string strQuery = "SELECT VALUE Address FROM TerritoriesDataContext.Addresses AS Address";

                if (!string.IsNullOrEmpty(strCriteria))
                    strQuery += " WHERE " + strCriteria;
                
                var query = _dm.CreateQuery<Address>(strQuery, parameters).Include("City"); ;
                objectResults = query.Execute(MergeOption.AppendOnly);
                var results = from a in objectResults
                              orderby a.Street, a.City.Name
                              select new
                              {
                                  Id = a.IdAddresses,
                                  DepartmentName = a.City.Department.Name,
                                  CityName = a.City.Name,
                                  Territory = GetTerritoryStr(a.Territory),
                                  Address = a.Street + " " + a.Number,
                                  Corner1 = a.Corner1,
                                  Corner2 = a.Corner2,
                                  Description = a.Description,
                                  HaveGeoposition = a.Lat != null && a.Lng != null
                              };
                return results.ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private string GetTerritoryStr(Territory t)
        {
            string rv = "";

            if (t != null)
                rv = t.Number + " - " + t.Name;

            return rv;
        }

        public Address NewObject()
        {
            Address rv = new Address();
            rv.Territory = new Territory();
            rv.City = new City();
            return rv;
        }

        public void DeleteAll()
        {
            try
            {
                _dm.address_DeleteAll();
                _dm.address_ResetId(0);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public List<string> GetPropertyList()
        {
            List<string> propertyList = new List<string>();
            
            System.Reflection.PropertyInfo[] properties = typeof(Address).GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.Name.Contains("City") && !prop.Name.Contains("Territory") && !prop.Name.Contains("Entity"))
                    propertyList.Add(prop.Name);
            }

            propertyList.Add("Territory.IdTerritory");
            propertyList.Add("Territory.Name");
            propertyList.Add("City.IdCity");
            propertyList.Add("City.Name");

            return propertyList;

        }

        #endregion

        private bool IsValid(Address v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Street))
            {
                if (!rv)
                    message += "\n";
                message += "Enter the street.";
                rv = false;
            }

            if (string.IsNullOrEmpty(v.Number) && string.IsNullOrEmpty(v.Corner1))
            {
                if (!rv)
                    message += "\n";
                message += "Enter the number or the corner.";
                rv = false;
            }

            //if (v.Territory == null || v.Territory.IdTerritory == 0)
            //{
            //    if (!rv)
            //        message += "\n";
            //    message += "Select any territory.";
            //    rv = false;
            //}

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
                              select new { Id = c.IdCity, Name = c.Name };                
                
                var rv = results.ToList();
                rv.Add(new { Id = 0, Name = "" });
                return rv.OrderBy(a => a.Name).ToList() ;
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
                              select new { Id = t.IdTerritory, Name = t.Number + " - " + t.Name };

                var rv = results.ToList();
                rv.Add(new { Id = 0, Name = "(no territory)" });
                return rv.OrderBy(a=>a.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreCompileQueries()
        {

            this._compiledLoadAddress = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from a in dm.Addresses
                                                               .Include("City.Department")
                                                               .Include("Territory")
                                                           where a.IdAddresses == id
                                                           select a
                );

            this._compiledGetAllAddresses = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm) => dm.Addresses.Include("City").Include("Territory").AsQueryable()
                );


        }
    }
}