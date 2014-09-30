using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AltosTools;
using AltosTools.WindowsForms.Maps;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using TerritoriesManagement.DataBridge;

namespace TerritoriesManagement.GUI
{
    public partial class frmMap : Form
    {

        Addresses server = new Addresses();

        private static frmMap Instance = null;
        static readonly object padlock = new object();

        #region Fields
        public int? TerritoryId = null;


        private GMapProvider _mapProvider;
        private int _mapZoom;
        private MapModeEnum _mapMode;

        private List<GMapPolygon> _otherPolygons;
        private List<GMapMarker> _otherMarkers;
        
        #endregion

        #region Internal variables  

        GMapPolygon currentPolygon;
        // markers
        GMapMarker currentMarker;

        // layers
        GMapOverlay top;

        bool isMouseDown;
        #endregion

        #region Public properties

        /// <summary>
        /// Get set the main polygon
        /// </summary>
        public GMapPolygon MainPolygon
        {
            get 
            {                
                return this.currentPolygon;            
            }
            set
            {
                this.currentPolygon = value;
            }

        }

        /// <summary>
        /// Get set the main marker
        /// </summary>
        public GMapMarker MainMarker
        {
            get
            {
                return currentMarker;
            }
            set
            {
                this.currentMarker = value;
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

        public List<GMapPolygon> OtherPolygons
        {
            get 
            {
                List<GMapPolygon> rv = top.Polygons.ToList();
                rv.Remove(currentPolygon);
                return rv;
            }
            set
            {
                _otherPolygons = value;
            }
        }

        public List<GMapMarker> OtherMarkers
        {
            get
            {
                List<GMapMarker> rv = top.Markers.ToList();
                rv.Remove(currentMarker);
                return rv;
            }
            set
            {
                _otherMarkers = value;
            }
        }


        public GMapProvider MapProvider
        {
            get { return _mapProvider; }
            set { _mapProvider = value; }
        }

        public int MapZoom
        {
            get { return _mapZoom; }
            set { _mapZoom = value; }
        }

        public MapModeEnum MapMode
        {
            get { return _mapMode; }
            set { _mapMode = value; }
        }
	
        #endregion        

        #region Constructors
        private frmMap()
        {
            //contruct fields
            _mapProvider = GMapProviders.GoogleMap;
            _mapZoom = 15;
            _mapMode = MapModeEnum.ReadOnly;

            InitializeComponent();
            
        }
        #endregion

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            lock (padlock)
            {
                if (Instance == null)
                {
                    Instance = new frmMap();
                }
            }
        }

        public static frmMap GetInstance()
        {
            if (Instance == null) CreateInstance();
            return Instance;
        }


        public void Clear()
        {
            MainMap.SelectedArea = new RectLatLng();
            currentMarker = null;
            currentPolygon = null;
            foreach (GMapOverlay overlay in MainMap.Overlays)
            {
                overlay.Markers.Clear();
            }

            MainMap.Overlays.Clear();
            _otherPolygons = null;
            _otherMarkers = null;    
        }

        private void frmGeoArea_Load(object sender, EventArgs e)
        {

            ConfigureAdditionalData();

            //load comboboxes
            cboMapType.DataSource = GMapProviders.List;
            cboMapType.DisplayMember = "Name";
            
            //config map
            ConfigMap();

            //extract data from the Object property
            //ExtractObjectData();
            //set the objects to edit
            SetObjectToEdit();

            if (_otherMarkers != null)
            {
                foreach (GMapMarker item in _otherMarkers)
                    top.Markers.Add(item);
            }

            if (_otherPolygons != null)
            {
                foreach (GMapPolygon item in _otherPolygons)
                    top.Polygons.Add(item);
            }

            if (!SetCenter(null))
                GoToAddress(this.Address);
        }

        void SetObjectToEdit()
        {

            if (_mapMode == MapModeEnum.EditPoint)
            {
                if (currentMarker != null)
                    top.Markers.Add(currentMarker);
            }

            if (_mapMode == MapModeEnum.EditArea)
            {
                if (currentPolygon == null)
                    currentPolygon = new GMapPolygon(new List<PointLatLng>(), "MyPolygon");

                MainMap.SetDrawingPolygon(currentPolygon);
                ViewAddresses();
            }


        }

        private void ConfigMap()
        {
            // config gmaps
            GMaps.Instance.UseRouteCache = true;
            GMaps.Instance.UseGeocoderCache = true;
            GMaps.Instance.UsePlacemarkCache = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            cboMapType.SelectedItem = _mapProvider;

            // config map 
            MainMap.MapProvider = _mapProvider;
            MainMap.MaxZoom = 20;
            MainMap.MinZoom = 5;
            MainMap.Zoom = _mapZoom;

            MainMap.Position = new PointLatLng();
            MainMap.PolygonsEnabled = true;
            if (_mapMode == MapModeEnum.EditArea)
                MainMap.AllowDrawPolygon = true;
            else
                MainMap.AllowDrawPolygon = false;

            // map events
            MainMap.OnMapZoomChanged += new MapZoomChanged(this.MainMap_OnMapZoomChanged);

            if (_mapMode == MapModeEnum.EditPoint)
            {
                MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
                MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
                MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
            }
            else
            {
                MainMap.MouseMove -= new MouseEventHandler(MainMap_MouseMove);
                MainMap.MouseDown -= new MouseEventHandler(MainMap_MouseDown);
                MainMap.MouseUp -= new MouseEventHandler(MainMap_MouseUp);
            }

            // get zoom  
            trackBarZoom.Minimum = MainMap.MinZoom;
            trackBarZoom.Maximum = MainMap.MaxZoom;
            trackBarZoom.Value = Convert.ToInt32(MainMap.Zoom);

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);
            }
        }

