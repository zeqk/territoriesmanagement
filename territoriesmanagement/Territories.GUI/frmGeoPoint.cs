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

            // add your custom map db provider
            // MsSQLPureImageCache ch = new MsSQLPureImageCache();
            //ch.ConnectionString = @"Data Source=RADIOMAN-PC\SQLEXPRESS;Initial Catalog=Test;Persist Security Info=False;User ID=aa;Password=aa;";
            //GMaps.Instance.ImageCacheSecond = ch;

            // set your proxy here if need
            //GMaps.Instance.Proxy = new WebProxy("10.2.0.100", 8080);
            //GMaps.Instance.Proxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeadam");

            // config map 
            MainMap.MapType = MapType.GoogleMap;
            MainMap.MaxZoom = 12;
            MainMap.MinZoom = 2;
            MainMap.Zoom = 9;
            MainMap.CurrentPosition = new PointLatLng(54.6961334816182, 25.2985095977783);
            //MainMap.CurrentPosition = new PointLatLng(29.8741410626414, 121.563806533813); // china test

            // map events
            //MainMap.OnCurrentPositionChanged += new CurrentPositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            //MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            //MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
            //MainMap.OnEmptyTileError += new EmptyTileError(MainMap_OnEmptyTileError);
            //MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
            //MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            //MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            //MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            //MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);

           

            // get position
            //textBoxLat.Text = MainMap.CurrentPosition.Lat.ToString(CultureInfo.InvariantCulture);
            //textBoxLng.Text = MainMap.CurrentPosition.Lng.ToString(CultureInfo.InvariantCulture);

            

            // get zoom  
            //trackBar1.Minimum = MainMap.MinZoom;
            //trackBar1.Maximum = MainMap.MaxZoom;
            //trackBar1.Value = MainMap.Zoom;

            

            // set current marker
            currentMarker = new GMapMarkerGoogleRed(MainMap.CurrentPosition);
            top.Markers.Add(currentMarker);

            // map center
            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);

            // add my city location for demo
            //GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
            //{
            //   PointLatLng? pos = GMaps.Instance.GetLatLngFromGeocoder("Lithuania, Vilnius", out status);
            //   if(pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            //   {
            //      currentMarker.Position = pos.Value;

            //      GMapMarker myCity = new GMapMarkerGoogleGreen(pos.Value);
            //      myCity.TooltipMode = MarkerTooltipMode.Always;
            //      myCity.ToolTipText = "Welcome to Lithuania! ;}";
            //      objects.Markers.Add(myCity);
            //   }
            //}

            MainMap.ZoomAndCenterMarkers(null);
         }

        private void frmGeoPoint_Load(object sender, EventArgs e)
        {
            string keywordToSearch = "";
            if (!string.IsNullOrEmpty(GeoPosition))
                keywordToSearch = GeoPosition;
            else
                keywordToSearch = Address;

            GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords(keywordToSearch);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
    }
}
