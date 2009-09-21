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

        internal Departments(TerritoriesDataContext dm)
        {
            _dm = dm;
            PreCompileQueries();
        }
        #endregion

        #region IGenericServer<Department> Members

        public Department Save(Department v)
        {
            string invalidMessage = "";
            if (IsValid(v, ref invalidMessage))
            {
                Department rv;
                if (v.IdDepartment == 0)
                    rv = this.Insert(v);
                else
                    rv = this.Update(v);
                return rv;
            }
            else
                throw new Exception(invalidMessage); 
        }

        public Department Insert(Department v)
        {
            try
            {
                _dm.AddToDepartments(v);
                _dm.SaveChanges();
                return v;
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Departments);
                throw e;
            }
        }

        public Department Update(Department v)
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
                Department dep = _dm.departments_GetById(id).First();
                _dm.DeleteObject(dep);
                _dm.SaveChanges();
            }
            catch (Exception e)
            {
                _dm.Refresh(RefreshMode.StoreWins, _dm.Departments);
                throw e;
            }
        }

        public Department Load(int id)
        {
            try
            {
                _dm.Departments.MergeOption = MergeOption.NoTracking;
                Department rv = _dm.departments_GetById(id).FirstOrDefault();
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
                ObjectResult<Department> objectResults;
                string strQuery = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department";

                if (strCriteria != "")
                    strQuery = strQuery + " WHERE " + strCriteria;

                var query = _dm.CreateQuery<Department>(strQuery, parameters);
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

        public bool IsValid(Department v, ref string message)
        {
            bool rv = true;
            if (string.IsNullOrEmpty(v.Name))
            {
                message += "Enter department name.";
                rv = false;
            }
            if (Exist(v))
            {
                if (!rv)
                    message += "\n";
                message += "The department already exist. Correct and retrieve.";
                rv = false;
            }
            return rv;
        }

        public Department NewObject()
        {
            Department rv = new Department();
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
            throw new NotImplementedException();
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

        private bool Exist(Department v)
        {
            var found = _compiledSameDepartment(_dm, v).ToList();

            return (found.Count > 0);
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
