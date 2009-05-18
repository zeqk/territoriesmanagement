using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Territories.Model;
using Territories.DAL;
          
namespace Territories.BLL
{
    public class Departments : IDataBridge<Department>
    {
        private TerritoriesDataContext _dm;      

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;

        #region Constructors
        public Departments()        
        {
            _dm = new TerritoriesDataContext();
            PreCompileQueries();
        }

        public Departments(EntityConnection conection)
        {
            _dm = new TerritoriesDataContext(conection);
            PreCompileQueries();
        }
        #endregion

        #region IGenericServer<Department> Members

        public Department Insert(Department v)
        {
            try
            {
                if (this.IsValid(v))
                {
                    _dm.AddToDepartments(v);
                    _dm.SaveChanges();                    
                }

                return v;
            }
            catch (Exception e)
            {

                throw e;

            }
        }

        public Department Update(Department v)
        {
            try
            {
                if (this.IsValid(v))
                {
                    _dm.ApplyPropertyChanges("Departments", v);
                    _dm.SaveChanges();
                }
                return v;
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(Department v)
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

        public Department Load(int id)
        {
            try
            {
                Department rv = _dm.departments_GetById(id).FirstOrDefault();
                return rv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<KeyListItem> Search(string strQuery, params ObjectParameter[] parameters) 
        {            
            try
            {
                if (strQuery == null || strQuery == "")
                {
                    var objectResults = _dm.departments_GetAll();
                    var results = from dep in objectResults
                                  select new KeyListItem { Id = dep.IdDepartment, Name = dep.Name };
                    return results.ToList<KeyListItem>();
                }
                else
                {
                    strQuery = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department WHERE " + strQuery;
                    ObjectQuery<Department> query = _dm.CreateQuery<Department>(strQuery, parameters);
                    var results = from dep in QueryExecutor.ExecuteList<Department>(query)
                               orderby dep.Name
                               select new KeyListItem { Id = dep.IdDepartment, Name = dep.Name };
                    return results.ToList<KeyListItem>();                         
                    
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool IsValid(Department v)
        {
            if (v.Name == "" || v.Name == null)
            {
                throw new Exception("The department name is invalid. Correct and retrieve.");
            }
            if (nameExist(v))
            {
                throw new Exception("The department already exist. Correct and retrieve.");
            }


            return true;
        }

        public Department NewObject()
        {
            Department rv = new Department();
            //rv.IdDepartment = 0;
            //rv.Name = "";
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
                var queryResults = _dm.cities_GetByDepartment(id);
                var cities = from city in queryResults
                             orderby city.Name
                             select new KeyListItem { Id = city.IdCity, Name = city.Name };
                rv.Add("Cities", cities.ToList());

                return rv;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private bool nameExist(Department v)
        {
            var results = QueryExecutor.ExecuteList<Department>(_compiledSameDepartment(_dm, v), MergeOption.PreserveChanges);

            if (results.Count > 0)
                return true;
            else
                return false;
        }

        private void PreCompileQueries()
        {

            _compiledSameDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Department v) => from dep in dm.Departments
                                                                 where dep.Name == v.Name && dep.IdDepartment != v.IdDepartment
                                                                 select dep

                );
        }
    }
}
