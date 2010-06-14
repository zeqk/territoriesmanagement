namespace TerritoriesManagement.GUI
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
            this.tabExternal = new System.Windows.Forms.TabPage();
            this.tabImportPanel = new System.Windows.Forms.TabControl();
            this.tabExternalImport = new System.Windows.Forms.TabPage();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.prbDataImport = new System.Windows.Forms.ProgressBar();
            this.btnConfigureConnection = new System.Windows.Forms.Button();
            this.lblConnecStr = new System.Windows.Forms.Label();
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.btnImportFromExternal = new System.Windows.Forms.Button();
            this.grdImportConfig = new System.Windows.Forms.PropertyGrid();
            this.tabExternalExport = new System.Windows.Forms.TabPage();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.rdoDepartments = new System.Windows.Forms.RadioButton();
            this.rdoTerritories = new System.Windows.Forms.RadioButton();
            this.rdoCities = new System.Windows.Forms.RadioButton();
            this.rdoAddresses = new System.Windows.Forms.RadioButton();
            this.chkListDepartments = new System.Windows.Forms.CheckedListBox();
            this.chkListTerritories = new System.Windows.Forms.CheckedListBox();
            this.chkListCities = new System.Windows.Forms.CheckedListBox();
            this.chkListAddresses = new System.Windows.Forms.CheckedListBox();
            this.txtExcelDestination = new System.Windows.Forms.TextBox();
            this.btnExportToExternal = new System.Windows.Forms.Button();
            this.btnBrowse3 = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDepartments = new System.Windows.Forms.CheckBox();
            this.chkPublishers = new System.Windows.Forms.CheckBox();
            this.chkTerritories = new System.Windows.Forms.CheckBox();
            this.chkTours = new System.Windows.Forms.CheckBox();
            this.chkAddresses = new System.Windows.Forms.CheckBox();
            this.chkCities = new System.Windows.Forms.CheckBox();
            this.txtImportDataFile = new System.Windows.Forms.TextBox();
            this.txtDataExportFile = new System.Windows.Forms.TextBox();
            this.btnImportData = new System.Windows.Forms.Button();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnExportData = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
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
            this.tabExternal.Size = new System.Drawing.Size(578, 423);
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
            this.tabImportPanel.Size = new System.Drawing.Size(572, 417);
            this.tabImportPanel.TabIndex = 0;
            // 
            // tabExternalImport
            // 
            this.tabExternalImport.Controls.Add(this.grpConfig);
            this.tabExternalImport.Controls.Add(this.grdImportConfig);
            this.tabExternalImport.Location = new System.Drawing.Point(4, 22);
            this.tabExternalImport.Name = "tabExternalImport";
            this.tabExternalImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternalImport.Size = new System.Drawing.Size(564, 391);
            this.tabExternalImport.TabIndex = 0;
            this.tabExternalImport.Text = "Import";
            this.tabExternalImport.UseVisualStyleBackColor = true;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.prbDataImport);
            this.grpConfig.Controls.Add(this.btnConfigureConnection);
            this.grpConfig.Controls.Add(this.lblConnecStr);
            this.grpConfig.Controls.Add(this.txtConnectStr);
            this.grpConfig.Controls.Add(this.btnImportFromExternal);
            this.grpConfig.Location = new System.Drawing.Point(1, 6);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(560, 164);
            this.grpConfig.TabIndex = 12;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Configure import properties";
            // 
            // prbDataImport
            // 
            this.prbDataImport.Location = new System.Drawing.Point(303, 112);
            this.prbDataImport.Name = "prbDataImport";
            this.prbDataImport.Size = new System.Drawing.Size(246, 24);
            this.prbDataImport.TabIndex = 16;
            // 
            // btnConfigureConnection
            // 
            this.btnConfigureConnection.Location = new System.Drawing.Point(469, 38);
            this.btnConfigureConnection.Name = "btnConfigureConnection";
            this.btnConfigureConnection.Size = new System.Drawing.Size(83, 23);
            this.btnConfigureConnection.TabIndex = 15;
            this.btnConfigureConnection.Text = "Configure";
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
            this.txtConnectStr.Size = new System.Drawing.Size(444, 52);
            this.txtConnectStr.TabIndex = 13;
            this.txtConnectStr.TextChanged += new System.EventHandler(this.txtConnectStr_TextChanged);
            // 
            // btnImportFromExternal
            // 
            this.btnImportFromExternal.Location = new System.Drawing.Point(19, 107);
            this.btnImportFromExternal.Name = "btnImportFromExternal";
            this.btnImportFromExternal.Size = new System.Drawing.Size(243, 35);
            this.btnImportFromExternal.TabIndex = 9;
            this.btnImportFromExternal.Text = "Import";
            this.btnImportFromExternal.UseVisualStyleBackColor = true;
            this.btnImportFromExternal.Click += new System.EventHandler(this.btnImportFromExternal_Click);
            // 
            // grdImportConfig
            // 
            this.grdImportConfig.Location = new System.Drawing.Point(-4, 176);
            this.grdImportConfig.Name = "grdImportConfig";
            this.grdImportConfig.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.grdImportConfig.Size = new System.Drawing.Size(568, 225);
            this.grdImportConfig.TabIndex = 11;
            // 
            // tabExternalExport
            // 
            this.tabExternalExport.Controls.Add(this.grpExport);
            this.tabExternalExport.Location = new System.Drawing.Point(4, 22);
            this.tabExternalExport.Name = "tabExternalExport";
            this.tabExternalExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternalExport.Size = new System.Drawing.Size(564, 391);
            this.tabExternalExport.TabIndex = 1;
            this.tabExternalExport.Text = "Export";
            this.tabExternalExport.UseVisualStyleBackColor = true;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.rdoDepartments);
            this.grpExport.Controls.Add(this.rdoTerritories);
            this.grpExport.Controls.Add(this.rdoCities);
            this.grpExport.Controls.Add(this.rdoAddresses);
            this.grpExport.Controls.Add(this.chkListDepartments);
            this.grpExport.Controls.Add(this.chkListTerritories);
            this.grpExport.Controls.Add(this.chkListCities);
            this.grpExport.Controls.Add(this.chkListAddresses);
            this.grpExport.Controls.Add(this.txtExcelDestination);
            this.grpExport.Controls.Add(this.btnExportToExternal);
            this.grpExport.Controls.Add(this.btnBrowse3);
            this.grpExport.Location = new System.Drawing.Point(1, 4);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(562, 383);
            this.grpExport.TabIndex = 17;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "Export to excel file";
            // 
            // rdoDepartments
            // 
            this.rdoDepartments.AutoSize = true;
            this.rdoDepartments.Location = new System.Drawing.Point(420, 167);
            this.rdoDepartments.Name = "rdoDepartments";
            this.rdoDepartments.Size = new System.Drawing.Size(85, 17);
            this.rdoDepartments.TabIndex = 21;
            this.rdoDepartments.TabStop = true;
            this.rdoDepartments.Text = "Departments";
            this.rdoDepartments.UseVisualStyleBackColor = true;
            // 
            // rdoTerritories
            // 
            this.rdoTerritories.AutoSize = true;
            this.rdoTerritories.Location = new System.Drawing.Point(285, 167);
            this.rdoTerritories.Name = "rdoTerritories";
            this.rdoTerritories.Size = new System.Drawing.Size(71, 17);
            this.rdoTerritories.TabIndex = 20;
            this.rdoTerritories.TabStop = true;
            this.rdoTerritories.Text = "Territories";
            this.rdoTerritories.UseVisualStyleBackColor = true;
            // 
            // rdoCities
            // 
            this.rdoCities.AutoSize = true;
            this.rdoCities.Location = new System.Drawing.Point(150, 167);
            this.rdoCities.Name = "rdoCities";
            this.rdoCities.Size = new System.Drawing.Size(50, 17);
            this.rdoCities.TabIndex = 19;
            this.rdoCities.TabStop = true;
            this.rdoCities.Text = "Cities";
            this.rdoCities.UseVisualStyleBackColor = true;
            // 
            // rdoAddresses
            // 
            this.rdoAddresses.AutoSize = true;
            this.rdoAddresses.Location = new System.Drawing.Point(15, 167);
            this.rdoAddresses.Name = "rdoAddresses";
            this.rdoAddresses.Size = new System.Drawing.Size(74, 17);
            this.rdoAddresses.TabIndex = 18;
            this.rdoAddresses.TabStop = true;
            this.rdoAddresses.Text = "Addresses";
            this.rdoAddresses.UseVisualStyleBackColor = true;
            // 
            // chkListDepartments
            // 
            this.chkListDepartments.CheckOnClick = true;
            this.chkListDepartments.Enabled = false;
            this.chkListDepartments.FormattingEnabled = true;
            this.chkListDepartments.Location = new System.Drawing.Point(420, 190);
            this.chkListDepartments.Name = "chkListDepartments";
            this.chkListDepartments.Size = new System.Drawing.Size(127, 169);
            this.chkListDepartments.TabIndex = 17;
            // 
            // chkListTerritories
            // 
            this.chkListTerritories.CheckOnClick = true;
            this.chkListTerritories.Enabled = false;
            this.chkListTerritories.FormattingEnabled = true;
            this.chkListTerritories.Location = new System.Drawing.Point(285, 190);
            this.chkListTerritories.Name = "chkListTerritories";
            this.chkListTerritories.Size = new System.Drawing.Size(127, 169);
            this.chkListTerritories.TabIndex = 16;
            // 
            // chkListCities
            // 
            this.chkListCities.CheckOnClick = true;
            this.chkListCities.Enabled = false;
            this.chkListCities.FormattingEnabled = true;
            this.chkListCities.Location = new System.Drawing.Point(150, 190);
            this.chkListCities.Name = "chkListCities";
            this.chkListCities.Size = new System.Drawing.Size(127, 169);
            this.chkListCities.TabIndex = 15;
            // 
            // chkListAddresses
            // 
            this.chkListAddresses.CheckOnClick = true;
            this.chkListAddresses.Enabled = false;
            this.chkListAddresses.FormattingEnabled = true;
            this.chkListAddresses.Location = new System.Drawing.Point(15, 190);
            this.chkListAddresses.Name = "chkListAddresses";
            this.chkListAddresses.Size = new System.Drawing.Size(127, 169);
            this.chkListAddresses.TabIndex = 14;
            // 
            // txtExcelDestination
            // 
            this.txtExcelDestination.Location = new System.Drawing.Point(15, 27);
            this.txtExcelDestination.Name = "txtExcelDestination";
            this.txtExcelDestination.ReadOnly = true;
            this.txtExcelDestination.Size = new System.Drawing.Size(379, 20);
            this.txtExcelDestination.TabIndex = 12;
            // 
            // btnExportToExternal
            // 
            this.btnExportToExternal.Location = new System.Drawing.Point(104, 65);
            this.btnExportToExternal.Name = "btnExportToExternal";
            this.btnExportToExternal.Size = new System.Drawing.Size(344, 35);
            this.btnExportToExternal.TabIndex = 13;
            this.btnExportToExternal.Text = "Export";
            this.btnExportToExternal.UseVisualStyleBackColor = true;
            this.btnExportToExternal.Click += new System.EventHandler(this.btnExportToExternal_Click);
            // 
            // btnBrowse3
            // 
            this.btnBrowse3.Location = new System.Drawing.Point(420, 24);
            this.btnBrowse3.Name = "btnBrowse3";
            this.btnBrowse3.Size = new System.Drawing.Size(118, 24);
            this.btnBrowse3.TabIndex = 11;
            this.btnBrowse3.Text = "Browse";
            this.btnBrowse3.UseVisualStyleBackColor = true;
            this.btnBrowse3.Click += new System.EventHandler(this.btnBrowse3_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabData);
            this.tabMain.Controls.Add(this.tabExternal);
            this.tabMain.Location = new System.Drawing.Point(8, 11);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(586, 449);
            this.tabMain.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.label2);
            this.tabData.Controls.Add(this.label1);
            this.tabData.Controls.Add(this.groupBox1);
            this.tabData.Controls.Add(this.txtImportDataFile);
            this.tabData.Controls.Add(this.txtDataExportFile);
            this.tabData.Controls.Add(this.btnImportData);
            this.tabData.Controls.Add(this.btnBrowse1);
            this.tabData.Controls.Add(this.btnExportData);
            this.tabData.Controls.Add(this.btnBrowse2);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(578, 423);
            this.tabData.TabIndex = 4;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Destination file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Source file";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDepartments);
            this.groupBox1.Controls.Add(this.chkPublishers);
            this.groupBox1.Controls.Add(this.chkTerritories);
            this.groupBox1.Controls.Add(this.chkTours);
            this.groupBox1.Controls.Add(this.chkAddresses);
            this.groupBox1.Controls.Add(this.chkCities);
            this.groupBox1.Location = new System.Drawing.Point(130, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 100);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // chkDepartments
            // 
            this.chkDepartments.AutoSize = true;
            this.chkDepartments.Location = new System.Drawing.Point(39, 67);
            this.chkDepartments.Name = "chkDepartments";
            this.chkDepartments.Size = new System.Drawing.Size(86, 17);
            this.chkDepartments.TabIndex = 19;
            this.chkDepartments.Text = "Departments";
            this.chkDepartments.UseVisualStyleBackColor = true;
            // 
            // chkPublishers
            // 
            this.chkPublishers.AutoSize = true;
            this.chkPublishers.Location = new System.Drawing.Point(165, 67);
            this.chkPublishers.Name = "chkPublishers";
            this.chkPublishers.Size = new System.Drawing.Size(74, 17);
            this.chkPublishers.TabIndex = 15;
            this.chkPublishers.Text = "Publishers";
            this.chkPublishers.UseVisualStyleBackColor = true;
            // 
            // chkTerritories
            // 
            this.chkTerritories.AutoSize = true;
            this.chkTerritories.Location = new System.Drawing.Point(165, 44);
            this.chkTerritories.Name = "chkTerritories";
            this.chkTerritories.Size = new System.Drawing.Size(72, 17);
            this.chkTerritories.TabIndex = 16;
            this.chkTerritories.Text = "Territories";
            this.chkTerritories.UseVisualStyleBackColor = true;
            // 
            // chkTours
            // 
            this.chkTours.AutoSize = true;
            this.chkTours.Location = new System.Drawing.Point(165, 21);
            this.chkTours.Name = "chkTours";
            this.chkTours.Size = new System.Drawing.Size(53, 17);
            this.chkTours.TabIndex = 14;
            this.chkTours.Text = "Tours";
            this.chkTours.UseVisualStyleBackColor = true;
            // 
            // chkAddresses
            // 
            this.chkAddresses.AutoSize = true;
            this.chkAddresses.Location = new System.Drawing.Point(39, 21);
            this.chkAddresses.Name = "chkAddresses";
            this.chkAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkAddresses.TabIndex = 17;
            this.chkAddresses.Text = "Addresses";
            this.chkAddresses.UseVisualStyleBackColor = true;
            // 
            // chkCities
            // 
            this.chkCities.AutoSize = true;
            this.chkCities.Location = new System.Drawing.Point(39, 44);
            this.chkCities.Name = "chkCities";
            this.chkCities.Size = new System.Drawing.Size(51, 17);
            this.chkCities.TabIndex = 18;
            this.chkCities.Text = "Cities";
            this.chkCities.UseVisualStyleBackColor = true;
            // 
            // txtImportDataFile
            // 
            this.txtImportDataFile.Location = new System.Drawing.Point(29, 189);
            this.txtImportDataFile.Name = "txtImportDataFile";
            this.txtImportDataFile.ReadOnly = true;
            this.txtImportDataFile.Size = new System.Drawing.Size(447, 20);
            this.txtImportDataFile.TabIndex = 12;
            // 
            // txtDataExportFile
            // 
            this.txtDataExportFile.Location = new System.Drawing.Point(29, 309);
            this.txtDataExportFile.Name = "txtDataExportFile";
            this.txtDataExportFile.ReadOnly = true;
            this.txtDataExportFile.Size = new System.Drawing.Size(447, 20);
            this.txtDataExportFile.TabIndex = 12;
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(374, 225);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(178, 35);
            this.btnImportData.TabIndex = 13;
            this.btnImportData.Text = "Import";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(482, 186);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(70, 24);
            this.btnBrowse1.TabIndex = 11;
            this.btnBrowse1.Text = "Browse";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(374, 346);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(178, 35);
            this.btnExportData.TabIndex = 13;
            this.btnExportData.Text = "Export";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(482, 305);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(70, 24);
            this.btnBrowse2.TabIndex = 11;
            this.btnBrowse2.Text = "Browse";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // ofdSourceFile
            // 
            this.ofdSourceFile.InitialDirectory = "C:\\\\";
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 472);
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
            this.tabData.PerformLayout();
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
        private System.Windows.Forms.PropertyGrid grdImportConfig;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TextBox txtImportDataFile;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.CheckBox chkDepartments;
        private System.Windows.Forms.TextBox txtDataExportFile;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.CheckBox chkCities;
        private System.Windows.Forms.CheckBox chkAddresses;
        private System.Windows.Forms.CheckBox chkTours;
        private System.Windows.Forms.CheckBox chkTerritories;
        private System.Windows.Forms.CheckBox chkPublishers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabExternalExport;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.RadioButton rdoDepartments;
        private System.Windows.Forms.RadioButton rdoTerritories;
        private System.Windows.Forms.RadioButton rdoCities;
        private System.Windows.Forms.RadioButton rdoAddresses;
        private System.Windows.Forms.CheckedListBox chkListDepartments;
        private System.Windows.Forms.CheckedListBox chkListTerritories;
        private System.Windows.Forms.CheckedListBox chkListCities;
        private System.Windows.Forms.CheckedListBox chkListAddresses;
        private System.Windows.Forms.TextBox txtExcelDestination;
        private System.Windows.Forms.Button btnExportToExternal;
        private System.Windows.Forms.Button btnBrowse3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}