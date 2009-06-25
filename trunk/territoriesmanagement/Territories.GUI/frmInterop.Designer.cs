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
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabGeoRss = new System.Windows.Forms.TabPage();
            this.lblRssSource = new System.Windows.Forms.Label();
            this.btnUpdateXls = new System.Windows.Forms.Button();
            this.txtRssSource = new System.Windows.Forms.TextBox();
            this.btnSelectRssSource = new System.Windows.Forms.Button();
            this.tabDataImport = new System.Windows.Forms.TabPage();
            this.odfRssSource = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.tabPanel.SuspendLayout();
            this.tabGeoRss.SuspendLayout();
            this.tabDataImport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabGeoRss);
            this.tabPanel.Controls.Add(this.tabDataImport);
            this.tabPanel.Location = new System.Drawing.Point(8, 11);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(611, 395);
            this.tabPanel.TabIndex = 0;
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
            this.tabGeoRss.Size = new System.Drawing.Size(583, 238);
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
            // tabDataImport
            // 
            this.tabDataImport.Controls.Add(this.groupBox1);
            this.tabDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabDataImport.Name = "tabDataImport";
            this.tabDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataImport.Size = new System.Drawing.Size(603, 369);
            this.tabDataImport.TabIndex = 1;
            this.tabDataImport.Text = "Data import";
            this.tabDataImport.UseVisualStyleBackColor = true;
            // 
            // odfRssSource
            // 
            this.odfRssSource.Filter = "xml files (*.xml)|*.xml";
            this.odfRssSource.InitialDirectory = "C:\\\\";
            this.odfRssSource.FileOk += new System.ComponentModel.CancelEventHandler(this.odfRssSource_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 254);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Departments";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 5;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(31, 87);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(87, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "IdDeparment";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(31, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(141, 20);
            this.textBox2.TabIndex = 7;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(31, 136);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(54, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Name";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(31, 159);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(141, 20);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(207, 159);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(141, 20);
            this.textBox4.TabIndex = 15;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(207, 136);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(54, 17);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "Name";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(207, 110);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(141, 20);
            this.textBox5.TabIndex = 13;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(207, 87);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(52, 17);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.Text = "IdCity";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(188, 61);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(160, 20);
            this.textBox6.TabIndex = 11;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(188, 38);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(51, 17);
            this.checkBox6.TabIndex = 10;
            this.checkBox6.Text = "Cities";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(207, 208);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(141, 20);
            this.textBox7.TabIndex = 17;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(207, 185);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(81, 17);
            this.checkBox7.TabIndex = 16;
            this.checkBox7.Text = "Department";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 418);
            this.Controls.Add(this.tabPanel);
            this.Name = "frmInterop";
            this.Text = "frmInterop";
            this.tabPanel.ResumeLayout(false);
            this.tabGeoRss.ResumeLayout(false);
            this.tabGeoRss.PerformLayout();
            this.tabDataImport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabGeoRss;
        private System.Windows.Forms.TabPage tabDataImport;
        private System.Windows.Forms.Label lblRssSource;
        private System.Windows.Forms.Button btnUpdateXls;
        private System.Windows.Forms.TextBox txtRssSource;
        private System.Windows.Forms.Button btnSelectRssSource;
        private System.Windows.Forms.OpenFileDialog odfRssSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox checkBox6;
    }
}