using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using Localizer;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.GUI.Configuration;
using TerritoriesManagement.Model;
using System.Drawing;

namespace TerritoriesManagement.GUI
{
    public partial class frmTerritories : Form
    {
        static private bool opened = false;
        private Territories server = new Territories();
        private bool isDirty;
        Configuration.Config config = new Configuration.Config();

        public frmTerritories()
        {
            if (opened)
                throw new Exception(GetString("The window is already open."));
            else
                opened = true;
            InitializeComponent();
            Globalization.RefreshUI(this);
        }

        private string GetString(string text)
        {
            return Globalization.GetString(text);
        }

        private void frmTerritories_Load(object sender, EventArgs e)
        {
            string[] columns = { "Territory.Name" };
            string[] variables = { "name" };
            schName.SetProperties(columns, variables);
            ConfigGrids();

            ClearFilter();
        }

        private void dgvResult_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count != 0)
            {
                var v = server.Load((int)dgvResult.SelectedRows[0].Cells["Id"].Value);
                ObjectToForm(v);
                if (tabPanel.Visible)
                    LoadRelations(v);

                this.isDirty = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
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
                this.server.Delete(v.IdTerritory);

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
            isDirty = false;
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
                    MessageBox.Show(GetString("You must select a territory."));
            }
        }

        private void frmTerritories_Shown(object sender, EventArgs e)
        {
            New();
        }

        private void frmTerritories_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            opened = false;
        }


        private void LoadResult(string strQuery, params ObjectParameter[] parameters)
        {
            try
            {
                var result = this.server.Search(strQuery, parameters.ToArray<ObjectParameter>());
                dgvResult.DataSource = result;
                lblResultCount.Text = result.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
            }
        }

        private void ConfigGrids()
        {
            dgvResult.Columns.Add("Id", GetString("Id"));
            dgvResult.Columns.Add("Name", GetString("Territory"));
            dgvResult.Columns.Add("Number", GetString("Number"));
            dgvResult.Columns.Add("Area", GetString("Area"));
            dgvResult.Columns.Add("blank", "");

            dgvResult.Columns["Id"].Visible = false;
            dgvResult.Columns["Id"].DataPropertyName = "Id";
            dgvResult.Columns["Name"].Width = 150;
            dgvResult.Columns["Name"].DataPropertyName = "Name";
            dgvResult.Columns["Number"].Width = 100;
            dgvResult.Columns["Number"].DataPropertyName = "Number";
            dgvResult.Columns["Area"].DataPropertyName = "Area";
            dgvResult.Columns["Area"].Visible = false;
            dgvResult.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = false;

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
            dgvTours.Columns.Add("StartDate", GetString("Start"));
            dgvTours.Columns.Add("EndDate", GetString("End"));
            dgvTours.Columns.Add("blank", "");

            dgvTours.Columns["Id"].Visible = false;
            dgvTours.Columns["Id"].DataPropertyName = "Id";
            dgvTours.Columns["Number"].Width = 100;
            dgvTours.Columns["Number"].DataPropertyName = "Number";
            dgvTours.Columns["StartDate"].Width = 150;
            dgvTours.Columns["StartDate"].DataPropertyName = "StartDate";
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
            var v = this.server.NewObject();
            ObjectToForm(v);
            txtName.Focus();
            this.isDirty = false;
        }        

        private void New()
        {
            bool yes = true;
            if (isDirty)
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
                    v = server.Save(v);

                    int? index = null;
                    int? scrollIndex = null;
                    if (dgvResult.SelectedRows.Count > 0)
                    {
                        index = dgvResult.SelectedRows[0].Index;
                        scrollIndex = dgvResult.FirstDisplayedScrollingRowIndex;
                    }

                    //traigo los datos
                    if (lblFiltered.Visible) Filter();
                    else ClearFilter();

                    if (index.HasValue)
                    {
                        dgvResult.Rows[index.Value].Selected = true;
                        dgvResult.FirstDisplayedScrollingRowIndex = scrollIndex.Value;
                    }
                    else
                        New();

                    isDirty = false;
                    txtName.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GetString("Error"));
                }
            }
            else
                MessageBox.Show(GetString("The data is incomplete."));
        }

        private bool IsComplete()
        {
            bool rv = true;
            if (string.IsNullOrEmpty(txtName.Text))
                rv = false;
            return rv;
        }

        private void Filter()
        {
            try
            {
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
                    LoadResult(strQuery, parameters.ToArray<ObjectParameter>());
                    lblFiltered.Visible = true;
                }
                else
                    MessageBox.Show(GetString("You must complete at least one search criteria."));

                dgvResult.ClearSelection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
            }


        }

        private void ClearFilter()
        {
            schName.Clear();
            LoadResult("");
            lblFiltered.Visible = false;
            dgvResult.ClearSelection();
        }        

        private void LoadRelations(Territory v)
        {
            IDictionary relations = this.server.LoadRelations(v.IdTerritory);
            dgvAddresses.DataSource = relations["Addresses"];
            dgvAddresses.Refresh();

            dgvAddresses.RowHeadersVisible = false;

            dgvTours.DataSource = relations["Tours"];
            dgvTours.Refresh();

            dgvTours.RowHeadersVisible = false;

        }        

        private void btnViewMap_Click(object sender, EventArgs e)
        {
            var map = frmMap.GetInstance();
            map.Clear();
            map.MapMode = MapModeEnum.EditArea;
            map.Address = Config.DefaultPlace;
            Territory t = FormToOject();

            GMapPolygon polygon = GetPolygon(t.Area);
            polygon.Name = t.Name;

            map.MainPolygon = polygon;
            map.TerritoryId = t.IdTerritory;

            if (map.ShowDialog() == DialogResult.OK)
            {
                string area = "";

                polygon = map.MainPolygon;
                if (polygon != null)
                {
                    CultureInfo info = CultureInfo.GetCultureInfo("en-US");
                    foreach (PointLatLng item in polygon.Points)
                    {
                        if (!string.IsNullOrEmpty(area))
                            area += Environment.NewLine;
                        area += item.Lat.ToString(info.NumberFormat) + " " + item.Lng.ToString(info.NumberFormat);
                    }
                    if (string.IsNullOrEmpty(area))
                        t.Area = null;
                    else
                        t.Area = area;
                }
                else
                    t.Area = null;

                ObjectToForm(t);
            }
        }

        private void schName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Filter();
        }

        

        private GMapPolygon GetPolygon(string areaStr)
        {
            List<PointLatLng> auxPoints = new List<PointLatLng>();
            if (areaStr != null)
                auxPoints = Helper.StrPointsToPointsLatLng(areaStr.Split('\n'));

            GMapPolygon polygon = new GMapPolygon(auxPoints,"");
            Pen pen = polygon.Stroke;
            pen.Color = Color.FromArgb(155, Color.Red);
            polygon.Stroke = pen;

            return polygon;
        }

        

    }
}
