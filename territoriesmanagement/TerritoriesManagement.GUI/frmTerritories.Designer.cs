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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEditMap = new System.Windows.Forms.Button();
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
            this.btnPrintTerritoryCards = new System.Windows.Forms.Button();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.chkHasAddresses = new System.Windows.Forms.CheckBox();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.lblFilterName = new System.Windows.Forms.Label();
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
            this.grpObject.Controls.Add(this.btnPrint);
            this.grpObject.Controls.Add(this.btnEditMap);
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
            this.grpObject.TabIndex = 1;
            this.grpObject.TabStop = false;
            this.grpObject.Text = "Territory";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::TerritoriesManagement.GUI.Properties.Resources.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(283, 106);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(55, 38);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEditMap
            // 
            this.btnEditMap.Image = ((System.Drawing.Image)(resources.GetObject("btnEditMap.Image")));
            this.btnEditMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditMap.Location = new System.Drawing.Point(242, 64);
            this.btnEditMap.Name = "btnEditMap";
            this.btnEditMap.Size = new System.Drawing.Size(96, 34);
            this.btnEditMap.TabIndex = 5;
            this.btnEditMap.Text = "Edit map";
            this.btnEditMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditMap.UseVisualStyleBackColor = true;
            this.btnEditMap.Click += new System.EventHandler(this.btnEditMap_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "Number", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.txtNumber.Location = new System.Drawing.Point(22, 72);
            this.txtNumber.Mask = "99999";
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.PromptChar = ' ';
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 4;
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
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Number";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "IdTerritory", true));
            this.lblId.Location = new System.Drawing.Point(321, 3);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 13);
            this.lblId.TabIndex = 1;
            // 
            // btnRelations
            // 
            this.btnRelations.Location = new System.Drawing.Point(215, 106);
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.Size = new System.Drawing.Size(55, 38);
            this.btnRelations.TabIndex = 9;
            this.btnRelations.Text = "View relations";
            this.btnRelations.UseVisualStyleBackColor = true;
            this.btnRelations.Click += new System.EventHandler(this.btnRelations_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(150, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 38);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(85, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 38);
            this.btnSave.TabIndex = 7;
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
            this.btnNew.Size = new System.Drawing.Size(55, 38);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Clear";
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
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerritory, "Name", true));
            this.txtName.Location = new System.Drawing.Point(22, 32);
            this.txtName.MaxLength = 80;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grdSearch
            // 
            this.grdSearch.Controls.Add(this.btnPrintTerritoryCards);
            this.grdSearch.Controls.Add(this.txtFilterName);
            this.grdSearch.Controls.Add(this.chkHasAddresses);
            this.grdSearch.Controls.Add(this.lblResultCount);
            this.grdSearch.Controls.Add(this.lblFilterName);
            this.grdSearch.Controls.Add(this.lblResult);
            this.grdSearch.Controls.Add(this.lblFiltered);
            this.grdSearch.Controls.Add(this.btnClearFilter);
            this.grdSearch.Controls.Add(this.dgvResult);
            this.grdSearch.Controls.Add(this.btnFilter);
            this.grdSearch.Location = new System.Drawing.Point(12, 6);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.Size = new System.Drawing.Size(362, 408);
            this.grdSearch.TabIndex = 0;
            this.grdSearch.TabStop = false;
            this.grdSearch.Text = "Search";
            // 
            // btnPrintTerritoryCards
            // 
            this.btnPrintTerritoryCards.Image = global::TerritoriesManagement.GUI.Properties.Resources.printer;
            this.btnPrintTerritoryCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintTerritoryCards.Location = new System.Drawing.Point(19, 378);
            this.btnPrintTerritoryCards.Name = "btnPrintTerritoryCards";
            this.btnPrintTerritoryCards.Size = new System.Drawing.Size(100, 24);
            this.btnPrintTerritoryCards.TabIndex = 15;
            this.btnPrintTerritoryCards.Text = "Cards";
            this.btnPrintTerritoryCards.UseVisualStyleBackColor = true;
            this.btnPrintTerritoryCards.Click += new System.EventHandler(this.btnPrintTerritoryCards_Click);
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(19, 32);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(229, 20);
            this.txtFilterName.TabIndex = 13;
            // 
            // chkHasAddresses
            // 
            this.chkHasAddresses.AutoSize = true;
            this.chkHasAddresses.Location = new System.Drawing.Point(19, 64);
            this.chkHasAddresses.Name = "chkHasAddresses";
            this.chkHasAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkHasAddresses.TabIndex = 12;
            this.chkHasAddresses.Text = "Addresses";
            this.chkHasAddresses.UseVisualStyleBackColor = true;
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(70, 90);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(0, 13);
            this.lblResultCount.TabIndex = 5;
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(16, 14);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(109, 13);
            this.lblFilterName.TabIndex = 0;
            this.lblFilterName.Text = "Filter by territory name";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(16, 90);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Result:";
            // 
            // lblFiltered
            // 
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltered.Location = new System.Drawing.Point(303, 90);
            this.lblFiltered.Name = "lblFiltered";
            this.lblFiltered.Size = new System.Drawing.Size(41, 13);
            this.lblFiltered.TabIndex = 6;
            this.lblFiltered.Text = "Filtered";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilter.Image")));
            this.btnClearFilter.Location = new System.Drawing.Point(308, 28);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(36, 27);
            this.btnClearFilter.TabIndex = 3;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(19, 106);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResult.Size = new System.Drawing.Size(325, 266);
            this.dgvResult.TabIndex = 7;
            this.dgvResult.VirtualMode = true;
            this.dgvResult.SelectionChanged += new System.EventHandler(this.dgvResult_SelectionChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(263, 28);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(36, 27);
            this.btnFilter.TabIndex = 2;
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
            this.tabPanel.TabIndex = 2;
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
            this.dgvAddresses.TabIndex = 0;
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTerritories_FormClosed_1);
            this.Load += new System.EventHandler(this.frmTerritories_Load);
            this.Shown += new System.EventHandler(this.frmTerritories_Shown);
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
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.MaskedTextBox txtNumber;
        private System.Windows.Forms.BindingSource bsTerritory;
        private System.Windows.Forms.Button btnEditMap;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkHasAddresses;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.Button btnPrintTerritoryCards;
    }
}