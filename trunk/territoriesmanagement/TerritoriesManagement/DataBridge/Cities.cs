using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using TerritoriesManagement.Model;
using ZeqkTools.Internationalization;

namespace TerritoriesManagement.DataBridge
{                
    public class Cities : IDataBridge<City>
    {
        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, City, IQueryable<City>> _compiledSameCity;
        private Func<TerritoriesDataContext, int, IQueryable<City>> _compileLoadCity;
        private Func<TerritoriesDataContext, IQueryable<City>> _compileGetAllCities;
        private Globalization _gl;

        public string Globalization
        {
            get 
            { 
                return _gl.Culture.IetfLanguageTag; 
            }
            set 
            { 
                _gl = new Globalization(value); 
            }
        }
	
        #region Constructors
        public Cities()        
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
            _gl = new Globalization("en-US");            
        }

        public Cities(string culture)
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
            _gl = new Globalization(culture);
        }

        public Cities(EntityConnection conection)
        {
            _dm = new TerritoriesDataContext(conection);
            PreCompileQueries();
            _gl = new Globalization();

        }
        #endregion

        #region IGenericServer<City> Members

        public City Save(City v)
        {
            
            string invalidMessage = "";
            if (IsValid(v, ref invalidMessage))
            {
                City rv; 
                if (v.IdCity == 0)
                    rv = this.Insert(v);
                else
                    rv = this.Update(v);
                return rv;
            }
            else
                throw new Exception(invalidMessage);     
        }

        public City Insert(City v)
        {
            try
            {
                int idDepartment = v.Department.IdDepartment;
                v.Department = null;
                v.DepartmentReference.EntityKey = new EntityKey("TerritoriesDataContext.Departments", "IdDepartment", idDepartment);
                _dm.AddToCities(v);
                _dm.SaveChanges();

                return Load(v.IdCity); //devuelvo un objeto desatachado
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Cities);
                throw e;
            }
        }

        public City Update(City v)
        {
            try
            {
                int idDepartment = v.Department.IdDepartment;

                _dm.ApplyPropertyChanges("Cities", v);

                //set navigation property
                _dm.Cities.MergeOption = MergeOption.AppendOnly;
                City c = _compileLoadCity(_dm, v.IdCity).FirstOrDefault();
                //City c = _dm.cities_GetById(v.IdCity).First();
                c.Department = _dm.departments_GetById(idDepartment).FirstOrDefault(); ;
                //
                _dm.SaveChanges();

                return v;
                
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Cities);
                throw e;
            }
        }

        public void Delete(int id)
        {
            try                
            {
                City city = _dm.cities_GetById(id).First();
                _dm.DeleteObject(city);
                _dm.SaveChanges();
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Cities);
                throw e;
            }
        }

        public City Load(int id)
        {
            try
            {
                _dm.Cities.MergeOption = MergeOption.NoTracking;
                City rv = this._compileLoadCity(_dm, id).FirstOrDefault();

                //City rv = _dm.cities_GetById(id).FirstOrDefault();
                //rv.DepartmentReference.Load();

                //_dm.DetachByKey(rv.EntityKey);
                
                return rv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList Search (string strCriteria, params ObjectParameter[] parameters)
        {
            
            try
            {
                ObjectResult<City> objectResults;
                string strQuery = "SELECT VALUE City FROM TerritoriesDataContext.Cities AS City";

                if (strCriteria != "")
                    strQuery = strQuery + " WHERE " + strCriteria;

                var query = _dm.CreateQuery<City>(strQuery, parameters);
                    objectResults = query.Execute(MergeOption.AppendOnly);
                var results = from city in objectResults
                              orderby city.Name,city.Department.Name
                              select new { Id = city.IdCity, Name = city.Name, DepartmentName = city.Department.Name };
                return results.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

        public City NewObject()
        {
            City rv = new City();            
            return rv;

        }

        public void DeleteAll()
        {
            try
            {
                _dm.cities_DeleteAll();
                _dm.cities_ResetId(0);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<string> GetPropertyList()
        {
            List<string> propertyList = new List<string>();

            System.Reflection.PropertyInfo[] properties = typeof(City).GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.Name.Contains("Department") && !prop.Name.Contains("Addresses")
                    && !prop.Name.Contains("Entity") && !prop.Name.Contains("Publishers"))
                    propertyList.Add(prop.Name);
            }

            propertyList.Add("Department.IdDepartment");
            propertyList.Add("Department.Name");

            return propertyList;

        }

        #endregion

        public bool IsValid(City v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += "Enter city name.";
                rv = false;
            }
            if (Exist(v))
            {
                if (!rv)
                    message += "\n";
                message += "The city already exists. Correct and retrieve.";
                rv = false;
            }
            if (v.Department == null || v.Department.IdDepartment==0)
            {
                if (!rv)
                    message += "\n";
                message += "Select any department.";
                rv = false;
            }
            return rv;
        }

        public IDictionary LoadRelations(int id)
        {
            try
            {
                IDictionary rv = new Hashtable();

                City city = _dm.cities_GetById(id).First();
                city.Addresses.Load();
                city.Publishers.Load();

                var addresses = from a in city.Addresses
                                 orderby a.Street, a.Number
                                 select new 
                                 { 
                                     Id = a.IdAddress, 
                                     Address = a.Street + " " + a.Number,
                                     Corners = a.Corner1
                                 };

                var publishers = from pub in city.Publishers
                                 orderby pub.Name
                                 select new { Id = pub.IdPublisher, Name = pub.Name };

                rv.Add("Addresses", addresses.ToList());
                rv.Add("Publishers",publishers.ToList());
                
                return rv;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Exist(City v)
        {
            var found = _compiledSameCity(_dm, v).ToList();

            return (found.Count > 0);
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

        public TerritoriesManagement.Model.Department GetDepartmentById(int id)
        {
            try 
	        {
                return _dm.departments_GetById(id).FirstOrDefault(); ;
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
                    (TerritoriesDataContext dm,City v) => from city in dm.Cities
                                where city.Name == v.Name && 
                                      city.Department.IdDepartment == v.Department.IdDepartment &&
                                      city.IdCity != v.IdCity
                                select city

                );

            this._compileLoadCity = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from city in dm.Cities.Include("Department")
                                                           where city.IdCity == id
                                                           select city
                );

            this._compileGetAllCities = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm) => dm.Cities.Include("Department").AsQueryable()
                );
            
        }

        public string GetString(Type type, string text, string culture)
        {
            _gl.Culture = new System.Globalization.CultureInfo(culture);
            return _gl.GetString(type, text);
        }
    }
}
