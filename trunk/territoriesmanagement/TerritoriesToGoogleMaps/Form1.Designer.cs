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
            this.grpMiddlePoint = new System.Windows.Forms.GroupBox();
            this.txtXmlSource = new System.Windows.Forms.TextBox();
            this.btnSelectXmlSource = new System.Windows.Forms.Button();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.btnCalculeMiddlePoint = new System.Windows.Forms.Button();
            this.ofdXmlSource = new System.Windows.Forms.OpenFileDialog();
            this.grpExcelToXml.SuspendLayout();
            this.grpMiddlePoint.SuspendLayout();
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
            // grpMiddlePoint
            // 
            this.grpMiddlePoint.Controls.Add(this.txtXmlSource);
            this.grpMiddlePoint.Controls.Add(this.btnSelectXmlSource);
            this.grpMiddlePoint.Controls.Add(this.lblLongitude);
            this.grpMiddlePoint.Controls.Add(this.lblLatitude);
            this.grpMiddlePoint.Controls.Add(this.txtLongitude);
            this.grpMiddlePoint.Controls.Add(this.txtLatitude);
            this.grpMiddlePoint.Controls.Add(this.btnCalculeMiddlePoint);
            this.grpMiddlePoint.Location = new System.Drawing.Point(12, 191);
            this.grpMiddlePoint.Name = "grpMiddlePoint";
            this.grpMiddlePoint.Size = new System.Drawing.Size(429, 195);
            this.grpMiddlePoint.TabIndex = 1;
            this.grpMiddlePoint.TabStop = false;
            this.grpMiddlePoint.Text = "Middle Point";
            // 
            // txtXmlSource
            // 
            this.txtXmlSource.Location = new System.Drawing.Point(6, 34);
            this.txtXmlSource.Name = "txtXmlSource";
            this.txtXmlSource.ReadOnly = true;
            this.txtXmlSource.Size = new System.Drawing.Size(303, 20);
            this.txtXmlSource.TabIndex = 8;
            // 
            // btnSelectXmlSource
            // 
            this.btnSelectXmlSource.Location = new System.Drawing.Point(325, 24);
            this.btnSelectXmlSource.Name = "btnSelectXmlSource";
            this.btnSelectXmlSource.Size = new System.Drawing.Size(91, 38);
            this.btnSelectXmlSource.TabIndex = 7;
            this.btnSelectXmlSource.Text = "Select XML source";
            this.btnSelectXmlSource.UseVisualStyleBackColor = true;
            this.btnSelectXmlSource.Click += new System.EventHandler(this.btnSelectXmlSource_Click);
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(225, 153);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(54, 13);
            this.lblLongitude.TabIndex = 6;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(80, 153);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(45, 13);
            this.lblLatitude.TabIndex = 5;
            this.lblLatitude.Text = "Latitude";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(228, 169);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(127, 20);
            this.txtLongitude.TabIndex = 4;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(80, 169);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(127, 20);
            this.txtLatitude.TabIndex = 3;
            // 
            // btnCalculeMiddlePoint
            // 
            this.btnCalculeMiddlePoint.Location = new System.Drawing.Point(149, 101);
            this.btnCalculeMiddlePoint.Name = "btnCalculeMiddlePoint";
            this.btnCalculeMiddlePoint.Size = new System.Drawing.Size(137, 38);
            this.btnCalculeMiddlePoint.TabIndex = 2;
            this.btnCalculeMiddlePoint.Text = "Calcule Middle Point";
            this.btnCalculeMiddlePoint.UseVisualStyleBackColor = true;
            this.btnCalculeMiddlePoint.Click += new System.EventHandler(this.btnCalculeMiddlePoint_Click);
            // 
            // ofdXmlSource
            // 
            this.ofdXmlSource.Filter = "excel files (*.xls)|*.xls";
            this.ofdXmlSource.InitialDirectory = "C:\\\\";
            // 
            // frmToGoogleMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 416);
            this.Controls.Add(this.grpMiddlePoint);
            this.Controls.Add(this.grpExcelToXml);
            this.Name = "frmToGoogleMaps";
            this.Text = "Territories to GoogleMaps";
            this.Load += new System.EventHandler(this.frmToGoogleMaps_Load);
            this.grpExcelToXml.ResumeLayout(false);
            this.grpExcelToXml.PerformLayout();
            this.grpMiddlePoint.ResumeLayout(false);
            this.grpMiddlePoint.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpMiddlePoint;
        private System.Windows.Forms.Button btnCalculeMiddlePoint;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtXmlSource;
        private System.Windows.Forms.Button btnSelectXmlSource;
        private System.Windows.Forms.OpenFileDialog ofdXmlSource;


    }
}

