namespace ZeqkTools.WindowsForms.Maps
{
    partial class frmGeoArea
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
            this.MainMap = new System.Windows.Forms.GMapControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblMapType = new System.Windows.Forms.Label();
            this.cboMapType = new System.Windows.Forms.ComboBox();
            this.btnToStaticMap = new System.Windows.Forms.Button();
            this.btnGenImage = new System.Windows.Forms.Button();
            this.sfdSaveScreen = new System.Windows.Forms.SaveFileDialog();
            this.tableBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableBase.SuspendLayout();
            this.tableBottom.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMap
            // 
            this.MainMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMap.CacheLocation = "C:\\Users\\zeqk\\AppData\\Roaming\\GMap.NET\\";
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.Location = new System.Drawing.Point(3, 3);
            this.MainMap.MapType = GMap.NET.MapType.GoogleMap;
            this.MainMap.MarkersEnabled = true;
            this.MainMap.Name = "MainMap";
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(651, 491);
            this.MainMap.TabIndex = 10;
            this.MainMap.Zoom = 2;
            this.MainMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.MainMap_OnMapZoomChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(660, 3);
            this.trackBar1.Maximum = 17;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(34, 491);
            this.trackBar1.TabIndex = 29;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 12;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblMapType
            // 
            this.lblMapType.AutoSize = true;
            this.lblMapType.Location = new System.Drawing.Point(3, 0);
            this.lblMapType.Name = "lblMapType";
            this.lblMapType.Size = new System.Drawing.Size(51, 11);
            this.lblMapType.TabIndex = 14;
            this.lblMapType.Text = "Map type";
            // 
            // cboMapType
            // 
            this.cboMapType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapType.FormattingEnabled = true;
            this.cboMapType.Location = new System.Drawing.Point(3, 15);
            this.cboMapType.Name = "cboMapType";
            this.cboMapType.Size = new System.Drawing.Size(222, 21);
            this.cboMapType.TabIndex = 13;
            this.cboMapType.SelectedValueChanged += new System.EventHandler(this.cboMapType_SelectedValueChanged);
            // 
            // btnToStaticMap
            // 
            this.btnToStaticMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToStaticMap.Location = new System.Drawing.Point(13, 3);
            this.btnToStaticMap.Name = "btnToStaticMap";
            this.btnToStaticMap.Size = new System.Drawing.Size(89, 40);
            this.btnToStaticMap.TabIndex = 12;
            this.btnToStaticMap.Text = "To image";
            this.btnToStaticMap.UseVisualStyleBackColor = true;
            this.btnToStaticMap.Click += new System.EventHandler(this.btnGenImage_Click);
            // 
            // btnGenImage
            // 
            this.btnGenImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenImage.Location = new System.Drawing.Point(12, 3);
            this.btnGenImage.Name = "btnGenImage";
            this.btnGenImage.Size = new System.Drawing.Size(91, 28);
            this.btnGenImage.TabIndex = 12;
            this.btnGenImage.Text = "To image";
            this.btnGenImage.UseVisualStyleBackColor = true;
            this.btnGenImage.Click += new System.EventHandler(this.btnGenImage_Click);
            // 
            // tableBase
            // 
            this.tableBase.ColumnCount = 1;
            this.tableBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.Controls.Add(this.tableBottom, 0, 1);
            this.tableBase.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBase.Location = new System.Drawing.Point(0, 0);
            this.tableBase.Name = "tableBase";
            this.tableBase.RowCount = 2;
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableBase.Size = new System.Drawing.Size(703, 561);
            this.tableBase.TabIndex = 30;
            // 
            // tableBottom
            // 
            this.tableBottom.ColumnCount = 2;
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableBottom.Controls.Add(this.tableButtons, 1, 0);
            this.tableBottom.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBottom.Location = new System.Drawing.Point(3, 506);
            this.tableBottom.Name = "tableBottom";
            this.tableBottom.RowCount = 1;
            this.tableBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottom.Size = new System.Drawing.Size(697, 52);
            this.tableBottom.TabIndex = 1;
            // 
            // tableButtons
            // 
            this.tableButtons.ColumnCount = 2;
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.Controls.Add(this.btnCancel, 0, 0);
            this.tableButtons.Controls.Add(this.btnOk, 1, 0);
            this.tableButtons.Location = new System.Drawing.Point(560, 3);
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.RowCount = 1;
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableButtons.Size = new System.Drawing.Size(134, 46);
            this.tableButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 38);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(70, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 38);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnToStaticMap, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(551, 46);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblMapType, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cboMapType, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(310, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.66543F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.33456F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(228, 40);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Controls.Add(this.trackBar1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.MainMap, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(697, 497);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // frmGeoArea
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(703, 561);
            this.Controls.Add(this.tableBase);
            this.Name = "frmGeoArea";
            this.Text = "Area";
            this.Load += new System.EventHandler(this.frmGeoArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableBase.ResumeLayout(false);
            this.tableBottom.ResumeLayout(false);
            this.tableButtons.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToStaticMap;
        private System.Windows.Forms.Button btnGenImage;
        private System.Windows.Forms.SaveFileDialog sfdSaveScreen;
        private System.Windows.Forms.GMapControl MainMap;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblMapType;
        private System.Windows.Forms.ComboBox cboMapType;
        private System.Windows.Forms.TableLayoutPanel tableBase;
        private System.Windows.Forms.TableLayoutPanel tableBottom;
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;

    }
}