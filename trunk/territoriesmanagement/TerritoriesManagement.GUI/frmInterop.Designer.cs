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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.ofdFileSource = new System.Windows.Forms.OpenFileDialog();
            this.sfdExcelDestination = new System.Windows.Forms.SaveFileDialog();
            this.sfdGMaps = new System.Windows.Forms.SaveFileDialog();
            this.tabExportPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabExportMaps = new System.Windows.Forms.TabPage();
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
            this.grpGMapsExport = new System.Windows.Forms.GroupBox();
            this.txtXmlDestination = new System.Windows.Forms.TextBox();
            this.btnExportToGmaps = new System.Windows.Forms.Button();
            this.btnSaveToGMaps = new System.Windows.Forms.Button();
            this.tabImportPanel = new System.Windows.Forms.TabControl();
            this.tabImportData = new System.Windows.Forms.TabPage();
            this.tabImportMaps = new System.Windows.Forms.TabPage();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.prbDataImport = new System.Windows.Forms.ProgressBar();
            this.btnConfigureConnection = new System.Windows.Forms.Button();
            this.lblConnecStr = new System.Windows.Forms.Label();
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.grdImportConfig = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnImportGeoRss = new System.Windows.Forms.Button();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.tabDataImport.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.tabExportPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabExportMaps.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.grpGMapsExport.SuspendLayout();
            this.tabImportPanel.SuspendLayout();
            this.tabImportData.SuspendLayout();
            this.tabImportMaps.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tabDataImport.Controls.Add(this.tabImportPanel);
            this.tabDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabDataImport.Name = "tabDataImport";
            this.tabDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataImport.Size = new System.Drawing.Size(578, 423);
            this.tabDataImport.TabIndex = 2;
            this.tabDataImport.Text = "Data import";
            this.tabDataImport.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDataImport);
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
            // ofdFileSource
            // 
            this.ofdFileSource.FileName = "openFileDialog1";
            this.ofdFileSource.InitialDirectory = "C:\\\\";
            // 
            // sfdExcelDestination
            // 
            this.sfdExcelDestination.Filter = "Excel files (*.xls)|*.xls";
            this.sfdExcelDestination.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdExcelDestiny_FileOk);
            // 
            // sfdGMaps
            // 
            this.sfdGMaps.Filter = "xml files (*.xml)|*.xml";
            this.sfdGMaps.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdGMaps_FileOk);
            // 
            // tabExportPanel
            // 
            this.tabExportPanel.Controls.Add(this.tabPage1);
            this.tabExportPanel.Controls.Add(this.tabExportMaps);
            this.tabExportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabExportPanel.Location = new System.Drawing.Point(3, 3);
            this.tabExportPanel.Name = "tabExportPanel";
            this.tabExportPanel.SelectedIndex = 0;
            this.tabExportPanel.Size = new System.Drawing.Size(572, 417);
            this.tabExportPanel.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpExport);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(564, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Excel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabExportMaps
            // 
            this.tabExportMaps.Controls.Add(this.grpGMapsExport);
            this.tabExportMaps.Location = new System.Drawing.Point(4, 22);
            this.tabExportMaps.Name = "tabExportMaps";
            this.tabExportMaps.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportMaps.Size = new System.Drawing.Size(564, 391);
            this.tabExportMaps.TabIndex = 1;
            this.tabExportMaps.Text = "Maps";
            this.tabExportMaps.UseVisualStyleBackColor = true;
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
            this.grpExport.Location = new System.Drawing.Point(-1, 4);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(566, 383);
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
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Location = new System.Drawing.Point(420, 27);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(118, 24);
            this.btnSaveToExcel.TabIndex = 11;
            this.btnSaveToExcel.Text = "Save";
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
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
            // 
            // btnSaveToGMaps
            // 
            this.btnSaveToGMaps.Location = new System.Drawing.Point(420, 27);
            this.btnSaveToGMaps.Name = "btnSaveToGMaps";
            this.btnSaveToGMaps.Size = new System.Drawing.Size(118, 24);
            this.btnSaveToGMaps.TabIndex = 11;
            this.btnSaveToGMaps.Text = "Save";
            this.btnSaveToGMaps.UseVisualStyleBackColor = true;
            // 
            // tabImportPanel
            // 
            this.tabImportPanel.Controls.Add(this.tabImportData);
            this.tabImportPanel.Controls.Add(this.tabImportMaps);
            this.tabImportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImportPanel.Location = new System.Drawing.Point(3, 3);
            this.tabImportPanel.Name = "tabImportPanel";
            this.tabImportPanel.SelectedIndex = 0;
            this.tabImportPanel.Size = new System.Drawing.Size(572, 417);
            this.tabImportPanel.TabIndex = 0;
            // 
            // tabImportData
            // 
            this.tabImportData.Controls.Add(this.grpConfig);
            this.tabImportData.Controls.Add(this.grdImportConfig);
            this.tabImportData.Location = new System.Drawing.Point(4, 22);
            this.tabImportData.Name = "tabImportData";
            this.tabImportData.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportData.Size = new System.Drawing.Size(564, 391);
            this.tabImportData.TabIndex = 0;
            this.tabImportData.Text = "Data";
            this.tabImportData.UseVisualStyleBackColor = true;
            // 
            // tabImportMaps
            // 
            this.tabImportMaps.Controls.Add(this.groupBox1);
            this.tabImportMaps.Location = new System.Drawing.Point(4, 22);
            this.tabImportMaps.Name = "tabImportMaps";
            this.tabImportMaps.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportMaps.Size = new System.Drawing.Size(564, 391);
            this.tabImportMaps.TabIndex = 1;
            this.tabImportMaps.Text = "Maps";
            this.tabImportMaps.UseVisualStyleBackColor = true;
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
            this.btnConfigureConnection.Location = new System.Drawing.Point(479, 53);
            this.btnConfigureConnection.Name = "btnConfigureConnection";
            this.btnConfigureConnection.Size = new System.Drawing.Size(83, 23);
            this.btnConfigureConnection.TabIndex = 15;
            this.btnConfigureConnection.Text = "Configure";
            this.btnConfigureConnection.UseVisualStyleBackColor = true;
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
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(21, 107);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(243, 35);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // grdImportConfig
            // 
            this.grdImportConfig.Location = new System.Drawing.Point(-2, 176);
            this.grdImportConfig.Name = "grdImportConfig";
            this.grdImportConfig.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.grdImportConfig.Size = new System.Drawing.Size(568, 225);
            this.grdImportConfig.TabIndex = 11;
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
            // 
            // btnSelectRssSource
            // 
            this.btnSelectRssSource.Location = new System.Drawing.Point(420, 27);
            this.btnSelectRssSource.Name = "btnSelectRssSource";
            this.btnSelectRssSource.Size = new System.Drawing.Size(118, 24);
            this.btnSelectRssSource.TabIndex = 11;
            this.btnSelectRssSource.Text = "Select";
            this.btnSelectRssSource.UseVisualStyleBackColor = true;
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
            this.tabDataImport.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabExport.ResumeLayout(false);
            this.tabExportPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabExportMaps.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.grpGMapsExport.ResumeLayout(false);
            this.grpGMapsExport.PerformLayout();
            this.tabImportPanel.ResumeLayout(false);
            this.tabImportData.ResumeLayout(false);
            this.tabImportMaps.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog odfRssSource;
        private System.Windows.Forms.TabPage tabDataImport;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.OpenFileDialog ofdFileSource;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.SaveFileDialog sfdExcelDestination;
        private System.Windows.Forms.SaveFileDialog sfdGMaps;
        private System.Windows.Forms.TabControl tabExportPanel;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.TabPage tabExportMaps;
        private System.Windows.Forms.GroupBox grpGMapsExport;
        private System.Windows.Forms.TextBox txtXmlDestination;
        private System.Windows.Forms.Button btnExportToGmaps;
        private System.Windows.Forms.Button btnSaveToGMaps;
        private System.Windows.Forms.TabControl tabImportPanel;
        private System.Windows.Forms.TabPage tabImportData;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.ProgressBar prbDataImport;
        private System.Windows.Forms.Button btnConfigureConnection;
        private System.Windows.Forms.Label lblConnecStr;
        private System.Windows.Forms.TextBox txtConnectStr;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PropertyGrid grdImportConfig;
        private System.Windows.Forms.TabPage tabImportMaps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRssSource;
        private System.Windows.Forms.Button btnImportGeoRss;
        private System.Windows.Forms.Button btnSelectRssSource;
    }
}