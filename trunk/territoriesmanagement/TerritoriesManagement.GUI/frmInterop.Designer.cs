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
            this.tabImport = new System.Windows.Forms.TabPage();
            this.tabImportPanel = new System.Windows.Forms.TabControl();
            this.tabExternalDataImport = new System.Windows.Forms.TabPage();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.prbDataImport = new System.Windows.Forms.ProgressBar();
            this.btnConfigureConnection = new System.Windows.Forms.Button();
            this.lblConnecStr = new System.Windows.Forms.Label();
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.grdImportConfig = new System.Windows.Forms.PropertyGrid();
            this.tabMapsImport = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnImportGeoRss = new System.Windows.Forms.Button();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.tabDataImport = new System.Windows.Forms.TabPage();
            this.grpDataImport = new System.Windows.Forms.GroupBox();
            this.chkImportDataDepartments = new System.Windows.Forms.CheckBox();
            this.chkImportDataCities = new System.Windows.Forms.CheckBox();
            this.chkImportDataAddresses = new System.Windows.Forms.CheckBox();
            this.chkImportDataTerritories = new System.Windows.Forms.CheckBox();
            this.chkImportDataPublishers = new System.Windows.Forms.CheckBox();
            this.chkImportDataTours = new System.Windows.Forms.CheckBox();
            this.txtImportDataFile = new System.Windows.Forms.TextBox();
            this.btnImportData = new System.Windows.Forms.Button();
            this.btnImportDataSelectFile = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.tabExportPanel = new System.Windows.Forms.TabControl();
            this.tabExternalDataExport = new System.Windows.Forms.TabPage();
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.tabMapsExport = new System.Windows.Forms.TabPage();
            this.grpGMapsExport = new System.Windows.Forms.GroupBox();
            this.txtXmlDestination = new System.Windows.Forms.TextBox();
            this.btnExportToGmaps = new System.Windows.Forms.Button();
            this.btnSaveToGMaps = new System.Windows.Forms.Button();
            this.ofdSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdDestinationFile = new System.Windows.Forms.SaveFileDialog();
            this.sfdGMaps = new System.Windows.Forms.SaveFileDialog();
            this.tabDataExport = new System.Windows.Forms.TabPage();
            this.grpDataExport = new System.Windows.Forms.GroupBox();
            this.chkDataExportDepartments = new System.Windows.Forms.CheckBox();
            this.chkDataExportCities = new System.Windows.Forms.CheckBox();
            this.chkDataExportAddresses = new System.Windows.Forms.CheckBox();
            this.chkDataExportTerritories = new System.Windows.Forms.CheckBox();
            this.chkDataExportPublishers = new System.Windows.Forms.CheckBox();
            this.chkDataExportTours = new System.Windows.Forms.CheckBox();
            this.txtDataExportFile = new System.Windows.Forms.TextBox();
            this.btnExportData = new System.Windows.Forms.Button();
            this.btnDataExportSave = new System.Windows.Forms.Button();
            this.tabImport.SuspendLayout();
            this.tabImportPanel.SuspendLayout();
            this.tabExternalDataImport.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.tabMapsImport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDataImport.SuspendLayout();
            this.grpDataImport.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.tabExportPanel.SuspendLayout();
            this.tabExternalDataExport.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.tabMapsExport.SuspendLayout();
            this.grpGMapsExport.SuspendLayout();
            this.tabDataExport.SuspendLayout();
            this.grpDataExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // odfRssSource
            // 
            this.odfRssSource.Filter = "xml files (*.xml)|*.xml";
            this.odfRssSource.InitialDirectory = "C:\\\\";
            this.odfRssSource.FileOk += new System.ComponentModel.CancelEventHandler(this.odfRssSource_FileOk);
            // 
            // tabImport
            // 
            this.tabImport.Controls.Add(this.tabImportPanel);
            this.tabImport.Location = new System.Drawing.Point(4, 22);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabImport.Size = new System.Drawing.Size(578, 423);
            this.tabImport.TabIndex = 2;
            this.tabImport.Text = "Data import";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // tabImportPanel
            // 
            this.tabImportPanel.Controls.Add(this.tabExternalDataImport);
            this.tabImportPanel.Controls.Add(this.tabMapsImport);
            this.tabImportPanel.Controls.Add(this.tabDataImport);
            this.tabImportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImportPanel.Location = new System.Drawing.Point(3, 3);
            this.tabImportPanel.Name = "tabImportPanel";
            this.tabImportPanel.SelectedIndex = 0;
            this.tabImportPanel.Size = new System.Drawing.Size(572, 417);
            this.tabImportPanel.TabIndex = 0;
            // 
            // tabExternalDataImport
            // 
            this.tabExternalDataImport.Controls.Add(this.grpConfig);
            this.tabExternalDataImport.Controls.Add(this.grdImportConfig);
            this.tabExternalDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabExternalDataImport.Name = "tabExternalDataImport";
            this.tabExternalDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternalDataImport.Size = new System.Drawing.Size(564, 391);
            this.tabExternalDataImport.TabIndex = 0;
            this.tabExternalDataImport.Text = "External data";
            this.tabExternalDataImport.UseVisualStyleBackColor = true;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.prbDataImport);
            this.grpConfig.Controls.Add(this.btnConfigureConnection);
            this.grpConfig.Controls.Add(this.lblConnecStr);
            this.grpConfig.Controls.Add(this.txtConnectStr);
            this.grpConfig.Controls.Add(this.btnImport);
            this.grpConfig.Location = new System.Drawing.Point(3, 6);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(568, 164);
            this.grpConfig.TabIndex = 12;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Configure import properties";
            // 
            // prbDataImport
            // 
            this.prbDataImport.Location = new System.Drawing.Point(305, 112);
            this.prbDataImport.Name = "prbDataImport";
            this.prbDataImport.Size = new System.Drawing.Size(246, 24);
            this.prbDataImport.TabIndex = 16;
            // 
            // btnConfigureConnection
            // 
            this.btnConfigureConnection.Location = new System.Drawing.Point(472, 52);
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
            this.lblConnecStr.Location = new System.Drawing.Point(18, 22);
            this.lblConnecStr.Name = "lblConnecStr";
            this.lblConnecStr.Size = new System.Drawing.Size(89, 13);
            this.lblConnecStr.TabIndex = 14;
            this.lblConnecStr.Text = "Connection string";
            // 
            // txtConnectStr
            // 
            this.txtConnectStr.Location = new System.Drawing.Point(21, 38);
            this.txtConnectStr.Multiline = true;
            this.txtConnectStr.Name = "txtConnectStr";
            this.txtConnectStr.Size = new System.Drawing.Size(444, 52);
            this.txtConnectStr.TabIndex = 13;
            this.txtConnectStr.TextChanged += new System.EventHandler(this.txtConnectStr_TextChanged);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(21, 107);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(243, 35);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // grdImportConfig
            // 
            this.grdImportConfig.Location = new System.Drawing.Point(-2, 176);
            this.grdImportConfig.Name = "grdImportConfig";
            this.grdImportConfig.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.grdImportConfig.Size = new System.Drawing.Size(568, 225);
            this.grdImportConfig.TabIndex = 11;
            // 
            // tabMapsImport
            // 
            this.tabMapsImport.Controls.Add(this.groupBox1);
            this.tabMapsImport.Location = new System.Drawing.Point(4, 22);
            this.tabMapsImport.Name = "tabMapsImport";
            this.tabMapsImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapsImport.Size = new System.Drawing.Size(463, 328);
            this.tabMapsImport.TabIndex = 1;
            this.tabMapsImport.Text = "Maps";
            this.tabMapsImport.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRssSource);
            this.groupBox1.Controls.Add(this.btnImportGeoRss);
            this.groupBox1.Controls.Add(this.btnSelectRssSource);
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 127);
            this.groupBox1.TabIndex = 16;
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
            // tabDataImport
            // 
            this.tabDataImport.Controls.Add(this.grpDataImport);
            this.tabDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabDataImport.Name = "tabDataImport";
            this.tabDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataImport.Size = new System.Drawing.Size(564, 391);
            this.tabDataImport.TabIndex = 2;
            this.tabDataImport.Text = "Data";
            this.tabDataImport.UseVisualStyleBackColor = true;
            // 
            // grpDataImport
            // 
            this.grpDataImport.Controls.Add(this.chkImportDataDepartments);
            this.grpDataImport.Controls.Add(this.chkImportDataCities);
            this.grpDataImport.Controls.Add(this.chkImportDataAddresses);
            this.grpDataImport.Controls.Add(this.chkImportDataTerritories);
            this.grpDataImport.Controls.Add(this.chkImportDataPublishers);
            this.grpDataImport.Controls.Add(this.chkImportDataTours);
            this.grpDataImport.Controls.Add(this.txtImportDataFile);
            this.grpDataImport.Controls.Add(this.btnImportData);
            this.grpDataImport.Controls.Add(this.btnImportDataSelectFile);
            this.grpDataImport.Location = new System.Drawing.Point(3, 19);
            this.grpDataImport.Name = "grpDataImport";
            this.grpDataImport.Size = new System.Drawing.Size(558, 206);
            this.grpDataImport.TabIndex = 17;
            this.grpDataImport.TabStop = false;
            this.grpDataImport.Text = "Import records";
            // 
            // chkImportDataDepartments
            // 
            this.chkImportDataDepartments.AutoSize = true;
            this.chkImportDataDepartments.Location = new System.Drawing.Point(143, 116);
            this.chkImportDataDepartments.Name = "chkImportDataDepartments";
            this.chkImportDataDepartments.Size = new System.Drawing.Size(86, 17);
            this.chkImportDataDepartments.TabIndex = 19;
            this.chkImportDataDepartments.Text = "Departments";
            this.chkImportDataDepartments.UseVisualStyleBackColor = true;
            // 
            // chkImportDataCities
            // 
            this.chkImportDataCities.AutoSize = true;
            this.chkImportDataCities.Location = new System.Drawing.Point(143, 93);
            this.chkImportDataCities.Name = "chkImportDataCities";
            this.chkImportDataCities.Size = new System.Drawing.Size(51, 17);
            this.chkImportDataCities.TabIndex = 18;
            this.chkImportDataCities.Text = "Cities";
            this.chkImportDataCities.UseVisualStyleBackColor = true;
            // 
            // chkImportDataAddresses
            // 
            this.chkImportDataAddresses.AutoSize = true;
            this.chkImportDataAddresses.Location = new System.Drawing.Point(143, 70);
            this.chkImportDataAddresses.Name = "chkImportDataAddresses";
            this.chkImportDataAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkImportDataAddresses.TabIndex = 17;
            this.chkImportDataAddresses.Text = "Addresses";
            this.chkImportDataAddresses.UseVisualStyleBackColor = true;
            // 
            // chkImportDataTerritories
            // 
            this.chkImportDataTerritories.AutoSize = true;
            this.chkImportDataTerritories.Location = new System.Drawing.Point(269, 93);
            this.chkImportDataTerritories.Name = "chkImportDataTerritories";
            this.chkImportDataTerritories.Size = new System.Drawing.Size(72, 17);
            this.chkImportDataTerritories.TabIndex = 16;
            this.chkImportDataTerritories.Text = "Territories";
            this.chkImportDataTerritories.UseVisualStyleBackColor = true;
            // 
            // chkImportDataPublishers
            // 
            this.chkImportDataPublishers.AutoSize = true;
            this.chkImportDataPublishers.Location = new System.Drawing.Point(269, 116);
            this.chkImportDataPublishers.Name = "chkImportDataPublishers";
            this.chkImportDataPublishers.Size = new System.Drawing.Size(74, 17);
            this.chkImportDataPublishers.TabIndex = 15;
            this.chkImportDataPublishers.Text = "Publishers";
            this.chkImportDataPublishers.UseVisualStyleBackColor = true;
            // 
            // chkImportDataTours
            // 
            this.chkImportDataTours.AutoSize = true;
            this.chkImportDataTours.Location = new System.Drawing.Point(269, 70);
            this.chkImportDataTours.Name = "chkImportDataTours";
            this.chkImportDataTours.Size = new System.Drawing.Size(53, 17);
            this.chkImportDataTours.TabIndex = 14;
            this.chkImportDataTours.Text = "Tours";
            this.chkImportDataTours.UseVisualStyleBackColor = true;
            // 
            // txtImportDataFile
            // 
            this.txtImportDataFile.Location = new System.Drawing.Point(15, 30);
            this.txtImportDataFile.Name = "txtImportDataFile";
            this.txtImportDataFile.ReadOnly = true;
            this.txtImportDataFile.Size = new System.Drawing.Size(379, 20);
            this.txtImportDataFile.TabIndex = 12;
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(108, 149);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(344, 35);
            this.btnImportData.TabIndex = 13;
            this.btnImportData.Text = "Import";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnImportDataSelectFile
            // 
            this.btnImportDataSelectFile.Location = new System.Drawing.Point(420, 27);
            this.btnImportDataSelectFile.Name = "btnImportDataSelectFile";
            this.btnImportDataSelectFile.Size = new System.Drawing.Size(118, 24);
            this.btnImportDataSelectFile.TabIndex = 11;
            this.btnImportDataSelectFile.Text = "Select";
            this.btnImportDataSelectFile.UseVisualStyleBackColor = true;
            this.btnImportDataSelectFile.Click += new System.EventHandler(this.btnImportDataSelectFile_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabImport);
            this.tabMain.Controls.Add(this.tabExport);
            this.tabMain.Location = new System.Drawing.Point(8, 11);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(586, 449);
            this.tabMain.TabIndex = 0;
            // 
            // tabExport
            // 
            this.tabExport.Controls.Add(this.tabExportPanel);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExport.Size = new System.Drawing.Size(578, 423);
            this.tabExport.TabIndex = 3;
            this.tabExport.Text = "Data export";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // tabExportPanel
            // 
            this.tabExportPanel.Controls.Add(this.tabExternalDataExport);
            this.tabExportPanel.Controls.Add(this.tabMapsExport);
            this.tabExportPanel.Controls.Add(this.tabDataExport);
            this.tabExportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabExportPanel.Location = new System.Drawing.Point(3, 3);
            this.tabExportPanel.Name = "tabExportPanel";
            this.tabExportPanel.SelectedIndex = 0;
            this.tabExportPanel.Size = new System.Drawing.Size(572, 417);
            this.tabExportPanel.TabIndex = 0;
            // 
            // tabExternalDataExport
            // 
            this.tabExternalDataExport.Controls.Add(this.grpExport);
            this.tabExternalDataExport.Location = new System.Drawing.Point(4, 22);
            this.tabExternalDataExport.Name = "tabExternalDataExport";
            this.tabExternalDataExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExternalDataExport.Size = new System.Drawing.Size(564, 391);
            this.tabExternalDataExport.TabIndex = 0;
            this.tabExternalDataExport.Text = "External data";
            this.tabExternalDataExport.UseVisualStyleBackColor = true;
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
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Controls.Add(this.btnSaveToExcel);
            this.grpExport.Location = new System.Drawing.Point(6, 22);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(562, 383);
            this.grpExport.TabIndex = 17;
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
            this.chkListDepartments.CheckOnClick = true;
            this.chkListDepartments.Enabled = false;
            this.chkListDepartments.FormattingEnabled = true;
            this.chkListDepartments.Location = new System.Drawing.Point(420, 193);
            this.chkListDepartments.Name = "chkListDepartments";
            this.chkListDepartments.Size = new System.Drawing.Size(127, 169);
            this.chkListDepartments.TabIndex = 17;
            // 
            // chkListTerritories
            // 
            this.chkListTerritories.CheckOnClick = true;
            this.chkListTerritories.Enabled = false;
            this.chkListTerritories.FormattingEnabled = true;
            this.chkListTerritories.Location = new System.Drawing.Point(285, 193);
            this.chkListTerritories.Name = "chkListTerritories";
            this.chkListTerritories.Size = new System.Drawing.Size(127, 169);
            this.chkListTerritories.TabIndex = 16;
            // 
            // chkListCities
            // 
            this.chkListCities.CheckOnClick = true;
            this.chkListCities.Enabled = false;
            this.chkListCities.FormattingEnabled = true;
            this.chkListCities.Location = new System.Drawing.Point(150, 193);
            this.chkListCities.Name = "chkListCities";
            this.chkListCities.Size = new System.Drawing.Size(127, 169);
            this.chkListCities.TabIndex = 15;
            // 
            // chkListAddresses
            // 
            this.chkListAddresses.CheckOnClick = true;
            this.chkListAddresses.Enabled = false;
            this.chkListAddresses.FormattingEnabled = true;
            this.chkListAddresses.Location = new System.Drawing.Point(15, 193);
            this.chkListAddresses.Name = "chkListAddresses";
            this.chkListAddresses.Size = new System.Drawing.Size(127, 169);
            this.chkListAddresses.TabIndex = 14;
            // 
            // txtExcelDestination
            // 
            this.txtExcelDestination.Location = new System.Drawing.Point(15, 30);
            this.txtExcelDestination.Name = "txtExcelDestination";
            this.txtExcelDestination.ReadOnly = true;
            this.txtExcelDestination.Size = new System.Drawing.Size(379, 20);
            this.txtExcelDestination.TabIndex = 12;
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
            // tabMapsExport
            // 
            this.tabMapsExport.Controls.Add(this.grpGMapsExport);
            this.tabMapsExport.Location = new System.Drawing.Point(4, 22);
            this.tabMapsExport.Name = "tabMapsExport";
            this.tabMapsExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapsExport.Size = new System.Drawing.Size(564, 391);
            this.tabMapsExport.TabIndex = 1;
            this.tabMapsExport.Text = "Maps";
            this.tabMapsExport.UseVisualStyleBackColor = true;
            // 
            // grpGMapsExport
            // 
            this.grpGMapsExport.Controls.Add(this.txtXmlDestination);
            this.grpGMapsExport.Controls.Add(this.btnExportToGmaps);
            this.grpGMapsExport.Controls.Add(this.btnSaveToGMaps);
            this.grpGMapsExport.Location = new System.Drawing.Point(3, 15);
            this.grpGMapsExport.Name = "grpGMapsExport";
            this.grpGMapsExport.Size = new System.Drawing.Size(566, 127);
            this.grpGMapsExport.TabIndex = 18;
            this.grpGMapsExport.TabStop = false;
            this.grpGMapsExport.Text = "Export to Gmaps";
            // 
            // txtXmlDestination
            // 
            this.txtXmlDestination.Location = new System.Drawing.Point(15, 30);
            this.txtXmlDestination.Name = "txtXmlDestination";
            this.txtXmlDestination.ReadOnly = true;
            this.txtXmlDestination.Size = new System.Drawing.Size(379, 20);
            this.txtXmlDestination.TabIndex = 12;
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
            // ofdSourceFile
            // 
            this.ofdSourceFile.InitialDirectory = "C:\\\\";
            // 
            // sfdGMaps
            // 
            this.sfdGMaps.Filter = "xml files (*.xml)|*.xml";
            this.sfdGMaps.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdGMaps_FileOk);
            // 
            // tabDataExport
            // 
            this.tabDataExport.Controls.Add(this.grpDataExport);
            this.tabDataExport.Location = new System.Drawing.Point(4, 22);
            this.tabDataExport.Name = "tabDataExport";
            this.tabDataExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataExport.Size = new System.Drawing.Size(564, 391);
            this.tabDataExport.TabIndex = 2;
            this.tabDataExport.Text = "Export data";
            this.tabDataExport.UseVisualStyleBackColor = true;
            // 
            // grpDataExport
            // 
            this.grpDataExport.Controls.Add(this.chkDataExportDepartments);
            this.grpDataExport.Controls.Add(this.chkDataExportCities);
            this.grpDataExport.Controls.Add(this.chkDataExportAddresses);
            this.grpDataExport.Controls.Add(this.chkDataExportTerritories);
            this.grpDataExport.Controls.Add(this.chkDataExportPublishers);
            this.grpDataExport.Controls.Add(this.chkDataExportTours);
            this.grpDataExport.Controls.Add(this.txtDataExportFile);
            this.grpDataExport.Controls.Add(this.btnExportData);
            this.grpDataExport.Controls.Add(this.btnDataExportSave);
            this.grpDataExport.Location = new System.Drawing.Point(3, 17);
            this.grpDataExport.Name = "grpDataExport";
            this.grpDataExport.Size = new System.Drawing.Size(558, 206);
            this.grpDataExport.TabIndex = 18;
            this.grpDataExport.TabStop = false;
            this.grpDataExport.Text = "Export records";
            // 
            // chkDataExportDepartments
            // 
            this.chkDataExportDepartments.AutoSize = true;
            this.chkDataExportDepartments.Location = new System.Drawing.Point(143, 116);
            this.chkDataExportDepartments.Name = "chkDataExportDepartments";
            this.chkDataExportDepartments.Size = new System.Drawing.Size(86, 17);
            this.chkDataExportDepartments.TabIndex = 19;
            this.chkDataExportDepartments.Text = "Departments";
            this.chkDataExportDepartments.UseVisualStyleBackColor = true;
            // 
            // chkDataExportCities
            // 
            this.chkDataExportCities.AutoSize = true;
            this.chkDataExportCities.Location = new System.Drawing.Point(143, 93);
            this.chkDataExportCities.Name = "chkDataExportCities";
            this.chkDataExportCities.Size = new System.Drawing.Size(51, 17);
            this.chkDataExportCities.TabIndex = 18;
            this.chkDataExportCities.Text = "Cities";
            this.chkDataExportCities.UseVisualStyleBackColor = true;
            // 
            // chkDataExportAddresses
            // 
            this.chkDataExportAddresses.AutoSize = true;
            this.chkDataExportAddresses.Location = new System.Drawing.Point(143, 70);
            this.chkDataExportAddresses.Name = "chkDataExportAddresses";
            this.chkDataExportAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkDataExportAddresses.TabIndex = 17;
            this.chkDataExportAddresses.Text = "Addresses";
            this.chkDataExportAddresses.UseVisualStyleBackColor = true;
            // 
            // chkDataExportTerritories
            // 
            this.chkDataExportTerritories.AutoSize = true;
            this.chkDataExportTerritories.Location = new System.Drawing.Point(269, 93);
            this.chkDataExportTerritories.Name = "chkDataExportTerritories";
            this.chkDataExportTerritories.Size = new System.Drawing.Size(72, 17);
            this.chkDataExportTerritories.TabIndex = 16;
            this.chkDataExportTerritories.Text = "Territories";
            this.chkDataExportTerritories.UseVisualStyleBackColor = true;
            // 
            // chkDataExportPublishers
            // 
            this.chkDataExportPublishers.AutoSize = true;
            this.chkDataExportPublishers.Location = new System.Drawing.Point(269, 116);
            this.chkDataExportPublishers.Name = "chkDataExportPublishers";
            this.chkDataExportPublishers.Size = new System.Drawing.Size(74, 17);
            this.chkDataExportPublishers.TabIndex = 15;
            this.chkDataExportPublishers.Text = "Publishers";
            this.chkDataExportPublishers.UseVisualStyleBackColor = true;
            // 
            // chkDataExportTours
            // 
            this.chkDataExportTours.AutoSize = true;
            this.chkDataExportTours.Location = new System.Drawing.Point(269, 70);
            this.chkDataExportTours.Name = "chkDataExportTours";
            this.chkDataExportTours.Size = new System.Drawing.Size(53, 17);
            this.chkDataExportTours.TabIndex = 14;
            this.chkDataExportTours.Text = "Tours";
            this.chkDataExportTours.UseVisualStyleBackColor = true;
            // 
            // txtDataExportFile
            // 
            this.txtDataExportFile.Location = new System.Drawing.Point(15, 30);
            this.txtDataExportFile.Name = "txtDataExportFile";
            this.txtDataExportFile.ReadOnly = true;
            this.txtDataExportFile.Size = new System.Drawing.Size(379, 20);
            this.txtDataExportFile.TabIndex = 12;
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(108, 149);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(344, 35);
            this.btnExportData.TabIndex = 13;
            this.btnExportData.Text = "Export";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // btnDataExportSave
            // 
            this.btnDataExportSave.Location = new System.Drawing.Point(420, 27);
            this.btnDataExportSave.Name = "btnDataExportSave";
            this.btnDataExportSave.Size = new System.Drawing.Size(118, 24);
            this.btnDataExportSave.TabIndex = 11;
            this.btnDataExportSave.Text = "Save";
            this.btnDataExportSave.UseVisualStyleBackColor = true;
            this.btnDataExportSave.Click += new System.EventHandler(this.btnDataExportSave_Click);
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
            this.tabImport.ResumeLayout(false);
            this.tabImportPanel.ResumeLayout(false);
            this.tabExternalDataImport.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.tabMapsImport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDataImport.ResumeLayout(false);
            this.grpDataImport.ResumeLayout(false);
            this.grpDataImport.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabExport.ResumeLayout(false);
            this.tabExportPanel.ResumeLayout(false);
            this.tabExternalDataExport.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.tabMapsExport.ResumeLayout(false);
            this.grpGMapsExport.ResumeLayout(false);
            this.grpGMapsExport.PerformLayout();
            this.tabDataExport.ResumeLayout(false);
            this.grpDataExport.ResumeLayout(false);
            this.grpDataExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog odfRssSource;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.OpenFileDialog ofdSourceFile;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.SaveFileDialog sfdDestinationFile;
        private System.Windows.Forms.SaveFileDialog sfdGMaps;
        private System.Windows.Forms.TabControl tabExportPanel;
        private System.Windows.Forms.TabPage tabExternalDataExport;
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.TabPage tabMapsExport;
        private System.Windows.Forms.GroupBox grpGMapsExport;
        private System.Windows.Forms.TextBox txtXmlDestination;
        private System.Windows.Forms.Button btnExportToGmaps;
        private System.Windows.Forms.Button btnSaveToGMaps;
        private System.Windows.Forms.TabControl tabImportPanel;
        private System.Windows.Forms.TabPage tabExternalDataImport;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.ProgressBar prbDataImport;
        private System.Windows.Forms.Button btnConfigureConnection;
        private System.Windows.Forms.Label lblConnecStr;
        private System.Windows.Forms.TextBox txtConnectStr;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PropertyGrid grdImportConfig;
        private System.Windows.Forms.TabPage tabMapsImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRssSource;
        private System.Windows.Forms.Button btnImportGeoRss;
        private System.Windows.Forms.Button btnSelectRssSource;
        private System.Windows.Forms.TabPage tabDataImport;
        private System.Windows.Forms.GroupBox grpDataImport;
        private System.Windows.Forms.TextBox txtImportDataFile;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Button btnImportDataSelectFile;
        private System.Windows.Forms.CheckBox chkImportDataDepartments;
        private System.Windows.Forms.CheckBox chkImportDataCities;
        private System.Windows.Forms.CheckBox chkImportDataAddresses;
        private System.Windows.Forms.CheckBox chkImportDataTerritories;
        private System.Windows.Forms.CheckBox chkImportDataPublishers;
        private System.Windows.Forms.CheckBox chkImportDataTours;
        private System.Windows.Forms.TabPage tabDataExport;
        private System.Windows.Forms.GroupBox grpDataExport;
        private System.Windows.Forms.CheckBox chkDataExportDepartments;
        private System.Windows.Forms.CheckBox chkDataExportCities;
        private System.Windows.Forms.CheckBox chkDataExportAddresses;
        private System.Windows.Forms.CheckBox chkDataExportTerritories;
        private System.Windows.Forms.CheckBox chkDataExportPublishers;
        private System.Windows.Forms.CheckBox chkDataExportTours;
        private System.Windows.Forms.TextBox txtDataExportFile;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Button btnDataExportSave;
    }
}