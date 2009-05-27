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

        private Departments server = new Departments();

        private bool isDirty;

        public frmDepartments()
        {
            
            InitializeComponent();
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            schName.SetProperties("Department.Name", "Filter department name", "name");
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

                    this.isDirty = false;
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
            this.isDirty = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void New()
        {
            bool yes = true;
            if (isDirty)
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
                    this.isDirty = false;
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
                this.server.Delete(v);
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

                if (schName.Parameter.Value.ToString() != "")
                {
                    strQuery = schName.Query;
                    parameters.Add(schName.Parameter);
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
            LoadResults("");
            lblFiltered.Visible = false;
            ClearForm();
        }

        private void btnRelations_Click(object sender, EventArgs e)
        {
            if (tabPanel.Visible == true)
                tabPanel.Visible = false;
            else
            {
                if (lblId.Text != "0")
                {
                    tabPanel.Visible = true;
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

        private void frmDepartments_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (MessageBox.Show("Desea guardar los cambios efectuados?", "Mensaje", MessageBoxButtons.OKCancel)==DialogResult.OK)
            //{
            //    this.server.SaveChanges();
            //}        
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