        private bool SetCenter(PointLatLng? center)
        {
            bool centered = false;
            if (center != null)
            {
                MainMap.Position = center.Value;
                centered = true;
            }
            else
            {
                if (_mapMode == MapModeEnum.EditArea)
                {
                    centered = MainMap.ZoomAndCenterMarkers("vertices");
                    if (!centered) centered = MainMap.ZoomAndCenterMarkers("top");
                    if (!centered)
                    {
                        if (top.Polygons.Count > 0 && top.Polygons[0].Points.Count > 0)
                        {
                            MainMap.Position = GeoHelper.CalculateMiddlePoint(top.Polygons[0]);
                            centered = true;
                        }
                    }
                }

                if (_mapMode == MapModeEnum.EditPoint)
                {
                    if (currentMarker != null)
                    {
                        MainMap.Position = currentMarker.Position;
                        centered = true;
                    }

                    if (!centered)
                        centered = MainMap.ZoomAndCenterMarkers("top");

                    if (!centered)
                    {
                        if (top.Polygons.Count > 0)
                            center = GeoHelper.CalculateMiddlePoint(top.Polygons[0]);
                    }
                }

                if (_mapMode == MapModeEnum.ReadOnly)
                    centered = MainMap.ZoomAndCenterMarkers("top");
            }

            txtLat.Text = MainMap.Position.Lat.ToString(CultureInfo.CurrentCulture);
            txtLng.Text = MainMap.Position.Lng.ToString(CultureInfo.CurrentCulture);

            return centered;
        }

        private void GoToAddress(string keywordsToSearch)
        {

            GeoCoderStatusCode status = MainMap.SetPositionByKeywords(keywordsToSearch);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Google Maps Geocoder can't find: '" + txtAddress.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            // set current marker
            if (_mapMode == MapModeEnum.EditPoint)
            {
                if (currentMarker != null)
                    currentMarker.Position = MainMap.Position;
                else
                    currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.red);

                if (!top.Markers.Contains(currentMarker))
                    top.Markers.Add(currentMarker);
                
            }

