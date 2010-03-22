using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TerritoriesManagement.Model;
using GMap.NET;
using System.Data.Objects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace TerritoriesManagement
{
    public class Functions
    {
        static public IList GetEntities(string entity, string entitySet, string where, params ObjectParameter[] parameters)
        {            
            IList rv = null;
            string strQuery = "SELECT VALUE " + entity + " FROM TerritoriesDataContext." + entitySet + " AS " + entity;

            if (where != "")
                strQuery = strQuery + " WHERE " + where;

            if (parameters == null)
            {
                parameters = new ObjectParameter[0];
            }
            
            TerritoriesDataContext dm = new TerritoriesDataContext();

           
            try
            {
                if (entitySet.Equals("Addresses"))
                {
                    var query = dm.CreateQuery<Address>(strQuery, parameters).Include("Territory")
                                                                          .Include("City");
                    var res = query.Execute(MergeOption.AppendOnly);

                    rv = res.ToList();
                }

                if (entitySet.Equals("Territories"))
                {
                    var res = dm.CreateQuery<Territory>(strQuery, parameters).Execute(System.Data.Objects.MergeOption.AppendOnly);
                    rv = res.ToList();
                }

                if (entitySet.Equals("Cities"))
                {
                    var res = dm.CreateQuery<City>(strQuery, parameters).Include("Department")
                                                                        .Execute(System.Data.Objects.MergeOption.AppendOnly);
                    rv = res.ToList();
                }

                if (entitySet.Equals("Departments"))
                {
                    var res = dm.CreateQuery<Department>(strQuery, parameters).Execute(System.Data.Objects.MergeOption.AppendOnly);
                    rv = res.ToList();
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            

            return rv;


        }

        static public string GetEntitySetNameByEntityName(string entityName)
        {
            Dictionary<string, string> rv = new Dictionary<string, string>();
            rv.Add("Department", "Departments");
            rv.Add("City", "Cities");
            rv.Add("Address", "Addresses");
            rv.Add("Publisher", "Publishers");
            rv.Add("Tour", "Tours");
            rv.Add("Territory", "Territories");

            return rv[entityName];
        }

        static public Type GetEntityTypeByEntityName(string entityName)
        {
            return Type.GetType("TerritoriesManagement.Model." + entityName);
        }


        static public object GetPropertyValue(object obj, string propertyName)
        {
            object value = null;

            if (!propertyName.Contains('.'))
                value = obj.GetType().GetProperty(propertyName).GetValue(obj, null);
            else
            {
                string[] subProperty = propertyName.Split('.');
                object refProperty = obj.GetType().GetProperty(subProperty[0]).GetValue(obj, null);
                if (refProperty != null)
                    value = refProperty.GetType().GetProperty(subProperty[1]).GetValue(refProperty, null);
            }
            return value;
        }

        #region GetProperties

        static public List<string> GetPropertyListByType(Type type)
        {
            List<string> propertyList = new List<string>();

            System.Reflection.PropertyInfo[] properties = type.GetProperties();

            if (type == typeof(City))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("Department") && !prop.Name.Contains("Addresses")
                        && !prop.Name.Contains("Entity") && !prop.Name.Contains("Publishers"))
                        propertyList.Add(prop.Name);
                }

                propertyList.Add("Department.IdDepartment");
                propertyList.Add("Department.Name");
            }

            if(type == typeof(Address))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("City") && !prop.Name.Contains("Territory") && !prop.Name.Contains("Entity"))
                        propertyList.Add(prop.Name);
                }

                propertyList.Add("Territory.IdTerritory");
                propertyList.Add("Territory.Name");
                propertyList.Add("City.IdCity");
                propertyList.Add("City.Name");
            }

            if (type == typeof(Department))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("Cities") && !prop.Name.Contains("Entity"))
                        propertyList.Add(prop.Name);
                }
            }

            if (type == typeof(Territory))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("Tours") && !prop.Name.Contains("Addresses") && !prop.Name.Contains("Entity"))
                        propertyList.Add(prop.Name);
                }
            }


            return propertyList;

        }
        #endregion
    }
}
