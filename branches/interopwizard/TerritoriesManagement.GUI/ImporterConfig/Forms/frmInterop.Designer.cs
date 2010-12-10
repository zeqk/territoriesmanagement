namespace TerritoriesManagement.GUI.ImporterConfig
{
    partial class frmInterop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterop));
            this.tabExternal = new System.Windows.Forms.TabPage();
            this.tabImportPanel = new System.Windows.Forms.TabControl();
            this.tabExternalImport = new System.Windows.Forms.TabPage();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.btnConfigTables = new System.Windows.Forms.Button();
            this.prbDataImport = new System.Windows.Forms.ProgressBar();
            this.btnConfigureConnection = new System.Windows.Forms.Button();
            this.lblConnecStr = new System.Windows.Forms.Label();
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.btnImportFromExternal = new System.Windows.Forms.Button();
            this.tabExternalExport = new System.Windows.Forms.TabPage();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.btnConfigEntities = new System.Windows.Forms.Button();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.btnSelectTemplate = new System.Windows.Forms.Button();
            this.txtExcelTemplate = new System.Windows.Forms.TextBox();
            this.btnExportToExternal = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDepartments = new System.Windows.Forms.CheckBox();
            this.btnImportData = new System.Windows.Forms.Button();
            this.chkPublishers = new System.Windows.Forms.CheckBox();
            this.btnExportData = new System.Windows.Forms.Button();
            this.chkTerritories = new System.Windows.Forms.CheckBox();
            this.chkTours = new System.Windows.Forms.CheckBox();
            this.chkAddresses = new System.Windows.Forms.CheckBox();
            this.chkCities = new System.Windows.Forms.CheckBox();
            this.ofdSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdDestinationFile = new System.Windows.Forms.SaveFileDialog();
            this.tabExternal.SuspendLayout();
            this.tabImportPanel.SuspendLayout();
            this.tabExternalImport.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.tabExternalExport.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabExternal
            // 
            this.tabExternal.Controls.Add(this.tabImportPanel);
            this.tabExternal.Location = new System.Drawing.Point(4, 22);
            this.tabExternal.Name = "tabExternal";
            this.tabExternal.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternal.Size = new System.Drawing.Size(349, 344);
            this.tabExternal.TabIndex = 2;
            this.tabExternal.Text = "External data";
            this.tabExternal.UseVisualStyleBackColor = true;
            // 
            // tabImportPanel
            // 
            this.tabImportPanel.Controls.Add(this.tabExternalImport);
            this.tabImportPanel.Controls.Add(this.tabExternalExport);
            this.tabImportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImportPanel.Location = new System.Drawing.Point(3, 3);
            this.tabImportPanel.Name = "tabImportPanel";
            this.tabImportPanel.SelectedIndex = 0;
            this.tabImportPanel.Size = new System.Drawing.Size(343, 338);
            this.tabImportPanel.TabIndex = 0;
            // 
            // tabExternalImport
            // 
            this.tabExternalImport.Controls.Add(this.grpConfig);
            this.tabExternalImport.Location = new System.Drawing.Point(4, 22);
            this.tabExternalImport.Name = "tabExternalImport";
            this.tabExternalImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternalImport.Size = new System.Drawing.Size(335, 312);
            this.tabExternalImport.TabIndex = 0;
            this.tabExternalImport.Text = "Import";
            this.tabExternalImport.UseVisualStyleBackColor = true;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.btnConfigTables);
            this.grpConfig.Controls.Add(this.prbDataImport);
            this.grpConfig.Controls.Add(this.btnConfigureConnection);
            this.grpConfig.Controls.Add(this.lblConnecStr);
            this.grpConfig.Controls.Add(this.txtConnectStr);
            this.grpConfig.Controls.Add(this.btnImportFromExternal);
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfig.Location = new System.Drawing.Point(3, 3);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(329, 306);
            this.grpConfig.TabIndex = 12;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Configure import properties";
            // 
            // btnConfigTables
            // 
            this.btnConfigTables.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigTables.Image")));
            this.btnConfigTables.Location = new System.Drawing.Point(98, 128);
            this.btnConfigTables.Name = "btnConfigTables";
            this.btnConfigTables.Size = new System.Drawing.Size(73, 39);
            this.btnConfigTables.TabIndex = 17;
            this.btnConfigTables.Text = "Tables";
            this.btnConfigTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfigTables.UseVisualStyleBackColor = true;
            this.btnConfigTables.Click += new System.EventHandler(this.btnConfigTables_Click);
            // 
            // prbDataImport
            // 
            this.prbDataImport.Location = new System.Drawing.Point(18, 188);
            this.prbDataImport.Name = "prbDataImport";
            this.prbDataImport.Size = new System.Drawing.Size(290, 24);
            this.prbDataImport.TabIndex = 16;
            this.prbDataImport.Click += new System.EventHandler(this.prbDataImport_Click);
            // 
            // btnConfigureConnection
            // 
            this.btnConfigureConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigureConnection.Image")));
            this.btnConfigureConnection.Location = new System.Drawing.Point(19, 128);
            this.btnConfigureConnection.Name = "btnConfigureConnection";
            this.btnConfigureConnection.Size = new System.Drawing.Size(73, 39);
            this.btnConfigureConnection.TabIndex = 15;
            this.btnConfigureConnection.Text = "Connection";
            this.btnConfigureConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfigureConnection.UseVisualStyleBackColor = true;
            this.btnConfigureConnection.Click += new System.EventHandler(this.btnConfigureConnection_Click);
            // 
            // lblConnecStr
            // 
            this.lblConnecStr.AutoSize = true;
            this.lblConnecStr.Location = new System.Drawing.Point(16, 22);
            this.lblConnecStr.Name = "lblConnecStr";
            this.lblConnecStr.Size = new System.Drawing.Size(89, 13);
            this.lblConnecStr.TabIndex = 14;
            this.lblConnecStr.Text = "Connection string";
            // 
            // txtConnectStr
            // 
            this.txtConnectStr.Location = new System.Drawing.Point(19, 38);
            this.txtConnectStr.Multiline = true;
            this.txtConnectStr.Name = "txtConnectStr";
            this.txtConnectStr.Size = new System.Drawing.Size(289, 84);
            this.txtConnectStr.TabIndex = 13;
            this.txtConnectStr.TextChanged += new System.EventHandler(this.txtConnectStr_TextChanged);
            // 
            // btnImportFromExternal
            // 
            this.btnImportFromExternal.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFromExternal.Image")));
            this.btnImportFromExternal.Location = new System.Drawing.Point(72, 222);
            this.btnImportFromExternal.Name = "btnImportFromExternal";
            this.btnImportFromExternal.Size = new System.Drawing.Size(155, 49);
            this.btnImportFromExternal.TabIndex = 9;
            this.btnImportFromExternal.Text = "Import";
            this.btnImportFromExternal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportFromExternal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportFromExternal.UseVisualStyleBackColor = true;
            this.btnImportFromExternal.Click += new System.EventHandler(this.btnImportFromExternal_Click);
            // 
            // tabExternalExport
            // 
            this.tabExternalExport.Controls.Add(this.grpExport);
            this.tabExternalExport.Location = new System.Drawing.Point(4, 22);
            this.tabExternalExport.Name = "tabExternalExport";
            this.tabExternalExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternalExport.Size = new System.Drawing.Size(335, 312);
            this.tabExternalExport.TabIndex = 1;
            this.tabExternalExport.Text = "Export";
            this.tabExternalExport.UseVisualStyleBackColor = true;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.btnConfigEntities);
            this.grpExport.Controls.Add(this.lblTemplate);
            this.grpExport.Controls.Add(this.btnSelectTemplate);
            this.grpExport.Controls.Add(this.txtExcelTemplate);
            this.grpExport.Controls.Add(this.btnExportToExternal);
            this.grpExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExport.Location = new System.Drawing.Point(3, 3);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(329, 306);
            this.grpExport.TabIndex = 17;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "Export to excel spreadsheet";
            // 
            // btnConfigEntities
            // 
            this.btnConfigEntities.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigEntities.Image")));
            this.btnConfigEntities.Location = new System.Drawing.Point(75, 84);
            this.btnConfigEntities.Name = "btnConfigEntities";
            this.btnConfigEntities.Size = new System.Drawing.Size(155, 48);
            this.btnConfigEntities.TabIndex = 26;
            this.btnConfigEntities.Text = "Tables";
            this.btnConfigEntities.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfigEntities.UseVisualStyleBackColor = true;
            this.btnConfigEntities.Click += new System.EventHandler(this.btnConfigEntities_Click);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(16, 22);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(51, 13);
            this.lblTemplate.TabIndex = 25;
            this.lblTemplate.Text = "Template";
            // 
            // btnSelectTemplate
            // 
            this.btnSelectTemplate.Location = new System.Drawing.Point(282, 36);
            this.btnSelectTemplate.Name = "btnSelectTemplate";
            this.btnSelectTemplate.Size = new System.Drawing.Size(41, 23);
            this.btnSelectTemplate.TabIndex = 23;
            this.btnSelectTemplate.Text = "...";
            this.btnSelectTemplate.UseVisualStyleBackColor = true;
            this.btnSelectTemplate.Click += new System.EventHandler(this.btnSelectTemplate_Click);
            // 
            // txtExcelTemplate
            // 
            this.txtExcelTemplate.Enabled = false;
            this.txtExcelTemplate.Location = new System.Drawing.Point(19, 38);
            this.txtExcelTemplate.Name = "txtExcelTemplate";
            this.txtExcelTemplate.Size = new System.Drawing.Size(252, 20);
            this.txtExcelTemplate.TabIndex = 22;
            // 
            // btnExportToExternal
            // 
            this.btnExportToExternal.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExternal.Image")));
            this.btnExportToExternal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToExternal.Location = new System.Drawing.Point(75, 138);
            this.btnExportToExternal.Name = "btnExportToExternal";
            this.btnExportToExternal.Size = new System.Drawing.Size(155, 49);
            this.btnExportToExternal.TabIndex = 13;
            this.btnExportToExternal.Text = "Export";
            this.btnExportToExternal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToExternal.UseVisualStyleBackColor = true;
            this.btnExportToExternal.Click += new System.EventHandler(this.btnExportToExternal_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabData);
            this.tabMain.Controls.Add(this.tabExternal);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(357, 370);
            this.tabMain.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.groupBox1);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(349, 344);
            this.tabData.TabIndex = 4;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDepartments);
            this.groupBox1.Controls.Add(this.btnImportData);
            this.groupBox1.Controls.Add(this.chkPublishers);
            this.groupBox1.Controls.Add(this.btnExportData);
            this.groupBox1.Controls.Add(this.chkTerritories);
            this.groupBox1.Controls.Add(this.chkTours);
            this.groupBox1.Controls.Add(this.chkAddresses);
            this.groupBox1.Controls.Add(this.chkCities);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 338);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // chkDepartments
            // 
            this.chkDepartments.AutoSize = true;
            this.chkDepartments.Location = new System.Drawing.Point(69, 82);
            this.chkDepartments.Name = "chkDepartments";
            this.chkDepartments.Size = new System.Drawing.Size(86, 17);
            this.chkDepartments.TabIndex = 19;
            this.chkDepartments.Text = "Departments";
            this.chkDepartments.UseVisualStyleBackColor = true;
            // 
            // btnImportData
            // 
            this.btnImportData.Image = ((System.Drawing.Image)(resources.GetObject("btnImportData.Image")));
            this.btnImportData.Location = new System.Drawing.Point(91, 124);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(155, 49);
            this.btnImportData.TabIndex = 13;
            this.btnImportData.Text = "Import";
            this.btnImportData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // chkPublishers
            // 
            this.chkPublishers.AutoSize = true;
            this.chkPublishers.Location = new System.Drawing.Point(195, 82);
            this.chkPublishers.Name = "chkPublishers";
            this.chkPublishers.Size = new System.Drawing.Size(74, 17);
            this.chkPublishers.TabIndex = 15;
            this.chkPublishers.Text = "Publishers";
            this.chkPublishers.UseVisualStyleBackColor = true;
            // 
            // btnExportData
            // 
            this.btnExportData.Image = ((System.Drawing.Image)(resources.GetObject("btnExportData.Image")));
            this.btnExportData.Location = new System.Drawing.Point(91, 198);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(155, 49);
            this.btnExportData.TabIndex = 13;
            this.btnExportData.Text = "Export";
            this.btnExportData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // chkTerritories
            // 
            this.chkTerritories.AutoSize = true;
            this.chkTerritories.Location = new System.Drawing.Point(195, 59);
            this.chkTerritories.Name = "chkTerritories";
            this.chkTerritories.Size = new System.Drawing.Size(72, 17);
            this.chkTerritories.TabIndex = 16;
            this.chkTerritories.Text = "Territories";
            this.chkTerritories.UseVisualStyleBackColor = true;
            // 
            // chkTours
            // 
            this.chkTours.AutoSize = true;
            this.chkTours.Location = new System.Drawing.Point(195, 36);
            this.chkTours.Name = "chkTours";
            this.chkTours.Size = new System.Drawing.Size(53, 17);
            this.chkTours.TabIndex = 14;
            this.chkTours.Text = "Tours";
            this.chkTours.UseVisualStyleBackColor = true;
            // 
            // chkAddresses
            // 
            this.chkAddresses.AutoSize = true;
            this.chkAddresses.Location = new System.Drawing.Point(69, 36);
            this.chkAddresses.Name = "chkAddresses";
            this.chkAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkAddresses.TabIndex = 17;
            this.chkAddresses.Text = "Addresses";
            this.chkAddresses.UseVisualStyleBackColor = true;
            // 
            // chkCities
            // 
            this.chkCities.AutoSize = true;
            this.chkCities.Location = new System.Drawing.Point(69, 59);
            this.chkCities.Name = "chkCities";
            this.chkCities.Size = new System.Drawing.Size(51, 17);
            this.chkCities.TabIndex = 18;
            this.chkCities.Text = "Cities";
            this.chkCities.UseVisualStyleBackColor = true;
            // 
            // ofdSourceFile
            // 
            this.ofdSourceFile.InitialDirectory = "C:\\\\";
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 389);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInterop";
            this.Text = "Interoperability";
            this.Load += new System.EventHandler(this.frmInterop_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInterop_FormClosing);
            this.tabExternal.ResumeLayout(false);
            this.tabImportPanel.ResumeLayout(false);
            this.tabExternalImport.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.tabExternalExport.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabExternal;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.OpenFileDialog ofdSourceFile;
        private System.Windows.Forms.SaveFileDialog sfdDestinationFile;
        private System.Windows.Forms.TabControl tabImportPanel;
        private System.Windows.Forms.TabPage tabExternalImport;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.ProgressBar prbDataImport;
        private System.Windows.Forms.Button btnConfigureConnection;
        private System.Windows.Forms.Label lblConnecStr;
        private System.Windows.Forms.TextBox txtConnectStr;
        private System.Windows.Forms.Button btnImportFromExternal;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.CheckBox chkDepartments;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.CheckBox chkCities;
        private System.Windows.Forms.CheckBox chkAddresses;
        private System.Windows.Forms.CheckBox chkTours;
        private System.Windows.Forms.CheckBox chkTerritories;
        private System.Windows.Forms.CheckBox chkPublishers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabExternalExport;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.Button btnExportToExternal;
        private System.Windows.Forms.TextBox txtExcelTemplate;
        private System.Windows.Forms.Button btnSelectTemplate;
        private System.Windows.Forms.Button btnConfigTables;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Button btnConfigEntities;
    }
}