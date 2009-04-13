using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Territories.DAL;


          
namespace Territories.DAL.Server
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
                return _dm.Departments.ElementAt<Department>(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Department> Search(string query, params ObjectParameter[] parameters)
        {
            
            try
            {
                if (query == null || query == "")
                    return _dm.departments_GetAll().ToList<Department>();
                else
                {
                    query = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department WHERE " + query;
                    return _dm.CreateQuery<Department>(query, parameters).ToList<Department>();

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

        public List<Department> All()
        {
            return this.Search("");
        }

        #endregion

        private bool nameExist(Department v)
        {

            ObjectParameter[] parameters = { new ObjectParameter("Name", v.Name) };

            ObjectResult<Department> results = _dm.CreateQuery<Department>("Name = '{0}'", parameters).Execute(MergeOption.AppendOnly);

            if (results.Count<Department>()>0)
                return true;
            else
                return false;
        }


        
    }
}
