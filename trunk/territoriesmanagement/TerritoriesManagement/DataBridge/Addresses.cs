using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Resources;
using TerritoriesManagement.Model;
using GMap.NET;

namespace TerritoriesManagement.DataBridge
{
    public class Addresses : IDataBridge<Address>
    {
        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, int, IQueryable<Address>> _compiledLoadAddress;
        private Func<TerritoriesDataContext, IQueryable<Address>> _compiledGetAllAddresses;

        ResourceManager _rm;

        #region Contructors
        public Addresses()
        {
            _rm = new ResourceManager(this.GetType());
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Addresses(EntityConnection connection)
        {

            _rm = new ResourceManager(this.GetType());
            _dm = new TerritoriesDataContext(connection);
            PreCompileQueries();
        }

        #endregion

        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

        #region IDataBridge<Address> Members

        public Address Save(Address v)
        {
            
            string invalidMessage ="";
            if (IsValid(v, ref invalidMessage))
            {
                Address rv;
                if (v.IdAddress == 0)
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
                Address original = _compiledLoadAddress(_dm, v.IdAddress).FirstOrDefault();
                               

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
                Address d = _dm.addresses_GetById(id).First();
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
                                  Id = a.IdAddress,
                                  DepartmentName = a.City.Department.Name,
                                  CityName = a.City.Name,
                                  Territory = GetTerritoryStr(a.Territory),
                                  Address = a.Street + " " + a.Number,
                                  Corner1 = a.Corner1,
                                  Corner2 = a.Corner2,
                                  Description = a.Description,
                                  HasGeoposition = a.Lat != null && a.Lng != null,
                                  Lat = a.Lat,
                                  Lng = a.Lng
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
                _dm.addresses_DeleteAll();
                _dm.addresses_ResetId(0);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        #endregion

        private bool IsValid(Address v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Street))
            {
                if (!rv)
                    message += Environment.NewLine;
                message += GetString("Enter the street.");
                rv = false;
            }

            if (string.IsNullOrEmpty(v.Number) && string.IsNullOrEmpty(v.Corner1))
            {
                if (!rv)
                    message += Environment.NewLine;
                message += GetString("Enter the number or the corner.");
                rv = false;
            }

            if (v.City == null || v.City.IdCity == 0)
            {
                if (!rv)
                    message += Environment.NewLine;
                message += GetString("Select some city.");
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

        public IList GetCities()
        {
            try
            {
                var objectResults = _dm.cities_GetAll();
                var results = from city in objectResults
                              orderby city.Name
                              select new { Id = city.IdCity, Name = city.Name };
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

        public IList GetCitiesByDepartments(int[] ids)
        {
            try
            {
                IList rv = null;
                if (ids.Length > 0)
                {
                    
                    var objectResults = _dm.cities_GetByDepartment(ids[0]);
                    var results = from c in objectResults
                                  select new { Id = c.IdCity, Name = c.Name };

                    
                    var auxRv = results.ToList();

                    if (ids.Length > 1)
                    {
                        for (int i = 0; i < ids.Length; i++)
                            if (i != 0)
                            {
                                objectResults = _dm.cities_GetByDepartment(ids[i]);
                                results = from c in objectResults
                                              select new { Id = c.IdCity, Name = c.Name };
                                auxRv.AddRange(results.ToList());
                            }
                    }

                    auxRv.Add(new { Id = 0, Name = "" });
                    rv = auxRv.OrderBy(a => a.Name).ToList();
                }
                return rv;
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
                rv.Add(new { Id = 0, Name = GetString("(no territory)") });
                return rv.OrderBy(a=>a.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Territory FindTerritory(PointLatLng point)
        {
            Territory rv = null;

            var territories = _dm.territories_GetAll();           

            foreach (Territory t in territories)
            {
                if (t.Area != null && t.Area != "")
                {
                    List<PointLatLng> polygon = Functions.StrPointsToPointsLatLng(t.Area.Split('\n'));
                    if (PointInPolygon(point, polygon.ToArray()))
                    {
                        rv = t;
                        break; //todo para probar
                    }
                }
            }

            return rv;
        }

        private bool PointInPolygon(PointLatLng p, PointLatLng[] poly)
        {
            PointLatLng p1, p2;

            bool inside = false;

            if (poly.Length < 3)
            {
                return inside;
            }

            PointLatLng oldPoint = new PointLatLng(poly[poly.Length - 1].Lat, poly[poly.Length - 1].Lng);

            for (int i = 0; i < poly.Length; i++)
            {
                PointLatLng newPoint = new PointLatLng(poly[i].Lat, poly[i].Lng);
                if (newPoint.Lat > oldPoint.Lat)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.Lat < p.Lat) == (p.Lat <= oldPoint.Lat)
                    && (p.Lng - p1.Lng) * (p2.Lat - p1.Lat)
                     < (p2.Lng - p1.Lng) * (p.Lat - p1.Lat))
                {
                    inside = !inside;
                }
                oldPoint = newPoint;
            }

            return inside;
        }

        private void PreCompileQueries()
        {

            this._compiledLoadAddress = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from a in dm.Addresses
                                                               .Include("City.Department")
                                                               .Include("Territory")
                                                           where a.IdAddress == id
                                                           select a
                );

            this._compiledGetAllAddresses = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm) => dm.Addresses.Include("City").Include("Territory").AsQueryable()
                );


        }
    }
}
