namespace TerritoriesToGoogleMaps
{
    partial class frmToGoogleMaps
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
            this.ofdExcelSource = new System.Windows.Forms.OpenFileDialog();
            this.grpExcelToXml = new System.Windows.Forms.GroupBox();
            this.txtXmlDestiny = new System.Windows.Forms.TextBox();
            this.btnSelectDestiny = new System.Windows.Forms.Button();
            this.btnConvertToXml = new System.Windows.Forms.Button();
            this.txtExcelSource = new System.Windows.Forms.TextBox();
            this.btnSelectExcelSource = new System.Windows.Forms.Button();
            this.sfdXmlDestiny = new System.Windows.Forms.SaveFileDialog();
            this.grpGoogleMapsToExcel = new System.Windows.Forms.GroupBox();
            this.txtXlsSource = new System.Windows.Forms.TextBox();
            this.btnSelectXlsSource = new System.Windows.Forms.Button();
            this.btnUpdateXls = new System.Windows.Forms.Button();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.odfRssSource = new System.Windows.Forms.OpenFileDialog();
            this.ofdXlsSource = new System.Windows.Forms.OpenFileDialog();
            this.lblRssSource = new System.Windows.Forms.Label();
            this.lblXlsSource = new System.Windows.Forms.Label();
            this.grpExcelToXml.SuspendLayout();
            this.grpGoogleMapsToExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdExcelSource
            // 
            this.ofdExcelSource.Filter = "excel files (*.xls)|*.xls";
            this.ofdExcelSource.InitialDirectory = "C:\\\\";
            this.ofdExcelSource.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdTerritoriesSheet_FileOk);
            // 
            // grpExcelToXml
            // 
            this.grpExcelToXml.Controls.Add(this.txtXmlDestiny);
            this.grpExcelToXml.Controls.Add(this.btnSelectDestiny);
            this.grpExcelToXml.Controls.Add(this.btnConvertToXml);
            this.grpExcelToXml.Controls.Add(this.txtExcelSource);
            this.grpExcelToXml.Controls.Add(this.btnSelectExcelSource);
            this.grpExcelToXml.Location = new System.Drawing.Point(12, 12);
            this.grpExcelToXml.Name = "grpExcelToXml";
            this.grpExcelToXml.Size = new System.Drawing.Size(430, 170);
            this.grpExcelToXml.TabIndex = 0;
            this.grpExcelToXml.TabStop = false;
            this.grpExcelToXml.Text = "Excel to XML";
            // 
            // txtXmlDestiny
            // 
            this.txtXmlDestiny.Location = new System.Drawing.Point(6, 79);
            this.txtXmlDestiny.Name = "txtXmlDestiny";
            this.txtXmlDestiny.ReadOnly = true;
            this.txtXmlDestiny.Size = new System.Drawing.Size(303, 20);
            this.txtXmlDestiny.TabIndex = 4;
            // 
            // btnSelectDestiny
            // 
            this.btnSelectDestiny.Location = new System.Drawing.Point(325, 76);
            this.btnSelectDestiny.Name = "btnSelectDestiny";
            this.btnSelectDestiny.Size = new System.Drawing.Size(91, 24);
            this.btnSelectDestiny.TabIndex = 3;
            this.btnSelectDestiny.Text = "Select destiny";
            this.btnSelectDestiny.UseVisualStyleBackColor = true;
            this.btnSelectDestiny.Click += new System.EventHandler(this.btnSelectDestiny_Click);
            // 
            // btnConvertToXml
            // 
            this.btnConvertToXml.Location = new System.Drawing.Point(80, 115);
            this.btnConvertToXml.Name = "btnConvertToXml";
            this.btnConvertToXml.Size = new System.Drawing.Size(270, 35);
            this.btnConvertToXml.TabIndex = 2;
            this.btnConvertToXml.Text = "Convert to XML";
            this.btnConvertToXml.UseVisualStyleBackColor = true;
            this.btnConvertToXml.Click += new System.EventHandler(this.btnConvertToXml_Click);
            // 
            // txtExcelSource
            // 
            this.txtExcelSource.Location = new System.Drawing.Point(6, 38);
            this.txtExcelSource.Name = "txtExcelSource";
            this.txtExcelSource.ReadOnly = true;
            this.txtExcelSource.Size = new System.Drawing.Size(303, 20);
            this.txtExcelSource.TabIndex = 1;
            // 
            // btnSelectExcelSource
            // 
            this.btnSelectExcelSource.Location = new System.Drawing.Point(325, 35);
            this.btnSelectExcelSource.Name = "btnSelectExcelSource";
            this.btnSelectExcelSource.Size = new System.Drawing.Size(91, 24);
            this.btnSelectExcelSource.TabIndex = 0;
            this.btnSelectExcelSource.Text = "Select source";
            this.btnSelectExcelSource.UseVisualStyleBackColor = true;
            this.btnSelectExcelSource.Click += new System.EventHandler(this.btnSelectExcelSource_Click);
            // 
            // sfdXmlDestiny
            // 
            this.sfdXmlDestiny.Filter = "xml files (*.xml)|*.xml";
            this.sfdXmlDestiny.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdXml_FileOk);
            // 
            // grpGoogleMapsToExcel
            // 
            this.grpGoogleMapsToExcel.Controls.Add(this.lblXlsSource);
            this.grpGoogleMapsToExcel.Controls.Add(this.lblRssSource);
            this.grpGoogleMapsToExcel.Controls.Add(this.txtXlsSource);
            this.grpGoogleMapsToExcel.Controls.Add(this.btnSelectXlsSource);
            this.grpGoogleMapsToExcel.Controls.Add(this.btnUpdateXls);
            this.grpGoogleMapsToExcel.Controls.Add(this.txtRssSource);
            this.grpGoogleMapsToExcel.Controls.Add(this.btnSelectRssSource);
            this.grpGoogleMapsToExcel.Location = new System.Drawing.Point(12, 191);
            this.grpGoogleMapsToExcel.Name = "grpGoogleMapsToExcel";
            this.grpGoogleMapsToExcel.Size = new System.Drawing.Size(517, 214);
            this.grpGoogleMapsToExcel.TabIndex = 1;
            this.grpGoogleMapsToExcel.TabStop = false;
            this.grpGoogleMapsToExcel.Text = "Google Maps to Excel";
            this.grpGoogleMapsToExcel.Enter += new System.EventHandler(this.grpGoogleMapsToExcel_Enter);
            // 
            // txtXlsSource
            // 
            this.txtXlsSource.Location = new System.Drawing.Point(9, 88);
            this.txtXlsSource.Name = "txtXlsSource";
            this.txtXlsSource.ReadOnly = true;
            this.txtXlsSource.Size = new System.Drawing.Size(369, 20);
            this.txtXlsSource.TabIndex = 9;
            // 
            // btnSelectXlsSource
            // 
            this.btnSelectXlsSource.Location = new System.Drawing.Point(384, 85);
            this.btnSelectXlsSource.Name = "btnSelectXlsSource";
            this.btnSelectXlsSource.Size = new System.Drawing.Size(118, 24);
            this.btnSelectXlsSource.TabIndex = 8;
            this.btnSelectXlsSource.Text = "Open";
            this.btnSelectXlsSource.UseVisualStyleBackColor = true;
            this.btnSelectXlsSource.Click += new System.EventHandler(this.btnSelectXlsSource_Click);
            // 
            // btnUpdateXls
            // 
            this.btnUpdateXls.Location = new System.Drawing.Point(80, 163);
            this.btnUpdateXls.Name = "btnUpdateXls";
            this.btnUpdateXls.Size = new System.Drawing.Size(270, 35);
            this.btnUpdateXls.TabIndex = 7;
            this.btnUpdateXls.Text = "Update Excel File";
            this.btnUpdateXls.UseVisualStyleBackColor = true;
            this.btnUpdateXls.Click += new System.EventHandler(this.btnUpdateXls_Click);
            // 
            // txtRssSource
            // 
            this.txtRssSource.Location = new System.Drawing.Point(9, 48);
            this.txtRssSource.Name = "txtRssSource";
            this.txtRssSource.ReadOnly = true;
            this.txtRssSource.Size = new System.Drawing.Size(369, 20);
            this.txtRssSource.TabIndex = 6;
            // 
            // btnSelectRssSource
            // 
            this.btnSelectRssSource.Location = new System.Drawing.Point(384, 45);
            this.btnSelectRssSource.Name = "btnSelectRssSource";
            this.btnSelectRssSource.Size = new System.Drawing.Size(118, 24);
            this.btnSelectRssSource.TabIndex = 5;
            this.btnSelectRssSource.Text = "Open";
            this.btnSelectRssSource.UseVisualStyleBackColor = true;
            this.btnSelectRssSource.Click += new System.EventHandler(this.btnSelectRssSource_Click);
            // 
            // odfRssSource
            // 
            this.odfRssSource.Filter = "xml files (*.xml)|*.xml";
            this.odfRssSource.InitialDirectory = "C:\\\\";
            this.odfRssSource.FileOk += new System.ComponentModel.CancelEventHandler(this.odfGMSource_FileOk);
            // 
            // ofdXlsSource
            // 
            this.ofdXlsSource.Filter = "excel files (*.xls)|*.xls";
            this.ofdXlsSource.InitialDirectory = "C:\\\\";
            this.ofdXlsSource.FileOk += new System.ComponentModel.CancelEventHandler(this.opfXlsDestiny_FileOk);
            // 
            // lblRssSource
            // 
            this.lblRssSource.AutoSize = true;
            this.lblRssSource.Location = new System.Drawing.Point(6, 32);
            this.lblRssSource.Name = "lblRssSource";
            this.lblRssSource.Size = new System.Drawing.Size(100, 13);
            this.lblRssSource.TabIndex = 10;
            this.lblRssSource.Text = "GeoRSS file source";
            // 
            // lblXlsSource
            // 
            this.lblXlsSource.AutoSize = true;
            this.lblXlsSource.Location = new System.Drawing.Point(6, 72);
            this.lblXlsSource.Name = "lblXlsSource";
            this.lblXlsSource.Size = new System.Drawing.Size(84, 13);
            this.lblXlsSource.TabIndex = 11;
            this.lblXlsSource.Text = "Excel file source";
            // 
            // frmToGoogleMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 498);
            this.Controls.Add(this.grpGoogleMapsToExcel);
            this.Controls.Add(this.grpExcelToXml);
            this.Name = "frmToGoogleMaps";
            this.Text = "Territories to GoogleMaps";
            this.Load += new System.EventHandler(this.frmToGoogleMaps_Load);
            this.grpExcelToXml.ResumeLayout(false);
            this.grpExcelToXml.PerformLayout();
            this.grpGoogleMapsToExcel.ResumeLayout(false);
            this.grpGoogleMapsToExcel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdExcelSource;
        private System.Windows.Forms.GroupBox grpExcelToXml;
        private System.Windows.Forms.TextBox txtExcelSource;
        private System.Windows.Forms.Button btnSelectExcelSource;
        private System.Windows.Forms.Button btnConvertToXml;
        private System.Windows.Forms.TextBox txtXmlDestiny;
        private System.Windows.Forms.Button btnSelectDestiny;
        private System.Windows.Forms.SaveFileDialog sfdXmlDestiny;
        private System.Windows.Forms.GroupBox grpGoogleMapsToExcel;
        private System.Windows.Forms.TextBox txtXlsSource;
        private System.Windows.Forms.Button btnSelectXlsSource;
        private System.Windows.Forms.Button btnUpdateXls;
        private System.Windows.Forms.TextBox txtRssSource;
        private System.Windows.Forms.Button btnSelectRssSource;
        private System.Windows.Forms.OpenFileDialog odfRssSource;
        private System.Windows.Forms.OpenFileDialog ofdXlsSource;
        private System.Windows.Forms.Label lblXlsSource;
        private System.Windows.Forms.Label lblRssSource;


    }
}

