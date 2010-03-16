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

        static public void Serialize(object obj, string path, bool overwrite)
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                TextWriter sw = new StreamWriter(path, !overwrite);

                serializer.Serialize(sw, obj);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public object Deserialize(Type type, string path)
        {
            try
            {
                object rv;

                XmlSerializer serializer = new XmlSerializer(type);
                TextReader sr = new StreamReader(path);
                rv = serializer.Deserialize(sr);
                sr.Close();
                return rv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
