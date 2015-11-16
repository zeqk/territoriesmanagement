namespace TerritoriesManagement.GUI
{
    partial class frmTerritoriesExportation
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
            this.chklstTerritories = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkSingleFile = new System.Windows.Forms.CheckBox();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.rdoFilterAll = new System.Windows.Forms.RadioButton();
            this.rdoFilterWithoutAddresses = new System.Windows.Forms.RadioButton();
            this.rdoFilterWithAddresses = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip.SuspendLayout();
            this.groupFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // chklstTerritories
            // 
            this.chklstTerritories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstTerritories.CheckOnClick = true;
            this.chklstTerritories.ContextMenuStrip = this.contextMenuStrip;
            this.chklstTerritories.FormattingEnabled = true;
            this.chklstTerritories.HorizontalScrollbar = true;
            this.chklstTerritories.Location = new System.Drawing.Point(12, 68);
            this.chklstTerritories.MultiColumn = true;
            this.chklstTerritories.Name = "chklstTerritories";
            this.chklstTerritories.Size = new System.Drawing.Size(798, 379);
            this.chklstTerritories.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSelectAll,
            this.toolStripMenuItemDeselectAll});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(128, 48);
            // 
            // toolStripMenuItemSelectAll
            // 
            this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
            this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItemSelectAll.Text = "Select all";
            this.toolStripMenuItemSelectAll.Click += new System.EventHandler(this.toolStripMenuItemSelectAll_Click);
            // 
            // toolStripMenuItemDeselectAll
            // 
            this.toolStripMenuItemDeselectAll.Name = "toolStripMenuItemDeselectAll";
            this.toolStripMenuItemDeselectAll.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItemDeselectAll.Text = "Deslect all";
            this.toolStripMenuItemDeselectAll.Click += new System.EventHandler(this.toolStripMenuItemDeselectAll_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(730, 23);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkSingleFile
            // 
            this.chkSingleFile.AutoSize = true;
            this.chkSingleFile.Checked = true;
            this.chkSingleFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSingleFile.Location = new System.Drawing.Point(625, 29);
            this.chkSingleFile.Name = "chkSingleFile";
            this.chkSingleFile.Size = new System.Drawing.Size(71, 17);
            this.chkSingleFile.TabIndex = 4;
            this.chkSingleFile.Text = "Single file";
            this.chkSingleFile.UseVisualStyleBackColor = true;
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Location = new System.Drawing.Point(481, 25);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(121, 21);
            this.cboReportType.TabIndex = 5;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.rdoFilterAll);
            this.groupFilter.Controls.Add(this.rdoFilterWithoutAddresses);
            this.groupFilter.Controls.Add(this.rdoFilterWithAddresses);
            this.groupFilter.Location = new System.Drawing.Point(12, 7);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(382, 55);
            this.groupFilter.TabIndex = 7;
            this.groupFilter.TabStop = false;
            // 
            // rdoFilterAll
            // 
            this.rdoFilterAll.Location = new System.Drawing.Point(245, 21);
            this.rdoFilterAll.Name = "rdoFilterAll";
            this.rdoFilterAll.Size = new System.Drawing.Size(113, 17);
            this.rdoFilterAll.TabIndex = 9;
            this.rdoFilterAll.TabStop = true;
            this.rdoFilterAll.Text = "All";
            this.rdoFilterAll.UseVisualStyleBackColor = true;
            this.rdoFilterAll.CheckedChanged += new System.EventHandler(this.rdoFilterWithAddresses_CheckedChanged);
            // 
            // rdoFilterWithoutAddresses
            // 
            this.rdoFilterWithoutAddresses.AutoSize = true;
            this.rdoFilterWithoutAddresses.Location = new System.Drawing.Point(118, 21);
            this.rdoFilterWithoutAddresses.Name = "rdoFilterWithoutAddresses";
            this.rdoFilterWithoutAddresses.Size = new System.Drawing.Size(113, 17);
            this.rdoFilterWithoutAddresses.TabIndex = 8;
            this.rdoFilterWithoutAddresses.TabStop = true;
            this.rdoFilterWithoutAddresses.Text = "Without addresses";
            this.rdoFilterWithoutAddresses.UseVisualStyleBackColor = true;
            this.rdoFilterWithoutAddresses.CheckedChanged += new System.EventHandler(this.rdoFilterWithAddresses_CheckedChanged);
            // 
            // rdoFilterWithAddresses
            // 
            this.rdoFilterWithAddresses.AutoSize = true;
            this.rdoFilterWithAddresses.Location = new System.Drawing.Point(6, 21);
            this.rdoFilterWithAddresses.Name = "rdoFilterWithAddresses";
            this.rdoFilterWithAddresses.Size = new System.Drawing.Size(98, 17);
            this.rdoFilterWithAddresses.TabIndex = 7;
            this.rdoFilterWithAddresses.TabStop = true;
            this.rdoFilterWithAddresses.Text = "With addresses";
            this.rdoFilterWithAddresses.UseVisualStyleBackColor = true;
            this.rdoFilterWithAddresses.CheckedChanged += new System.EventHandler(this.rdoFilterWithAddresses_CheckedChanged);
            // 
            // frmTerritoriesExportation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 453);
            this.Controls.Add(this.groupFilter);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.chkSingleFile);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chklstTerritories);
            this.Name = "frmTerritoriesExportation";
            this.Text = "Territories exportation";
            this.Load += new System.EventHandler(this.frmTerritoriesPrinting_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklstTerritories;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkSingleFile;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.RadioButton rdoFilterAll;
        private System.Windows.Forms.RadioButton rdoFilterWithoutAddresses;
        private System.Windows.Forms.RadioButton rdoFilterWithAddresses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeselectAll;
    }
}