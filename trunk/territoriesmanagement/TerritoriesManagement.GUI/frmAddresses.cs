using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using System.IO;
using System.Collections;
using System.Resources;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ZeqkTools.WindowsForms.Maps;
using ZeqkTools.WindowsForms.Controls;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Model;
using TerritoriesManagement.Export;

namespace TerritoriesManagement.GUI
{
    public partial class frmAddresses : Form
    {
        Addresses _server = new Addresses();
        Config.Config _config;
        ResourceManager _rm;

        bool _isGettingAll = false;

        public frmAddresses()
        {
            _rm = new ResourceManager(this.GetType());
            InitializeComponent();

        }

        private string GetString(string text)
        {
            //return _rm.GetString(text, Thread.CurrentThread.CurrentCulture);
            return text;
        }

        private void frmAddresses_Load(object sender, EventArgs e)
        {
            _config = new Config.Config();
            _config.LoadSavedConfig();

            chkStreet.Checked = true;

            ConfigGrids();

            var departments = this._server.GetDepartments();

            chklstDepartment.DisplayMember = "Name";
            chklstDepartment.ValueMember = "Id";
            chklstDepartment.DataSource = departments;

            var cities = this._server.GetCities();
            chklstCity.DisplayMember = "Name";
            chklstCity.ValueMember = "Id";
            chklstCity.DataSource = cities;

            var territories = _server.GetTerritories();
            chklstTerritory.DisplayMember = "Name";
            chklstTerritory.ValueMember = "Id";
            chklstTerritory.DataSource = territories;

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmAddress myForm = new frmAddress(_server))
            {
                try
                {
                    var address = _server.NewObject();
                    myForm.Address = address;

                    myForm.ShowDialog();

                    if (lblFiltered.Visible) Search();
                    else GetAll();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 1)
            {
                var v = _server.Load((int)dgvResult.SelectedRows[0].Cells["Id"].Value);

                using (frmAddress myForm = new frmAddress(_server))
                {
                    try
                    {
                        myForm.Address = v;
                        myForm.ShowDialog();

                        if (lblFiltered.Visible) Search();
                        else GetAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show(GetString("You must select some address."));
        }

        private void fields_CheckedChanged(object sender, EventArgs e)
        {
            List<string> columns = new List<string>();
            List<string> variables = new List<string>();

            if (chkStreet.Checked)
            {
                columns.Add("Address.Street");
                variables.Add("street");
            }

            if (chkCorners.Checked)
            {
                columns.Add("Address.Corner1");
                variables.Add("corner1");
                columns.Add("Address.Corner2");
                variables.Add("corner2");
            }

            if (chkDescription.Checked)
            {
                columns.Add("Address.Description");
                variables.Add("desc");
            }
            if (columns.Count > 0)
            {
                schStreet.SetProperties(columns.ToArray(), variables.ToArray());
            }
            else
            {
                MessageBox.Show(GetString("You must select at least one search field."));
                ((CheckBox)sender).Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dgvResult.SelectedRows.Count; i++)
                    {
                        int idAddress = (int)dgvResult.SelectedRows[i].Cells["Id"].Value;

                        _server.Delete(idAddress);                       
                    }

                    if (lblFiltered.Visible) Search();
                    else GetAll();
	            }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GetString("Error"));
                }
            }
            else
                MessageBox.Show(GetString("You must select some address."));

        }

        private void LoadResult(string query)
        {
            try
            {
                var addresses = this._server.Search(query);
                dgvResult.DataSource = addresses;
                lblResultCount.Text = addresses.Count.ToString();
                dgvResult.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
            }
            lblFiltered.Visible = false;
        }

        private void ConfigGrids()
        {
            dgvResult.RowHeadersVisible = false;
            dgvResult.Columns.Add("Id", GetString("Id"));            
            dgvResult.Columns.Add("DepartmentName",GetString("Department"));
            dgvResult.Columns.Add("CityName", GetString("City"));
            dgvResult.Columns.Add("Territory", GetString("Territory"));
            dgvResult.Columns.Add("Address", GetString("Street and Nº"));
            dgvResult.Columns.Add("Corner1", GetString("Corner1"));
            dgvResult.Columns.Add("Corner2", GetString("Corner2"));
            dgvResult.Columns.Add("Description", GetString("Description"));
            dgvResult.Columns.Add("HasGeoPosition", GetString("GEO"));
            dgvResult.Columns.Add("Lat", GetString("Lat"));
            dgvResult.Columns.Add("Lng", GetString("Lng"));
            dgvResult.Columns.Add("blank", "");

            dgvResult.Columns["Id"].Visible = false;
            dgvResult.Columns["Id"].DataPropertyName = "Id";
            dgvResult.Columns["DepartmentName"].Width = 100;
            dgvResult.Columns["DepartmentName"].DataPropertyName = "DepartmentName";
            dgvResult.Columns["CityName"].Width = 100;
            dgvResult.Columns["CityName"].DataPropertyName = "CityName";
            dgvResult.Columns["Territory"].Width = 100;
            dgvResult.Columns["Territory"].DataPropertyName = "Territory";
            dgvResult.Columns["Address"].Width = 100;
            dgvResult.Columns["Address"].DataPropertyName = "Address";
            dgvResult.Columns["Corner1"].Width = 100;
            dgvResult.Columns["Corner1"].DataPropertyName = "Corner1";
            dgvResult.Columns["Corner2"].Width = 100;
            dgvResult.Columns["Corner2"].DataPropertyName = "Corner2";
            dgvResult.Columns["Description"].Width = 160;
            dgvResult.Columns["Description"].DataPropertyName = "Description";
            dgvResult.Columns["HasGeoPosition"].Width = 40;
            dgvResult.Columns["HasGeoPosition"].DataPropertyName = "HasGeoPosition";
            dgvResult.Columns["Lat"].Visible = false;
            dgvResult.Columns["Lat"].DataPropertyName = "Lat";
            dgvResult.Columns["Lng"].Visible = false;
            dgvResult.Columns["Lng"].DataPropertyName = "Lng";

            dgvResult.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = true;

        }

