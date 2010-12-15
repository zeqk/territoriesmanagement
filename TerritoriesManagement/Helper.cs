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
        static public IList GetEntities(TerritoriesDataContext dm,string entityName, string where, params ObjectParameter[] parameters)
        {
            IList rv = null;
            string entitySet = GetEntitySetNameByEntityName(dm,entityName);
            Type type = GetEntityTypeByEntityName(entityName);

            List<string> relatedEntities = GetRelatedEntities(entityName);

            string strQuery = "SELECT VALUE " + entityName + " FROM TerritoriesDataContext." + entitySet + " AS " + entityName;

            if (where != "")
                strQuery = strQuery + " WHERE " + where;

            if (parameters == null)
            {
                parameters = new ObjectParameter[0];
            }

            try
            {
                var query = dm.CreateQuery(entityName, strQuery, parameters);
                
                foreach (string relatedEntity in relatedEntities)
                    Include(ref query, relatedEntity);
                
                ObjectResult result =  query.Execute(MergeOption.AppendOnly);
                
                rv = (IList)ExecuteLinqMethod(result, "ToList", type);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return rv;

        }

        private static void Include(ref ObjectQuery query, string relatedEntity)
        {
            string[] parameters = { relatedEntity };
            query.GetType().GetMethod("Include").Invoke(query, parameters);
        }

        public static object ExecuteMethod(object obj, string methodName, params object[] parameters)
        {
            return obj.GetType().GetMethod(methodName).Invoke(obj, parameters);
        }

        public static object ExecuteMethod(object obj, string methodName, Type genericType, params object[] parameters)
        {
            Type[] parametersTypes = new Type[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
                parametersTypes[i] = parameters[i].GetType();

            MethodInfo method = obj.GetType().GetMethod(methodName, parametersTypes);
            method = method.MakeGenericMethod(genericType);
            return method.Invoke(obj, parameters);
        }

        public static object ExecuteLinqMethod(object obj, string methodName, Type genericType, params object[] parameters)
        {
            MethodInfo method = typeof(Enumerable).GetMethod(methodName);
            method = method.MakeGenericMethod(genericType);
            return method.Invoke(obj,null);
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

        static public string GetEntitySetNameByEntityName(ObjectContext context, string entityName)
        {
            string rv = null;

            PropertyInfo[] props = context.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType.Name == "ObjectQuery`1")
                {
                    if (prop.PropertyType.GetGenericArguments()[0].Name == entityName)
                    {
                        rv = prop.Name;
                        break;
                    }
                }
            }

            return rv;
        }

        static public string GetEntityNameByEntitySetName(string entitySetName)
        {
            TerritoriesDataContext dm = new TerritoriesDataContext();
            return GetEntityNameByEntitySetName(dm, entitySetName);
        }

        static public string GetEntityNameByEntitySetName(ObjectContext context, string entitySetName)
        {
            string rv = null;
            PropertyInfo entitySet = context.GetType().GetProperty(entitySetName);
            if (entitySet != null)
                if (entitySet.PropertyType.Name == "ObjectQuery`1")
                    rv = entitySet.PropertyType.GetGenericArguments()[0].Name;
            return rv;
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

        static public PointLatLng? AddressToGeoPos(string address)
        {
            GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
            PointLatLng? pos = GMaps.Instance.GetLatLngFromGeocoder(address, out status);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
                pos = null;
            return pos;
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
