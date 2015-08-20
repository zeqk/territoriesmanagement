using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AltosTools;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Localizer;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Export;
using System.Text;
using TerritoriesManagement.Model;
using TerritoriesManagement.Reporting;

namespace TerritoriesManagement.GUI
{
    public partial class frmAddresses : Form
    {
        Addresses server = new Addresses();

        bool isGettingAll = false;

        int prevWidth;

        public frmAddresses()
        {
            InitializeComponent();
            prevWidth = dgvResult.Width;
            Globalization.RefreshUI(this);

        }

        private string GetString(string text,params object[] args)
        {
            string rv = Localizer.Globalization.GetString(text);            
            return string.Format(rv,args);
        }

        private void frmAddresses_Load(object sender, EventArgs e)
        {
            chkStreet.Checked = true;

            ConfigGrids();

            var departments = this.server.GetDepartments();

            chklstDepartment.DisplayMember = "Name";
            chklstDepartment.ValueMember = "Id";
            chklstDepartment.DataSource = departments;

            var cities = this.server.GetCities();
            chklstCity.DisplayMember = "Name";
            chklstCity.ValueMember = "Id";
            chklstCity.DataSource = cities;

            var territories = server.GetTerritories();
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
            using (frmAddress myForm = new frmAddress(server))
            {
                try
                {
                    var address = server.NewObject();
                    myForm.Address = address;

                    if (myForm.ShowDialog() == DialogResult.OK)
                    {
                        if (lblFiltered.Visible) Search();
                        else GetAll();
                    }

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
                var v = server.Load((int)dgvResult.SelectedRows[0].Cells["Id"].Value);

                using (frmAddress myForm = new frmAddress(server))
                {
                    try
                    {
                        myForm.Address = v;
                        if (myForm.ShowDialog() == DialogResult.OK)
                        {

                            int index = dgvResult.SelectedRows[0].Index;
                            int scrollIndex = dgvResult.FirstDisplayedScrollingRowIndex;

                            if (lblFiltered.Visible) Search();
                            else GetAll();

                            dgvResult.ClearSelection();
                            dgvResult.Rows[index].Selected = true;
                            dgvResult.FirstDisplayedScrollingRowIndex = scrollIndex;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show(GetString("You must select an address."));
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
                if (MessageBox.Show(GetString("Are you sure you want to delete these {0} addresses?", dgvResult.SelectedRows.Count), "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        for (int i = 0; i < dgvResult.SelectedRows.Count; i++)
                        {
                            int idAddress = (int)dgvResult.SelectedRows[i].Cells["Id"].Value;

                            server.Delete(idAddress);
                        }

                        if (lblFiltered.Visible) Search();
                        else GetAll();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, GetString("Error"));
                    }
                }
            }
            else
                MessageBox.Show(GetString("You must select an address."));

        }

        private void LoadResult(string query, params ObjectParameter[] parameters)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            try
            {
                var addresses = this.server.Search(query,parameters);
                dgvResult.DataSource = addresses;
                lblResultCount.Text = addresses.Count.ToString();                
                lblFiltered.Visible = (query != "");
                dgvResult.ClearSelection();

                //foreach (DataGridViewRow row in this.dgvResult.Rows)
                //{
                //    if ((bool)row.Cells["Mark"].Value == true)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.LightGray;
                //    }
                //}
                watch.Stop();
                var tiempo = watch.Elapsed.TotalSeconds;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
            }
        }

        private void ConfigGrids()
        {
            dgvResult.RowHeadersVisible = false;
            dgvResult.Columns.Add("Id", GetString("Id"));            
            dgvResult.Columns.Add("DepartmentName",GetString("Department"));
            dgvResult.Columns.Add("CityName", GetString("City"));
            dgvResult.Columns.Add("Territory", GetString("Territory"));
            dgvResult.Columns.Add("InternalTerritoryNumber", GetString("Number"));
            dgvResult.Columns.Add("Address", GetString("Street and Nº"));
            dgvResult.Columns.Add("Corner1", GetString("Corner 1"));
            dgvResult.Columns.Add("Corner2", GetString("Corner 2"));
            dgvResult.Columns.Add("Description", GetString("Description"));
            dgvResult.Columns.Add(new DataGridViewCheckBoxColumn());
            dgvResult.Columns[9].Name = "HasGeoPosition";
            dgvResult.Columns[9].HeaderText = GetString("GEO");
            dgvResult.Columns.Add("Marked", GetString("Marked"));            
            dgvResult.Columns.Add("Lat", GetString("Lat"));
            dgvResult.Columns.Add("Lng", GetString("Lng"));

            dgvResult.Columns["Id"].Visible = false;
            dgvResult.Columns["Id"].DataPropertyName = "Id";
            dgvResult.Columns["DepartmentName"].MinimumWidth = 100;
            dgvResult.Columns["DepartmentName"].Width = 100;
            dgvResult.Columns["DepartmentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["DepartmentName"].DataPropertyName = "DepartmentName";
            dgvResult.Columns["CityName"].MinimumWidth = 85;
            dgvResult.Columns["CityName"].Width = 85;
            dgvResult.Columns["CityName"].DataPropertyName = "CityName";
            dgvResult.Columns["CityName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["Territory"].MinimumWidth = 85;
            dgvResult.Columns["Territory"].DataPropertyName = "Territory";
            dgvResult.Columns["Territory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["InternalTerritoryNumber"].MinimumWidth = 50;
            dgvResult.Columns["InternalTerritoryNumber"].Width = 50;
            dgvResult.Columns["InternalTerritoryNumber"].DataPropertyName = "InternalTerritoryNumber";
            dgvResult.Columns["InternalTerritoryNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvResult.Columns["InternalTerritoryNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResult.Columns["Address"].MinimumWidth = 100;
            dgvResult.Columns["Address"].Width = 100;
            dgvResult.Columns["Address"].DataPropertyName = "Address";
            dgvResult.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["Corner1"].MinimumWidth = 100;
            dgvResult.Columns["Corner1"].Width = 100;
            dgvResult.Columns["Corner1"].DataPropertyName = "Corner1";
            dgvResult.Columns["Corner1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["Corner2"].MinimumWidth = 100;
            dgvResult.Columns["Corner2"].Width = 100;
            dgvResult.Columns["Corner2"].DataPropertyName = "Corner2";
            dgvResult.Columns["Corner2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["Description"].MinimumWidth = 150;
            dgvResult.Columns["Description"].Width = 150;
            dgvResult.Columns["Description"].DataPropertyName = "Description";
            dgvResult.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.Columns["HasGeoPosition"].MinimumWidth = 40;
            dgvResult.Columns["HasGeoPosition"].Width = 40;
            dgvResult.Columns["HasGeoPosition"].DataPropertyName = "HasGeoPosition";
            dgvResult.Columns["HasGeoPosition"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvResult.Columns["Marked"].Visible = false;
            dgvResult.Columns["Marked"].DataPropertyName = "Marked";
            dgvResult.Columns["Lat"].Visible = false;
            dgvResult.Columns["Lat"].DataPropertyName = "Lat";
            dgvResult.Columns["Lng"].Visible = false;
            dgvResult.Columns["Lng"].DataPropertyName = "Lng";

            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = true;

        }

        private void GetAll()
        {
            isGettingAll = true;
            schStreet.Clear();
            chklstDepartment.CheckAllItems();
            chklstCity.DataSource = this.server.GetCities();
            chklstCity.CheckAllItems();
            chklstTerritory.CheckAllItems();
            chkMarked.Checked = false;
            LoadResult("");
            lblFiltered.Visible = false;
            isGettingAll = false;
        }

        private void Search()
        {
            try
            {

                List<ObjectParameter> parameters = new List<ObjectParameter>();
                string strQuery = GetQuery(out parameters);
                if (!string.IsNullOrEmpty(strQuery))
                {
                    this.LoadResult(strQuery, parameters.ToArray());
                    //var addresses = this.server.Search(strQuery, parameters.ToArray<ObjectParameter>());
                    //dgvResult.DataSource = addresses;
                    //lblResultCount.Text = addresses.Count.ToString();
                    //lblFiltered.Visible = true;
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
                
                //obtengo la lista de ids de los territorios seleccionados
                var territoriesIds = chklstTerritory.CheckedItemsValues;
                string auxQueryStr = "";
                //por cada id seleccionado creo un parámetro (ObjectParameter) de búsqueda
                for (int i = 0; i < territoriesIds.Count; i++)
			    {
                    if (auxQueryStr != "")
                         auxQueryStr += " OR ";

                    if ((int)territoriesIds[i] != -1) //el id -1 representa al null
                    {
                        string varName = "IdTerritory" + i.ToString();
                        auxQueryStr += "Address.Territory.IdTerritory = @" + varName;
                        ObjectParameter param = new ObjectParameter(varName, territoriesIds[i]);
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
                if (auxParameters.Count > 0 || queryStr.Contains("IS NULL"))
                    queryStr += " AND ";

                var citiesIds = chklstCity.CheckedItemsValues;
                string auxQueryStr = "";
                for (int i = 0; i < citiesIds.Count; i++)
			    {
                    if (auxQueryStr != "")
                         auxQueryStr += " OR ";

                     string varName = "IdCity" + i.ToString();
                     auxQueryStr += "Address.City.IdCity = @" + varName;
                     ObjectParameter param = new ObjectParameter(varName, citiesIds[i]);
                     auxParameters.Add(param);
			    }
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

            if (chkMarked.Checked)
            {
                if (auxParameters.Count > 0)
                    queryStr += " AND ";
                queryStr += " Address.CustomField2 IS NOT NULL";
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



        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgvResult.SelectedRows.Count; i++)
		        {
                    //dgvResult.SelectedRows[i].DefaultCellStyle.BackColor = Color.LightGray;
    			    int id = (int)dgvResult.SelectedRows[i].Cells["Id"].Value;
                    sb.Append(id + ", ");
		        }
                string ids = sb.ToString();
                ids = ids.Remove(ids.Length - 2);

                server.MarkAddresses(ids,true);

                int index = dgvResult.SelectedRows[0].Index;
                int scrollIndex = dgvResult.FirstDisplayedScrollingRowIndex;

                if (lblFiltered.Visible) Search();
                else GetAll();

                dgvResult.ClearSelection();
                dgvResult.Rows[index].Selected = true;
                dgvResult.FirstDisplayedScrollingRowIndex = scrollIndex;
            }
        }



        private void unMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgvResult.SelectedRows.Count; i++)
                {
                    int id = (int)dgvResult.SelectedRows[i].Cells["Id"].Value;
                    sb.Append(id + ", ");
                }
                string ids = sb.ToString();
                ids = ids.Remove(ids.Length - 2);

                server.MarkAddresses(ids, false);

                int index = dgvResult.SelectedRows[0].Index;
                int scrollIndex = dgvResult.FirstDisplayedScrollingRowIndex;

                if (lblFiltered.Visible) Search();
                else GetAll();

                dgvResult.ClearSelection();

                if((dgvResult.Rows.Count - 1) > index)
                    dgvResult.Rows[index].Selected = true;
                if ((dgvResult.Rows.Count - 1) > scrollIndex)
                    dgvResult.FirstDisplayedScrollingRowIndex = scrollIndex;
            }
        }

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
                var list = (IList<AddressItem1>)dgvResult.DataSource;
                ReportsHelper.GenerateAddressesListReport(list, path);

                MessageBox.Show("El archivo " + path + " se generó exitosamente");
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
                var selectedRows = dgvResult.SelectedRows;
                List<GMapMarker> markers = new List<GMapMarker>();
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    bool hasGeoPosition = (bool)selectedRows[i].Cells["HasGeoposition"].Value;
                    if (hasGeoPosition)
                    {
                        double lat = (double)selectedRows[i].Cells["Lat"].Value;
                        double lng = (double)selectedRows[i].Cells["Lng"].Value;
                        string address = selectedRows[i].Cells["Address"].Value.ToString();

                        //int? internalNumber = (int?)selectedRows[i].Cells["InternalTerritoryNumber"].Value;

                        GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(lat, lng));
                        marker.Size = new System.Drawing.Size(4, 4);
                        //if(internalNumber.HasValue)
                        //    marker.Tag = internalNumber.Value;
                        marker.ToolTipText = address;
                        marker.Icon = Properties.Resources.legendIcon;
                        markers.Add(marker);
                    }
                }

                var map = frmMap.GetInstance();
                
                map.Clear();
                map.OtherMarkers = markers;
                map.MapMode = MapModeEnum.ReadOnly;
                map.ShowDialog();
            }
        }

        private void chklstDepartment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!isGettingAll)
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

                var cities = this.server.GetCitiesByDepartments(departments.Cast<int>().ToArray());                
                chklstCity.DataSource = cities;

            }
        }

        private void schStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }


        private void btnViewStatistics_Click(object sender, EventArgs e)
        {
            bool ok = false;
            double distance = 0;
            using (frmAddressesStatistics myForm = new frmAddressesStatistics())
            {
                ok = (myForm.ShowDialog() == DialogResult.OK);
                distance = myForm.Distance;
            }

            
            if (ok  && dgvResult.Rows.Count > 0)
            {
                var rows = dgvResult.Rows;
                List<GMapMarker> markers = new List<GMapMarker>();

                List<PointLatLng> points = new List<PointLatLng>();

                for (int i = 0; i < rows.Count; i++)
                {
                    bool hasGeoPosition = (bool)rows[i].Cells["HasGeoposition"].Value;
                    if (hasGeoPosition)
                    {
                        double lat = (double)rows[i].Cells["Lat"].Value;
                        double lng = (double)rows[i].Cells["Lng"].Value;                       

                        points.Add(new PointLatLng(lat, lng));
                    }
                }

                IList clusterdPoints = GeoHelper.GetClusteredPoints(points, distance);

                foreach (List<PointLatLng> cluster in clusterdPoints)
                {


                    PointLatLng clusterCenter = GeoHelper.CalculateMiddlePoint(cluster);

                    GMapMarkerCustom marker = new GMapMarkerCustom(clusterCenter);
                    marker.Size = new System.Drawing.Size(10, 10);
                    marker.ToolTipText = cluster.Count.ToString();

                    Bitmap icon = Properties.Resources.yellow; //1
                    if (cluster.Count > 1 && cluster.Count <= 10)
                        icon = Properties.Resources.green;
                    else if (cluster.Count > 10 && cluster.Count <= 50)
                    {
                        icon = Properties.Resources.lightblue;
                    }
                    else if (cluster.Count > 50 && cluster.Count <= 100)
                    {
                        icon = Properties.Resources.blue;
                    }
                    else if (cluster.Count > 100 && cluster.Count <= 200)
                    {
                        icon = Properties.Resources.purple;
                    }
                    else if (cluster.Count > 200)
                    {
                        icon = Properties.Resources.red;
                    }
                    marker.Icon = icon;
                    
                    //marker.Offset = new Point(10,34);
                    markers.Add(marker);                    
                }

                var map = frmMap.GetInstance();                
                map.Clear();
                map.OtherMarkers = markers;
                map.MapMode = MapModeEnum.ReadOnly;
                map.ShowDialog();
                
            }
        }

        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {             
            if (e.ColumnIndex == 1)
            {
                string value = (string)this.dgvResult.Rows[e.RowIndex].Cells["Marked"].Value;                
                if(value != null)
                {
                    Color color = Color.FromName(value);
                    if(color.A != 0 && color.B != 0 && color.G != 0 && color.R != 0)
                        this.dgvResult.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
                }
            }
        }

        ////TODO. para seleccionar las columnas a ver
        //private void dgvResult_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ctxHeaderMenu.Show(dgvResult, e.X, e.Y);
        //    }
        //}

        //private void contextMenuItem_Click(object sender, EventArgs e)
        //{
        //    ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        //}
        
    }
}
