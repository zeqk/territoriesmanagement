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
    public partial class frmTerritories : Form
    {
        static private bool _opened = false;
        private BLL.Territories server = new BLL.Territories();

        private bool _isDirty;

        public frmTerritories()
        {
            if (_opened)
                throw new Exception("The window is already opened.");
            else
                _opened = true;
            InitializeComponent();
        }

        private void frmTerritories_Load(object sender, EventArgs e)
        {
            string[] columns = { "Territory.Name","Territory.Number" };
            string[] variables = { "name","number" };
            schName.SetProperties(columns, variables);
            ConfigGrids();

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
            dgvResults.Columns.Add("Name", "Territory");
            dgvResults.Columns.Add("Number", "Number");
            dgvResults.Columns.Add("blank", "");

            dgvResults.Columns["Id"].Visible = false;
            dgvResults.Columns["Id"].DataPropertyName = "Id";
            dgvResults.Columns["Name"].Width = 150;
            dgvResults.Columns["Name"].DataPropertyName = "Name";
            dgvResults.Columns["Number"].Width = 100;
            dgvResults.Columns["Number"].DataPropertyName = "Number";
            dgvResults.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;

            dgvAddresses.Columns.Add("Id", "Id");
            dgvAddresses.Columns.Add("Address", "Address");
            dgvAddresses.Columns.Add("Corners", "Between");
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

            dgvTours.Columns.Add("Id", "Id");
            dgvTours.Columns.Add("Number", "Tour Nº");
            dgvTours.Columns.Add("BeginDate", "Begin");
            dgvTours.Columns.Add("EndDate", "End");
            dgvTours.Columns.Add("blank", "");

            dgvTours.Columns["Id"].Visible = false;
            dgvTours.Columns["Id"].DataPropertyName = "Id";
            dgvTours.Columns["Number"].Width = 100;
            dgvTours.Columns["Number"].DataPropertyName = "Number";
            dgvTours.Columns["BeginDate"].Width = 150;
            dgvTours.Columns["BeginDate"].DataPropertyName = "BeginDate";
            dgvTours.Columns["EndDate"].Width = 150;
            dgvTours.Columns["EndDate"].DataPropertyName = "EndDate";
            dgvTours.Columns["blank"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvTours.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTours.MultiSelect = false;

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

        private Territory FormToOject()
        {
            Territory rv = (Territory)this.bsTerritory.DataSource;
            return rv;
        }

        private void ObjectToForm(Territory v)
        {
            this.bsTerritory.DataSource = v;
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
                    v =this.server.Save(v);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var v = FormToOject();
            try
            {
                this.server.Delete(v.IdTerritory);
                Filter();
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

                    LoadRelations((Territory)bsTerritory.DataSource);
                }
                else
                    MessageBox.Show("You must select any territory");
            }
        }

        private void LoadRelations(Territory v)
        {
            IDictionary relations = this.server.LoadRelations(v.IdTerritory);
            dgvAddresses.DataSource = relations["Addresses"];
            dgvAddresses.Refresh();

            dgvAddresses.RowHeadersVisible = false;

            dgvTours.DataSource = relations["Tours"];
            dgvTours.Refresh();

            dgvTours.RowHeadersVisible = false;

        }

        private void frmTerritories_Shown(object sender, EventArgs e)
        {
            New();
        }

        private bool IsComplete()
        {
            bool rv = true;
            if (string.IsNullOrEmpty(txtName.Text))
                rv = false;
            if (string.IsNullOrEmpty(txtNumber.Text))
                rv = false;

            return rv;
        }

        private void frmTerritories_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _opened = false;
        }


    }
}
