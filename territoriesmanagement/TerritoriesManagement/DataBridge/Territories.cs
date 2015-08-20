using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.Collections;
using System.Resources;
using TerritoriesManagement.Model;
using GMap.NET;
using System.Linq.Expressions;

namespace TerritoriesManagement.DataBridge
{
    #region classes

    public class TerritoryItem1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Area { get; set; }
        public int AddressesCount { get; set; }
    }

    public class TerritoryItem2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    #endregion

    public class Territories : IDataBridge<Territory>
    {

        

        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, int, IQueryable<Territory>> _compileLoadTerritory;
        private Func<TerritoriesDataContext, Territory, IQueryable<Territory>> _compileSameTerritory;
        
        ResourceManager _rm;

        #region Constructors
        public Territories()
        {
            _rm = new ResourceManager(this.GetType());
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Territories(EntityConnection conection)
        {
            _rm = new ResourceManager(this.GetType());
            _dm = new TerritoriesDataContext(conection);
            PreCompileQueries();

        }
        #endregion

        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

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
                              select new TerritoryItem1
                                {
                                    Id = t.IdTerritory,
                                    Name = t.Name,
                                    Number = t.Number,
                                    Area = t.Area,
                                    AddressesCount = t.Addresses.Count
                                };
                return results.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<TerritoryItem1> SearchItem1(string name, bool hasAddresses)
        {
            try
            {
                Expression<Func<Territory,bool>> whereExp = null;
                if(hasAddresses)
                    whereExp = t => t.Name.ToUpper().Contains(name.ToUpper()) && t.Addresses.Count > 0;
                else
                    whereExp = t => t.Name.ToUpper().Contains(name.ToUpper());

                var rv = _dm.Territories.Where(whereExp)
                    .OrderBy(t => t.Number).ThenBy(t => t.Name)
                    .Select(t => 
                        new TerritoryItem1
                        { 
                            Id = t.IdTerritory, 
                            Name = t.Name, 
                            Number = t.Number, 
                            Area = t.Area, 
                            AddressesCount = t.Addresses.Count 
                        }
                        ).ToList();

                return rv;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<SimpleObject> SearchSimpleObject(string name, bool hasAddresses)
        {
            try
            {
                Expression<Func<Territory, bool>> whereExp = null;
                if (hasAddresses)
                    whereExp = t => t.Name.ToUpper().Contains(name.ToUpper()) && t.Addresses.Count > 0;
                else
                    whereExp = t => t.Name.ToUpper().Contains(name.ToUpper());

                var list = _dm.Territories.Where(whereExp)
                    .OrderBy(t => t.Number).ThenBy(t => t.Name)
                    .Select(t =>
                        new 
                        {
                            t.IdTerritory,
                            t.Number,
                            t.Name
                        }
                        ).ToList();
                var rv = list.Select(o =>
                        new SimpleObject
                        {
                            Value = o.IdTerritory.ToString(),
                            Text = (o.Number.HasValue ? o.Number.Value + " - " : string.Empty) + o.Name
                        }
                    ).ToList();


                return rv;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Territory> SearchByIds(IList<int> ids)
        {
            _dm.Territories.MergeOption = MergeOption.NoTracking;
            var rv = _dm.Territories.Where(t => ids.Contains(t.IdTerritory)).ToList();
            return rv;
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

        #endregion

        private bool IsValid(Territory v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += GetString("Enter territory name.");
                rv = false;
            }

            if (Exist(v))
            {
                message += GetString("The territory already exists. Correct and try again.");
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
                                     Id = a.IdAddress,
                                     Address = a.Street + " " + a.Number,
                                     Corners = a.Corner1
                                 };

                var tours = from tour in t.Tours
                                 orderby tour.TourNumber
                                 select new 
                                 { 
                                     Id = tour.IdTerritory, 
                                     Tour = tour.TourNumber, 
                                     StartDate  = tour.StartDate, 
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
                                                                where (t.Name == v.Name || t.Number == v.Number) && t.IdTerritory != v.IdTerritory
                                                                select t
                );

            this._compileLoadTerritory = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from t in dm.Territories
                                                           where t.IdTerritory == id
                                                           select t
                );
        }
    }
}
