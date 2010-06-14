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
using System.Reflection;
using System.Globalization;

namespace TerritoriesManagement
{
    public class Functions
    {
        static public IList GetEntities(TerritoriesDataContext dm, string entity, string entitySet, string where, params ObjectParameter[] parameters)
        {            
            IList rv = null;
            string strQuery = "SELECT VALUE " + entity + " FROM TerritoriesDataContext." + entitySet + " AS " + entity;

            if (where != "")
                strQuery = strQuery + " WHERE " + where;

            if (parameters == null)
            {
                parameters = new ObjectParameter[0];
            }
           
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
                    var res = dm.CreateQuery<Territory>(strQuery, parameters).Execute(MergeOption.AppendOnly);
                    rv = res.ToList();
                }

                if (entitySet.Equals("Cities"))
                {
                    var res = dm.CreateQuery<City>(strQuery, parameters).Include("Department")
                                                                        .Execute(MergeOption.AppendOnly);
                    rv = res.ToList();
                }

                if (entitySet.Equals("Departments"))
                {
                    var res = dm.CreateQuery<Department>(strQuery, parameters).Execute(MergeOption.AppendOnly);
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
        
        static public List<Property> GetPropertyListByType(Type type)
        {
            List<Property> propertyList = new List<Property>();

            PropertyInfo[] properties = type.GetProperties();

            if (type == typeof(City))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("Department") && !prop.Name.Contains("Addresses")
                        && !prop.Name.Contains("Entity") && !prop.Name.Contains("Publishers"))
                        propertyList.Add(new Property(prop.Name,prop.PropertyType));
                }

                propertyList.Add(new Property("Department.IdDepartment",typeof(int)));
                propertyList.Add(new Property("Department.Name",typeof(string)));
            }

            if(type == typeof(Address))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("City") && !prop.Name.Contains("Territory") && !prop.Name.Contains("Entity"))
                        propertyList.Add(new Property(prop.Name,prop.PropertyType));
                }

                propertyList.Add(new Property("InternalTerritoryNumber", typeof(int)));
                propertyList.Add(new Property("Territory.IdTerritory",typeof(int)));
                propertyList.Add(new Property("Territory.Name",typeof(string)));

                propertyList.Add(new Property("City.IdCity",typeof(int)));
                propertyList.Add(new Property("City.Name",typeof(string)));
            }

            if (type == typeof(Department))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("Cities") && !prop.Name.Contains("Entity"))
                        propertyList.Add(new Property(prop.Name,prop.PropertyType));
                }
            }

            if (type == typeof(Territory))
            {
                foreach (var prop in properties)
                {
                    if (!prop.Name.Contains("Tours") && !prop.Name.Contains("Addresses") && !prop.Name.Contains("Entity"))
                        propertyList.Add(new Property(prop.Name,prop.PropertyType));
                }
            }


            return propertyList;

        }

        static public List<string> GetPropertyStrListByTypeName(string typeName)
        {
            Type type = Type.GetType("TerritoriesManagement.Model." + typeName);
            List<string> propertyList = GetPropertyListByType(type).Select(P => P.Name).ToList();


            return propertyList;

        }        

        static public bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        static public Type NullableToType(Type type)
        {
            System.ComponentModel.NullableConverter nc = new System.ComponentModel.NullableConverter(type);
            Type underlyingType = nc.UnderlyingType;
            return underlyingType;
        }

        static public DateTime GetLastModDate()
        {
            try
            {
                TerritoriesDataContext dm = new TerritoriesDataContext();
                DateTime last = dm.autids_getLastModification().First();
                dm.Dispose();
                return last;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #region Maps methods
        static public List<PointLatLng> StrPointsToPointsLatLng(string[] strPoints)
        {
            List<PointLatLng> points = new List<PointLatLng>();

            for (int i = 0; i < strPoints.Length; i++)
            {

                string[] strArray = strPoints[i].Split(' ');
                bool canParse = true;
                double lat = 0;
                double lng = 0;
                if (!double.TryParse(strArray[0], NumberStyles.Any, new CultureInfo("en-US"), out lat))
                    canParse = false;

                if (!double.TryParse(strArray[1], NumberStyles.Any, new CultureInfo("en-US"), out lng))
                    canParse = false;

                if (canParse)
                {
                    PointLatLng point = new PointLatLng(lat, lng);
                    points.Add(point);
                }
            }

            return points;
        }
        #endregion
    }

    
}
