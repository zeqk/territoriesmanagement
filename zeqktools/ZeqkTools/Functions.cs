using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeqkTools
{
    public class Functions
    {
        static public GeoPoint CalculateMiddlePoint(List<GeoPoint> points)
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

            GeoPoint point = new GeoPoint(lat, lng);

            return point;

        }
    }

    public struct GeoPoint
    {
        public double Lat, Lng;

        public GeoPoint(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}
