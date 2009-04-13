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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCities));
            this.grpObject = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnRelations = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grdSearch = new System.Windows.Forms.GroupBox();
            this.lblFilterDepartment = new System.Windows.Forms.Label();
            this.cmbFilterDepartment = new System.Windows.Forms.ComboBox();
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
            this.grpObject.Controls.Add(this.label1);
            this.grpObject.Controls.Add(this.cmbDepartment);
            this.grpObject.Controls.Add(this.lblId);
            this.grpObject.Controls.Add(this.btnRelations);
            this.grpObject.Controls.Add(this.btnDelete);
            this.grpObject.Controls.Add(this.btnUpdate);
            this.grpObject.Controls.Add(this.btnNew);
            this.grpObject.Controls.Add(this.lblName);
            this.grpObject.Controls.Add(this.txtName);
            this.grpObject.Location = new System.Drawing.Point(383, 6);
            this.grpObject.Name = "grpObject";
            this.grpObject.Size = new System.Drawing.Size(362, 153);
            this.grpObject.TabIndex = 0;
            this.grpObject.TabStop = false;
            this.grpObject.Text = "City";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(22, 32);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(317, 21);
            this.cmbDepartment.TabIndex = 17;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(321, 3);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 13);
            this.lblId.TabIndex = 11;
            // 
            // btnRelations
            // 
            this.btnRelations.Location = new System.Drawing.Point(270, 101);
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
            this.btnDelete.Location = new System.Drawing.Point(187, 101);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 38);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(104, 101);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(69, 38);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(21, 101);
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
            this.lblName.Location = new System.Drawing.Point(18, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(22, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(317, 20);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grdSearch
            // 
            this.grdSearch.Controls.Add(this.lblFilterDepartment);
            this.grdSearch.Controls.Add(this.cmbFilterDepartment);
            this.grdSearch.Controls.Add(this.lblResult);
            this.grdSearch.Controls.Add(this.lblFiltered);
            this.grdSearch.Controls.Add(this.schName);
            this.grdSearch.Controls.Add(this.btnClearFilter);
            this.grdSearch.Controls.Add(this.dgvResults);
            this.grdSearch.Controls.Add(this.btnFilter);
            this.grdSearch.Location = new System.Drawing.Point(12, 6);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.Size = new System.Drawing.Size(362, 423);
            this.grdSearch.TabIndex = 1;
            this.grdSearch.TabStop = false;
            this.grdSearch.Text = "Search";
            // 
            // lblFilterDepartment
            // 
            this.lblFilterDepartment.AutoSize = true;
            this.lblFilterDepartment.Location = new System.Drawing.Point(16, 61);
            this.lblFilterDepartment.Name = "lblFilterDepartment";
            this.lblFilterDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblFilterDepartment.TabIndex = 16;
            this.lblFilterDepartment.Text = "Department";
            // 
            // cmbFilterDepartment
            // 
            this.cmbFilterDepartment.FormattingEnabled = true;
            this.cmbFilterDepartment.Location = new System.Drawing.Point(19, 75);
            this.cmbFilterDepartment.Name = "cmbFilterDepartment";
            this.cmbFilterDepartment.Size = new System.Drawing.Size(325, 21);
            this.cmbFilterDepartment.TabIndex = 15;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(16, 104);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(45, 13);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Results:";
            // 
            // lblFiltered
            // 
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltered.Location = new System.Drawing.Point(303, 105);
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
            this.dgvResults.Location = new System.Drawing.Point(19, 121);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(325, 296);
            this.dgvResults.TabIndex = 5;
            this.dgvResults.VirtualMode = true;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
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
            this.tabPanel.Location = new System.Drawing.Point(383, 165);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(362, 264);
            this.tabPanel.TabIndex = 12;
            this.tabPanel.Visible = false;
            // 
            // tabDirections
            // 
            this.tabDirections.Controls.Add(this.dgvDirections);
            this.tabDirections.Location = new System.Drawing.Point(4, 22);
            this.tabDirections.Name = "tabDirections";
            this.tabDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirections.Size = new System.Drawing.Size(354, 238);
            this.tabDirections.TabIndex = 0;
            this.tabDirections.Text = "Directions";
            this.tabDirections.UseVisualStyleBackColor = true;
            // 
            // dgvDirections
            // 
            this.dgvDirections.AllowUserToAddRows = false;
            this.dgvDirections.AllowUserToDeleteRows = false;
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDirections.Location = new System.Drawing.Point(3, 3);
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.ReadOnly = true;
            this.dgvDirections.Size = new System.Drawing.Size(348, 232);
            this.dgvDirections.TabIndex = 0;
            // 
            // tabPublishers
            // 
            this.tabPublishers.Controls.Add(this.dgvPublishers);
            this.tabPublishers.Location = new System.Drawing.Point(4, 22);
            this.tabPublishers.Name = "tabPublishers";
            this.tabPublishers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPublishers.Size = new System.Drawing.Size(354, 238);
            this.tabPublishers.TabIndex = 1;
            this.tabPublishers.Text = "Publishers";
            this.tabPublishers.UseVisualStyleBackColor = true;
            // 
            // dgvPublishers
            // 
            this.dgvPublishers.AllowUserToAddRows = false;
            this.dgvPublishers.AllowUserToDeleteRows = false;
            this.dgvPublishers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublishers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPublishers.Location = new System.Drawing.Point(3, 3);
            this.dgvPublishers.Name = "dgvPublishers";
            this.dgvPublishers.ReadOnly = true;
            this.dgvPublishers.Size = new System.Drawing.Size(348, 232);
            this.dgvPublishers.TabIndex = 1;
            // 
            // frmCities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 471);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.grpObject);
            this.Name = "frmCities";
            this.Text = "Cities";
            this.Load += new System.EventHandler(this.frmDepartments_Load);
            this.grpObject.ResumeLayout(false);
            this.grpObject.PerformLayout();
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
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRelations;
        private My.Controls.Search schName;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabDirections;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblFiltered;
        private System.Windows.Forms.TabPage tabPublishers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblFilterDepartment;
        private System.Windows.Forms.ComboBox cmbFilterDepartment;
        private System.Windows.Forms.DataGridView dgvPublishers;
    }
}