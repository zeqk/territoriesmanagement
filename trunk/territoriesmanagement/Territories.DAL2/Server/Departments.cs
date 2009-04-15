﻿using System;
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

        public ObjectResult<Department> Search(string strQuery, params ObjectParameter[] parameters)
        {
            
            try
            {
                if (strQuery == null || strQuery == "")
                {                    
                    return _dm.Departments.Execute(MergeOption.AppendOnly);
                }
                else
                {
                    strQuery = "SELECT VALUE Department FROM TerritoriesDataContext.Departments AS Department WHERE " + strQuery;
                    return  _dm.CreateQuery<Department>(strQuery, parameters).Execute(MergeOption.AppendOnly);
                    
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

        public ObjectResult<Department> All()
        {
            return this.Search("");
        }

        #endregion

        private bool nameExist(Department v)
        {
            var results = from d in _dm.Departments
                          where d.Name == v.Name
                          select d.Name;

            if (results.Count<string>()>0)
                return true;
            else
                return false;
        }


        
    }
}
