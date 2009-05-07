using System;
using System.Collections.Generic;
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

        private Department _department;

        private bool isDirty;

        private BindingSource source = new BindingSource();

        public frmDepartments()
        {
            
            InitializeComponent();
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            schName.SetProperties("Department.Name", "Filter department name", "name");

            this.LoadResults("");
            ConfigDgvResults();


            
            
        }
        private void LoadResults(string query)
        {
            try
            {
                source.DataSource = this.server.Search(query);
                source.Sort = "Name";//no funciona
                dgvResults.DataSource  = source;
                
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Error");
            }
            lblFiltered.Visible = false;

        }

        private void ConfigDgvResults()
        {            
            
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;           

            dgvResults.RowHeadersVisible = false;
            dgvResults.Columns["Id"].Visible = false;

            dgvResults.Columns["Name"].HeaderText = "Department";
            dgvResults.Columns["Name"].Width = 200;
            

            dgvResults.Columns.Add("blank", "");
            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.Columns["Id"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvResults.Columns["Name"].SortMode = DataGridViewColumnSortMode.Automatic;

        }        



        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        } 

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {            
                
                if (dgvResults.SelectedRows.Count != 0)
                {
                    var dep = this.server.Load((int)dgvResults.SelectedRows[0].Cells["Id"].Value);
                    this.ObjectToForm(dep);
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
            this.bsCities.DataSource = dep.Cities;
        }

        private void ClearForm()
        {
            dgvResults.ClearSelection();
            var dep = this.server.NewObject();
            this.ObjectToForm(dep);
            txtName.Focus();
            this.isDirty = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
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
                    var dep = this.server.NewObject();
                    this.ObjectToForm(dep);
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
            var dep = this.FormToOject();

            try
            {
                if (dep.IdDepartment == 0)
                    this.server.Insert(dep);
                else
                    this.server.Update(dep);

                this.LoadResults("");
                //this.ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dep = this.FormToOject();
            try
            {
                this.server.Delete(dep);
                this.LoadResults("");
                this.ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void Filter()
        {
            try
            {
                this.schName.MakeQuery();
                ObjectParameter[]  parameters ={ this.schName.Parameter};

                this.dgvResults.DataSource = this.server.Search(this.schName.Query, parameters);

                lblFiltered.Visible = true;

                this.ClearForm();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error");
            }
            
            
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            this.LoadResults("");
            this.lblFiltered.Visible = false;
            this.ClearForm();
        }

        private void btnRelations_Click(object sender, EventArgs e)
        {
            if (this.tabPanel.Visible == true)
                this.tabPanel.Visible = false;
            else
            {
                if (lblId.Text != "0")
                {
                    this.tabPanel.Visible = true;
                     

                }
                else
                    MessageBox.Show("You must selecet any department");
            }
                

        }

        private void LoadRelations(List<City> cities)
        {
            dgvCities.DataSource = cities;

            dgvCities.RowHeadersVisible = false;

            dgvCities.Columns["IdCity"].Visible = false;
            dgvCities.Columns["Department"].Visible = false;
            dgvCities.Columns["Directions"].Visible = false;
            dgvCities.Columns["Publishers"].Visible = false;

            dgvCities.Columns["Name"].HeaderText = "City";
            dgvCities.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dgvCities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDepartments_Shown(object sender, EventArgs e)
        {
            this.New();
        }

        private void frmDepartments_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Desea guardar los cambios efectuados?", "Mensaje", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.server.SaveChanges();
            }
        }

        
    }
}
