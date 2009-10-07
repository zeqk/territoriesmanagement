using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using System.Globalization;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;

namespace Territories.GUI
{
    public partial class frmGeoPoint : Form
    {
        // marker
        GMapMarker currentMarker;
        GMapMarker center;

        // layers
        GMapOverlay top;
        GMapOverlay objects;

	    public string Address
	    {
		    get { return txtAddress.Text;}
		    set { txtAddress.Text = value;}
	    }

        private string _geoPosition;

        public string GeoPosition
        {
	        get { return _geoPosition;}
	        set { _geoPosition = value;}
        }
	
	

        public frmGeoPoint()
        {
            InitializeComponent();

            
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords(txtAddress.Text);            
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void frmGeoPoint_Load(object sender, EventArgs e)
        {
            ConfigMap();

            string keywordToSearch = "";
            if (!string.IsNullOrEmpty(GeoPosition))
                keywordToSearch = GeoPosition;
            else
                keywordToSearch = Address;
            GoToAddress(keywordToSearch);
            
        }

        private void GoToAddress(string keywordToSearch)
        {
            

            GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords(keywordToSearch);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // set current marker
            currentMarker = new GMapMarkerGoogleCustom(MainMap.CurrentPosition, Properties.Resources.legendIcon);
            top.Markers.Add(currentMarker);

            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);
        }

        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            center.Position = point;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.GeoPosition = MainMap.CurrentPosition.Lat.ToString(new CultureInfo("en-US")) + " " + MainMap.CurrentPosition.Lng.ToString(new CultureInfo("en-US"));
            

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords("-34.77677 -58.31553");
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // set current marker
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(-34.77776,-58.31740));
            points.Add(new PointLatLng(-34.77885,-58.31646));
            points.Add(new PointLatLng(-34.77698,-58.31348));
            points.Add(new PointLatLng(-34.77535,-58.31506));
            currentMarker = new GMapMarkerPolygon(MainMap.CurrentPosition, points);
            top.Markers.Add(currentMarker);
        }
        
    }
}
