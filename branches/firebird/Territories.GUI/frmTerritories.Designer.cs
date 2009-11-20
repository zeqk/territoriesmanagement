namespace Territories.GUI
{
    partial class frmTerritories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerritories));
            this.grpObject = new System.Windows.Forms.GroupBox();
            this.btnViewMap = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.MaskedTextBox();
            this.bsTerritory = new System.Windows.Forms.BindingSource(this.components);
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnRelations = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grdSearch = new System.Windows.Forms.GroupBox();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.schName = new ZeqkTools.Controls.Search();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabAddresses = new System.Windows.Forms.TabPage();
            this.dgvAddresses = new System.Windows.Forms.DataGridView();
            this.tabTours = new System.Windows.Forms.TabPage();
            this.dgvTours = new System.Windows.Forms.DataGridView();
            this.grpObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTerritory)).BeginInit();
            this.grdSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tabPanel.SuspendLayout();
            this.tabAddresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).BeginInit();
            this.tabTours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTours)).BeginInit();
            this.SuspendLayout();
            // 
            // grpObject
            // 
            this.grpObject.Controls.Add(this.btnViewMap);
            this.grpObject.Controls.Add(this.txtNumber);
            this.grpObject.Controls.Add(this.lblNumber);
            this.grpObject.Controls.Add(this.lblId);
            this.grpObject.Controls.Add(this.btnRelations);
            this.grpObject.Controls.Add(this.btnDelete);
            this.grpObject.Controls.Add(this.btnSave);
            this.grpObject.Controls.Add(this.btnNew);
            this.grpObject.Controls.Add(this.lblName);
            this.grpObject.Controls.Add(this.txtName);
            resources.ApplyResources(this.grpObject, "grpObject");
            this.grpObject.Name = "grpObject";
            this.grpObject.TabStop = false;
            // 
            // btnViewMap
            // 
            resources.ApplyResources(this.btnViewMap, "btnViewMap");
            this.btnViewMap.Name = "btnViewMap";
            this.btnViewMap.UseVisualStyleBackColor = true;
            this.btnViewMap.Click += new System.EventHandler(this.btnViewMap_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "Number", true));
            resources.ApplyResources(this.txtNumber, "txtNumber");
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ValidatingType = typeof(int);
            // 
            // bsTerritory
            // 
            this.bsTerritory.DataSource = typeof(Territories.Model.Territory);
            // 
            // lblNumber
            // 
            resources.ApplyResources(this.lblNumber, "lblNumber");
            this.lblNumber.Name = "lblNumber";
            // 
            // lblId
            // 
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "IdTerritory", true));
            this.lblId.Name = "lblId";
            // 
            // btnRelations
            // 
            resources.ApplyResources(this.btnRelations, "btnRelations");
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.UseVisualStyleBackColor = true;
            this.btnRelations.Click += new System.EventHandler(this.btnRelations_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "Name", true));
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grdSearch
            // 
            this.grdSearch.Controls.Add(this.lblFilterName);
            this.grdSearch.Controls.Add(this.schName);
            this.grdSearch.Controls.Add(this.lblResult);
            this.grdSearch.Controls.Add(this.lblFiltered);
            this.grdSearch.Controls.Add(this.btnClearFilter);
            this.grdSearch.Controls.Add(this.dgvResults);
            this.grdSearch.Controls.Add(this.btnFilter);
            resources.ApplyResources(this.grdSearch, "grdSearch");
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.TabStop = false;
            // 
            // lblFilterName
            // 
            resources.ApplyResources(this.lblFilterName, "lblFilterName");
            this.lblFilterName.Name = "lblFilterName";
            // 
            // schName
            // 
            resources.ApplyResources(this.schName, "schName");
            this.schName.Columns = null;
            this.schName.Criteria = ZeqkTools.Query.Enumerators.Criterias.EqualTo;
            this.schName.Name = "schName";
            this.schName.Parameters = null;
            this.schName.Query = null;
            this.schName.VariableNames = null;
            // 
            // lblResult
            // 
            resources.ApplyResources(this.lblResult, "lblResult");
            this.lblResult.Name = "lblResult";
            // 
            // lblFiltered
            // 
            resources.ApplyResources(this.lblFiltered, "lblFiltered");
            this.lblFiltered.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltered.Name = "lblFiltered";
            // 
            // btnClearFilter
            // 
            resources.ApplyResources(this.btnClearFilter, "btnClearFilter");
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResults.VirtualMode = true;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            // 
            // btnFilter
            // 
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabAddresses);
            this.tabPanel.Controls.Add(this.tabTours);
            resources.ApplyResources(this.tabPanel, "tabPanel");
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            // 
            // tabAddresses
            // 
            this.tabAddresses.Controls.Add(this.dgvAddresses);
            resources.ApplyResources(this.tabAddresses, "tabAddresses");
            this.tabAddresses.Name = "tabAddresses";
            this.tabAddresses.UseVisualStyleBackColor = true;
            // 
            // dgvAddresses
            // 
            this.dgvAddresses.AllowUserToAddRows = false;
            this.dgvAddresses.AllowUserToDeleteRows = false;
            this.dgvAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvAddresses, "dgvAddresses");
            this.dgvAddresses.MultiSelect = false;
            this.dgvAddresses.Name = "dgvAddresses";
            this.dgvAddresses.ReadOnly = true;
            this.dgvAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddresses.VirtualMode = true;
            // 
            // tabTours
            // 
            this.tabTours.Controls.Add(this.dgvTours);
            resources.ApplyResources(this.tabTours, "tabTours");
            this.tabTours.Name = "tabTours";
            this.tabTours.UseVisualStyleBackColor = true;
            // 
            // dgvTours
            // 
            this.dgvTours.AllowUserToAddRows = false;
            this.dgvTours.AllowUserToDeleteRows = false;
            this.dgvTours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvTours, "dgvTours");
            this.dgvTours.MultiSelect = false;
            this.dgvTours.Name = "dgvTours";
            this.dgvTours.ReadOnly = true;
            this.dgvTours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTours.VirtualMode = true;
            // 
            // frmTerritories
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.grpObject);
            this.Name = "frmTerritories";
            this.Load += new System.EventHandler(this.frmTerritories_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTerritories_FormClosed_1);
            this.grpObject.ResumeLayout(false);
            this.grpObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTerritory)).EndInit();
            this.grdSearch.ResumeLayout(false);
            this.grdSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tabPanel.ResumeLayout(false);
            this.tabAddresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).EndInit();
            this.tabTours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTours)).EndInit();
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
        private System.Windows.Forms.TabPage tabTours;
        protected System.Windows.Forms.DataGridView dgvTours;
        private ZeqkTools.Controls.Search schName;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.MaskedTextBox txtNumber;
        private System.Windows.Forms.BindingSource bsTerritory;
        private System.Windows.Forms.Button btnViewMap;
    }
}