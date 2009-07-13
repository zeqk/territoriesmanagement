namespace Territories.GUI
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
            this.lblRssSource = new System.Windows.Forms.Label();
            this.btnUpdateXls = new System.Windows.Forms.Button();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.ofdFileSource = new System.Windows.Forms.OpenFileDialog();
            this.tabDataImport.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.tabProviders.SuspendLayout();
            this.tabMsExcel.SuspendLayout();
            this.tabGeoRss.SuspendLayout();
            this.tabPanel.SuspendLayout();
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
            this.tabDataImport.Size = new System.Drawing.Size(759, 590);
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
            this.grpConfig.Size = new System.Drawing.Size(750, 279);
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
            this.tabProviders.Size = new System.Drawing.Size(750, 196);
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
            this.tabMsExcel.Size = new System.Drawing.Size(742, 170);
            this.tabMsExcel.TabIndex = 0;
            this.tabMsExcel.Text = "MS Excel";
            this.tabMsExcel.UseVisualStyleBackColor = true;
            // 
            // btnSetConnectStr
            // 
            this.btnSetConnectStr.Location = new System.Drawing.Point(489, 77);
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
            this.btnSelectExcelFile.Location = new System.Drawing.Point(489, 24);
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
            this.txtConnectStr.Size = new System.Drawing.Size(424, 70);
            this.txtConnectStr.TabIndex = 1;
            this.txtConnectStr.TextChanged += new System.EventHandler(this.txtConnectStr_TextChanged);
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Enabled = false;
            this.txtExcelFile.Location = new System.Drawing.Point(32, 26);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(424, 20);
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
            this.btnImport.Location = new System.Drawing.Point(550, 40);
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
            this.grdImportConfig.Size = new System.Drawing.Size(753, 292);
            this.grdImportConfig.TabIndex = 1;
            this.grdImportConfig.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.grdImportConfig_PropertyValueChanged);
            // 
            // tabGeoRss
            // 
            this.tabGeoRss.Controls.Add(this.lblRssSource);
            this.tabGeoRss.Controls.Add(this.btnUpdateXls);
            this.tabGeoRss.Controls.Add(this.txtRssSource);
            this.tabGeoRss.Controls.Add(this.btnSelectRssSource);
            this.tabGeoRss.Location = new System.Drawing.Point(4, 22);
            this.tabGeoRss.Name = "tabGeoRss";
            this.tabGeoRss.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeoRss.Size = new System.Drawing.Size(759, 590);
            this.tabGeoRss.TabIndex = 0;
            this.tabGeoRss.Text = "GeoRSS import";
            this.tabGeoRss.UseVisualStyleBackColor = true;
            // 
            // lblRssSource
            // 
            this.lblRssSource.AutoSize = true;
            this.lblRssSource.Location = new System.Drawing.Point(12, 37);
            this.lblRssSource.Name = "lblRssSource";
            this.lblRssSource.Size = new System.Drawing.Size(100, 13);
            this.lblRssSource.TabIndex = 14;
            this.lblRssSource.Text = "GeoRSS file source";
            // 
            // btnUpdateXls
            // 
            this.btnUpdateXls.Location = new System.Drawing.Point(123, 96);
            this.btnUpdateXls.Name = "btnUpdateXls";
            this.btnUpdateXls.Size = new System.Drawing.Size(270, 35);
            this.btnUpdateXls.TabIndex = 13;
            this.btnUpdateXls.Text = "Update Excel File";
            this.btnUpdateXls.UseVisualStyleBackColor = true;
            this.btnUpdateXls.Click += new System.EventHandler(this.btnUpdateXls_Click);
            // 
            // txtRssSource
            // 
            this.txtRssSource.Location = new System.Drawing.Point(15, 53);
            this.txtRssSource.Name = "txtRssSource";
            this.txtRssSource.ReadOnly = true;
            this.txtRssSource.Size = new System.Drawing.Size(417, 20);
            this.txtRssSource.TabIndex = 12;
            // 
            // btnSelectRssSource
            // 
            this.btnSelectRssSource.Location = new System.Drawing.Point(438, 50);
            this.btnSelectRssSource.Name = "btnSelectRssSource";
            this.btnSelectRssSource.Size = new System.Drawing.Size(118, 24);
            this.btnSelectRssSource.TabIndex = 11;
            this.btnSelectRssSource.Text = "Open";
            this.btnSelectRssSource.UseVisualStyleBackColor = true;
            this.btnSelectRssSource.Click += new System.EventHandler(this.btnSelectRssSource_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabDataImport);
            this.tabPanel.Controls.Add(this.tabGeoRss);
            this.tabPanel.Location = new System.Drawing.Point(8, 11);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(767, 616);
            this.tabPanel.TabIndex = 0;
            // 
            // ofdFileSource
            // 
            this.ofdFileSource.FileName = "openFileDialog1";
            this.ofdFileSource.InitialDirectory = "C:\\\\";
            this.ofdFileSource.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdFileSource_FileOk);
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 632);
            this.Controls.Add(this.tabPanel);
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
            this.tabGeoRss.PerformLayout();
            this.tabPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblRssSource;
        private System.Windows.Forms.Button btnUpdateXls;
        private System.Windows.Forms.TextBox txtRssSource;
        private System.Windows.Forms.Button btnSelectRssSource;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.Button btnSetConnectStr;
        private System.Windows.Forms.OpenFileDialog ofdFileSource;
    }
}