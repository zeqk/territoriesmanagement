﻿using System;
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
using Territories.BLL;

namespace Territories.GUI
{
    public partial class frmGeoArea : Form
    {
        public List<PointLatLng> Area;
        public List<GMapMarker> Points;

        // marker
        GMapMarker center;

        // layers
        GMapOverlay top;

        public frmGeoArea()
        {
            Area = new List<PointLatLng>();
            Points = new List<GMapMarker>();
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
            //Seteo el centro del mapa
            PointLatLng middle = new PointLatLng(0, 0);
            if(Area.Count > 0)
                middle = Functions.CalculateMiddlePoint(Area);
            else
                if(Points.Count > 0)
                    middle = CalculateMiddlePoint(Points);

            MainMap.CurrentPosition = middle;

            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);

            if (Area.Count > 2)
            {
                GMapMarkerPolygon polygon = new GMapMarkerPolygon(MainMap.CurrentPosition, Area);
                top.Markers.Add(polygon);
            }
            foreach (var mark in Points)
                top.Markers.Add(mark);
        }

        private void ConfigMap()
        {
            Config.Config config = new Territories.GUI.Config.Config();
            config.LoadSavedConfig();

            // config gmaps
            GMaps.Instance.UseRouteCache = true;
            GMaps.Instance.UseGeocoderCache = true;
            GMaps.Instance.UsePlacemarkCache = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // config map 
            MainMap.MapType = config.MapType;
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

        

        

        private PointLatLng CalculateMiddlePoint(List<GMapMarker> marks)
        {
            var points = marks.Select(m => m.Position);

            PointLatLng point  = Functions.CalculateMiddlePoint(points.ToList());
            
            return point;

        }

        private RectLatLng CalculateRectangle(IList<GMapMarker> marks)
        {
            RectLatLng rect = new RectLatLng();

            if (marks.Count > 1)
            {
                double maxLat = marks.Max(m => m.Position.Lat);
                double minLat = marks.Min(m => m.Position.Lat);

                double maxLng = marks.Max(m => m.Position.Lng);
                double minLng = marks.Min(m => m.Position.Lng);

                double widthLat = maxLat - minLat;
                double heightLng = maxLng - minLng;

                rect = new RectLatLng(maxLat, minLng, heightLng, widthLat);
            }
            else
            {
                if (marks.Count > 0)
                {
                    SizeLatLng size = new SizeLatLng(0.005, 0.009);
                    PointLatLng point = new PointLatLng(marks[0].Position.Lat + 0.0025, marks[0].Position.Lng - 0.0045);
                    rect = new RectLatLng(point, size);
                    
                }
            }
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
            bool onlyPoints = false;
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
            {
                MainMap.SelectedArea = CalculateRectangle(Points);
                onlyPoints = true;
            }
            

            if (!MainMap.SelectedArea.IsEmpty)
            {
                StaticImage st = new StaticImage(MainMap);
                st.Owner = this;
                st.OnlyPoints = onlyPoints;
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

        private void MainMap_OnMapZoomChanged()
        {
            trackBar1.Value = MainMap.Zoom;
        }
    }
}
