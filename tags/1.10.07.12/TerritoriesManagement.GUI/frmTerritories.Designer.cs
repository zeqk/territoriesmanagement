namespace TerritoriesManagement.GUI
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
            this.lblResultCount = new System.Windows.Forms.Label();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.schName = new AltosTools.WindowsForms.Controls.Search();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabAddresses = new System.Windows.Forms.TabPage();
            this.dgvAddresses = new System.Windows.Forms.DataGridView();
            this.tabTours = new System.Windows.Forms.TabPage();
            this.dgvTours = new System.Windows.Forms.DataGridView();
            this.grpObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTerritory)).BeginInit();
            this.grdSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
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
            this.grpObject.Location = new System.Drawing.Point(383, 6);
            this.grpObject.Name = "grpObject";
            this.grpObject.Size = new System.Drawing.Size(362, 158);
            this.grpObject.TabIndex = 0;
            this.grpObject.TabStop = false;
            this.grpObject.Text = "Territory";
            // 
            // btnViewMap
            // 
            this.btnViewMap.Image = ((System.Drawing.Image)(resources.GetObject("btnViewMap.Image")));
            this.btnViewMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewMap.Location = new System.Drawing.Point(260, 64);
            this.btnViewMap.Name = "btnViewMap";
            this.btnViewMap.Size = new System.Drawing.Size(78, 34);
            this.btnViewMap.TabIndex = 24;
            this.btnViewMap.Text = "View map";
            this.btnViewMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewMap.UseVisualStyleBackColor = true;
            this.btnViewMap.Click += new System.EventHandler(this.btnViewMap_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "Number", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.txtNumber.Location = new System.Drawing.Point(22, 72);
            this.txtNumber.Mask = "99999";
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.PromptChar = ' ';
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 23;
            this.txtNumber.ValidatingType = typeof(int);
            // 
            // bsTerritory
            // 
            this.bsTerritory.DataSource = typeof(TerritoriesManagement.Model.Territory);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(19, 55);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 22;
            this.lblNumber.Text = "Number";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "IdTerritory", true));
            this.lblId.Location = new System.Drawing.Point(321, 3);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 13);
            this.lblId.TabIndex = 11;
            // 
            // btnRelations
            // 
            this.btnRelations.Location = new System.Drawing.Point(269, 106);
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.Size = new System.Drawing.Size(69, 38);
            this.btnRelations.TabIndex = 10;
            this.btnRelations.Text = "View relations";
            this.btnRelations.UseVisualStyleBackColor = true;
            this.btnRelations.Click += new System.EventHandler(this.btnRelations_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(186, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 38);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(103, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Update";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(20, 106);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 38);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "Name", true));
            this.txtName.Location = new System.Drawing.Point(22, 32);
            this.txtName.MaxLength = 80;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 20);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grdSearch
            // 
            this.grdSearch.Controls.Add(this.lblResultCount);
            this.grdSearch.Controls.Add(this.lblFilterName);
            this.grdSearch.Controls.Add(this.schName);
            this.grdSearch.Controls.Add(this.lblResult);
            this.grdSearch.Controls.Add(this.lblFiltered);
            this.grdSearch.Controls.Add(this.btnClearFilter);
            this.grdSearch.Controls.Add(this.dgvResult);
            this.grdSearch.Controls.Add(this.btnFilter);
            this.grdSearch.Location = new System.Drawing.Point(12, 6);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.Size = new System.Drawing.Size(362, 408);
            this.grdSearch.TabIndex = 1;
            this.grdSearch.TabStop = false;
            this.grdSearch.Text = "Search";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(56, 71);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(0, 13);
            this.lblResultCount.TabIndex = 61;
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(16, 14);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(109, 13);
            this.lblFilterName.TabIndex = 18;
            this.lblFilterName.Text = "Filter by territory name";
            // 
            // schName
            // 
            this.schName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.schName.Columns = null;
            this.schName.Location = new System.Drawing.Point(19, 32);
            this.schName.Name = "schName";
            this.schName.Parameters = null;
            this.schName.Query = null;
            this.schName.Size = new System.Drawing.Size(238, 22);
            this.schName.TabIndex = 17;
            this.schName.VariableNames = null;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(16, 71);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Result:";
            // 
            // lblFiltered
            // 
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltered.Location = new System.Drawing.Point(303, 72);
            this.lblFiltered.Name = "lblFiltered";
            this.lblFiltered.Size = new System.Drawing.Size(41, 13);
            this.lblFiltered.TabIndex = 12;
            this.lblFiltered.Text = "Filtered";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilter.Image")));
            this.btnClearFilter.Location = new System.Drawing.Point(308, 28);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(36, 27);
            this.btnClearFilter.TabIndex = 10;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(19, 86);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResult.Size = new System.Drawing.Size(325, 312);
            this.dgvResult.TabIndex = 5;
            this.dgvResult.VirtualMode = true;
            this.dgvResult.SelectionChanged += new System.EventHandler(this.dgvResult_SelectionChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(263, 28);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(36, 27);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabAddresses);
            this.tabPanel.Controls.Add(this.tabTours);
            this.tabPanel.Location = new System.Drawing.Point(383, 170);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(362, 244);
            this.tabPanel.TabIndex = 12;
            this.tabPanel.Visible = false;
            // 
            // tabAddresses
            // 
            this.tabAddresses.Controls.Add(this.dgvAddresses);
            this.tabAddresses.Location = new System.Drawing.Point(4, 22);
            this.tabAddresses.Name = "tabAddresses";
            this.tabAddresses.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddresses.Size = new System.Drawing.Size(354, 218);
            this.tabAddresses.TabIndex = 0;
            this.tabAddresses.Text = "Addresses";
            this.tabAddresses.UseVisualStyleBackColor = true;
            // 
            // dgvAddresses
            // 
            this.dgvAddresses.AllowUserToAddRows = false;
            this.dgvAddresses.AllowUserToDeleteRows = false;
            this.dgvAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddresses.Location = new System.Drawing.Point(6, 6);
            this.dgvAddresses.MultiSelect = false;
            this.dgvAddresses.Name = "dgvAddresses";
            this.dgvAddresses.ReadOnly = true;
            this.dgvAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddresses.Size = new System.Drawing.Size(342, 206);
            this.dgvAddresses.TabIndex = 6;
            this.dgvAddresses.VirtualMode = true;
            // 
            // tabTours
            // 
            this.tabTours.Controls.Add(this.dgvTours);
            this.tabTours.Location = new System.Drawing.Point(4, 22);
            this.tabTours.Name = "tabTours";
            this.tabTours.Padding = new System.Windows.Forms.Padding(3);
            this.tabTours.Size = new System.Drawing.Size(354, 218);
            this.tabTours.TabIndex = 1;
            this.tabTours.Text = "Tours";
            this.tabTours.UseVisualStyleBackColor = true;
            // 
            // dgvTours
            // 
            this.dgvTours.AllowUserToAddRows = false;
            this.dgvTours.AllowUserToDeleteRows = false;
            this.dgvTours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTours.Location = new System.Drawing.Point(6, 6);
            this.dgvTours.MultiSelect = false;
            this.dgvTours.Name = "dgvTours";
            this.dgvTours.ReadOnly = true;
            this.dgvTours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTours.Size = new System.Drawing.Size(342, 206);
            this.dgvTours.TabIndex = 7;
            this.dgvTours.VirtualMode = true;
            // 
            // frmTerritories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 434);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.grpObject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTerritories";
            this.Text = "Territories";
            this.Load += new System.EventHandler(this.frmTerritories_Load);
            this.Shown += new System.EventHandler(this.frmTerritories_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTerritories_FormClosed_1);
            this.grpObject.ResumeLayout(false);
            this.grpObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTerritory)).EndInit();
            this.grdSearch.ResumeLayout(false);
            this.grdSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
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
        protected System.Windows.Forms.DataGridView dgvResult;
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
        private AltosTools.WindowsForms.Controls.Search schName;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.MaskedTextBox txtNumber;
        private System.Windows.Forms.BindingSource bsTerritory;
        private System.Windows.Forms.Button btnViewMap;
        private System.Windows.Forms.Label lblResultCount;
    }
}