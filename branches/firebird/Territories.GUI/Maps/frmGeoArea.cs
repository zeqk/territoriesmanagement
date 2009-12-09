using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Territories.GUI
{
    public partial class frmGeoArea : Form
    {
        public List<PointLatLng> Area;
        public List<GMapMarker> Marks;

        // marker
        GMapMarker currentMarker;
        GMapMarker center;

        // layers
        GMapOverlay top;

        public frmGeoArea()
        {
            Area = new List<PointLatLng>();
            Marks = new List<GMapMarker>();
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGeoArea_Load(object sender, EventArgs e)
        {
            ConfigMap();
            PointLatLng middle = CalculateMiddlePoint(Area);

            MainMap.CurrentPosition = middle;

            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);

            if (Area.Count > 3)
            {
                currentMarker = new GMapMarkerPolygon(MainMap.CurrentPosition, Area);
                top.Markers.Add(currentMarker);
            }
            foreach (var mark in Marks)
                top.Markers.Add(mark);
        }

        private void ConfigMap()
        {
            // config gmaps
            GMaps.Instance.UseRouteCache = true;
            GMaps.Instance.UseGeocoderCache = true;
            GMaps.Instance.UsePlacemarkCache = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // config map 
            MainMap.MapType = MapType.GoogleMap;
            MainMap.MaxZoom = 20;
            MainMap.MinZoom = 5;
            MainMap.Zoom = 16;

            //string[] geoPos = GeoPosition.Split(' ');

            MainMap.CurrentPosition = new PointLatLng();

            // map events
            MainMap.OnCurrentPositionChanged += new CurrentPositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            //MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            //MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
            //MainMap.OnEmptyTileError += new EmptyTileError(MainMap_OnEmptyTileError);
            //MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
            //MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            //MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            //MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            //MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);


            // map center
            //center = new GMapMarkerCross(MainMap.CurrentPosition);
            //top.Markers.Add(center);

            // get zoom  
            trackBar1.Minimum = MainMap.MinZoom;
            trackBar1.Maximum = MainMap.MaxZoom;
            trackBar1.Value = MainMap.Zoom;

            // add custom layers  
            {
                //routes = new GMapOverlay(MainMap, "routes");
                //MainMap.Overlays.Add(routes);

                top = new GMapOverlay(MainMap, "top");
                MainMap.Overlays.Add(top);
            }

            MainMap.ZoomAndCenterMarkers(null);
        }

        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            center.Position = point;
        }

        

        private PointLatLng CalculateMiddlePoint(List<PointLatLng> points)
        {
            double lat = 0;
            double lng = 0;

            List<double> lats = new List<double>();
            List<double> lngs = new List<double>();

            foreach (PointLatLng pos in points)
            {
                lats.Add(pos.Lat);
                lngs.Add(pos.Lng);
            }


            double latDistance = lats.Max() - lats.Min();
            double auxLat = latDistance / 2;
            lat = lats.Min() + auxLat;

            double lngDistance = lngs.Max() - lngs.Min();
            double auxLng = lngDistance / 2;
            lng = lngs.Min() + auxLng;

            PointLatLng point = new PointLatLng(lat, lng);
            return point;

        }

        private RectLatLng CalculateRectangle(IList<GMapMarker> marks)
        {
            RectLatLng rect = new RectLatLng();

            double maxLat = marks.Max(m => m.Position.Lat);
            double minLat = marks.Min(m => m.Position.Lat);

            double maxLng = marks.Max(m => m.Position.Lng);
            double minLng = marks.Min(m => m.Position.Lng);

            rect = new RectLatLng(maxLat, minLng, maxLng - minLng, maxLat - minLat);
            
            return rect;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenImage_Click(object sender, EventArgs e)
        {
            if (top.Markers[1].GetType() == typeof(GMapMarkerPolygon))
            {
                GMapMarkerPolygon polygon = (GMapMarkerPolygon)top.Markers[1];
                double maxLat = polygon.GeoPoints.Max(p => p.Lat);
                double minLat = polygon.GeoPoints.Min(p => p.Lat);

                double maxLng = polygon.GeoPoints.Max(p => p.Lng);
                double minLng = polygon.GeoPoints.Min(p => p.Lng);
                RectLatLng area = new RectLatLng(maxLat, minLng, maxLng - minLng, maxLat - minLat);
                MainMap.SelectedArea = area;
            }
            else
                MainMap.SelectedArea = CalculateRectangle(Marks);
            

            if (!MainMap.SelectedArea.IsEmpty)
            {
                StaticImage st = new StaticImage(MainMap);
                st.Owner = this;
                st.Show();
            }
            else
            {
                MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBar1.Value;
        }
    }
}
