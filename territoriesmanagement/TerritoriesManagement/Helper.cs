using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using GMap.NET;
using TerritoriesManagement.Model;

namespace TerritoriesManagement
{
    public class Helper
    {
        static public IList GetEntities<TEntity>(TerritoriesDataContext dm, string where, params ObjectParameter[] parameters)
        {
            IList rv = null;
            string entity = typeof(TEntity).Name;
            string entitySet = GetEntitySetNameByEntityName(entity);

            List<string> relatedEntities = GetRelatedEntities(entity);

            string strQuery = "SELECT VALUE " + entity + " FROM TerritoriesDataContext." + entitySet + " AS " + entity;

            if (where != "")
                strQuery = strQuery + " WHERE " + where;

            if (parameters == null)
            {
                parameters = new ObjectParameter[0];
            }

            try
            {
                var query = dm.CreateQuery<TEntity>(strQuery, parameters);

                foreach (string relatedEntity in relatedEntities)
                    query.Include(relatedEntity);

                var res = query.Execute(MergeOption.AppendOnly);
                rv = res.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return rv;


        }
       
        static public List<string> GetRelatedEntities(string entityName)
        {
            List<string> entities = new List<string>();
            Type type = GetEntityTypeByEntityName(entityName);
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType.BaseType.FullName == "System.Data.Objects.DataClasses.EntityObject")
                    entities.Add(prop.Name);
            }   

            return entities;
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

        static public string GetEntityNameByEntitySetName(string entitySetName)
        {
            Dictionary<string, string> rv = new Dictionary<string, string>();
            rv.Add("Departments", "Department");
            rv.Add("Cities", "City");
            rv.Add("Addresses", "Address");
            rv.Add("Publishers", "Publisher");
            rv.Add("Tours", "Tour");
            rv.Add("Territories", "Territory");

            return rv[entitySetName];
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
            
            
            foreach (var prop in properties)
            {
                if (!(prop.PropertyType.BaseType.FullName == "System.Data.Objects.DataClasses.RelatedEnd") &&
                    !(prop.PropertyType.BaseType.FullName == "System.Data.Objects.DataClasses.StructuralObject") &&
                    !(prop.PropertyType.BaseType.FullName == "System.Data.Objects.DataClasses.EntityReference") &&
                    !(prop.PropertyType.BaseType.FullName == "System.Data.Objects.DataClasses.EntityObject") &&
                    !(prop.PropertyType.FullName == "System.Data.EntityKey") &&
                    !(prop.PropertyType.FullName == "System.Data.EntityState"))
                    propertyList.Add(new Property(prop.Name,prop.PropertyType));
            }

            if (type == typeof(City))
            {
                propertyList.Add(new Property("Department.IdDepartment", typeof(int)));
                propertyList.Add(new Property("Department.Name", typeof(string)));

            }
                

            if(type == typeof(Address))
            {
                propertyList.Add(new Property("Territory.IdTerritory",typeof(int)));
                propertyList.Add(new Property("Territory.Name",typeof(string)));

                propertyList.Add(new Property("City.IdCity",typeof(int)));
                propertyList.Add(new Property("City.Name",typeof(string)));
            }

            return propertyList;

        }

        static public List<Property> GetPropertyListByType(string typeName)
        {
            Type type = Type.GetType("TerritoriesManagement.Model." + typeName);

            return GetPropertyListByType(type);

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
