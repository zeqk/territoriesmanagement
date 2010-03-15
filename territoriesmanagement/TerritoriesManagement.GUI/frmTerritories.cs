using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ZeqkTools.WindowsForms.Maps;
using TerritoriesManagement.Model;
using TerritoriesManagement.DataBridge;

namespace TerritoriesManagement.GUI
{
    public partial class frmTerritories : Form
    {
        static private bool _opened = false;
        private Territories _server = new Territories();
        private bool _isDirty;
        Config.Config _config;
        ResourceManager _rm;

        public frmTerritories()
        {
            _rm = new ResourceManager(this.GetType());

            if (_opened)
                throw new Exception(GetString("The window is already open."));
            else
                _opened = true;
            InitializeComponent();
        }

        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

        private void frmTerritories_Load(object sender, EventArgs e)
        {
            _config = new Config.Config();
            _config.LoadSavedConfig();

            //string[] columns = { "Territory.Name","Territory.Number" };
            //string[] variables = { "name","number" };
            string[] columns = { "Territory.Name" };
            string[] variables = { "name" };
            schName.SetProperties(columns, variables);
            ConfigGrids();

            ClearFilter();
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count != 0)
            {
                var v = _server.Load((int)dgvResults.SelectedRows[0].Cells["Id"].Value);
                ObjectToForm(v);
                if (tabPanel.Visible)
                    LoadRelations(v);

                this._isDirty = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this._isDirty = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var v = FormToOject();
            try
            {
                this._server.Delete(v.IdTerritory);

                if (lblFiltered.Visible) Filter();
                else ClearFilter();

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            var v = FormToOject();
            ClearFilter();
            ObjectToForm(v);
            _isDirty = false;
            txtName.Focus();
        }

        private void btnRelations_Click(object sender, EventArgs e)
        {
            if (tabPanel.Visible == true)
            {
                tabPanel.Visible = false;
                btnRelations.Text = GetString("View relations");
            }
            else
            {
                if (lblId.Text != "0")
                {
                    tabPanel.Visible = true;
                    btnRelations.Text = GetString("Hide relations");

                    LoadRelations((Territory)bsTerritory.DataSource);
                }
                else
                    MessageBox.Show(GetString("You must select any territory."));
            }
        }

        private void frmTerritories_Shown(object sender, EventArgs e)
        {
            New();
        }

        private void frmTerritories_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _opened = false;
        }


