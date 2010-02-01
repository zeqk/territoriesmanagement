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

namespace ZeqkTools.WindowsForms.Maps
{
    public partial class frmGeoPoint : Form
    {
        public MapType MapType = MapType.GoogleMap;
        
        // marker
        GMapMarker currentMarker;
        GMapMarker center;

        // layers
        GMapOverlay top;
        GMapOverlay objects;

        bool isMouseDown;

	    public string Address
	    {
		    get { return txtAddress.Text;}
		    set { txtAddress.Text = value;}
	    }

        private PointLatLng _geoPosition;

        public PointLatLng GeoPosition
        {
	        get { return _geoPosition;}
	        set { _geoPosition = value;}
        }
	
	

        public frmGeoPoint()
        {
            InitializeComponent();
            _geoPosition = new PointLatLng();
        }

        

        private void btnGo_Click(object sender, EventArgs e)
        {            
            GoToAddress(txtAddress.Text);
        }

        private void ConfigMap()
        {
            cboMapType.DataSource = Enum.GetValues(MapType.GetType());

            isMouseDown = false;
            // config gmaps
            GMaps.Instance.UseRouteCache = true;
            GMaps.Instance.UseGeocoderCache = true;
            GMaps.Instance.UsePlacemarkCache = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;           

            // config map 
            MainMap.MapType = MapType;
            MainMap.MaxZoom = 20;
            MainMap.MinZoom = 5;
            MainMap.Zoom = 16;

            //string[] geoPos = GeoPosition.Split(' ');

            MainMap.CurrentPosition = new PointLatLng();

            // map events
            MainMap.OnCurrentPositionChanged += new CurrentPositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            //MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
            //MainMap.OnEmptyTileError += new EmptyTileError(MainMap_OnEmptyTileError);
            //MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
            //MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);

            // get zoom  
            trackBar1.Minimum = MainMap.MinZoom;
            trackBar1.Maximum = MainMap.MaxZoom;
            trackBar1.Value = MainMap.Zoom;

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
            cboMapType.DataSource = Enum.GetValues(typeof(GMap.NET.MapType));
            cboMapType.SelectedItem = MapType;

            ConfigMap();

            if (!GeoPosition.IsEmpty)
                GoToCoordinate(GeoPosition);
            else
                GoToAddress(this.Address);
            
        }

        private void GoToAddress(string keywordToSearch)
        {            

            GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords(keywordToSearch);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // set current marker
            currentMarker = new GMapMarkerGoogleRed(MainMap.CurrentPosition);
            top.Markers.Add(currentMarker);

            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);

            txtLat.Text = MainMap.CurrentPosition.Lat.ToString(CultureInfo.CurrentCulture);
            txtLng.Text = MainMap.CurrentPosition.Lng.ToString(CultureInfo.CurrentCulture);
        }

        private void GoToCoordinate(PointLatLng p)
        {
            MainMap.CurrentPosition = p;
            // set current marker
            currentMarker = new GMapMarkerGoogleRed(MainMap.CurrentPosition);
            top.Markers.Add(currentMarker);

            center = new GMapMarkerCross(MainMap.CurrentPosition);
            top.Markers.Add(center);

            txtLat.Text = MainMap.CurrentPosition.Lat.ToString(CultureInfo.CurrentCulture);
            txtLng.Text = MainMap.CurrentPosition.Lng.ToString(CultureInfo.CurrentCulture);
        }



        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            center.Position = point;
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                UpdateCurrentMarkerPositionText();
            }
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        void UpdateCurrentMarkerPositionText()
        {
            txtLat.Text = currentMarker.Position.Lat.ToString(CultureInfo.InvariantCulture);
            txtLng.Text = currentMarker.Position.Lng.ToString(CultureInfo.InvariantCulture);
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                UpdateCurrentMarkerPositionText();
            }
        }

        void MainMap_OnMarkerClick(GMapMarker item)
        {
            MainMap.CurrentPosition = item.Position;
            MainMap.Zoom = 5;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.GeoPosition = currentMarker.Position;            

            this.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBar1.Value;
        }


        private void MainMap_OnMapZoomChanged()
        {
            trackBar1.Value = MainMap.Zoom;
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GoToAddress(txtAddress.Text);
        }

        private void cboMapType_SelectedValueChanged(object sender, EventArgs e)
        {
            MainMap.MapType = (MapType)cboMapType.SelectedValue;
        }
        
    }
}
