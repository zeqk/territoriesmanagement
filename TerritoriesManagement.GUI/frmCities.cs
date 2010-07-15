using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using Localizer;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.GUI
{
    public partial class frmCities : Form
    {
        static private bool opened = false;
        private Cities server = new Cities();

        private bool isDirty;

        public frmCities()
        {
            
            if (opened)
                throw new Exception(GetString("The window is already open."));
            else
                opened = true;

            InitializeComponent();

            Globalization.RefreshUI(this);
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

            cboFilterDepartment.DataSource = this.server.GetDepartments();
            cboFilterDepartment.DisplayMember = "Name";
            cboFilterDepartment.ValueMember = "Id";
            cboFilterDepartment.SelectedItem = null;

            isDirty = false; //porque al cargar los datos del combo el isDirty sepone en true
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
                this.server.Delete(v.IdCity);

                //traigo los datos actualizados
                if (lblFiltered.Visible) Filter();
                else ClearFilter();

                //limpio el formulario
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GetString("Error"));
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

                    LoadRelations((City)bsCity.DataSource);
                }
                else
                    MessageBox.Show(GetString("You must select a city"));
            }
        }

        private void frmCities_Shown(object sender, EventArgs e)
        {
            New();
        }

        private void frmCities_FormClosed(object sender, FormClosedEventArgs e)
        {
            opened = false;
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }


        private void LoadResult(string strQuery, params ObjectParameter[] parameters)
        {
            try
            {
                var result = this.server.Search(strQuery, parameters);
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
            dgvResult.Columns.Add("Name", GetString("City"));
            dgvResult.Columns.Add("DepartmentName", GetString("Department"));
            dgvResult.Columns.Add("blank", "");

            dgvResult.Columns["Id"].Visible = false;
            dgvResult.Columns["Id"].DataPropertyName = "Id";
            dgvResult.Columns["Name"].Width = 150;
            dgvResult.Columns["Name"].DataPropertyName = "Name";
            dgvResult.Columns["DepartmentName"].Width = 100;
            dgvResult.Columns["DepartmentName"].DataPropertyName = "DepartmentName";
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

            dgvPublishers.Columns.Add("Id", GetString("Id"));
            dgvPublishers.Columns.Add("Name", GetString("Publisher"));
            dgvPublishers.Columns.Add("blank", "");

            dgvPublishers.Columns["Id"].Visible = false;
            dgvPublishers.Columns["Id"].DataPropertyName = "Id";
            dgvPublishers.Columns["Name"].Width = 200;
            dgvPublishers.Columns["Name"].DataPropertyName = "Name";
            dgvPublishers.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublishers.MultiSelect = false;

        }

        private City FormToOject()
        {
            City rv = (City)this.bsCity.DataSource;
            rv.Department = new Model.Department();
            if (cboDepartment.SelectedItem != null)
                rv.Department.IdDepartment = (int)cboDepartment.SelectedValue;
            else 
                rv.Department.IdDepartment = 0;
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
                    v = this.server.Save(v);

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
            if (txtName.Text == "")
                rv = false;
            if (cboDepartment.SelectedValue == null)
                rv = false;

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

                if (cboFilterDepartment.SelectedValue != null)
                {
                    if (parameters.Count > 0)
                        strQuery = strQuery + " AND ";

                    strQuery = strQuery + "City.Department.IdDepartment = @IdDepartment";
                    ObjectParameter depPar = new ObjectParameter("IdDepartment", (int)cboFilterDepartment.SelectedValue);

                    parameters.Add(depPar);
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
            cboFilterDepartment.SelectedItem = null;
            schName.Clear();
            LoadResult("");
            lblFiltered.Visible = false;
            dgvResult.ClearSelection();
        }        

        private void LoadRelations(City v)
        {
            IDictionary relations = this.server.LoadRelations(v.IdCity);
            dgvAddresses.DataSource = relations["Addresses"];
            dgvAddresses.Refresh();

            dgvAddresses.RowHeadersVisible = false;

            dgvPublishers.DataSource = relations["Publishers"];
            dgvPublishers.Refresh();

            dgvPublishers.RowHeadersVisible = false;

        }

        private string GetString(string text)
        {
            return Globalization.GetString(text);            
        }

    }
}
