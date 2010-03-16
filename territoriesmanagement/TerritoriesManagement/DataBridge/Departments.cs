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
using System.Resources;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.DataBridge
{
    public class Departments : IDataBridge<TerritoriesManagement.Model.Department>
    {
        private TerritoriesDataContext _dm;
        private Func<TerritoriesDataContext, TerritoriesManagement.Model.Department, IQueryable<TerritoriesManagement.Model.Department>> _compiledSameDepartment;

        ResourceManager _rm;

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

        public Departments(TerritoriesDataContext dm)
        {
            _dm = dm;
            PreCompileQueries();
        }
        #endregion

        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

        #region IGenericServer<Department> Members

        public TerritoriesManagement.Model.Department Save(TerritoriesManagement.Model.Department v)
        {
            string invalidMessage = "";
            if (IsValid(v, ref invalidMessage))
            {
                TerritoriesManagement.Model.Department rv;                
                if (v.IdDepartment == 0)
                    rv = this.Insert(v);
                else
                    rv = this.Update(v);
                return rv;
            }
            else
                throw new Exception(invalidMessage); 
        }

        public TerritoriesManagement.Model.Department Insert(TerritoriesManagement.Model.Department v)
        {
            try
            {
                _dm.AddToDepartments(v);
                _dm.SaveChanges();
                return Load(v.IdDepartment); //devuelvo un objeto desatachado
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Departments);
                throw e;
            }
        }

        public TerritoriesManagement.Model.Department Update(TerritoriesManagement.Model.Department v)
        {
            try
            {
                _dm.ApplyPropertyChanges("Departments", v);
                _dm.SaveChanges();

                return v;                
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Departments);
                throw e;
            }
        }

        public void Delete(int id)
        {
            try                
            {
                TerritoriesManagement.Model.Department dep = _dm.departments_GetById(id).First();
                _dm.DeleteObject(dep);
                _dm.SaveChanges();
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Departments);
                throw e;
            }
        }

        public TerritoriesManagement.Model.Department Load(int id)
        {
            try
            {
                _dm.Departments.MergeOption = MergeOption.NoTracking;
                TerritoriesManagement.Model.Department rv = _dm.departments_GetById(id).FirstOrDefault();
                return rv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList Search(string strCriteria, params ObjectParameter[] parameters) 
        {            
            try
            {
                ObjectResult<TerritoriesManagement.Model.Department> objectResults;
                string strQuery = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department";

                if (strCriteria != "")
                    strQuery = strQuery + " WHERE " + strCriteria;

                var query = _dm.CreateQuery<TerritoriesManagement.Model.Department>(strQuery, parameters);
                    objectResults = query.Execute(MergeOption.AppendOnly);
                var results = from dep in objectResults
                              orderby dep.Name
                              select new { Id = dep.IdDepartment, Name = dep.Name };
                return results.ToList(); 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsValid(TerritoriesManagement.Model.Department v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += GetString("Enter department name.");
                rv = false;
            }
            if (Exist(v))
            {
                if (!rv)
                    message += Environment.NewLine;

                message += GetString("The department already exists. Correct and retrieve.");
                rv = false;
            }
            return rv;
        }

        public TerritoriesManagement.Model.Department NewObject()
        {
            TerritoriesManagement.Model.Department rv = new TerritoriesManagement.Model.Department();
            //rv.IdDepartment = 0;
            //rv.Name = "";
            //rv.Cities = new EntitySet<City>();
            return rv;

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

        public void DeleteAll()
        {
            try
            {
                _dm.departments_DeleteAll();
                _dm.departments_ResetId(0);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<string> GetPropertyList()
        {
            List<string> propertyList = new List<string>();

            System.Reflection.PropertyInfo[] properties = typeof(Model.Department).GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.Name.Contains("Cities") && !prop.Name.Contains("Entity"))
                    propertyList.Add(prop.Name);
            }

            return propertyList;

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
                             select new { Id = city.IdCity, Name = city.Name };
                rv.Add("Cities", cities.ToList());

                return rv;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private bool Exist(TerritoriesManagement.Model.Department v)
        {
            var found = _compiledSameDepartment(_dm, v).ToList();
            
            return (found.Count > 0);
        }

        private void PreCompileQueries()
        {

            _compiledSameDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, TerritoriesManagement.Model.Department v) => from dep in dm.Departments
                                                                 where dep.Name == v.Name && dep.IdDepartment != v.IdDepartment
                                                                 select dep

                );
        }
        
    }
}
