using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    _dal.SaveChanges(_dm);                    
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

        public void Delete(Department v) //TODO
        {
            try                
            {
                //_dm.Attach(v);
                _dm.DeleteObject(v);
                _dal.SaveChanges(_dm);
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
                _dm.Departments.MergeOption = MergeOption.AppendOnly;
                Department results = _dal.ExecuteFirstOrDefault<Department>(_compiledLoadDepartment(_dm, id));
                return results;
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
                    var results = _dal.ExecuteList<KeyListItem>(_compiledAllDepartments(_dm));
                    return results;
                }
                else
                {
                    strQuery = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department WHERE " + strQuery;
                    ObjectQuery<Department> query = _dm.CreateQuery<Department>(strQuery, parameters);
                    var deps = from dep in _dal.ExecuteList<Department>(query)
                               orderby dep.Name
                               select new KeyListItem { Id = dep.IdDepartment, Name = dep.Name };
                    return deps.ToList<KeyListItem>();                         
                    
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
            rv.IdDepartment = 0;
            rv.Name = "";
            //rv.Cities = new EntitySet<City>();
            return rv;

        }

        public List<KeyListItem> All()
        {
            return this.Search("");
        }

        #endregion


        private bool nameExist(Department v)
        {
            var results = _dal.ExecuteList<Department>(_compiledSameDepartment(_dm,v));

            if (results.Count > 0)
                return true;
            else
                return false;
        }

        private Func<TerritoriesDataContext, int, IQueryable<Department>> _compiledLoadDepartment;

        private Func<TerritoriesDataContext, IQueryable<KeyListItem>> _compiledAllDepartments;

        private Func<TerritoriesDataContext, Department, IQueryable<Department>> _compiledSameDepartment;

        private void PreCompileQueries()
        {
            _compiledLoadDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext db,int id) => from dep in db.Departments.Include("Cities")
                                                          where dep.IdDepartment == id
                                                          select dep
                                                          
                );
            _compiledAllDepartments = CompiledQuery.Compile
                (
                    (TerritoriesDataContext db) => from dep in db.Departments
                                                   orderby dep.Name
                                                   select new KeyListItem 
                                                   { 
                                                        Id = dep.IdDepartment, 
                                                        Name = dep.Name
                                                   }
                );

            _compiledSameDepartment = CompiledQuery.Compile
                (
                    (TerritoriesDataContext db, Department v ) => from dep in db.Departments
                                                                  where dep.Name == v.Name && dep.IdDepartment!=v.IdDepartment
                                                                  select dep
                                                   
                );

        }
    }
}
