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
        public List<string> GeoPositions;
        public List<string> Marks;

        // marker
        GMapMarker currentMarker;
        GMapMarker center;

        // layers
        GMapOverlay top;
        GMapOverlay objects;

        public frmGeoArea()
        {
            GeoPositions = new List<string>();
            Marks = new List<string>();
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

            List<PointLatLng> points = StrPointsToPointsLatLng(GeoPositions);
            PointLatLng middle = CalculateMiddlePoint(points);

            MainMap.CurrentPosition = middle;

            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);

            currentMarker = new GMapMarkerPolygon(MainMap.CurrentPosition, points);
            top.Markers.Add(currentMarker);

            List<PointLatLng> marks = StrPointsToPointsLatLng(this.Marks);
            foreach (var item in marks)
            {
                top.Markers.Add(new GMapMarkerGoogleCustom(item, Properties.Resources.legendIcon));
            }


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

            // add custom layers  
            {
                //routes = new GMapOverlay(MainMap, "routes");
                //MainMap.Overlays.Add(routes);

                objects = new GMapOverlay(MainMap, "objects");
                MainMap.Overlays.Add(objects);

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

        private List<PointLatLng> StrPointsToPointsLatLng(List<string> strPoints)
        {
            List<PointLatLng> points = new List<PointLatLng>();

            foreach (string item in strPoints)
            {
                string[] strArray = item.Split(' ');
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

        }
    }
}
