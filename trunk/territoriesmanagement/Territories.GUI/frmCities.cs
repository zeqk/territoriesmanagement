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
using Territories.Model;
using Territories.BLL;

namespace Territories.GUI
{
    public partial class frmCities : Form
    {
        static private bool _opened = false;
        private Cities server = new Cities();

        private bool _isDirty;

        public frmCities()
        {
            if (_opened)
                throw new Exception("The window is already opened.");
            else
                _opened = true;
            InitializeComponent();
        }

        private void frmCities_Load(object sender, EventArgs e)
        {
            string[] columns = { "City.Name" };
            string[] variables = { "name" };
            schName.SetProperties(columns, variables);
            ConfigGrids();

            cboDepartment.DataSource = this.server.GetDepartments();
            cboDepartment.DisplayMember = "Name";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedItem = null;

            cboFilterDepartment.DataSource = this.server.GetDepartments();
            cboFilterDepartment.DisplayMember = "Name";
            cboFilterDepartment.ValueMember = "Id";
            cboFilterDepartment.SelectedItem = null;

            LoadResults("");
        }

        private void LoadResults(string query)
        {
            try
            {
                dgvResults.DataSource = this.server.Search(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            lblFiltered.Visible = false;
        }

        private void ConfigGrids()
        {

            dgvResults.Columns.Add("Id", "Id");
            dgvResults.Columns.Add("Name", "City");
            dgvResults.Columns.Add("DepartmentName", "Department");
            dgvResults.Columns.Add("blank", "");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["Name"].Width = 150;
            dgvResults.Columns["Name"].DataPropertyName = "Name";
            dgvResults.Columns["DepartmentName"].Width = 100;
            dgvResults.Columns["DepartmentName"].DataPropertyName = "DepartmentName";
            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;

            dgvDirections.Columns.Add("Id", "Id");
            dgvDirections.Columns.Add("Name", "Direction");
            dgvDirections.Columns.Add("blank", "");

            dgvDirections.Columns["Id"].Visible = false;
            dgvDirections.Columns["Id"].DataPropertyName = "Id";
            dgvDirections.Columns["Name"].Width = 200;
            dgvDirections.Columns["Name"].DataPropertyName = "Name";
            dgvDirections.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDirections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDirections.MultiSelect = false;

            dgvPublishers.Columns.Add("Id", "Id");
            dgvPublishers.Columns.Add("Name", "Publisher");
            dgvPublishers.Columns.Add("blank", "");

            dgvPublishers.Columns["Id"].Visible = false;
            dgvPublishers.Columns["Id"].DataPropertyName = "Id";
            dgvPublishers.Columns["Name"].Width = 200;
            dgvPublishers.Columns["Name"].DataPropertyName = "Name";
            dgvPublishers.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublishers.MultiSelect = false;

        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count != 0)
            {
                var v = server.Load((int)dgvResults.SelectedRows[0].Cells["Id"].Value);
                ObjectToForm(v);
                if (tabPanel.Visible)
                    LoadRelations(v);

                this._isDirty = false;
            }
        }

        private City FormToOject()
        {
            City rv = (City)this.bsCity.DataSource;
            rv.Department = new Department();
            rv.Department.IdDepartment = (int)cboDepartment.SelectedValue;
            return rv;
        }

        private void ObjectToForm(City v)
        {
            this.bsCity.DataSource = v;
            if (v.Department != null)
                this.cboDepartment.SelectedValue = v.Department.IdDepartment;
            else
                this.cboDepartment.SelectedItem = null;
        }

        private void ClearForm()
        {
            dgvResults.ClearSelection();
            var v = this.server.NewObject();
            ObjectToForm(v);
            txtName.Focus();
            this._isDirty = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this._isDirty = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void New()
        {
            bool yes = true;
            if (_isDirty)
                if (MessageBox.Show("Desea continuar?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    yes = false;
                    txtName.Focus();
                }
            if (yes)
            {
                ClearForm();
                try
                {
                    var v = this.server.NewObject();
                    ObjectToForm(v);
                    this._isDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
        {
            if (IsComplete())
            {
                var v = this.FormToOject();

                try
                {
                    this.server.Save(v);

                    LoadResults("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
                MessageBox.Show("The data is incomplete");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var v = FormToOject();
            try
            {
                this.server.Delete(v.IdCity);
                LoadResults("");
                ClearForm();
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

                if (cboFilterDepartment.SelectedValue != null)
                {
                    if (parameters.Count > 0)
                        strQuery = strQuery + " AND ";

                    strQuery = strQuery + "City.Department.IdDepartment = @IdDepartment";
                    ObjectParameter depPar = new ObjectParameter("IdDepartment", (int)cboFilterDepartment.SelectedValue);

                    parameters.Add(depPar);
                }

                dgvResults.DataSource = this.server.Search(strQuery, parameters.ToArray<ObjectParameter>());

                lblFiltered.Visible = true;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cboFilterDepartment.SelectedItem = null;
            schName.Clear();
            LoadResults("");
            lblFiltered.Visible = false;
            ClearForm();
        }

        private void btnRelations_Click(object sender, EventArgs e)
        {
            if (tabPanel.Visible == true)
            {
                tabPanel.Visible = false;
                btnRelations.Text = "View relations";
            }
            else
            {
                if (lblId.Text != "0")
                {
                    tabPanel.Visible = true;
                    btnRelations.Text = "Hide relations";

                    LoadRelations((City)bsCity.DataSource);
                }
                else
                    MessageBox.Show("You must select any city");
            }
        }

        private void LoadRelations(City v)
        {
            IDictionary relations = this.server.LoadRelations(v.IdCity);
            dgvDirections.DataSource = relations["Cities"];
            dgvDirections.Refresh();

            dgvDirections.RowHeadersVisible = false;

            dgvPublishers.DataSource = relations["Publishers"];
            dgvPublishers.Refresh();

            dgvPublishers.RowHeadersVisible = false;

        }

        private void frmCities_Shown(object sender, EventArgs e)
        {
            New();
        }

        private bool IsComplete()
        {
            bool rv = true;
            if (txtName.Text == "")
                rv = false;
            if (cboDepartment.SelectedValue == null)
                rv = false;

            return rv;
        }

        private void frmCities_FormClosed(object sender, FormClosedEventArgs e)
        {
            _opened = false;
        }


    }
}