            SetCenter(MainMap.Position);
            
        }

        #region Map event methods

        private void MainMap_OnMapZoomChanged()
        {
            trackBarZoom.Value = Convert.ToInt32(MainMap.Zoom);
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
            MainMap.SelectedArea = MainMap.ViewArea;

            if (_mapMode == MapModeEnum.EditArea)
            {
                if (currentPolygon.Points.Count > 2)
                    MainMap.SelectedArea = CalculateRectangle(currentPolygon.Points);
            }            
            

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
            MainMap.MapProvider = (GMapProvider)cboMapType.SelectedItem;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            GoToAddress(txtAddress.Text);
            SetCenter(null); //Set center by MainMap.Position
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

            PointLatLng point = GeoHelper.CalculateMiddlePoint(points.ToList());

            return point;

        }

        private PointLatLng CalculateMiddlePoint(List<PointLatLng> marks)
        {

            PointLatLng point = GeoHelper.CalculateMiddlePoint(marks);

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

        private void ConfigureAdditionalData()
        {

            var territoryList = server.GetTerritories();
            var departmentList = server.GetDepartments();

            //grpTerritories
            chklstTerritories.DisplayMember = "Name";
            chklstTerritories.ValueMember = "Id";
            chklstTerritories.DataSource = territoryList;


            
            //grpAddresses
            chklstDepartment.DisplayMember = "Name";
            chklstDepartment.ValueMember = "Id";
            chklstDepartment.DataSource = departmentList;

            chklstTerritory.DisplayMember = "Name";
            chklstTerritory.ValueMember = "Id";
            chklstTerritory.DataSource = territoryList;

            chklstDepartment.UncheckAllItems();
            chklstTerritories.UncheckAllItems();
            chklstTerritory.UncheckAllItems();

            if (TerritoryId.HasValue)
            {
                if (TerritoryId.Value != 0)
                {
                    chklstTerritories.Check(TerritoryId.Value, "Id");
                    chklstTerritory.Check(TerritoryId.Value, "Id");
                }
            }

            panelAdData.Expand = false;

        }

        #region View territories

        void ViewTerritories()
        {
            top.Polygons.Clear();
            if (_mapMode == MapModeEnum.EditArea && currentPolygon != null)
                top.Polygons.Add(currentPolygon);

            IList territoriesToShow = GetTerritoriesToShow();
            if (territoriesToShow != null)
            {
                foreach (var item in territoriesToShow)
                {
                    string areaStr = (string)Helper.GetPropertyValue(item, "Area");
                    if (areaStr != null)
                    {
                        List<PointLatLng> vertices = Helper.StrPointsToPointsLatLng(areaStr.Split('\n'));
                        string terrName = (string)Helper.GetPropertyValue(item, "Name");
                        GMapPolygon polygon = new GMapPolygon(vertices, terrName);
                        top.Polygons.Add(polygon);
                    }
                }
            }
        }

        private IList GetTerritoriesToShow()
        {
            IList rv = null;

            List<ObjectParameter> auxParameters = new List<ObjectParameter>();
            string queryStr = "";

            int currentId = 0;
            if (TerritoryId.HasValue)
                currentId = TerritoryId.Value;

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

        #endregion

        #region View addresses

        void ViewAddresses()
        {
            IList addressesToShow = GetAddressToShow();

            top.Markers.Clear();

            if(_mapMode == MapModeEnum.EditPoint && currentMarker != null)            
                top.Markers.Add(currentMarker);

            if (addressesToShow != null)
            {
                foreach (var item in addressesToShow)
                {
                    double? lat = (double?)Helper.GetPropertyValue(item, "Lat");
                    double? lng = (double?)Helper.GetPropertyValue(item, "Lng");
                    if (lat.HasValue && lng.HasValue)
                    {
                        GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(lat.Value, lng.Value));
                        int? internalNumber = (int?)Helper.GetPropertyValue(item, "InternalTerritoryNumber");
                        if (internalNumber.HasValue)
                            marker.Tag = internalNumber.Value;
                        marker.ToolTipText = Helper.GetPropertyValue(item, "Address").ToString();
                        marker.Size = new System.Drawing.Size(4, 4);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        marker.Icon = Properties.Resources.legendIcon;
                        top.Markers.Add(marker);
                    }
                }
            }
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

                var territoriesIds = chklstTerritory.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < territoriesIds.Count; i++)
                {
                    if (auxQueryStr != "")
                        auxQueryStr += " OR ";
                                        
                    if ((int)territoriesIds[i] != -1) //el id -1 representa al null
                    {
                        if ((int)territoriesIds[i] != 0) //el id 0 es el nuevo
                        {
                            string varName = "IdTerritory" + i.ToString();
                            auxQueryStr += "Address.Territory.IdTerritory = @" + varName;
                            ObjectParameter param = new ObjectParameter(varName, territoriesIds[i]);
                            auxParameters.Add(param);
                        }
                    }
                    else
                        auxQueryStr += "Address.Territory IS NULL";
                }
                if (!string.IsNullOrEmpty(auxQueryStr))
                    queryStr += "(" + auxQueryStr + ")";
            }
            //chklstDepartment
            if (chklstDepartment.CheckedItems.Count > 0)
            {
                if (auxParameters.Count > 0 || queryStr.Contains("IS NULL"))
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

            parameters = auxParameters;
            return queryStr;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            ViewTerritories();
            ViewAddresses();
        }

        private void frmMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            panelAdData.Expand = false;
        }

        private void panelAdData_ExpandClick(object sender, EventArgs e)
        {            
            if(((BSE.Windows.Forms.Panel)sender).Expand)
                panelAdData.Width = 200;
        }

        

    }
}