        private void LoadResults(string query)
        {
            try
            {
                dgvResults.DataSource = this._server.Search(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            lblFiltered.Visible = false;
        }

        private void ConfigGrids()
        {
            dgvResults.Columns.Add("Id", GetString("Id"));
            dgvResults.Columns.Add("Name", GetString("Territory"));
            dgvResults.Columns.Add("Number", GetString("Number"));
            dgvResults.Columns.Add("blank", "");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["Name"].Width = 150;
            dgvResults.Columns["Name"].DataPropertyName = "Name";
            dgvResults.Columns["Number"].Width = 100;
            dgvResults.Columns["Number"].DataPropertyName = "Number";
            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;

            dgvAddresses.Columns.Add("Id", GetString("Id"));
            dgvAddresses.Columns.Add("Address", GetString("Address"));
            dgvAddresses.Columns.Add("Corners", GetString("Between"));
            dgvAddresses.Columns.Add("blank", "");

            dgvAddresses.Columns["Id"].Visible = false;
            dgvAddresses.Columns["Id"].DataPropertyName = "Id";
            dgvAddresses.Columns["Address"].Width = 200;
            dgvAddresses.Columns["Address"].DataPropertyName = "Address";
            dgvAddresses.Columns["Corners"].Width = 200;
            dgvAddresses.Columns["Corners"].DataPropertyName = "Corners";
            dgvAddresses.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvAddresses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAddresses.MultiSelect = false;

            dgvTours.Columns.Add("Id", GetString("Id"));
            dgvTours.Columns.Add("Number", GetString("Tour Nº"));
            dgvTours.Columns.Add("BeginDate", GetString("Begin"));
            dgvTours.Columns.Add("EndDate", GetString("End"));
            dgvTours.Columns.Add("blank", "");

            dgvTours.Columns["Id"].Visible = false;
            dgvTours.Columns["Id"].DataPropertyName = "Id";
            dgvTours.Columns["Number"].Width = 100;
            dgvTours.Columns["Number"].DataPropertyName = "Number";
            dgvTours.Columns["BeginDate"].Width = 150;
            dgvTours.Columns["BeginDate"].DataPropertyName = "BeginDate";
            dgvTours.Columns["EndDate"].Width = 150;
            dgvTours.Columns["EndDate"].DataPropertyName = "EndDate";
            dgvTours.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvTours.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTours.MultiSelect = false;

        }

        private Territory FormToOject()
        {
            return (Territory)this.bsTerritory.DataSource;            
        }

        private void ObjectToForm(Territory v)
        {
            this.bsTerritory.DataSource = v;
        }

        private void ClearData()
        {
            var v = this._server.NewObject();
            ObjectToForm(v);
            txtName.Focus();
            this._isDirty = false;
        }        

        private void New()
        {
            bool yes = true;
            if (_isDirty)
                if (MessageBox.Show(GetString("There is some unsaved data. Do you want to continue?"), GetString("Message"), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    yes = false;
                    txtName.Focus();
                }
            if (yes)
            {
                ClearData();
            }
        }        

        private void Save()
        {
            if (IsComplete())
            {
                var v = this.FormToOject();

                try
                {
                    v =this._server.Save(v);

                    //traigo los datos
                    if (lblFiltered.Visible) Filter();
                    else ClearFilter();

                    _isDirty = false;
                    txtName.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GetString("Error"));
                }
            }
            else
                MessageBox.Show(GetString("The data is incomplete"));
        }

        private bool IsComplete()
        {
            bool rv = true;
            if (string.IsNullOrEmpty(txtName.Text))
                rv = false;
            //if (string.IsNullOrEmpty(txtNumber.Text))
            //    rv = false;

            return rv;
        }

        private void Filter()
        {
            try
            {
                var v = FormToOject();

                schName.MakeQuery();
                List<ObjectParameter> parameters = new List<ObjectParameter>();
                string strQuery = "";

                if (!schName.IsClean())
                {
                    strQuery = schName.Query;
                    schName.Parameters.ForEach(delegate(ObjectParameter param)
                    {
                        parameters.Add(param);
                    });
                }

                if (!string.IsNullOrEmpty(strQuery))
                {
                    dgvResults.DataSource = this._server.Search(strQuery, parameters.ToArray<ObjectParameter>());
                    lblFiltered.Visible = true;
                }
                else
                    MessageBox.Show(GetString("You must complete at least 1 search field"));

                dgvResults.ClearSelection();

                ObjectToForm(v);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
            }


        }

        private void ClearFilter()
        {
            schName.Clear();
            LoadResults("");
            lblFiltered.Visible = false;
            dgvResults.ClearSelection();
        }        

        private void LoadRelations(Territory v)
        {
            IDictionary relations = this._server.LoadRelations(v.IdTerritory);
            dgvAddresses.DataSource = relations["Addresses"];
            dgvAddresses.Refresh();

            dgvAddresses.RowHeadersVisible = false;

            dgvTours.DataSource = relations["Tours"];
            dgvTours.Refresh();

            dgvTours.RowHeadersVisible = false;

        }

        private void btnViewMap_Click(object sender, EventArgs e)
        {
            using (frmGeoPolygon myForm = new frmGeoPolygon())
            {
                myForm.Address = _config.Place;
                myForm.MapType = _config.MapType;
                Territory t = FormToOject();
                if (!string.IsNullOrEmpty(t.Area))
                {
                    string[] strPoints = t.Area.Split('\n');
                    myForm.Polygon = StrPointsToPointsLatLng(strPoints);
                    
                }

                if (t.Addresses.Count > 0)
                {
                    List<GMapMarker> marks = new List<GMapMarker>();
                    foreach (var item in t.Addresses)
                    {
                        if (item.Lat.HasValue && item.Lng.HasValue)
                        {

                            GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(item.Lat.Value, item.Lng.Value));
                            marker.Tag = item.IdAddress;
                            marker.ToolTipText = item.Street + item.Number;
                            marker.Icon = Properties.Resources.legendIcon;
                            marks.Add(marker);
                        }
                    }
                    myForm.SecondaryMarkers = marks;
                }

                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    string area = "";

                    var polygon = myForm.Polygon;
                    foreach (PointLatLng item in polygon)
                    {
                        if (!string.IsNullOrEmpty(area))
                            area += Environment.NewLine;
                        area += item.Lat + " " + item.Lng;
                    }
                    if (string.IsNullOrEmpty(area))
                        t.Area = null;
                    else
                        t.Area = area;

                    ObjectToForm(t);
                }

            }
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

        

    }
}
