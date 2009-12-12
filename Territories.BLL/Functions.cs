using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Territories.Model;
using GMap.NET;
using System.Data.Objects;

namespace Territories.BLL
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

        static public PointLatLng CalculateMiddlePoint(List<PointLatLng> points)
        {

            double lat = 0;
            double lng = 0;

            //la distancia de la latitud. la mayor latitud - la menor latitud
            double latDistance = points.Max(p => p.Lat) - points.Min(p => p.Lat);
            //la mitad de la distancia
            double auxLat = latDistance / 2;
            //calculo el punto medio entre la latitud mayor y la latitud menor
            lat = points.Min(p => p.Lat) + auxLat;

            double lngDistance = points.Max(p => p.Lng) - points.Min(p => p.Lng);
            double auxLng = lngDistance / 2;
            lng = points.Min(p => p.Lng) + auxLng;

            PointLatLng point = new PointLatLng(lat, lng);

            return point;

        }
    }
}
