using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.Collections;
using Territories.Model;

namespace Territories.BLL.DataBridge
{
    public class Territories : IDataBridge<Territory>
    {
        private TerritoriesDataContext _dm;

        private Func<TerritoriesDataContext, int, IQueryable<Territory>> _compileLoadTerritory;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compileSameTerritory;

        #region Constructors
        public Territories()        
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Territories(EntityConnection conection)
        {
            _dm = new TerritoriesDataContext(conection);
            PreCompileQueries();

        }
        #endregion

        #region IDataBridge<Territory> Members

        public Territory Save(Territory v)
        {
            string invalidMessage = "";
            if (IsValid(v, ref invalidMessage))
            {                
                Territory rv;
                if (v.IdTerritory == 0)
                    rv = this.Insert(v);
                else
                    rv = this.Update(v);
                return rv;
            }
            else
                throw new Exception(invalidMessage);    
        }

        public Territory Insert(Territory v)
        {
            try
            {
                _dm.AddToTerritories(v);
                _dm.SaveChanges();
                return Load(v.IdTerritory); //devuelvo un objeto desatachado
            }
            catch (Exception ex)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Territories);
                throw ex;
            }
        }

        public Territory Update(Territory v)
        {
            try
            {
                _dm.ApplyPropertyChanges("Territories", v);
                _dm.SaveChanges();
                return v;
            }
            catch (Exception ex)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Territories);
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Territory territory = _dm.territories_GetById(id).First();
                _dm.DeleteObject(territory);
                _dm.SaveChanges();
            }
            catch (Exception ex)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Territories);
                throw ex;
            }
        }

        public Territory Load(int id)
        {
            try
            {
                _dm.Territories.MergeOption = MergeOption.NoTracking;
                Territory rv = this._compileLoadTerritory(_dm, id).First();
                rv.Addresses.Load();
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
                ObjectResult<Territory> objectResults;
                string strQuery = "SELECT VALUE Territory FROM TerritoriesDataContext.Territories AS Territory";

                if (strCriteria != "")
                    strQuery = strQuery + " WHERE " + strCriteria;

                var query = _dm.CreateQuery<Territory>(strQuery, parameters);
                objectResults = query.Execute(MergeOption.AppendOnly);
                var results = from t in objectResults
                              orderby t.Name, t.Number
                              select new { Id = t.IdTerritory, Name = t.Name, Number = t.Number };
                return results.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Territory NewObject()
        {
            Territory rv = new Territory();
            return rv;
        }

        public void DeleteAll()
        {
            try
            {
                _dm.territories_DeleteAll();
                _dm.territories_ResetId(0);
                    
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<string> GetPropertyList()
        {
            List<string> propertyList = new List<string>();

            System.Reflection.PropertyInfo[] properties = typeof(Territory).GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.Name.Contains("Tours") && !prop.Name.Contains("Addresses") && !prop.Name.Contains("Entity"))
                    propertyList.Add(prop.Name);
            }

            return propertyList;

        }

        #endregion

        private bool IsValid(Territory v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += "Enter territory name.";
                rv = false;
            }
            
            //if (v.Number==0)
            //{
            //    message += "Enter territory number.";
            //    rv = false;
            //}

            if (Exist(v))
            {
                message += "The territory already exist.";
                rv = false;
            }

            return rv;
        }

        private bool Exist(Territory v)
        {
            var found = _compileSameTerritory(_dm, v).ToList();

            return (found.Count > 0);
        }

        public IDictionary LoadRelations(int id)
        {
            try
            {
                IDictionary rv = new Hashtable();

                Territory t = _dm.territories_GetById(id).First();
                t.Addresses.Load();
                t.Tours.Load();

                var addresses = from a in t.Addresses
                                 orderby a.Street, a.Number
                                 select new
                                 {
                                     Id = a.IdAddresses,
                                     Address = a.Street + " " + a.Number,
                                     Corners = a.Corner1
                                 };

                var tours = from tour in t.Tours
                                 orderby tour.TourNumber
                                 select new 
                                 { 
                                     Id = tour.IdTerritory, 
                                     Tour = tour.TourNumber, 
                                     BeginDate  = tour.BeginDate, 
                                     EndDate = tour.EndDate
                                 };

                rv.Add("Addresses", addresses.ToList());
                rv.Add("Tours", tours.ToList());

                return rv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreCompileQueries()
        {
            this._compileSameTerritory = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Territory v) => from t in dm.Territories
                                                                where (t.Name ==v.Name || t.Number ==v.Number) && t.IdTerritory != v.IdTerritory
                                                                select t
                );

            this._compileLoadTerritory = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from t in dm.Territories
                                                           where t.IdTerritory ==id
                                                           select t
                );
        }
    }
}
