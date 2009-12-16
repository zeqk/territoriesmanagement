using GMap.NET.WindowsForms.Markers;
namespace GMap.NET.WindowsForms.Markers
{
   using System.Drawing;
   using System.Collections.Generic;

   public class GMapMarkerPolygon : GMapMarker
   {
      public Pen Pen;

      public List<PointLatLng> GeoPoints;

      public GMapMarkerPolygon(PointLatLng p,List<PointLatLng> points)
          : base(p)
      {
         Pen = new Pen(Brushes.Blue, 3);
         GeoPoints = points;
      }

      public override void OnRender(Graphics g)
      {
        List<Point> points = new List<Point>();
        foreach (var gPoint in GeoPoints)
	    {
            System.Windows.Forms.GMapControl c = new System.Windows.Forms.GMapControl();
            
            GMap.NET.Point p = c.FromLatLngToLocal(gPoint);

            points.Add(new Point(p.X, p.Y));
	    }
          

        g.DrawPolygon(
      }
   }
}
