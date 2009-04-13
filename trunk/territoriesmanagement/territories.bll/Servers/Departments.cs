using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Territories.DAL;

          
namespace Territories.BLL.Servers
{                
    public class Departments : IGenerics<Department>
    {
        private TerritoriesDataContext _dm;


        #region Constructors
        public Departments()        
        {
            _dm = new TerritoriesDataContext(); 
        }

        public Departments(TerritoriesDataContext dm)
        {
            _dm = dm;

        }
        #endregion

        #region IGenericServer<Department> Members

        public Department Insert(Department v)
        {
            try
            {
                //Department rv = _dm.departments_Add(v.IdDepartment, v.Name).First<Department>();
                _dm.AddToDepartments(v);
                _dm.SaveChanges();
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
                //Department rv = _dm.departments_UpdateById(v.IdDepartment, v.Name).First<Department>();
                _dm.AttachTo("Departments", v);
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
                return _dm.Departments.ElementAt<Department>(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Department> Search(string query, object[] parameters)
        {
            try
            {
                return _dm.Departments.Where(query, parameters).ToList<Department>();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void IsValid(Department v)
        {
            if (v.Name == "" || v.Name == null)
            {
                throw new Exception("The department name is invalid. Correct and retrieve.");
            }
        }

        public Department NewObject()
        {
            Department rv = new Department();
            rv.IdDepartment = 0;
            rv.Name = "";
            //rv.Cities = new EntitySet<City>();
            return rv;

        }

        public List<Department> All()
        {
            return _dm.Departments.ToList<Department>();
        }

        #endregion


        
    }
}