        private void GetAll()
        {
            _isGettingAll = true;
            schStreet.Clear();
            chklstDepartment.CheckAllItems();
            chklstCity.DataSource = this._server.GetCities();
            chklstCity.CheckAllItems();
            chklstTerritory.CheckAllItems();
            LoadResult("");
            lblFiltered.Visible = false;
            _isGettingAll = false;
        }

        private void Search()
        {
            try
            {

                List<ObjectParameter> parameters = new List<ObjectParameter>();
                string strQuery = GetQuery(out parameters);
                if (!string.IsNullOrEmpty(strQuery))
                {
                    var addresses = this._server.Search(strQuery, parameters.ToArray<ObjectParameter>());
                    dgvResult.DataSource = addresses;
                    lblResultCount.Text = addresses.Count.ToString();
                    lblFiltered.Visible = true;
                }
                else
                    MessageBox.Show(GetString("You must select at least one search criteria."));

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private string GetQuery(out List<ObjectParameter> parameters)
        {
            List<ObjectParameter> auxParameters = new List<ObjectParameter>();
            schStreet.MakeQuery();
            string queryStr = "";

            if (!schStreet.IsClean())
            {
                queryStr = schStreet.Query;
                schStreet.Parameters.ForEach(delegate(ObjectParameter param)
                {
                    auxParameters.Add(param);
                });
            }

            //chklstTerritory
            if (chklstTerritory.CheckedItems.Count > 0)
            {
                if (auxParameters.Count > 0)
                    queryStr += " AND ";

                var territories = chklstTerritory.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < territories.Count; i++)
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

            parameters = auxParameters;
            return queryStr;
        }

        private void dgvResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxMenu.Show(dgvResult, e.Location);
            }
        }

        private void copyGoogleMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count!=0)
            {
                DataGridViewRow row = dgvResult.SelectedRows[0];

                string text = row.Cells["Address"].Value.ToString() + ", " + 
                    row.Cells["CityName"].Value.ToString() + ", " + 
                    row.Cells["DepartmentName"].Value.ToString();

                Clipboard.SetText(text);
            }
        }
        #region ToGMaps
        private void btnToGMaps_Click(object sender, EventArgs e)
        {
            sfdGMaps.ShowDialog();
            
        }

        private void sfdGMaps_FileOk(object sender, CancelEventArgs e)
        {
            List<ObjectParameter> parameters = new List<ObjectParameter>();
            string strQuery = GetQuery(out parameters);

            string path = Path.GetFullPath(sfdGMaps.FileName);
            try
            {
                ExportTool tool = new ExportTool();
                tool.ExportToGMap(path, strQuery, parameters.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ToExcel
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            sfdExcelDestiny.ShowDialog();
        }
        private void sfdExcelDestiny_FileOk(object sender, CancelEventArgs e)
        {
            List<ObjectParameter> parameters = new List<ObjectParameter>();
            string strQuery = GetQuery(out parameters);

            string path = Path.GetFullPath(sfdExcelDestiny.FileName);

            try
            {
                Addresses address = new Addresses();
                string[] properties = Functions.GetPropertyStrListByTypeName("Address").ToArray();
                ExportTool tool = new ExportTool();
                tool.ExportToExcel(path, "Address", "Addresses", properties, strQuery, parameters.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void viewMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                using (frmGeoPolygon myForm = new frmGeoPolygon())
                {
                
                    var selectedRows = dgvResult.SelectedRows;
                    List<GMapMarker> marks = new List<GMapMarker>();
                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        bool hasGeoPosition = (bool)selectedRows[i].Cells["HasGeoPosition"].Value;
                        if (hasGeoPosition)
                        {
                            double lat = (double)selectedRows[i].Cells["Lat"].Value;
                            double lng = (double)selectedRows[i].Cells["Lng"].Value;
                            string address = selectedRows[i].Cells["Address"].Value.ToString();
                            int idAddres = (int)selectedRows[i].Cells["Id"].Value;

                            GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(lat, lng));
                            marker.Size = new System.Drawing.Size(4, 4);
                            marker.Tag = idAddres;
                            marker.ToolTipText = address;
                            marker.Icon = Properties.Resources.legendIcon;
                            marks.Add(marker);
                        }
                    }
                    myForm.SecondaryMarkers = marks;
                    myForm.AllowDrawPolygon = false;
                    myForm.ShowDialog();
                }
            }
        }

        private void chklstDepartment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_isGettingAll)
            {
                var departments = chklstDepartment.CheckedItemsValues;

                if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
                {
                    if (e.Index < chklstDepartment.ItemsValues.Count && e.Index > 0)
                        departments.Add(chklstDepartment.ItemsValues[e.Index - 1]);
                }

                if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
                {
                    if (e.Index < chklstDepartment.ItemsValues.Count && e.Index > 0)
                        departments.Remove(chklstDepartment.ItemsValues[e.Index - 1]);
                }

                var cities = this._server.GetCitiesByDepartments(departments.Cast<int>().ToArray());                
                chklstCity.DataSource = cities;

            }
        }
        
    }
}
