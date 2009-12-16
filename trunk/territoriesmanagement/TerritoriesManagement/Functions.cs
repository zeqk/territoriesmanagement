using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TerritoriesManagement.Model;
using GMap.NET;
using System.Data.Objects;

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
    }
}
