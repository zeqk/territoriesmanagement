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
using Territories.BLL.DataBridge;

namespace Territories.GUI
{
    public partial class frmDepartments : Form
    {
        static private bool _opened = false;
        private Departments _server = new Departments();
        private bool _isDirty;

        public frmDepartments()
        {
            if (_opened)
                throw new Exception("The window is already opened.");
            else
                _opened = true;   
            InitializeComponent();
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            string[] columns = { "Department.Name" };
            string[] variables = { "name" };
            schName.SetProperties(columns,variables);
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
                this._server.Delete(v.IdDepartment);

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

                    LoadRelations((Model.Department)bsDepartment.DataSource);
                }
                else
                    MessageBox.Show(GetString("You must select some department"));
            }
        }

        private void frmDepartments_Shown(object sender, EventArgs e)
        {
            New();
        }

        private void frmDepartments_FormClosed(object sender, FormClosedEventArgs e)
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
                MessageBox.Show(ex.Message, GetString("Error"));
            }
            lblFiltered.Visible = false;
        }

        private void ConfigGrids()
        {

            dgvResults.Columns.Add("Id", GetString("Id"));
            dgvResults.Columns.Add("Name", GetString("Department"));
            dgvResults.Columns.Add("blank","");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["Name"].Width =250;
            dgvResults.Columns["Name"].DataPropertyName = "Name";
            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;

            dgvCities.Columns.Add("Id", "Id");
            dgvCities.Columns.Add("Name", "City");            
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
            var v = this.FormToOject();
            if (IsComplete())
            {
                try
                {                    
                    v = this._server.Save(v);

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

        private void LoadRelations(Model.Department v)
        {
            dgvCities.DataSource = this._server.LoadRelations(v.IdDepartment)["Cities"];
            dgvCities.Refresh();

            dgvCities.RowHeadersVisible = false;

        }
        private string GetString(string text)
        {
            return text;
        }

        private void Internationalize()
        {
            //this.lblDepartment.Text = GetString("Department");
            //this.btnRelations.Text = GetString("View relations");
            //this.btnDelete.Text = GetString("Delete");
            //this.btnSave.Text = GetString("Save");
            //this.btnNew.Text = GetString("New");
            //this.lblName.Text = GetString("Name");
            //this.grdSearch.Text = GetString("Search");
            //this.lblFilterName.Text = GetString("Filter for city name");
            //this.lblFilterDepartment.Text = GetString("Filter for department");
            //this.lblResult.Text = GetString("Result:");
            //this.lblFiltered.Text = GetString("Filtered");
            //this.tabAddresses.Text = GetString("Addresses");
            //this.tabPublishers.Text = GetString("Publishers");
            //this.Text = GetString("Cities");
            //this.grpObject.Text = GetString("City");
        }

        
    }
}
