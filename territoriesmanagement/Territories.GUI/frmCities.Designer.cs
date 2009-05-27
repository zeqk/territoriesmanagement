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
            this.lblFilterDepartment = new System.Windows.Forms.Label();
            this.cboFilterDepartment = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.schName = new My.Controls.Search();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabDirections = new System.Windows.Forms.TabPage();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.tabPublishers = new System.Windows.Forms.TabPage();
            this.dgvPublishers = new System.Windows.Forms.DataGridView();
            this.grpObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).BeginInit();
            this.grdSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tabPanel.SuspendLayout();
            this.tabDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            this.tabPublishers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublishers)).BeginInit();
            this.SuspendLayout();
            // 
            // grpObject
            // 
            this.grpObject.Controls.Add(this.lblDepartment);
            this.grpObject.Controls.Add(this.cboDepartment);
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
            this.grpObject.Text = "City";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(19, 63);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 13;
            this.lblDepartment.Text = "Department";
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(22, 79);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(325, 21);
            this.cboDepartment.TabIndex = 12;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCity, "IdCity", true));
            this.lblId.Location = new System.Drawing.Point(321, 3);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 13);
            this.lblId.TabIndex = 11;
            // 
            // bsCity
            // 
            this.bsCity.DataSource = typeof(Territories.Model.City);
            // 
            // btnRelations
            // 
            this.btnRelations.Location = new System.Drawing.Point(269, 106);
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.Size = new System.Drawing.Size(69, 38);
            this.btnRelations.TabIndex = 10;
            this.btnRelations.Text = "View &Relations";
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
            this.btnDelete.Text = "&Delete";
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
            this.btnSave.Text = "&Update";
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
            this.btnNew.Text = "&New";
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
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCity, "Name", true));
            this.txtName.Location = new System.Drawing.Point(22, 32);
            this.txtName.MaxLength = 80;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(325, 20);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grdSearch
            // 
            this.grdSearch.Controls.Add(this.lblFilterDepartment);
            this.grdSearch.Controls.Add(this.cboFilterDepartment);
            this.grdSearch.Controls.Add(this.lblResult);
            this.grdSearch.Controls.Add(this.lblFiltered);
            this.grdSearch.Controls.Add(this.schName);
            this.grdSearch.Controls.Add(this.btnClearFilter);
            this.grdSearch.Controls.Add(this.dgvResults);
            this.grdSearch.Controls.Add(this.btnFilter);
            this.grdSearch.Location = new System.Drawing.Point(12, 6);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.Size = new System.Drawing.Size(362, 408);
            this.grdSearch.TabIndex = 1;
            this.grdSearch.TabStop = false;
            this.grdSearch.Text = "Search";
            // 
            // lblFilterDepartment
            // 
            this.lblFilterDepartment.AutoSize = true;
            this.lblFilterDepartment.Location = new System.Drawing.Point(16, 63);
            this.lblFilterDepartment.Name = "lblFilterDepartment";
            this.lblFilterDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblFilterDepartment.TabIndex = 16;
            this.lblFilterDepartment.Text = "Department";
            // 
            // cboFilterDepartment
            // 
            this.cboFilterDepartment.FormattingEnabled = true;
            this.cboFilterDepartment.Location = new System.Drawing.Point(19, 79);
            this.cboFilterDepartment.Name = "cboFilterDepartment";
            this.cboFilterDepartment.Size = new System.Drawing.Size(325, 21);
            this.cboFilterDepartment.TabIndex = 15;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(16, 114);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(45, 13);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Results:";
            // 
            // lblFiltered
            // 
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltered.Location = new System.Drawing.Point(303, 115);
            this.lblFiltered.Name = "lblFiltered";
            this.lblFiltered.Size = new System.Drawing.Size(41, 13);
            this.lblFiltered.TabIndex = 12;
            this.lblFiltered.Text = "Filtered";
            // 
            // schName
            // 
            this.schName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.schName.Column = null;
            this.schName.Criteria = My.Enumerators.Criterias.EqualTo;
            this.schName.Location = new System.Drawing.Point(19, 16);
            this.schName.Name = "schName";
            this.schName.Parameter = null;
            this.schName.Query = null;
            this.schName.Size = new System.Drawing.Size(241, 42);
            this.schName.TabIndex = 14;
            this.schName.VariableName = null;
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
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(19, 131);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResults.Size = new System.Drawing.Size(325, 267);
            this.dgvResults.TabIndex = 5;
            this.dgvResults.VirtualMode = true;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
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
            this.tabPanel.Controls.Add(this.tabDirections);
            this.tabPanel.Controls.Add(this.tabPublishers);
            this.tabPanel.Location = new System.Drawing.Point(383, 170);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(362, 244);
            this.tabPanel.TabIndex = 12;
            this.tabPanel.Visible = false;
            // 
            // tabDirections
            // 
            this.tabDirections.Controls.Add(this.dgvDirections);
            this.tabDirections.Location = new System.Drawing.Point(4, 22);
            this.tabDirections.Name = "tabDirections";
            this.tabDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirections.Size = new System.Drawing.Size(354, 218);
            this.tabDirections.TabIndex = 0;
            this.tabDirections.Text = "Directions";
            this.tabDirections.UseVisualStyleBackColor = true;
            // 
            // dgvDirections
            // 
            this.dgvDirections.AllowUserToAddRows = false;
            this.dgvDirections.AllowUserToDeleteRows = false;
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Location = new System.Drawing.Point(6, 6);
            this.dgvDirections.MultiSelect = false;
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.ReadOnly = true;
            this.dgvDirections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirections.Size = new System.Drawing.Size(342, 206);
            this.dgvDirections.TabIndex = 6;
            this.dgvDirections.VirtualMode = true;
            // 
            // tabPublishers
            // 
            this.tabPublishers.Controls.Add(this.dgvPublishers);
            this.tabPublishers.Location = new System.Drawing.Point(4, 22);
            this.tabPublishers.Name = "tabPublishers";
            this.tabPublishers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPublishers.Size = new System.Drawing.Size(354, 218);
            this.tabPublishers.TabIndex = 1;
            this.tabPublishers.Text = "Publishers";
            this.tabPublishers.UseVisualStyleBackColor = true;
            // 
            // dgvPublishers
            // 
            this.dgvPublishers.AllowUserToAddRows = false;
            this.dgvPublishers.AllowUserToDeleteRows = false;
            this.dgvPublishers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublishers.Location = new System.Drawing.Point(6, 6);
            this.dgvPublishers.MultiSelect = false;
            this.dgvPublishers.Name = "dgvPublishers";
            this.dgvPublishers.ReadOnly = true;
            this.dgvPublishers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPublishers.Size = new System.Drawing.Size(342, 206);
            this.dgvPublishers.TabIndex = 7;
            this.dgvPublishers.VirtualMode = true;
            // 
            // frmCities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 434);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.grpObject);
            this.Name = "frmCities";
            this.Text = "Cities";
            this.Load += new System.EventHandler(this.frmCities_Load);
            this.Shown += new System.EventHandler(this.frmCities_Shown);
            this.grpObject.ResumeLayout(false);
            this.grpObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCity)).EndInit();
            this.grdSearch.ResumeLayout(false);
            this.grdSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tabPanel.ResumeLayout(false);
            this.tabDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
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
        private My.Controls.Search schName;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabDirections;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblFiltered;
        protected System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.TabPage tabPublishers;
        protected System.Windows.Forms.DataGridView dgvPublishers;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblFilterDepartment;
        private System.Windows.Forms.ComboBox cboFilterDepartment;
        private System.Windows.Forms.BindingSource bsCity;
    }
}