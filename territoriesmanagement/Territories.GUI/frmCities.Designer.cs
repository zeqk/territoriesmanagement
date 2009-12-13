namespace Territories.GUI
{
    partial class frmCities
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCities));
            this.grpObject = new System.Windows.Forms.GroupBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.bsCity = new System.Windows.Forms.BindingSource(this.components);
            this.btnRelations = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grdSearch = new System.Windows.Forms.GroupBox();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.schName = new ZeqkTools.WindowsForms.Controls.Search();
            this.lblFilterDepartment = new System.Windows.Forms.Label();
            this.cboFilterDepartment = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabAddresses = new System.Windows.Forms.TabPage();
            this.dgvAddresses = new System.Windows.Forms.DataGridView();
            this.tabPublishers = new System.Windows.Forms.TabPage();
            this.dgvPublishers = new System.Windows.Forms.DataGridView();
            this.grpObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).BeginInit();
            this.grdSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tabPanel.SuspendLayout();
            this.tabAddresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).BeginInit();
            this.tabPublishers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublishers)).BeginInit();
            this.SuspendLayout();
            // 
            // grpObject
            // 
            this.grpObject.AccessibleDescription = null;
            this.grpObject.AccessibleName = null;
            resources.ApplyResources(this.grpObject, "grpObject");
            this.grpObject.BackgroundImage = null;
            this.grpObject.Controls.Add(this.lblDepartment);
            this.grpObject.Controls.Add(this.cboDepartment);
            this.grpObject.Controls.Add(this.lblId);
            this.grpObject.Controls.Add(this.btnRelations);
            this.grpObject.Controls.Add(this.btnDelete);
            this.grpObject.Controls.Add(this.btnSave);
            this.grpObject.Controls.Add(this.btnNew);
            this.grpObject.Controls.Add(this.lblName);
            this.grpObject.Controls.Add(this.txtName);
            this.grpObject.Font = null;
            this.grpObject.Name = "grpObject";
            this.grpObject.TabStop = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AccessibleDescription = null;
            this.lblDepartment.AccessibleName = null;
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Font = null;
            this.lblDepartment.Name = "lblDepartment";
            // 
            // cboDepartment
            // 
            this.cboDepartment.AccessibleDescription = null;
            this.cboDepartment.AccessibleName = null;
            resources.ApplyResources(this.cboDepartment, "cboDepartment");
            this.cboDepartment.BackgroundImage = null;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = null;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // lblId
            // 
            this.lblId.AccessibleDescription = null;
            this.lblId.AccessibleName = null;
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCity, "IdCity", true));
            this.lblId.Font = null;
            this.lblId.Name = "lblId";
            // 
            // bsCity
            // 
            this.bsCity.DataSource = typeof(Territories.Model.City);
            // 
            // btnRelations
            // 
            this.btnRelations.AccessibleDescription = null;
            this.btnRelations.AccessibleName = null;
            resources.ApplyResources(this.btnRelations, "btnRelations");
            this.btnRelations.BackgroundImage = null;
            this.btnRelations.Font = null;
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.UseVisualStyleBackColor = true;
            this.btnRelations.Click += new System.EventHandler(this.btnRelations_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = null;
            this.btnDelete.AccessibleName = null;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.BackgroundImage = null;
            this.btnDelete.Font = null;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = null;
            this.btnSave.Font = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleDescription = null;
            this.btnNew.AccessibleName = null;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.BackgroundImage = null;
            this.btnNew.Font = null;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblName
            // 
            this.lblName.AccessibleDescription = null;
            this.lblName.AccessibleName = null;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Font = null;
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            this.txtName.AccessibleDescription = null;
            this.txtName.AccessibleName = null;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.BackgroundImage = null;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCity, "Name", true));
            this.txtName.Font = null;
            this.txtName.Name = "txtName";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grdSearch
            // 
            this.grdSearch.AccessibleDescription = null;
            this.grdSearch.AccessibleName = null;
            resources.ApplyResources(this.grdSearch, "grdSearch");
            this.grdSearch.BackgroundImage = null;
            this.grdSearch.Controls.Add(this.lblFilterName);
            this.grdSearch.Controls.Add(this.schName);
            this.grdSearch.Controls.Add(this.lblFilterDepartment);
            this.grdSearch.Controls.Add(this.cboFilterDepartment);
            this.grdSearch.Controls.Add(this.lblResult);
            this.grdSearch.Controls.Add(this.lblFiltered);
            this.grdSearch.Controls.Add(this.btnClearFilter);
            this.grdSearch.Controls.Add(this.dgvResults);
            this.grdSearch.Controls.Add(this.btnFilter);
            this.grdSearch.Font = null;
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.TabStop = false;
            // 
            // lblFilterName
            // 
            this.lblFilterName.AccessibleDescription = null;
            this.lblFilterName.AccessibleName = null;
            resources.ApplyResources(this.lblFilterName, "lblFilterName");
            this.lblFilterName.Font = null;
            this.lblFilterName.Name = "lblFilterName";
            // 
            // schName
            // 
            this.schName.AccessibleDescription = null;
            this.schName.AccessibleName = null;
            resources.ApplyResources(this.schName, "schName");
            this.schName.BackgroundImage = null;
            this.schName.Columns = null;
            this.schName.Criteria = ZeqkTools.Query.Enumerators.Criterias.EqualTo;
            this.schName.Font = null;
            this.schName.Name = "schName";
            this.schName.Parameters = null;
            this.schName.Query = null;
            this.schName.VariableNames = null;
            // 
            // lblFilterDepartment
            // 
            this.lblFilterDepartment.AccessibleDescription = null;
            this.lblFilterDepartment.AccessibleName = null;
            resources.ApplyResources(this.lblFilterDepartment, "lblFilterDepartment");
            this.lblFilterDepartment.Font = null;
            this.lblFilterDepartment.Name = "lblFilterDepartment";
            // 
            // cboFilterDepartment
            // 
            this.cboFilterDepartment.AccessibleDescription = null;
            this.cboFilterDepartment.AccessibleName = null;
            resources.ApplyResources(this.cboFilterDepartment, "cboFilterDepartment");
            this.cboFilterDepartment.BackgroundImage = null;
            this.cboFilterDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterDepartment.Font = null;
            this.cboFilterDepartment.FormattingEnabled = true;
            this.cboFilterDepartment.Name = "cboFilterDepartment";
            // 
            // lblResult
            // 
            this.lblResult.AccessibleDescription = null;
            this.lblResult.AccessibleName = null;
            resources.ApplyResources(this.lblResult, "lblResult");
            this.lblResult.Font = null;
            this.lblResult.Name = "lblResult";
            // 
            // lblFiltered
            // 
            this.lblFiltered.AccessibleDescription = null;
            this.lblFiltered.AccessibleName = null;
            resources.ApplyResources(this.lblFiltered, "lblFiltered");
            this.lblFiltered.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltered.Font = null;
            this.lblFiltered.Name = "lblFiltered";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.AccessibleDescription = null;
            this.btnClearFilter.AccessibleName = null;
            resources.ApplyResources(this.btnClearFilter, "btnClearFilter");
            this.btnClearFilter.BackgroundImage = null;
            this.btnClearFilter.Font = null;
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AccessibleDescription = null;
            this.dgvResults.AccessibleName = null;
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.BackgroundImage = null;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Font = null;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResults.VirtualMode = true;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.AccessibleDescription = null;
            this.btnFilter.AccessibleName = null;
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.BackgroundImage = null;
            this.btnFilter.Font = null;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.AccessibleDescription = null;
            this.tabPanel.AccessibleName = null;
            resources.ApplyResources(this.tabPanel, "tabPanel");
            this.tabPanel.BackgroundImage = null;
            this.tabPanel.Controls.Add(this.tabAddresses);
            this.tabPanel.Controls.Add(this.tabPublishers);
            this.tabPanel.Font = null;
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            // 
            // tabAddresses
            // 
            this.tabAddresses.AccessibleDescription = null;
            this.tabAddresses.AccessibleName = null;
            resources.ApplyResources(this.tabAddresses, "tabAddresses");
            this.tabAddresses.BackgroundImage = null;
            this.tabAddresses.Controls.Add(this.dgvAddresses);
            this.tabAddresses.Font = null;
            this.tabAddresses.Name = "tabAddresses";
            this.tabAddresses.UseVisualStyleBackColor = true;
            // 
            // dgvAddresses
            // 
            this.dgvAddresses.AccessibleDescription = null;
            this.dgvAddresses.AccessibleName = null;
            this.dgvAddresses.AllowUserToAddRows = false;
            this.dgvAddresses.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvAddresses, "dgvAddresses");
            this.dgvAddresses.BackgroundImage = null;
            this.dgvAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddresses.Font = null;
            this.dgvAddresses.MultiSelect = false;
            this.dgvAddresses.Name = "dgvAddresses";
            this.dgvAddresses.ReadOnly = true;
            this.dgvAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddresses.VirtualMode = true;
            // 
            // tabPublishers
            // 
            this.tabPublishers.AccessibleDescription = null;
            this.tabPublishers.AccessibleName = null;
            resources.ApplyResources(this.tabPublishers, "tabPublishers");
            this.tabPublishers.BackgroundImage = null;
            this.tabPublishers.Controls.Add(this.dgvPublishers);
            this.tabPublishers.Font = null;
            this.tabPublishers.Name = "tabPublishers";
            this.tabPublishers.UseVisualStyleBackColor = true;
            // 
            // dgvPublishers
            // 
            this.dgvPublishers.AccessibleDescription = null;
            this.dgvPublishers.AccessibleName = null;
            this.dgvPublishers.AllowUserToAddRows = false;
            this.dgvPublishers.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvPublishers, "dgvPublishers");
            this.dgvPublishers.BackgroundImage = null;
            this.dgvPublishers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublishers.Font = null;
            this.dgvPublishers.MultiSelect = false;
            this.dgvPublishers.Name = "dgvPublishers";
            this.dgvPublishers.ReadOnly = true;
            this.dgvPublishers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPublishers.VirtualMode = true;
            // 
            // frmCities
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.grpObject);
            this.Font = null;
            this.Icon = null;
            this.Name = "frmCities";
            this.Load += new System.EventHandler(this.frmCities_Load);
            this.Shown += new System.EventHandler(this.frmCities_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCities_FormClosed);
            this.grpObject.ResumeLayout(false);
            this.grpObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).EndInit();
            this.grdSearch.ResumeLayout(false);
            this.grdSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tabPanel.ResumeLayout(false);
            this.tabAddresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).EndInit();
            this.tabPublishers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublishers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpObject;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox grdSearch;
        protected System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRelations;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabAddresses;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblFiltered;
        protected System.Windows.Forms.DataGridView dgvAddresses;
        private System.Windows.Forms.TabPage tabPublishers;
        protected System.Windows.Forms.DataGridView dgvPublishers;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblFilterDepartment;
        private System.Windows.Forms.ComboBox cboFilterDepartment;
        private System.Windows.Forms.BindingSource bsCity;
        private ZeqkTools.WindowsForms.Controls.Search schName;
        private System.Windows.Forms.Label lblFilterName;
    }
}