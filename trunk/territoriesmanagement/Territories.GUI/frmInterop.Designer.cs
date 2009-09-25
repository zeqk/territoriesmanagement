﻿namespace Territories.GUI
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
            this.btnImportGeoRss = new System.Windows.Forms.Button();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.tabExport = new System.Windows.Forms.TabControl();
            this.ofdFileSource = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.txtExcelDestiny = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSelectExcel = new System.Windows.Forms.Button();
            this.sfdExcelDestiny = new System.Windows.Forms.SaveFileDialog();
            this.tabDataImport.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.tabProviders.SuspendLayout();
            this.tabMsExcel.SuspendLayout();
            this.tabGeoRss.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tabOther.Size = new System.Drawing.Size(742, 170);
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
            this.tabGeoRss.Controls.Add(this.groupBox1);
            this.tabGeoRss.Location = new System.Drawing.Point(4, 22);
            this.tabGeoRss.Name = "tabGeoRss";
            this.tabGeoRss.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeoRss.Size = new System.Drawing.Size(578, 590);
            this.tabGeoRss.TabIndex = 0;
            this.tabGeoRss.Text = "GeoRSS import";
            this.tabGeoRss.UseVisualStyleBackColor = true;
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
            // txtRssSource
            // 
            this.txtRssSource.Location = new System.Drawing.Point(15, 30);
            this.txtRssSource.Name = "txtRssSource";
            this.txtRssSource.ReadOnly = true;
            this.txtRssSource.Size = new System.Drawing.Size(379, 20);
            this.txtRssSource.TabIndex = 12;
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
            // tabExport
            // 
            this.tabExport.Controls.Add(this.tabDataImport);
            this.tabExport.Controls.Add(this.tabGeoRss);
            this.tabExport.Controls.Add(this.tabPage1);
            this.tabExport.Location = new System.Drawing.Point(8, 11);
            this.tabExport.Name = "tabExport";
            this.tabExport.SelectedIndex = 0;
            this.tabExport.Size = new System.Drawing.Size(586, 616);
            this.tabExport.TabIndex = 0;
            // 
            // ofdFileSource
            // 
            this.ofdFileSource.FileName = "openFileDialog1";
            this.ofdFileSource.InitialDirectory = "C:\\\\";
            this.ofdFileSource.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdFileSource_FileOk);
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
            // grpExport
            // 
            this.grpExport.Controls.Add(this.txtExcelDestiny);
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Controls.Add(this.btnSelectExcel);
            this.grpExport.Location = new System.Drawing.Point(6, 25);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(566, 127);
            this.grpExport.TabIndex = 16;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "Export to excel file";
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
            // 
            // btnSelectExcel
            // 
            this.btnSelectExcel.Location = new System.Drawing.Point(420, 27);
            this.btnSelectExcel.Name = "btnSelectExcel";
            this.btnSelectExcel.Size = new System.Drawing.Size(118, 24);
            this.btnSelectExcel.TabIndex = 11;
            this.btnSelectExcel.Text = "Select";
            this.btnSelectExcel.UseVisualStyleBackColor = true;
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 632);
            this.Controls.Add(this.tabExport);
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
            this.tabExport.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabExport;
        private System.Windows.Forms.Button btnSetConnectStr;
        private System.Windows.Forms.OpenFileDialog ofdFileSource;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.TextBox txtExcelDestiny;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSelectExcel;
        private System.Windows.Forms.SaveFileDialog sfdExcelDestiny;
    }
}