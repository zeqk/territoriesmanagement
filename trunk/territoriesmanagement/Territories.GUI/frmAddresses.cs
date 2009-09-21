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
    public partial class frmAddresses : Form
    {
        BLL.Addresses _server = new Addresses();
        
        public frmAddresses()
        {
            InitializeComponent();

        }

        private void frmAddresses_Load(object sender, EventArgs e)
        {
            chkStreet.Checked = true;

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
            dgvResults.Columns.Add("Address", "Street and Nº");
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
            dgvResults.Columns["Address"].Width = 100;
            dgvResults.Columns["Address"].DataPropertyName = "Address";
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

        private void btnAll_Click(object sender, EventArgs e)
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

                    strQuery += "Address.City.IdCity = @IdCity";
                    ObjectParameter cityPar = new ObjectParameter("IdCity", (int)cboCity.SelectedValue);

                    parameters.Add(cityPar);
                }
                else
                    if (cboDepartment.SelectedValue!=null)
                    {
                        if (parameters.Count > 0)
                            strQuery += " AND ";

                        strQuery += "Address.City.Department.IdDepartment = @IdDepartment";
                        ObjectParameter depPar = new ObjectParameter("IdDepartment", (int)cboDepartment.SelectedValue);

                        parameters.Add(depPar);
                    }

                if (cboTerritory.SelectedValue != null)
                {
                    if (parameters.Count > 0)
                        strQuery += " AND ";

                    strQuery += "Address.Territory.IdTerritory = @IdTerritory";
                    ObjectParameter terrPar = new ObjectParameter("IdTerritory", (int)cboTerritory.SelectedValue);

                    parameters.Add(terrPar);
                }
                if (!string.IsNullOrEmpty(strQuery))
                {
                    dgvResults.DataSource = this._server.Search(strQuery, parameters.ToArray<ObjectParameter>());
                    lblFiltered.Visible = true;
                }
                else
                    MessageBox.Show("Debe llenar al menos 1 campo de búsqueda");

                
            }
            catch (Exception ex)
            {                
                throw ex;
            }  
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmAddress myForm = new frmAddress(_server))
            {
                try
                {
                    var address = _server.NewObject();
                    myForm.Address = address;

                    myForm.ShowDialog();
                    if (myForm.DialogResult == DialogResult.OK)
                    {
                        address = myForm.Address;
                        _server.Save(address);
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

                using (frmAddress myForm = new frmAddress(_server))
                {
                    try
                    {
                        myForm.Address = v;

                        myForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Select any address.");
        }

        private void fields_CheckedChanged(object sender, EventArgs e)
        {
            List<string> columns = new List<string>();
            List<string> variables = new List<string>();

            if (chkStreet.Checked)
            {
                columns.Add("Address.Street");
                variables.Add("street");
            }

            if (chkCorners.Checked)
            {
                columns.Add("Address.Corner1");
                variables.Add("corner1");
                columns.Add("Address.Corner2");
                variables.Add("corner2");
            }

            if (chkDescription.Checked)
            {
                columns.Add("Address.Description");
                variables.Add("desc");
            }
            if (columns.Count>0)
            {
                schStreet.SetProperties(columns.ToArray(), variables.ToArray());
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos 1 campo donde buscar");
                ((CheckBox)sender).Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count!=0)
            {
                int idAddress = (int)dgvResults.SelectedRows[0].Cells["Id"].Value;
                try
                {
                    _server.Delete(idAddress);
                    Filter();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            
        }
    }
}
