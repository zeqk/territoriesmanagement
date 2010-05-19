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
using GMap.NET.WindowsForms.ToolTips;
using ZeqkTools.WindowsForms.Maps;
using System.Collections;
using System.Data.Objects;
using TerritoriesManagement.Model;
using TerritoriesManagement.DataBridge;

namespace TerritoriesManagement.GUI
{
    public partial class frmMap : Form
    {

        Addresses server = new Addresses();
        #region Fields
        private MapType _mapType;
        private int _mapZoom;
        private bool _allowDrawPolygon;     
               
        private GMapPolygon currentPolygon;

        public object Object;
        #endregion

        #region Internal variables  

        // markers
        GMapMarker center;
        GMapMarker currentMarker;

        // layers
        GMapOverlay top;

        bool isMouseDown;
        #endregion

        #region Public properties

        /// <summary>
        /// Get set the main polygon
        /// </summary>
        public GMapPolygon Polygon
        {
            get 
            {                
                return currentPolygon;            
            }
            private set
            {
                currentPolygon = value;
            }
        }

        /// <summary>
        /// Get set the address to center the map
        /// </summary>
        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public MapType MapType
        {
            get { return _mapType; }
            set { _mapType = value; }
        }

        public int MapZoom
        {
            get { return _mapZoom; }
            set { _mapZoom = value; }
        }

        public bool AllowDrawPolygon
        {
            get { return _allowDrawPolygon; }
            set { _allowDrawPolygon = value; }
        }
	
        #endregion        

        #region Constructors
        public frmMap()
        {
            //contruct fields
            _mapType = MapType.GoogleMap;
            _mapZoom = 15;

            currentPolygon = new GMapPolygon(new List<PointLatLng>(), "MyPolygon");
            
            InitializeComponent();
        }
        #endregion
        private void frmGeoArea_Load(object sender, EventArgs e)
        {
            ConfigureAdditionalData();
            //Load comboboxes
            cboMapType.DataSource = Enum.GetValues(_mapType.GetType());

            //Config map
            ConfigMap();
                        
            string areaStr = (string)Functions.GetPropertyValue(Object,"Area");
            if(areaStr != null)
            {
                List<PointLatLng> auxPoints = Functions.StrPointsToPointsLatLng(areaStr.Split('\n'));
                currentPolygon.Points.AddRange(auxPoints);
            }
            //get the center of the markers
            PointLatLng? middle = null;
            if (currentPolygon.Points.Count > 0)                
                middle = ZeqkTools.Functions.CalculateMiddlePoint(currentPolygon);

            //set the center of the map
            if (middle.HasValue)
            {
                MainMap.CurrentPosition = middle.Value;
                center = new GMapMarkerCross(MainMap.CurrentPosition);
                top.Markers.Add(center);

                // set current marker
                if (!_allowDrawPolygon)
                {
                    currentMarker = new GMapMarkerGoogleRed(MainMap.CurrentPosition);
                    top.Markers.Add(currentMarker);
                }
            }

            //config the polygon             
            top.Polygons.Add(currentPolygon);

            if (_allowDrawPolygon)
                MainMap.SetDrawingPolygon(currentPolygon);

            if (center == null)
                GoToAddress(Address);            

        }

        private void ConfigMap()
        {
            // config gmaps
            GMaps.Instance.UseRouteCache = true;
            GMaps.Instance.UseGeocoderCache = true;
            GMaps.Instance.UsePlacemarkCache = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // config map 
            MainMap.MapType = _mapType;
            MainMap.MaxZoom = 20;
            MainMap.MinZoom = 5;
            MainMap.Zoom = _mapZoom;

            MainMap.CurrentPosition = new PointLatLng();
            MainMap.PolygonsEnabled = true;
            MainMap.AllowDrawPolygon = _allowDrawPolygon;

            // map events
            MainMap.OnCurrentPositionChanged += new CurrentPositionChanged(MainMap_OnCurrentPositionChanged);
            MainMap.OnMapZoomChanged += new MapZoomChanged(this.MainMap_OnMapZoomChanged);

            if (!_allowDrawPolygon)
            {
                MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
                MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
                MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
            }
            // get zoom  
            trackBarZoom.Minimum = MainMap.MinZoom;
            trackBarZoom.Maximum = MainMap.MaxZoom;
            trackBarZoom.Value = Convert.ToInt32(MainMap.Zoom);

            // add custom layers  
            {
                top = new GMapOverlay(MainMap, "top");
                MainMap.Overlays.Add(top);
            }

            MainMap.ZoomAndCenterMarkers("top");
        }

