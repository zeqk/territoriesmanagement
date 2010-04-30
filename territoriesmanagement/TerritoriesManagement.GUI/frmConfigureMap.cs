using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Model;
using ZeqkTools.WindowsForms.Maps;

namespace TerritoriesManagement.GUI
{
    public partial class frmConfigureMap : Form
    {


        Addresses addressServer = new Addresses();
        Territories territoryServer = new Territories();

        Config.Config config;

        #region Fields
        private GMapPolygon _polygon;
        private object _object;
        #endregion

        #region Properties

        public GMapPolygon Polygon
        {
            get { return _polygon; }
            set { _polygon = value; }
        }
	

        public object Object
        {
            get { return _object; }
            set { _object = value; }
        }

        #endregion


        public frmConfigureMap()
        {
            config = new Config.Config();
            config.LoadSavedConfig();

            InitializeComponent();
        }

        private void chklstDepartment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var departments = chklstDepartment.CheckedItemsValues;

            if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                if (chklstDepartment.ItemsValues.Count < e.Index)
                    departments.Add(chklstDepartment.ItemsValues[e.Index]);
            }

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                if (chklstDepartment.ItemsValues.Count < e.Index)
                    departments.Remove(chklstDepartment.ItemsValues[e.Index]);
            }

            var cities = this.addressServer.GetCitiesByDepartments(departments.Cast<int>().ToArray());
            chklstCity.DataSource = cities;
        }

        private void btnViewMap_Click(object sender, EventArgs e)
        {
            using (frmGeoPolygon myForm = new frmGeoPolygon())
            {
                myForm.Address = config.Place;
                myForm.MapType = config.MapType;
                
                object area = _object.GetType().GetProperty("Area").GetValue(_object, null);
                
                if(area != null)
                {
                    string areaStr = area.ToString();
                    string[] strPoints = areaStr.Split('\n');
                    GMapPolygon polygon = new GMapPolygon(StrPointsToPointsLatLng(strPoints),"Territory polygon");
                    myForm.Polygon = polygon;

                }

                List<GMapMarker> marks = new List<GMapMarker>();

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
                            marker.Tag = Functions.GetPropertyValue(item, "Id").ToString();                            
                            marker.ToolTipText = Functions.GetPropertyValue(item, "Address").ToString();
                            marker.Size = new System.Drawing.Size(4, 4);
                            marker.TooltipMode = MarkerTooltipMode.OnMouseOver;
                            marker.Icon = Properties.Resources.legendIcon;
                            marks.Add(marker);
                        }
                    }                    
                }
                List<GMapPolygon> polygons = new List<GMapPolygon>();

                IList territoriesToShow = GetTerritoriesToShow();
                if (territoriesToShow != null)
                {
                    foreach (var item in territoriesToShow)
                    {
                        string areaStr = (string)Functions.GetPropertyValue(item, "Area");
                        if (areaStr != null)
                        {
                            List<PointLatLng> vertices = StrPointsToPointsLatLng(areaStr.Split('\n'));
                            string terrName = (string)Functions.GetPropertyValue(item,"Name");
                            GMapPolygon polygon = new GMapPolygon(vertices, terrName);
                            polygons.Add(polygon);
                        }
                    }
                }

                myForm.SecondaryMarkers = marks;
                myForm.SecondaryPolygons = polygons;

                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    _polygon = myForm.Polygon;
                }

            }
        }

        private IList GetTerritoriesToShow()
        {
            IList rv = null;

            List<ObjectParameter> auxParameters = new List<ObjectParameter>();
            string queryStr = "";


            int currentId = -1;

            if (_object.GetType() == typeof(Territory))
                currentId = (int)_object.GetType().GetProperty("IdTerritory").GetValue(_object, null);

            //chklstTerritory2
            if (chklstTerritory2.CheckedItems.Count > 0)
            {
                if (auxParameters.Count > 0)
                    queryStr += " AND ";

                var territories = chklstTerritory2.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < territories.Count; i++)
                {
                    if ((int)territories[i] != 0 && (int)territories[i]!= currentId)
                    {
                        if (auxQueryStr != "")
                            auxQueryStr += " OR ";

                    
                        string varName = "IdTerritory" + i.ToString();
                        auxQueryStr += "Territory.IdTerritory = @" + varName;
                        ObjectParameter param = new ObjectParameter(varName, territories[i]);
                        auxParameters.Add(param);
                    }
                }

                if(!string.IsNullOrEmpty(auxQueryStr))
                    queryStr += "(" + auxQueryStr + ")";
            }



            if (!string.IsNullOrEmpty(queryStr))
            {
                rv = this.territoryServer.Search(queryStr, auxParameters.ToArray<ObjectParameter>());

            }

            return rv;
        }

        private IList GetAddressToShow()
        {
            IList rv = null;

            List<ObjectParameter> parameters = new List<ObjectParameter>();
            string queryStr = GetAddressQuery(out parameters);
            if (!string.IsNullOrEmpty(queryStr))
            {
                rv = this.addressServer.Search(queryStr, parameters.ToArray<ObjectParameter>());

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

                int currentId = -1;
                if (_object.GetType() == typeof(Territory))
                    currentId = (int)_object.GetType().GetProperty("IdTerritory").GetValue(_object, null);

                var territories = chklstTerritory.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < territories.Count; i++)
                {
                    if ((int)territories[i] != currentId)
                    {
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
                    }
                }
                if(!string.IsNullOrEmpty(auxQueryStr))
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


        private List<PointLatLng> StrPointsToPointsLatLng(string[] strPoints)
        {
            List<PointLatLng> points = new List<PointLatLng>();

            for (int i = 0; i < strPoints.Length; i++)
            {

                string[] strArray = strPoints[i].Split(' ');
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmConfigureMap_Load(object sender, EventArgs e)
        {
            var departments = addressServer.GetDepartments();

            chklstDepartment.DisplayMember = "Name";
            chklstDepartment.ValueMember = "Id";
            chklstDepartment.DataSource = departments;

            chklstCity.DisplayMember = "Name";
            chklstCity.ValueMember = "Id";

            var territories = addressServer.GetTerritories();
            chklstTerritory.DisplayMember = "Name";
            chklstTerritory.ValueMember = "Id";
            chklstTerritory.DataSource = territories;

            var territories2 = addressServer.GetTerritories();
            chklstTerritory2.DisplayMember = "Name";
            chklstTerritory2.ValueMember = "Id";
            chklstTerritory2.DataSource = territories2;


            chklstDepartment.UncheckAllItems();
            chklstTerritory.UncheckAllItems();
            chklstTerritory2.UncheckAllItems();

            if (_object.GetType() == typeof(Territory))
            {
                int id = (int)_object.GetType().GetProperty("IdTerritory").GetValue(_object, null);
                if (id != 0)
                {
                    chklstTerritory.Check(id, "Id");
                    chklstTerritory2.Check(id, "Id");
                }
            }
            
        }
    }
}
