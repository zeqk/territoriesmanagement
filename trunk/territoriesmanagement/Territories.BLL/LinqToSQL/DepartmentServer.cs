using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Data.Linq;
using Territories.DAL;

namespace Territories.BLL.LinqToSQL
{
    class DepartmentServer : IGenerics<Department>
    {
        private TerritoriesDataContext _db;
        

        #region Constructors
        public  DepartmentServer()
        {
            _db = new TerritoriesDataContext();
        }
        
        public DepartmentServer(TerritoriesDataContext db)
        {
            _db = db;           
                        
        }
        #endregion

        #region IGenericServer<Department> Members

        public void Insert(Department v)
        {
            try
            {                
                _db.Departments.InsertOnSubmit(v);
            }
            catch (Exception e)
            {
                
                throw e;

            }
        }

        public void Update(Department v)
        {
            try
            {
                _db.Departments.Attach(v);
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
                _db.Departments.DeleteOnSubmit(v);
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
                return _db.Departments.ElementAt<Department>(id);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public List<Department> Search(string query,object[] parameters)
        {
            try
            {
                return _db.Departments.Where(query, parameters).ToList<Department>();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public List<Department> All(string query, object[] parameters)
        {
            try
            {
                return _db.Departments.ToList<Department>();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void IsValid(Department v)
        {
            if (v.Name=="" || v.Name==null)
            {
                throw new Exception("The department name is invalid. Correct and retrieve.");
            }
        }

        public Department NewObject()
        {
            Department rv = new Department();
            rv.IdDepartment = 0;
            rv.Name = "";
            rv.Cities = new EntitySet<City>();
            return rv;

        }

        #endregion
    }
}
