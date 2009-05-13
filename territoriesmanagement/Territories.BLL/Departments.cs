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
        private CommandExecutor _dal;

        private Func<TerritoriesDataContext, int,IQueryable<Department>> _compiledLoadDepartment;

        private Func<TerritoriesDataContext, IOrderedQueryable<Department>> _compiledAllDepartments;

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;

        private Func<TerritoriesDataContext, int, IOrderedQueryable<City>> _compiledCitiesByDepartment;

        #region Constructors
        public Departments()        
        {
            _dm = new TerritoriesDataContext();
            _dal = new CommandExecutor();
            PreCompileQueries();
        }

        public Departments(EntityConnection conection)
        {
            _dm = new TerritoriesDataContext(conection);
            _dal = new CommandExecutor();
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
                    this.SaveChanges();//TODO
                    
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
                    this.SaveChanges();//TODO
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
                this.SaveChanges();//TODO
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
                Department rv = _dal.ExecuteFirstOrDefault<Department>(_compiledLoadDepartment(_dm,id),MergeOption.PreserveChanges);
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
                    var queryResults = _dal.ExecuteList<Department>(_compiledAllDepartments(_dm));
                    var results = from dep in queryResults
                                  select new KeyListItem { Id = dep.IdDepartment, Name = dep.Name };
                    return results.ToList<KeyListItem>();
                }
                else
                {
                    strQuery = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department WHERE " + strQuery;
                    ObjectQuery<Department> query = _dm.CreateQuery<Department>(strQuery, parameters);                    
                    var results = from dep in _dal.ExecuteList<Department>(query)
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
                _dal.SaveChanges(_dm);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion


        public IList GetRelations(int id)
        {
            try
            {
                IList rv = new ArrayList();
                var queryResults = _dal.ExecuteList<City>(_compiledCitiesByDepartment(_dm,id));
                var cities = from city in queryResults
                              select new KeyListItem { Id = city.IdCity, Name = city.Name };
                rv.Add(cities);
                return rv;  
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private bool nameExist(Department v)
        {
            var results = _dal.ExecuteList<Department>(_compiledSameDepartment(_dm,v),MergeOption.PreserveChanges);

            if (results.Count > 0)
                return true;
            else
                return false;
        }

        private void PreCompileQueries()
        {
            _compiledLoadDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int id) => from dep in dm.Departments
                                                           where dep.IdDepartment == id
                                                           select dep

                );
            _compiledAllDepartments = CompiledQuery.Compile
                (
                     (TerritoriesDataContext dm) => from dep in dm.Departments
                                                   orderby dep.Name
                                                   select dep
                );

            _compiledSameDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, Department v) => from dep in dm.Departments
                                                                 where dep.Name == v.Name && dep.IdDepartment != v.IdDepartment
                                                                 select dep

                );

            _compiledCitiesByDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext dm, int idDep) => from city in dm.Cities
                                                              where city.Department.IdDepartment == idDep
                                                              orderby city.Name
                                                              select city
                );

        }
    }
}
