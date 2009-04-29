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
            this.ofdTerritoriesSheet = new System.Windows.Forms.OpenFileDialog();
            this.grpExcelToXml = new System.Windows.Forms.GroupBox();
            this.txtPathOut = new System.Windows.Forms.TextBox();
            this.btnSelectDestiny = new System.Windows.Forms.Button();
            this.btnConvertToXml = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.sfdXml = new System.Windows.Forms.SaveFileDialog();
            this.grpExcelToXml.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdTerritoriesSheet
            // 
            this.ofdTerritoriesSheet.Filter = "excel files (*.xls)|*.xls";
            this.ofdTerritoriesSheet.InitialDirectory = "C:\\\\";
            this.ofdTerritoriesSheet.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdTerritoriesSheet_FileOk);
            // 
            // grpExcelToXml
            // 
            this.grpExcelToXml.Controls.Add(this.txtPathOut);
            this.grpExcelToXml.Controls.Add(this.btnSelectDestiny);
            this.grpExcelToXml.Controls.Add(this.btnConvertToXml);
            this.grpExcelToXml.Controls.Add(this.txtPath);
            this.grpExcelToXml.Controls.Add(this.btnOpenFile);
            this.grpExcelToXml.Location = new System.Drawing.Point(12, 12);
            this.grpExcelToXml.Name = "grpExcelToXml";
            this.grpExcelToXml.Size = new System.Drawing.Size(535, 170);
            this.grpExcelToXml.TabIndex = 0;
            this.grpExcelToXml.TabStop = false;
            this.grpExcelToXml.Text = "Excel to XML";
            // 
            // txtPathOut
            // 
            this.txtPathOut.Location = new System.Drawing.Point(6, 79);
            this.txtPathOut.Name = "txtPathOut";
            this.txtPathOut.ReadOnly = true;
            this.txtPathOut.Size = new System.Drawing.Size(411, 20);
            this.txtPathOut.TabIndex = 4;
            // 
            // btnSelectDestiny
            // 
            this.btnSelectDestiny.Location = new System.Drawing.Point(423, 76);
            this.btnSelectDestiny.Name = "btnSelectDestiny";
            this.btnSelectDestiny.Size = new System.Drawing.Size(91, 24);
            this.btnSelectDestiny.TabIndex = 3;
            this.btnSelectDestiny.Text = "Select destiny";
            this.btnSelectDestiny.UseVisualStyleBackColor = true;
            this.btnSelectDestiny.Click += new System.EventHandler(this.btnSelectDestiny_Click);
            // 
            // btnConvertToXml
            // 
            this.btnConvertToXml.Location = new System.Drawing.Point(113, 115);
            this.btnConvertToXml.Name = "btnConvertToXml";
            this.btnConvertToXml.Size = new System.Drawing.Size(270, 35);
            this.btnConvertToXml.TabIndex = 2;
            this.btnConvertToXml.Text = "Convert to XML";
            this.btnConvertToXml.UseVisualStyleBackColor = true;
            this.btnConvertToXml.Click += new System.EventHandler(this.btnConvertToXml_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(6, 38);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(411, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(423, 35);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(91, 24);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // sfdXml
            // 
            this.sfdXml.Filter = "xml files (*.xml)|*.xml";
            this.sfdXml.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdXml_FileOk);
            // 
            // frmToGoogleMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 543);
            this.Controls.Add(this.grpExcelToXml);
            this.Name = "frmToGoogleMaps";
            this.Text = "Territories to GoogleMaps";
            this.grpExcelToXml.ResumeLayout(false);
            this.grpExcelToXml.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdTerritoriesSheet;
        private System.Windows.Forms.GroupBox grpExcelToXml;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnConvertToXml;
        private System.Windows.Forms.TextBox txtPathOut;
        private System.Windows.Forms.Button btnSelectDestiny;
        private System.Windows.Forms.SaveFileDialog sfdXml;


    }
}

