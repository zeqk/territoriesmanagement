﻿using System;
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

        private Cities server = new Cities();

        private bool isDirty;

        public frmCities()
        {
            
            InitializeComponent();
        }

        private void frmCities_Load(object sender, EventArgs e)
        {
            schName.SetProperties("City.Name", "Filter city name", "name");
            ConfigGrids();

            this.cboDepartment.DataSource = this.server.GetDepartments();                     
            this.cboDepartment.DisplayMember = "Name";
            this.cboDepartment.ValueMember = "Id";
            this.cboDepartment.SelectedItem = null;

            this.cboFilterDepartment.DataSource = this.server.GetDepartments();
            this.cboFilterDepartment.DisplayMember = "Name";
            this.cboFilterDepartment.ValueMember = "Id";
            this.cboFilterDepartment.SelectedItem = null;

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
            dgvResults.Columns.Add("Name","City");
            dgvResults.Columns.Add("DepartmentName", "Department");
            dgvResults.Columns.Add("blank","");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["Name"].Width =150;
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
            dgvPublishers.Columns.Add("Name", "City");
            dgvPublishers.Columns.Add("blank", "");

            dgvPublishers.Columns["Id"].Visible = false;
            dgvPublishers.Columns["Id"].DataPropertyName = "Id";
            dgvPublishers.Columns["Name"].Width = 200;
            dgvPublishers.Columns["Name"].DataPropertyName = "Name";
            dgvPublishers.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublishers.MultiSelect = false;

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

                List<ObjectParameter> parameters =  new List<ObjectParameter>();
                string strQuery = "";

                if (schName.Parameter.Value.ToString() != "")
                {
                    strQuery = schName.Query;
                    parameters.Add(schName.Parameter);
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
                tabPanel.Visible = false;
            else
            {
                if (lblId.Text != "0")
                {
                    tabPanel.Visible = true;
                    LoadRelations((City)bsCity.DataSource);
                }
                else
                    MessageBox.Show("You must select any city");
            }   
        }

        private void LoadRelations(City v)
        {
            dgvDirections.DataSource = this.server.LoadRelations(v.IdCity)["Cities"];
            dgvDirections.Refresh();

            dgvDirections.RowHeadersVisible = false;

            dgvPublishers.DataSource = this.server.LoadRelations(v.IdCity)["Publishers"];
            dgvPublishers.Refresh();

            dgvPublishers.RowHeadersVisible = false;

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

        
    }
}
