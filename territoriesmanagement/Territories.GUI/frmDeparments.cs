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
    public partial class frmDepartments : Form
    {
        static private bool _opened = false;

        private Departments server = new Departments();

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
            this.LoadResults("");  
            
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
            dgvResults.Columns.Add("Name","Department");
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

        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private Department FormToOject()
        {
            return (Department)this.bsDepartment.DataSource;
        }

        private void ObjectToForm(Department dep)
        {
            this.bsDepartment.DataSource = dep;
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
                if (MessageBox.Show("Desea continuar?", "Message", MessageBoxButtons.YesNo) == DialogResult.No)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void Update()
        {
            var v = this.FormToOject();
            if (IsComplete())
            {
                try
                {                    
                    v = this.server.Save(v);

                    LoadResults("");
                    ClearForm();
                    ObjectToForm(v);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            else
                MessageBox.Show("The data is incomplete");            
        }

        private bool IsComplete()
        {
            bool rv = true;
            if (txtName.Text == "")
                rv = false;
            return rv;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var v = FormToOject();
            try
            {
                this.server.Delete(v.IdDepartment);
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
                string strQuery ="";

                if (!schName.IsClean())
                {
                    strQuery = schName.Query;
                    parameters = schName.Parameters;
                }

                if (!string.IsNullOrEmpty(strQuery))
                {
                    dgvResults.DataSource = this.server.Search(strQuery, parameters.ToArray<ObjectParameter>());
                    lblFiltered.Visible = true;
                }
                else
                    MessageBox.Show("Debe llenar al menos 1 campo de búsqueda");

                ClearForm();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Error");
            }
            
            
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
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

                    LoadRelations((Department)bsDepartment.DataSource);
                }
                else
                    MessageBox.Show("You must select any department");
            }
        }

        private void LoadRelations(Department v)
        {
            dgvCities.DataSource = this.server.LoadRelations(v.IdDepartment)["Cities"];
            dgvCities.Refresh();

            dgvCities.RowHeadersVisible = false;

        }

        private void frmDepartments_Shown(object sender, EventArgs e)
        {
            New();
        }
        

        private void frmDepartments_FormClosed(object sender, FormClosedEventArgs e)
        {
            _opened = false;
        }

        
    }
}
