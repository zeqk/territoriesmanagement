using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using Localizer;
using TerritoriesManagement.DataBridge;

namespace TerritoriesManagement.GUI
{
    public partial class frmDepartments : Form
    {
        static private bool opened = false;
        private Departments server = new Departments();
        private bool isDirty;

        public frmDepartments()
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

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            string[] columns = { "Department.Name" };
            string[] variables = { "name" };
            schName.SetProperties(columns,variables);
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
                this.server.Delete(v.IdDepartment);

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

                    LoadRelations((Model.Department)bsDepartment.DataSource);
                }
                else
                    MessageBox.Show(GetString("You must select a department"));
            }
        }

        private void frmDepartments_Shown(object sender, EventArgs e)
        {
            New();
        }

        private void frmDepartments_FormClosed(object sender, FormClosedEventArgs e)
        {
            opened = false;
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
            dgvResult.Columns.Add("Name", GetString("Department"));
            dgvResult.Columns.Add("blank","");

            dgvResult.Columns["Id"].Visible = false;
            dgvResult.Columns["Id"].DataPropertyName = "Id";
            dgvResult.Columns["Name"].Width =250;
            dgvResult.Columns["Name"].DataPropertyName = "Name";
            dgvResult.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.MultiSelect = false;

            dgvCities.Columns.Add("Id", GetString("Id"));
            dgvCities.Columns.Add("Name", GetString("City"));            
            dgvCities.Columns.Add("blank", "");

            dgvCities.Columns["Id"].Visible = false;
            dgvCities.Columns["Id"].DataPropertyName = "Id";
            dgvCities.Columns["Name"].Width = 200;
            dgvCities.Columns["Name"].DataPropertyName = "Name";
            dgvCities.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCities.MultiSelect = false;

        } 

        private Model.Department FormToOject()
        {
            return (Model.Department)this.bsDepartment.DataSource;
        }

        private void ObjectToForm(Model.Department v)
        {
            this.bsDepartment.DataSource = v;
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
            var v = this.FormToOject();
            if (IsComplete())
            {
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
            if (string.IsNullOrEmpty(txtName.Text))
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
                    parameters = schName.Parameters;
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

        private void LoadRelations(Model.Department v)
        {
            dgvCities.DataSource = this.server.LoadRelations(v.IdDepartment)["Cities"];
            dgvCities.Refresh();

            dgvCities.RowHeadersVisible = false;

        }

        private void schName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Filter();
        }

        
    }
}