        private void GoToAddress(string keywordsToSearch)
        {

            GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords(keywordsToSearch);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // set current marker
            if (!_allowDrawPolygon)
            {
                if (currentMarker == null)
                {
                    currentMarker = new GMapMarkerGoogleRed(new PointLatLng());
                    top.Markers.Add(currentMarker);
                }

                currentMarker.Position = MainMap.CurrentPosition;
            }

            if (center == null)
                center = new GMapMarkerCross(new PointLatLng());
            
            center.Position = MainMap.CurrentPosition;
            if(!top.Markers.Contains(center))
                top.Markers.Add(center);

            txtLat.Text = MainMap.CurrentPosition.Lat.ToString(CultureInfo.CurrentCulture);
            txtLng.Text = MainMap.CurrentPosition.Lng.ToString(CultureInfo.CurrentCulture);
        }

        #region Map event methods

        private void MainMap_OnMapZoomChanged()
        {
            trackBarZoom.Value = Convert.ToInt32(MainMap.Zoom);
        }

        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            center.Position = point;
        }

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
        
        #endregion        

        #region Controls events methods

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnGenImage_Click(object sender, EventArgs e)
        {
            //calculate the area to print
            if (currentPolygon.Points.Count > 0)
                MainMap.SelectedArea = CalculateRectangle(currentPolygon.Points);
            else
                //MainMap.SelectedArea = CalculateRectangle(_secondaryMarkers.Select(m => m.Position).ToList()); TODO: generar el rectangulo segun los poligonos secundarios

            MainMap.SelectedArea = AddMargin(MainMap.SelectedArea);


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

        private void cboMapType_SelectedValueChanged(object sender, EventArgs e)
        {
            MainMap.MapType = (MapType)cboMapType.SelectedValue;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            GoToAddress(txtAddress.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MainMap.ClearDrawingPolygon();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarZoom.Value;
        }

        #endregion

        #region Auxiliar functions

        private PointLatLng CalculateMiddlePoint(params GMapMarker[] marks)
        {
            return CalculateMiddlePoint(marks.ToList());
        }

        private PointLatLng CalculateMiddlePoint(List<GMapMarker> marks)
        {
            List<PointLatLng> points = marks.Select(m => m.Position).ToList();

            PointLatLng point = ZeqkTools.Functions.CalculateMiddlePoint(points.ToList());

            return point;

        }

        private PointLatLng CalculateMiddlePoint(List<PointLatLng> marks)
        {

            PointLatLng point = ZeqkTools.Functions.CalculateMiddlePoint(marks);

            return point;
        }        

        private RectLatLng CalculateRectangle(IList<PointLatLng> points)
        {
            RectLatLng rect = new RectLatLng();

            if (points.Count > 1)
            {
                double maxLat = points.Max(p => p.Lat);
                double minLat = points.Min(p => p.Lat);

                double maxLng = points.Max(p => p.Lng);
                double minLng = points.Min(p => p.Lng);

                double widthLat = maxLat - minLat;
                double heightLng = maxLng - minLng;

                rect = new RectLatLng(maxLat, minLng, heightLng, widthLat);

            }
            else
            {
                if (points.Count > 0)
                {
                    SizeLatLng size = new SizeLatLng(0.005, 0.009);
                    PointLatLng point = new PointLatLng(points[0].Lat + 0.0025, points[0].Lng - 0.0045);
                    rect = new RectLatLng(point, size);

                }
            }
            return rect;
        }

        private RectLatLng AddMargin(RectLatLng rect)
        {
            rect.LocationTopLeft = new PointLatLng(rect.LocationTopLeft.Lat + 0.0009, rect.LocationTopLeft.Lng - 0.002);
            rect.HeightLat = rect.HeightLat + 0.0018;
            rect.WidthLng = rect.WidthLng + 0.004;

            return rect;
        }

        

        #endregion

        private void chklstTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void ConfigureAdditionalData()
        {

            var territoryList = server.GetTerritories();

            chklstTerritories.DisplayMember = "Name";
            chklstTerritories.ValueMember = "Id";
            chklstTerritories.DataSource = territoryList;
            grpTerritories.Visible = false;


            var departmentList = server.GetDepartments();

            chklstDepartment.DisplayMember = "Name";
            chklstDepartment.ValueMember = "Id";
            chklstDepartment.DataSource = departmentList;

            chklstCity.DisplayMember = "Name";
            chklstCity.ValueMember = "Id";

            chklstTerritory.DisplayMember = "Name";
            chklstTerritory.ValueMember = "Id";
            chklstTerritory.DataSource = territoryList;
            grpAddresses.Visible = false;

        }

        #region View territories
        private void btnTerritories_Click(object sender, EventArgs e)
        {
            grpTerritories.Visible = true;
        }

        private void btnViewTerritories_Click(object sender, EventArgs e)
        {
            top.Polygons.Clear();
            top.Polygons.Add(currentPolygon);

            IList territoriesToShow = GetTerritoriesToShow();
            if (territoriesToShow != null)
            {
                foreach (var item in territoriesToShow)
                {
                    string areaStr = (string)Functions.GetPropertyValue(item, "Area");
                    if (areaStr != null)
                    {
                        List<PointLatLng> vertices = Functions.StrPointsToPointsLatLng(areaStr.Split('\n'));
                        string terrName = (string)Functions.GetPropertyValue(item, "Name");
                        GMapPolygon polygon = new GMapPolygon(vertices, terrName);
                        top.Polygons.Add(polygon);
                    }
                }
            }

            grpTerritories.Visible = false;
            
        }

        private IList GetTerritoriesToShow()
        {
            IList rv = null;

            List<ObjectParameter> auxParameters = new List<ObjectParameter>();
            string queryStr = "";

            int currentId = 0;
            if (Object.GetType() == typeof(Territory))
                currentId = (int)Functions.GetPropertyValue(Object, "IdTerritory");

            //chklstTerritory
            if (chklstTerritories.CheckedItems.Count > 0)
            {
                if (auxParameters.Count > 0)
                    queryStr += " AND ";

                IList territoriesIds = chklstTerritories.CheckedItemsValues;

                string auxQueryStr = "";
                for (int i = 0; i < territoriesIds.Count; i++)
                {
                    int id = (int)territoriesIds[i];
                    if (id != 0 && id != currentId)
                    {
                        if (auxQueryStr != "")
                            auxQueryStr += " OR ";


                        string varName = "IdTerritory" + i.ToString();
                        auxQueryStr += "Territory.IdTerritory = @" + varName;
                        ObjectParameter param = new ObjectParameter(varName, territoriesIds[i]);
                        auxParameters.Add(param);
                    }
                }

                if (!string.IsNullOrEmpty(auxQueryStr))
                    queryStr += "(" + auxQueryStr + ")";
            }



            if (!string.IsNullOrEmpty(queryStr))
            {
                rv = new Territories().Search(queryStr, auxParameters.ToArray<ObjectParameter>());
            }

            return rv;
        }

        private void btnCancelTerritories_Click(object sender, EventArgs e)
        {
            grpTerritories.Visible = false;
        }

        #endregion

        #region View addresses
        private void btnAddresses_Click(object sender, EventArgs e)
        {
            grpAddresses.Visible = true;
        }

        private void btnViewAddresses_Click(object sender, EventArgs e)
        {
            IList addressesToShow = GetAddressToShow();

            if (addressesToShow != null)
            {
                foreach (var item in addressesToShow)
                {
                    double? lat = (double?)Functions.GetPropertyValue(item, "Lat");
                    double? lng = (double?)Functions.GetPropertyValue(item, "Lng");
                    if (lat.HasValue && lng.HasValue)
                    {
                        GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(lat.Value, lng.Value));
                        int? internalNumber = (int?)Functions.GetPropertyValue(item, "InternalTerritoryNumber");
                        if (internalNumber.HasValue)
                            marker.Tag = internalNumber.Value;
                        marker.ToolTipText = Functions.GetPropertyValue(item, "Address").ToString();
                        marker.Size = new System.Drawing.Size(4, 4);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        marker.Icon = Properties.Resources.legendIcon;
                        top.Markers.Add(marker);
                    }
                }
            }

            grpAddresses.Visible = false;
        }

        private void btnCancelAddresses_Click(object sender, EventArgs e)
        {
            grpAddresses.Visible = false;
        }

        private IList GetAddressToShow()
        {
            IList rv = null;

            List<ObjectParameter> parameters = new List<ObjectParameter>();
            string queryStr = GetAddressQuery(out parameters);
            if (!string.IsNullOrEmpty(queryStr))
            {
                rv = server.Search(queryStr, parameters.ToArray<ObjectParameter>());

            }

            return rv;
        }

        private string GetAddressQuery(out List<ObjectParameter> parameters)
        {
            List<ObjectParameter> auxParameters = new List<ObjectParameter>();
            string queryStr = "";

            //chklstTerritory
            if (chklstTerritory.CheckedItems.Count > 0)
            {
                if (auxParameters.Count > 0)
                    queryStr += " AND ";

                //int currentId = -1;
                //if (Object.GetType() == typeof(Territory))
                //    currentId = (int)Functions.GetPropertyValue(Object, "IdTerritory");

                var territories = chklstTerritory.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < territories.Count; i++)
                {
                    //if ((int)territories[i] != currentId)
                    //{
                    if (auxQueryStr != "")
                        auxQueryStr += " OR ";

                    if ((int)territories[i] != 0)
                    {
                        string varName = "IdTerritory" + i.ToString();
                        auxQueryStr += "Address.Territory.IdTerritory = @" + varName;
                        ObjectParameter param = new ObjectParameter(varName, territories[i]);
                        auxParameters.Add(param);
                    }
                    else
                        auxQueryStr += "Address.Territory IS NULL";
                    //}
                }
                if (!string.IsNullOrEmpty(auxQueryStr))
                    queryStr += "(" + auxQueryStr + ")";
            }

            //chklstCity
            if (chklstCity.CheckedItems.Count > 0)
            {
                if (auxParameters.Count > 0)
                    queryStr += " AND ";

                var cities = chklstCity.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < cities.Count; i++)
                {
                    if (auxQueryStr != "")
                        auxQueryStr += " OR ";

                    string varName = "IdCity" + i.ToString();
                    auxQueryStr += "Address.City.IdCity = @" + varName;
                    ObjectParameter param = new ObjectParameter(varName, cities[i]);
                    auxParameters.Add(param);
                }
                queryStr += "(" + auxQueryStr + ")";
            }
            else
            {
                //chklstDepartment
                if (chklstDepartment.CheckedItems.Count > 0)
                {
                    if (auxParameters.Count > 0)
                        queryStr += " AND ";

                    var cities = chklstDepartment.CheckedItemsValues;
                    string auxQueryStr = "";
                    for (int i = 0; i < cities.Count; i++)
                    {
                        if (auxQueryStr != "")
                            auxQueryStr += " OR ";

                        string varName = "IdDepartment" + i.ToString();
                        auxQueryStr += "Address.City.Department.IdDepartment = @" + varName;
                        ObjectParameter param = new ObjectParameter(varName, cities[i]);
                        auxParameters.Add(param);
                    }
                    queryStr += "(" + auxQueryStr + ")";
                }
            }

            parameters = auxParameters;
            return queryStr;
        }

        #endregion








    }
}
