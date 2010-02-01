namespace ZeqkTools.WindowsForms.Maps
{
    partial class frmGeoPoint
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
            this.tableBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tableBody = new System.Windows.Forms.TableLayoutPanel();
            this.MainMap = new System.Windows.Forms.GMapControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tableBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableProperties = new System.Windows.Forms.TableLayoutPanel();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.lblLng = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.cboMapType = new System.Windows.Forms.ComboBox();
            this.lblMapType = new System.Windows.Forms.Label();
            this.tableBase.SuspendLayout();
            this.tableTop.SuspendLayout();
            this.tableBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableBottom.SuspendLayout();
            this.tableProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableBase
            // 
            this.tableBase.ColumnCount = 1;
            this.tableBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.Controls.Add(this.tableTop, 0, 0);
            this.tableBase.Controls.Add(this.tableBody, 0, 1);
            this.tableBase.Controls.Add(this.tableBottom, 0, 2);
            this.tableBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBase.Location = new System.Drawing.Point(0, 0);
            this.tableBase.Name = "tableBase";
            this.tableBase.RowCount = 3;
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableBase.Size = new System.Drawing.Size(755, 550);
            this.tableBase.TabIndex = 5;
            // 
            // tableTop
            // 
            this.tableTop.ColumnCount = 2;
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableTop.Controls.Add(this.btnGo, 1, 0);
            this.tableTop.Controls.Add(this.txtAddress, 0, 0);
            this.tableTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTop.Location = new System.Drawing.Point(3, 3);
            this.tableTop.Name = "tableTop";
            this.tableTop.RowCount = 1;
            this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTop.Size = new System.Drawing.Size(749, 44);
            this.tableTop.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(672, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(74, 38);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(3, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(663, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // tableBody
            // 
            this.tableBody.ColumnCount = 2;
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableBody.Controls.Add(this.MainMap, 0, 0);
            this.tableBody.Controls.Add(this.trackBar1, 1, 0);
            this.tableBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBody.Location = new System.Drawing.Point(3, 53);
            this.tableBody.Name = "tableBody";
            this.tableBody.RowCount = 1;
            this.tableBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBody.Size = new System.Drawing.Size(749, 439);
            this.tableBody.TabIndex = 1;
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
            this.MainMap.Size = new System.Drawing.Size(697, 433);
            this.MainMap.TabIndex = 31;
            this.MainMap.Zoom = 2;
            this.MainMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.MainMap_OnMapZoomChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(706, 3);
            this.trackBar1.Maximum = 17;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(40, 433);
            this.trackBar1.TabIndex = 30;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 12;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // tableBottom
            // 
            this.tableBottom.AutoScroll = true;
            this.tableBottom.ColumnCount = 3;
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableBottom.Controls.Add(this.btnCancel, 1, 0);
            this.tableBottom.Controls.Add(this.btnOk, 2, 0);
            this.tableBottom.Controls.Add(this.tableProperties, 0, 0);
            this.tableBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBottom.Location = new System.Drawing.Point(3, 498);
            this.tableBottom.Name = "tableBottom";
            this.tableBottom.RowCount = 1;
            this.tableBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottom.Size = new System.Drawing.Size(749, 49);
            this.tableBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(612, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 38);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(682, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(64, 38);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // tableProperties
            // 
            this.tableProperties.ColumnCount = 3;
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableProperties.Controls.Add(this.lblLat, 0, 0);
            this.tableProperties.Controls.Add(this.txtLng, 1, 1);
            this.tableProperties.Controls.Add(this.lblLng, 1, 0);
            this.tableProperties.Controls.Add(this.txtLat, 0, 1);
            this.tableProperties.Controls.Add(this.cboMapType, 2, 1);
            this.tableProperties.Controls.Add(this.lblMapType, 2, 0);
            this.tableProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableProperties.Location = new System.Drawing.Point(3, 3);
            this.tableProperties.Name = "tableProperties";
            this.tableProperties.RowCount = 2;
            this.tableProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.63636F));
            this.tableProperties.Size = new System.Drawing.Size(603, 43);
            this.tableProperties.TabIndex = 16;
            // 
            // lblLat
            // 
            this.lblLat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(3, 1);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(22, 13);
            this.lblLat.TabIndex = 17;
            this.lblLat.Text = "Lat";
            // 
            // txtLng
            // 
            this.txtLng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLng.Location = new System.Drawing.Point(203, 19);
            this.txtLng.Name = "txtLng";
            this.txtLng.ReadOnly = true;
            this.txtLng.Size = new System.Drawing.Size(195, 20);
            this.txtLng.TabIndex = 18;
            // 
            // lblLng
            // 
            this.lblLng.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLng.AutoSize = true;
            this.lblLng.Location = new System.Drawing.Point(203, 1);
            this.lblLng.Name = "lblLng";
            this.lblLng.Size = new System.Drawing.Size(25, 13);
            this.lblLng.TabIndex = 19;
            this.lblLng.Text = "Lng";
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.Location = new System.Drawing.Point(3, 19);
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = true;
            this.txtLat.Size = new System.Drawing.Size(194, 20);
            this.txtLat.TabIndex = 16;
            // 
            // cboMapType
            // 
            this.cboMapType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapType.FormattingEnabled = true;
            this.cboMapType.Location = new System.Drawing.Point(404, 18);
            this.cboMapType.Name = "cboMapType";
            this.cboMapType.Size = new System.Drawing.Size(196, 21);
            this.cboMapType.TabIndex = 20;
            this.cboMapType.SelectedValueChanged += new System.EventHandler(this.cboMapType_SelectedValueChanged);
            // 
            // lblMapType
            // 
            this.lblMapType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMapType.AutoSize = true;
            this.lblMapType.Location = new System.Drawing.Point(404, 1);
            this.lblMapType.Name = "lblMapType";
            this.lblMapType.Size = new System.Drawing.Size(51, 13);
            this.lblMapType.TabIndex = 21;
            this.lblMapType.Text = "Map type";
            // 
            // frmGeoPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 550);
            this.Controls.Add(this.tableBase);
            this.Name = "frmGeoPoint";
            this.Text = "Position";
            this.Load += new System.EventHandler(this.frmGeoPoint_Load);
            this.tableBase.ResumeLayout(false);
            this.tableTop.ResumeLayout(false);
            this.tableTop.PerformLayout();
            this.tableBody.ResumeLayout(false);
            this.tableBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableBottom.ResumeLayout(false);
            this.tableProperties.ResumeLayout(false);
            this.tableProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableBase;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cboMapType;
        private System.Windows.Forms.Label lblLng;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.GMapControl MainMap;
        private System.Windows.Forms.TableLayoutPanel tableTop;
        private System.Windows.Forms.TableLayoutPanel tableBody;
        private System.Windows.Forms.TableLayoutPanel tableBottom;
        private System.Windows.Forms.TableLayoutPanel tableProperties;
        private System.Windows.Forms.Label lblMapType;
    }
}