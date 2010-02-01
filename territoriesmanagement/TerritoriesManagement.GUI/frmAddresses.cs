using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Model;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using GMap.NET.WindowsForms;
using TerritoriesManagement.Export;
using System.IO;
using ZeqkTools.WindowsForms.Maps;
using ZeqkTools.WindowsForms.Controls;
using System.Collections;


namespace TerritoriesManagement.GUI
{
    public partial class frmAddresses : Form
    {
        Addresses _server = new Addresses();
        Config.Config _config;

        bool _isGettingAll = false;

        public frmAddresses()
        {
            InitializeComponent();

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
            if (dgvResults.SelectedRows.Count == 1)
            {
                var v = _server.Load((int)dgvResults.SelectedRows[0].Cells["Id"].Value);

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
                MessageBox.Show("Select one address.");
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
                MessageBox.Show("You must select at least one search criteria.");
                ((CheckBox)sender).Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dgvResults.SelectedRows.Count; i++)
                    {
                        int idAddress = (int)dgvResults.SelectedRows[i].Cells["Id"].Value;

                        _server.Delete(idAddress);                       
                    }

                    if (lblFiltered.Visible) Search();
                    else GetAll();
	            }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
                MessageBox.Show("Select one address.");

        }

        private void LoadResults(string query)
        {
            try
            {
                var addresses = this._server.Search(query);
                dgvResults.DataSource = addresses;
                lblResultsCount.Text = addresses.Count.ToString();
                dgvResults.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            lblFiltered.Visible = false;
        }

        private void ConfigGrids()
        {
            dgvResults.RowHeadersVisible = false;

            dgvResults.Columns.Add("Id", "Id");            
            dgvResults.Columns.Add("DepartmentName", "Department");
            dgvResults.Columns.Add("CityName", "City");
            dgvResults.Columns.Add("Territory", "Territory");
            dgvResults.Columns.Add("Address", "Street and Nº");
            dgvResults.Columns.Add("Corner1", "Corner1");
            dgvResults.Columns.Add("Corner2", "Corner2");
            dgvResults.Columns.Add("Description", "Description");
            dgvResults.Columns.Add("HaveGeoPosition", "GEO");
            dgvResults.Columns.Add("Lat", "Lat");
            dgvResults.Columns.Add("Lng", "Lng");
            dgvResults.Columns.Add("blank", "");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["DepartmentName"].Width = 100;
            dgvResults.Columns["DepartmentName"].DataPropertyName = "DepartmentName";
            dgvResults.Columns["CityName"].Width = 100;
            dgvResults.Columns["CityName"].DataPropertyName = "CityName";
            dgvResults.Columns["Territory"].Width = 100;
            dgvResults.Columns["Territory"].DataPropertyName = "Territory";
            dgvResults.Columns["Address"].Width = 100;
            dgvResults.Columns["Address"].DataPropertyName = "Address";
            dgvResults.Columns["Corner1"].Width = 100;
            dgvResults.Columns["Corner1"].DataPropertyName = "Corner1";
            dgvResults.Columns["Corner2"].Width = 100;
            dgvResults.Columns["Corner2"].DataPropertyName = "Corner2";
            dgvResults.Columns["Description"].Width = 160;
            dgvResults.Columns["Description"].DataPropertyName = "Description";
            dgvResults.Columns["HaveGeoPosition"].Width = 40;
            dgvResults.Columns["HaveGeoPosition"].DataPropertyName = "HaveGeoPosition";
            dgvResults.Columns["Lat"].Visible = false;
            dgvResults.Columns["Lat"].DataPropertyName = "Lat";
            dgvResults.Columns["Lng"].Visible = false;
            dgvResults.Columns["Lng"].DataPropertyName = "Lng";

            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = true;

        }

        private void GetAll()
        {
            _isGettingAll = true;
            schStreet.Clear();
            chklstDepartment.CheckAllItems();
            chklstCity.DataSource = this._server.GetCities();
            chklstCity.CheckAllItems();
            chklstTerritory.CheckAllItems();
            LoadResults("");
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
                    dgvResults.DataSource = addresses;
                    lblResultsCount.Text = addresses.Count.ToString();
                    lblFiltered.Visible = true;
                }
                else
                    MessageBox.Show("You must select at least one search criteria.");

                
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

            //if (cboCity.SelectedValue != null)
            //{
            //    if (auxParameters.Count > 0)
            //        queryStr += " AND ";

            //    queryStr += "Address.City.IdCity = @IdCity";
            //    ObjectParameter cityPar = new ObjectParameter("IdCity", (int)cboCity.SelectedValue);

            //    auxParameters.Add(cityPar);
            //}
            //else
            //    if (cboDepartment.SelectedValue != null)
            //    {
            //        if (auxParameters.Count > 0)
            //            queryStr += " AND ";

            //        queryStr += "Address.City.Department.IdDepartment = @IdDepartment";
            //        ObjectParameter depPar = new ObjectParameter("IdDepartment", (int)cboDepartment.SelectedValue);

            //        auxParameters.Add(depPar);
            //    }

            parameters = auxParameters;
            return queryStr;
        }

        private void dgvResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxMenu.Show(dgvResults, e.Location);
            }
        }

        private void copyGoogleMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count!=0)
            {
                DataGridViewRow row = dgvResults.SelectedRows[0];

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
                string[] properties = address.GetPropertyList().ToArray();

                ExportTool.ExportToExcel(path, "Address", "Addresses", properties, strQuery, parameters.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void viewMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count > 0)
            {
                using (frmGeoArea myForm = new frmGeoArea())
                {
                
                    var selectedRows = dgvResults.SelectedRows;
                    List<GMapMarker> marks = new List<GMapMarker>();
                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        bool haveGeoPosition = (bool)selectedRows[i].Cells["HaveGeoPosition"].Value;
                        if (haveGeoPosition)
                        {
                            double lat = (double)selectedRows[i].Cells["Lat"].Value;
                            double lng = (double)selectedRows[i].Cells["Lng"].Value;
                            string address = selectedRows[i].Cells["Address"].Value.ToString();
                            int idAddres = (int)selectedRows[i].Cells["Id"].Value;

                            GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(lat, lng));
                            marker.Tag = idAddres;
                            marker.ToolTipText = address;
                            marker.Icon = Properties.Resources.legendIcon;
                            marks.Add(marker);
                        }
                    }
                    myForm.Points = marks;
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
                    departments.Add(chklstDepartment.ItemsValues[e.Index]);

                if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
                    departments.Remove(chklstDepartment.ItemsValues[e.Index]);

                var cities = this._server.GetCitiesByDepartments(departments.Cast<int>().ToArray());                
                chklstCity.DataSource = cities;

            }
        }
        
    }
}
