using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Territories.DAL;
using Territories.DAL.Server;

namespace Territories.GUI
{
    public partial class frmCities : Form
    {        
        
        private Cities server = new Cities();

        private bool isDirty;

        private BindingSource source = new BindingSource();

        public frmCities()
        {            
            InitializeComponent();
            
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            schName.SetProperties("City.Name", "Filter city name", "name");

            this.LoadResults("");
            ConfigDgvResults();

            
            cmbDepartment.DataSource = this.server.GetDepartments();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.SelectedItem = null;

            cmbFilterDepartment.DataSource = this.server.GetDepartments();
            cmbFilterDepartment.DisplayMember = "Name";
            cmbFilterDepartment.SelectedItem = null;
            this.ClearForm();
            this.New();
            
        }
        private void LoadResults(string query)
        {
            try
            {
                source.DataSource = this.server.Search(query);
                dgvResults.DataSource = source;

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
            dgvResults.Columns["IdCity"].Visible = false;

            dgvResults.Columns["Name"].HeaderText = "City";

            dgvResults.Columns["Publishers"].Visible = false;
            dgvResults.Columns["Directions"].Visible = false;

            dgvResults.Columns["Department"].Visible = false;

            dgvResults.Columns.Add("DepName", "Department");            
            
                        
            dgvResults.Columns.Add("blank", "");
            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.Columns["IdCity"].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            dgvResults.Columns["Name"].SortMode = DataGridViewColumnSortMode.Automatic;                                 

        }        



        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();            
        }        

        private void ObjectToForm(City city)
        {
            lblId.Text = city.IdCity.ToString();
            txtName.Text = city.Name;
            cmbDepartment.SelectedItem = city.Department;            

            this.LoadRelations(city.Directions.ToList<Direction>(),city.Publishers.ToList<Publisher>());

        }

        private City FormToObject()
        {
            var city = new City();
            city.IdCity = Int32.Parse(lblId.Text);
            city.Name = txtName.Text;
            city.Department =(Department) cmbDepartment.SelectedItem;
            return city;
        }


        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count != 0)
            {
                var city = (City)source[dgvResults.SelectedRows[0].Index];
                this.ObjectToForm(city);
                this.isDirty = false;
            }
            else
                this.ObjectToForm(this.server.NewObject());
            
        }

        private void ClearForm()
        {
            dgvResults.ClearSelection();
            txtName.Clear();
            lblId.Text = "";
            cmbDepartment.SelectedItem = null;
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
                this.ClearForm();
                try
                {
                    var city = this.server.NewObject();
                    this.ObjectToForm(city);
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
            var city = this.FormToObject();

            try
            {
                if (city.IdCity == 0)
                    this.server.Insert(city);
                else
                    this.server.Update(city);

                this.LoadResults("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var city = this.FormToObject();
            try
            {
                this.server.Delete(city);
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
                    this.tabPanel.Visible = true;
                else
                    MessageBox.Show("You must selecet any department");
            }
                

        }

        private void LoadRelations(List<Direction> directions,List<Publisher> publishers)
        {
            //dgvDirections.DataSource = directions;

            //dgvDirections.RowHeadersVisible = false;

            //dgvDirections.Columns["IdDirection"].Visible = false;
            //dgvDirections.Columns["Department"].Visible = false;
            //dgvDirections.Columns["Directions"].Visible = false;
            //dgvDirections.Columns["Publishers"].Visible = false;

            //dgvDirections.Columns["Name"].HeaderText = "City";
            //dgvDirections.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            
        }

        private void dgvResults_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var city = (City)source[e.RowIndex];
            dgvResults.Rows[e.RowIndex].Cells["DepName"].ReadOnly = false;
            dgvResults.Rows[e.RowIndex].Cells["DepName"].Value = city.Department.Name;
        }

        
    }
}
