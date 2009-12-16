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
            this.odfRssSource = new System.Windows.Forms.OpenFileDialog();
            this.tabDataImport = new System.Windows.Forms.TabPage();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.lblProvider = new System.Windows.Forms.Label();
            this.cboProvider = new System.Windows.Forms.ComboBox();
            this.tabProviders = new System.Windows.Forms.TabControl();
            this.tabMsExcel = new System.Windows.Forms.TabPage();
            this.btnSetConnectStr = new System.Windows.Forms.Button();
            this.lblConnecStr = new System.Windows.Forms.Label();
            this.lblExcelFile = new System.Windows.Forms.Label();
            this.btnSelectExcelFile = new System.Windows.Forms.Button();
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.btnImport = new System.Windows.Forms.Button();
            this.grdImportConfig = new System.Windows.Forms.PropertyGrid();
            this.tabGeoRss = new System.Windows.Forms.TabPage();
            this.grpGMapsExport = new System.Windows.Forms.GroupBox();
            this.txtXmlDestiny = new System.Windows.Forms.TextBox();
            this.btnExportToGmaps = new System.Windows.Forms.Button();
            this.btnSaveToGMaps = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnImportGeoRss = new System.Windows.Forms.Button();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.tabMaps = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.rdoDepartments = new System.Windows.Forms.RadioButton();
            this.rdoTerritories = new System.Windows.Forms.RadioButton();
            this.rdoCities = new System.Windows.Forms.RadioButton();
            this.rdoAddresses = new System.Windows.Forms.RadioButton();
            this.chkListDepartments = new System.Windows.Forms.CheckedListBox();
            this.chkListTerritories = new System.Windows.Forms.CheckedListBox();
            this.chkListCities = new System.Windows.Forms.CheckedListBox();
            this.chkListAddresses = new System.Windows.Forms.CheckedListBox();
            this.txtExcelDestiny = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.ofdFileSource = new System.Windows.Forms.OpenFileDialog();
            this.sfdExcelDestiny = new System.Windows.Forms.SaveFileDialog();
            this.sfdGMaps = new System.Windows.Forms.SaveFileDialog();
            this.tabDataImport.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.tabProviders.SuspendLayout();
            this.tabMsExcel.SuspendLayout();
            this.tabGeoRss.SuspendLayout();
            this.grpGMapsExport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMaps.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // odfRssSource
            // 
            this.odfRssSource.Filter = "xml files (*.xml)|*.xml";
            this.odfRssSource.InitialDirectory = "C:\\\\";
            this.odfRssSource.FileOk += new System.ComponentModel.CancelEventHandler(this.odfRssSource_FileOk);
            // 
            // tabDataImport
            // 
            this.tabDataImport.Controls.Add(this.grpConfig);
            this.tabDataImport.Controls.Add(this.grdImportConfig);
            this.tabDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabDataImport.Name = "tabDataImport";
            this.tabDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataImport.Size = new System.Drawing.Size(578, 590);
            this.tabDataImport.TabIndex = 2;
            this.tabDataImport.Text = "Data import";
            this.tabDataImport.UseVisualStyleBackColor = true;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.lblProvider);
            this.grpConfig.Controls.Add(this.cboProvider);
            this.grpConfig.Controls.Add(this.tabProviders);
            this.grpConfig.Controls.Add(this.btnImport);
            this.grpConfig.Location = new System.Drawing.Point(3, 6);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(568, 279);
            this.grpConfig.TabIndex = 10;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Configure import properties";
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(60, 26);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(102, 13);
            this.lblProvider.TabIndex = 12;
            this.lblProvider.Text = "Select data provider";
            // 
            // cboProvider
            // 
            this.cboProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvider.FormattingEnabled = true;
            this.cboProvider.Location = new System.Drawing.Point(63, 42);
            this.cboProvider.Name = "cboProvider";
            this.cboProvider.Size = new System.Drawing.Size(289, 21);
            this.cboProvider.TabIndex = 11;
            // 
            // tabProviders
            // 
            this.tabProviders.Controls.Add(this.tabMsExcel);
            this.tabProviders.Controls.Add(this.tabOther);
            this.tabProviders.Location = new System.Drawing.Point(0, 78);
            this.tabProviders.Name = "tabProviders";
            this.tabProviders.SelectedIndex = 0;
            this.tabProviders.Size = new System.Drawing.Size(568, 196);
            this.tabProviders.TabIndex = 10;
            // 
            // tabMsExcel
            // 
            this.tabMsExcel.Controls.Add(this.btnSetConnectStr);
            this.tabMsExcel.Controls.Add(this.lblConnecStr);
            this.tabMsExcel.Controls.Add(this.lblExcelFile);
            this.tabMsExcel.Controls.Add(this.btnSelectExcelFile);
            this.tabMsExcel.Controls.Add(this.txtConnectStr);
            this.tabMsExcel.Controls.Add(this.txtExcelFile);
            this.tabMsExcel.Location = new System.Drawing.Point(4, 22);
            this.tabMsExcel.Name = "tabMsExcel";
            this.tabMsExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabMsExcel.Size = new System.Drawing.Size(560, 170);
            this.tabMsExcel.TabIndex = 0;
            this.tabMsExcel.Text = "MS Excel";
            this.tabMsExcel.UseVisualStyleBackColor = true;
            // 
            // btnSetConnectStr
            // 
            this.btnSetConnectStr.Location = new System.Drawing.Point(414, 77);
            this.btnSetConnectStr.Name = "btnSetConnectStr";
            this.btnSetConnectStr.Size = new System.Drawing.Size(113, 37);
            this.btnSetConnectStr.TabIndex = 5;
            this.btnSetConnectStr.Text = "Set connection string";
            this.btnSetConnectStr.UseVisualStyleBackColor = true;
            this.btnSetConnectStr.Click += new System.EventHandler(this.btnSetConnectStr_Click);
            // 
            // lblConnecStr
            // 
            this.lblConnecStr.AutoSize = true;
            this.lblConnecStr.Location = new System.Drawing.Point(29, 61);
            this.lblConnecStr.Name = "lblConnecStr";
            this.lblConnecStr.Size = new System.Drawing.Size(89, 13);
            this.lblConnecStr.TabIndex = 4;
            this.lblConnecStr.Text = "Connection string";
            // 
            // lblExcelFile
            // 
            this.lblExcelFile.AutoSize = true;
            this.lblExcelFile.Location = new System.Drawing.Point(29, 10);
            this.lblExcelFile.Name = "lblExcelFile";
            this.lblExcelFile.Size = new System.Drawing.Size(49, 13);
            this.lblExcelFile.TabIndex = 3;
            this.lblExcelFile.Text = "Excel file";
            // 
            // btnSelectExcelFile
            // 
            this.btnSelectExcelFile.Location = new System.Drawing.Point(414, 24);
            this.btnSelectExcelFile.Name = "btnSelectExcelFile";
            this.btnSelectExcelFile.Size = new System.Drawing.Size(113, 23);
            this.btnSelectExcelFile.TabIndex = 2;
            this.btnSelectExcelFile.Text = "Select excel file";
            this.btnSelectExcelFile.UseVisualStyleBackColor = true;
            this.btnSelectExcelFile.Click += new System.EventHandler(this.btnSelectExcelFile_Click);
            // 
            // txtConnectStr
            // 
            this.txtConnectStr.Location = new System.Drawing.Point(32, 77);
            this.txtConnectStr.Multiline = true;
            this.txtConnectStr.Name = "txtConnectStr";
            this.txtConnectStr.Size = new System.Drawing.Size(341, 70);
            this.txtConnectStr.TabIndex = 1;
            this.txtConnectStr.TextChanged += new System.EventHandler(this.txtConnectStr_TextChanged);
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Enabled = false;
            this.txtExcelFile.Location = new System.Drawing.Point(32, 26);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(341, 20);
            this.txtExcelFile.TabIndex = 0;
            // 
            // tabOther
            // 
            this.tabOther.Location = new System.Drawing.Point(4, 22);
            this.tabOther.Name = "tabOther";
            this.tabOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabOther.Size = new System.Drawing.Size(560, 170);
            this.tabOther.TabIndex = 1;
            this.tabOther.Text = "Other";
            this.tabOther.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(418, 40);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(113, 23);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // grdImportConfig
            // 
            this.grdImportConfig.Location = new System.Drawing.Point(3, 291);
            this.grdImportConfig.Name = "grdImportConfig";
            this.grdImportConfig.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.grdImportConfig.Size = new System.Drawing.Size(568, 292);
            this.grdImportConfig.TabIndex = 1;
            this.grdImportConfig.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.grdImportConfig_PropertyValueChanged);
            // 
            // tabGeoRss
            // 
            this.tabGeoRss.Controls.Add(this.grpGMapsExport);
            this.tabGeoRss.Controls.Add(this.groupBox1);
            this.tabGeoRss.Location = new System.Drawing.Point(4, 22);
            this.tabGeoRss.Name = "tabGeoRss";
            this.tabGeoRss.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeoRss.Size = new System.Drawing.Size(578, 590);
            this.tabGeoRss.TabIndex = 0;
            this.tabGeoRss.Text = "Maps";
            this.tabGeoRss.UseVisualStyleBackColor = true;
            // 
            // grpGMapsExport
            // 
            this.grpGMapsExport.Controls.Add(this.txtXmlDestiny);
            this.grpGMapsExport.Controls.Add(this.btnExportToGmaps);
            this.grpGMapsExport.Controls.Add(this.btnSaveToGMaps);
            this.grpGMapsExport.Location = new System.Drawing.Point(6, 180);
            this.grpGMapsExport.Name = "grpGMapsExport";
            this.grpGMapsExport.Size = new System.Drawing.Size(566, 127);
            this.grpGMapsExport.TabIndex = 17;
            this.grpGMapsExport.TabStop = false;
            this.grpGMapsExport.Text = "Export to Gmaps";
            // 
            // txtXmlDestiny
            // 
            this.txtXmlDestiny.Location = new System.Drawing.Point(15, 30);
            this.txtXmlDestiny.Name = "txtXmlDestiny";
            this.txtXmlDestiny.ReadOnly = true;
            this.txtXmlDestiny.Size = new System.Drawing.Size(379, 20);
            this.txtXmlDestiny.TabIndex = 12;
            // 
            // btnExportToGmaps
            // 
            this.btnExportToGmaps.Location = new System.Drawing.Point(104, 68);
            this.btnExportToGmaps.Name = "btnExportToGmaps";
            this.btnExportToGmaps.Size = new System.Drawing.Size(344, 35);
            this.btnExportToGmaps.TabIndex = 13;
            this.btnExportToGmaps.Text = "Export";
            this.btnExportToGmaps.UseVisualStyleBackColor = true;
            this.btnExportToGmaps.Click += new System.EventHandler(this.btnExportToGmaps_Click);
            // 
            // btnSaveToGMaps
            // 
            this.btnSaveToGMaps.Location = new System.Drawing.Point(420, 27);
            this.btnSaveToGMaps.Name = "btnSaveToGMaps";
            this.btnSaveToGMaps.Size = new System.Drawing.Size(118, 24);
            this.btnSaveToGMaps.TabIndex = 11;
            this.btnSaveToGMaps.Text = "Save";
            this.btnSaveToGMaps.UseVisualStyleBackColor = true;
            this.btnSaveToGMaps.Click += new System.EventHandler(this.btnSaveToGMaps_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRssSource);
            this.groupBox1.Controls.Add(this.btnImportGeoRss);
            this.groupBox1.Controls.Add(this.btnSelectRssSource);
            this.groupBox1.Location = new System.Drawing.Point(6, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 127);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import from GeoRss file";
            // 
            // txtRssSource
            // 
            this.txtRssSource.Location = new System.Drawing.Point(15, 30);
            this.txtRssSource.Name = "txtRssSource";
            this.txtRssSource.ReadOnly = true;
            this.txtRssSource.Size = new System.Drawing.Size(379, 20);
            this.txtRssSource.TabIndex = 12;
            // 
            // btnImportGeoRss
            // 
            this.btnImportGeoRss.Location = new System.Drawing.Point(104, 68);
            this.btnImportGeoRss.Name = "btnImportGeoRss";
            this.btnImportGeoRss.Size = new System.Drawing.Size(344, 35);
            this.btnImportGeoRss.TabIndex = 13;
            this.btnImportGeoRss.Text = "Import";
            this.btnImportGeoRss.UseVisualStyleBackColor = true;
            this.btnImportGeoRss.Click += new System.EventHandler(this.btnImportGeoRss_Click);
            // 
            // btnSelectRssSource
            // 
            this.btnSelectRssSource.Location = new System.Drawing.Point(420, 27);
            this.btnSelectRssSource.Name = "btnSelectRssSource";
            this.btnSelectRssSource.Size = new System.Drawing.Size(118, 24);
            this.btnSelectRssSource.TabIndex = 11;
            this.btnSelectRssSource.Text = "Select";
            this.btnSelectRssSource.UseVisualStyleBackColor = true;
            this.btnSelectRssSource.Click += new System.EventHandler(this.btnSelectRssSource_Click);
            // 
            // tabMaps
            // 
            this.tabMaps.Controls.Add(this.tabDataImport);
            this.tabMaps.Controls.Add(this.tabGeoRss);
            this.tabMaps.Controls.Add(this.tabPage1);
            this.tabMaps.Location = new System.Drawing.Point(8, 11);
            this.tabMaps.Name = "tabMaps";
            this.tabMaps.SelectedIndex = 0;
            this.tabMaps.Size = new System.Drawing.Size(586, 616);
            this.tabMaps.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpExport);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 590);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Data export";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.grpExport.Controls.Add(this.txtExcelDestiny);
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Controls.Add(this.btnSaveToExcel);
            this.grpExport.Location = new System.Drawing.Point(6, 25);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(566, 559);
            this.grpExport.TabIndex = 16;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "Export to excel file";
            // 
            // rdoDepartments
            // 
            this.rdoDepartments.AutoSize = true;
            this.rdoDepartments.Location = new System.Drawing.Point(420, 170);
            this.rdoDepartments.Name = "rdoDepartments";
            this.rdoDepartments.Size = new System.Drawing.Size(85, 17);
            this.rdoDepartments.TabIndex = 21;
            this.rdoDepartments.TabStop = true;
            this.rdoDepartments.Text = "Departments";
            this.rdoDepartments.UseVisualStyleBackColor = true;
            this.rdoDepartments.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoTerritories
            // 
            this.rdoTerritories.AutoSize = true;
            this.rdoTerritories.Location = new System.Drawing.Point(285, 170);
            this.rdoTerritories.Name = "rdoTerritories";
            this.rdoTerritories.Size = new System.Drawing.Size(71, 17);
            this.rdoTerritories.TabIndex = 20;
            this.rdoTerritories.TabStop = true;
            this.rdoTerritories.Text = "Territories";
            this.rdoTerritories.UseVisualStyleBackColor = true;
            this.rdoTerritories.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoCities
            // 
            this.rdoCities.AutoSize = true;
            this.rdoCities.Location = new System.Drawing.Point(150, 170);
            this.rdoCities.Name = "rdoCities";
            this.rdoCities.Size = new System.Drawing.Size(50, 17);
            this.rdoCities.TabIndex = 19;
            this.rdoCities.TabStop = true;
            this.rdoCities.Text = "Cities";
            this.rdoCities.UseVisualStyleBackColor = true;
            this.rdoCities.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoAddresses
            // 
            this.rdoAddresses.AutoSize = true;
            this.rdoAddresses.Location = new System.Drawing.Point(15, 170);
            this.rdoAddresses.Name = "rdoAddresses";
            this.rdoAddresses.Size = new System.Drawing.Size(74, 17);
            this.rdoAddresses.TabIndex = 18;
            this.rdoAddresses.TabStop = true;
            this.rdoAddresses.Text = "Addresses";
            this.rdoAddresses.UseVisualStyleBackColor = true;
            this.rdoAddresses.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // chkListDepartments
            // 
            this.chkListDepartments.Enabled = false;
            this.chkListDepartments.FormattingEnabled = true;
            this.chkListDepartments.Location = new System.Drawing.Point(420, 193);
            this.chkListDepartments.Name = "chkListDepartments";
            this.chkListDepartments.Size = new System.Drawing.Size(127, 169);
            this.chkListDepartments.TabIndex = 17;
            // 
            // chkListTerritories
            // 
            this.chkListTerritories.Enabled = false;
            this.chkListTerritories.FormattingEnabled = true;
            this.chkListTerritories.Location = new System.Drawing.Point(285, 193);
            this.chkListTerritories.Name = "chkListTerritories";
            this.chkListTerritories.Size = new System.Drawing.Size(127, 169);
            this.chkListTerritories.TabIndex = 16;
            // 
            // chkListCities
            // 
            this.chkListCities.Enabled = false;
            this.chkListCities.FormattingEnabled = true;
            this.chkListCities.Location = new System.Drawing.Point(150, 193);
            this.chkListCities.Name = "chkListCities";
            this.chkListCities.Size = new System.Drawing.Size(127, 169);
            this.chkListCities.TabIndex = 15;
            // 
            // chkListAddresses
            // 
            this.chkListAddresses.Enabled = false;
            this.chkListAddresses.FormattingEnabled = true;
            this.chkListAddresses.Location = new System.Drawing.Point(15, 193);
            this.chkListAddresses.Name = "chkListAddresses";
            this.chkListAddresses.Size = new System.Drawing.Size(127, 169);
            this.chkListAddresses.TabIndex = 14;
            // 
            // txtExcelDestiny
            // 
            this.txtExcelDestiny.Location = new System.Drawing.Point(15, 30);
            this.txtExcelDestiny.Name = "txtExcelDestiny";
            this.txtExcelDestiny.ReadOnly = true;
            this.txtExcelDestiny.Size = new System.Drawing.Size(379, 20);
            this.txtExcelDestiny.TabIndex = 12;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(104, 68);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(344, 35);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Location = new System.Drawing.Point(420, 27);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(118, 24);
            this.btnSaveToExcel.TabIndex = 11;
            this.btnSaveToExcel.Text = "Save";
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // ofdFileSource
            // 
            this.ofdFileSource.FileName = "openFileDialog1";
            this.ofdFileSource.InitialDirectory = "C:\\\\";
            this.ofdFileSource.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdFileSource_FileOk);
            // 
            // sfdExcelDestiny
            // 
            this.sfdExcelDestiny.Filter = "Excel files (*.xls)|*.xls";
            this.sfdExcelDestiny.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdExcelDestiny_FileOk);
            // 
            // sfdGMaps
            // 
            this.sfdGMaps.Filter = "xml files (*.xml)|*.xml";
            this.sfdGMaps.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdGMaps_FileOk);
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 632);
            this.Controls.Add(this.tabMaps);
            this.Name = "frmInterop";
            this.Text = "Interoperability";
            this.Load += new System.EventHandler(this.frmInterop_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInterop_FormClosing);
            this.tabDataImport.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.tabProviders.ResumeLayout(false);
            this.tabMsExcel.ResumeLayout(false);
            this.tabMsExcel.PerformLayout();
            this.tabGeoRss.ResumeLayout(false);
            this.grpGMapsExport.ResumeLayout(false);
            this.grpGMapsExport.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMaps.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog odfRssSource;
        private System.Windows.Forms.TabPage tabDataImport;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.ComboBox cboProvider;
        private System.Windows.Forms.TabControl tabProviders;
        private System.Windows.Forms.TabPage tabMsExcel;
        private System.Windows.Forms.Label lblConnecStr;
        private System.Windows.Forms.Label lblExcelFile;
        private System.Windows.Forms.Button btnSelectExcelFile;
        private System.Windows.Forms.TextBox txtConnectStr;
        private System.Windows.Forms.TextBox txtExcelFile;
        private System.Windows.Forms.TabPage tabOther;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PropertyGrid grdImportConfig;
        private System.Windows.Forms.TabPage tabGeoRss;
        private System.Windows.Forms.Button btnImportGeoRss;
        private System.Windows.Forms.TextBox txtRssSource;
        private System.Windows.Forms.Button btnSelectRssSource;
        private System.Windows.Forms.TabControl tabMaps;
        private System.Windows.Forms.Button btnSetConnectStr;
        private System.Windows.Forms.OpenFileDialog ofdFileSource;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.TextBox txtExcelDestiny;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.SaveFileDialog sfdExcelDestiny;
        private System.Windows.Forms.CheckedListBox chkListAddresses;
        private System.Windows.Forms.RadioButton rdoAddresses;
        private System.Windows.Forms.CheckedListBox chkListDepartments;
        private System.Windows.Forms.CheckedListBox chkListTerritories;
        private System.Windows.Forms.CheckedListBox chkListCities;
        private System.Windows.Forms.RadioButton rdoDepartments;
        private System.Windows.Forms.RadioButton rdoTerritories;
        private System.Windows.Forms.RadioButton rdoCities;
        private System.Windows.Forms.GroupBox grpGMapsExport;
        private System.Windows.Forms.TextBox txtXmlDestiny;
        private System.Windows.Forms.Button btnExportToGmaps;
        private System.Windows.Forms.Button btnSaveToGMaps;
        private System.Windows.Forms.SaveFileDialog sfdGMaps;
    }
}