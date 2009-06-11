using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using Territories.BLL;
using Territories.Model;


namespace Territories.GUI
{
    public partial class frmDirections : Form
    {
        BLL.Directions _server = new Directions();
        private bool _isDirty;
        
        public frmDirections()
        {
            InitializeComponent();

        }

        private void search2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDirections_Load(object sender, EventArgs e)
        {
            string[] columns1 = { "Direction.Street" };
            string[] variables1 = { "street" };
            schStreet.SetProperties(columns1, variables1);

            ConfigGrids();

            cboDepartment.DataSource = this._server.GetDepartments();
            cboDepartment.DisplayMember = "Name";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedItem = null;
            
            cboCity.DisplayMember = "Name";
            cboCity.ValueMember = "Id";
            cboCity.SelectedItem = null;

            cboTerritory.DataSource = _server.GetTerritories();
            cboTerritory.DisplayMember = "Name";
            cboTerritory.ValueMember = "Id";
            cboTerritory.SelectedItem = null;

            
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
            dgvResults.RowHeadersVisible = false;

            dgvResults.Columns.Add("Id", "Id");            
            dgvResults.Columns.Add("DepartmentName", "Department");
            dgvResults.Columns.Add("CityName", "City");
            dgvResults.Columns.Add("Territory", "Territory");
            dgvResults.Columns.Add("Direction", "Street and Nº");
            dgvResults.Columns.Add("Corner1", "Corner1");
            dgvResults.Columns.Add("Corner2", "Corner2");
            dgvResults.Columns.Add("Description", "Description");
            dgvResults.Columns.Add("blank", "");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["DepartmentName"].Width = 100;
            dgvResults.Columns["DepartmentName"].DataPropertyName = "DepartmentName";
            dgvResults.Columns["CityName"].Width = 100;
            dgvResults.Columns["CityName"].DataPropertyName = "CityName";
            dgvResults.Columns["Territory"].Width = 100;
            dgvResults.Columns["Territory"].DataPropertyName = "Territory";
            dgvResults.Columns["Direction"].Width = 100;
            dgvResults.Columns["Direction"].DataPropertyName = "Direction";
            dgvResults.Columns["Corner1"].Width = 100;
            dgvResults.Columns["Corner1"].DataPropertyName = "Corner1";
            dgvResults.Columns["Corner2"].Width = 100;
            dgvResults.Columns["Corner2"].DataPropertyName = "Corner2";
            dgvResults.Columns["Description"].Width = 200;
            dgvResults.Columns["Description"].DataPropertyName = "Description";

            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            schStreet.Clear();
            cboDepartment.SelectedItem = null;
            cboTerritory.SelectedItem = null;
            LoadResults("");
            lblFiltered.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            try
            {
                schStreet.MakeQuery();
                List<ObjectParameter> parameters = new List<ObjectParameter>();
                string strQuery = "";

                if (!schStreet.IsClean())
                {
                    strQuery = schStreet.Query;
                    schStreet.Parameters.ForEach(delegate(ObjectParameter param)
                    {
                        parameters.Add(param);
                    });
                }

                if (cboCity.SelectedValue != null)
                {
                    if (parameters.Count > 0)
                        strQuery += " AND ";

                    strQuery += "Direction.City.IdCity = @IdCity";
                    ObjectParameter cityPar = new ObjectParameter("IdCity", (int)cboCity.SelectedValue);

                    parameters.Add(cityPar);
                }

                if (cboTerritory.SelectedValue != null)
                {
                    if (parameters.Count > 0)
                        strQuery += " AND ";

                    strQuery += "Direction.Territory.IdTerritory = @IdTerritory";
                    ObjectParameter terrPar = new ObjectParameter("IdTerritory", (int)cboTerritory.SelectedValue);

                    parameters.Add(terrPar);
                }

                dgvResults.DataSource = this._server.Search(strQuery, parameters.ToArray<ObjectParameter>());

                lblFiltered.Visible = true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }  
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmDirection myForm = new frmDirection(_server))
            {
                try
                {
                    var dir = _server.NewObject();
                    myForm.Direction = dir;

                    myForm.ShowDialog();
                    if (myForm.DialogResult == DialogResult.OK)
                    {
                        dir = myForm.Direction;
                        _server.Save(dir);
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
            if (dgvResults.SelectedRows.Count != 0)
            {
                var v = _server.Load((int)dgvResults.SelectedRows[0].Cells["Id"].Value);

                using (frmDirection myForm = new frmDirection(_server))
                {
                    try
                    {
                        myForm.Direction = v;

                        myForm.ShowDialog();
                        if (myForm.DialogResult == DialogResult.OK)
                        {
                            v = myForm.Direction;
                            _server.Save(v);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
            else
                MessageBox.Show("Select any direction");
        }
    }
}
