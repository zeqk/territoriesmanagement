namespace Territories.GUI
{
    partial class frmDirection
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
            this.components = new System.ComponentModel.Container();
            this.grpMaps = new System.Windows.Forms.GroupBox();
            this.grpGeoLocation = new System.Windows.Forms.GroupBox();
            this.chkHaveGeo = new System.Windows.Forms.CheckBox();
            this.lblLon = new System.Windows.Forms.Label();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.bsGeoposition = new System.Windows.Forms.BindingSource(this.components);
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblMap2 = new System.Windows.Forms.Label();
            this.txtMap2 = new System.Windows.Forms.TextBox();
            this.bsDirection = new System.Windows.Forms.BindingSource(this.components);
            this.lblMap1 = new System.Windows.Forms.Label();
            this.txtMap1 = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.cboTerritory = new System.Windows.Forms.ComboBox();
            this.grpPhones = new System.Windows.Forms.GroupBox();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpUbication = new System.Windows.Forms.GroupBox();
            this.lblHouseData = new System.Windows.Forms.Label();
            this.txtHouseData = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCorner2 = new System.Windows.Forms.Label();
            this.lblCorner1 = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtCorner2 = new System.Windows.Forms.TextBox();
            this.txtCorner1 = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtField1 = new System.Windows.Forms.TextBox();
            this.lblField1 = new System.Windows.Forms.Label();
            this.grpMaps.SuspendLayout();
            this.grpGeoLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsGeoposition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDirection)).BeginInit();
            this.grpPhones.SuspendLayout();
            this.grpUbication.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaps
            // 
            this.grpMaps.Controls.Add(this.grpGeoLocation);
            this.grpMaps.Controls.Add(this.lblMap2);
            this.grpMaps.Controls.Add(this.txtMap2);
            this.grpMaps.Controls.Add(this.lblMap1);
            this.grpMaps.Controls.Add(this.txtMap1);
            this.grpMaps.Location = new System.Drawing.Point(373, 12);
            this.grpMaps.Name = "grpMaps";
            this.grpMaps.Size = new System.Drawing.Size(304, 255);
            this.grpMaps.TabIndex = 40;
            this.grpMaps.TabStop = false;
            this.grpMaps.Text = "Ubication";
            // 
            // grpGeoLocation
            // 
            this.grpGeoLocation.Controls.Add(this.chkHaveGeo);
            this.grpGeoLocation.Controls.Add(this.lblLon);
            this.grpGeoLocation.Controls.Add(this.lblLat);
            this.grpGeoLocation.Controls.Add(this.txtLon);
            this.grpGeoLocation.Controls.Add(this.txtLat);
            this.grpGeoLocation.Location = new System.Drawing.Point(26, 113);
            this.grpGeoLocation.Name = "grpGeoLocation";
            this.grpGeoLocation.Size = new System.Drawing.Size(253, 115);
            this.grpGeoLocation.TabIndex = 4;
            this.grpGeoLocation.TabStop = false;
            this.grpGeoLocation.Text = "Geo location";
            // 
            // chkHaveGeo
            // 
            this.chkHaveGeo.AutoSize = true;
            this.chkHaveGeo.Location = new System.Drawing.Point(131, 17);
            this.chkHaveGeo.Name = "chkHaveGeo";
            this.chkHaveGeo.Size = new System.Drawing.Size(109, 17);
            this.chkHaveGeo.TabIndex = 4;
            this.chkHaveGeo.Text = "Have geoposition";
            this.chkHaveGeo.UseVisualStyleBackColor = true;
            this.chkHaveGeo.CheckedChanged += new System.EventHandler(this.chkHaveGeo_CheckedChanged);
            // 
            // lblLon
            // 
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new System.Drawing.Point(20, 64);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(54, 13);
            this.lblLon.TabIndex = 3;
            this.lblLon.Text = "Longitude";
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(20, 24);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(45, 13);
            this.lblLat.TabIndex = 2;
            this.lblLat.Text = "Latitude";
            // 
            // txtLon
            // 
            this.txtLon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGeoposition, "Longitude", true));
            this.txtLon.Location = new System.Drawing.Point(23, 80);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(176, 20);
            this.txtLon.TabIndex = 1;
            // 
            // bsGeoposition
            // 
            this.bsGeoposition.DataSource = typeof(Territories.Model.GeoPosition);
            this.bsGeoposition.CurrentItemChanged += new System.EventHandler(this.GeoPositionHaveChanges);
            // 
            // txtLat
            // 
            this.txtLat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGeoposition, "Latitude", true));
            this.txtLat.Location = new System.Drawing.Point(23, 40);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(176, 20);
            this.txtLat.TabIndex = 0;
            // 
            // lblMap2
            // 
            this.lblMap2.AutoSize = true;
            this.lblMap2.Location = new System.Drawing.Point(23, 65);
            this.lblMap2.Name = "lblMap2";
            this.lblMap2.Size = new System.Drawing.Size(37, 13);
            this.lblMap2.TabIndex = 3;
            this.lblMap2.Text = "Map 2";
            // 
            // txtMap2
            // 
            this.txtMap2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Map2", true));
            this.txtMap2.Location = new System.Drawing.Point(26, 81);
            this.txtMap2.Name = "txtMap2";
            this.txtMap2.Size = new System.Drawing.Size(220, 20);
            this.txtMap2.TabIndex = 2;
            // 
            // bsDirection
            // 
            this.bsDirection.DataSource = typeof(Territories.Model.Direction);
            this.bsDirection.CurrentItemChanged += new System.EventHandler(this.HaveChanges);
            // 
            // lblMap1
            // 
            this.lblMap1.AutoSize = true;
            this.lblMap1.Location = new System.Drawing.Point(23, 21);
            this.lblMap1.Name = "lblMap1";
            this.lblMap1.Size = new System.Drawing.Size(37, 13);
            this.lblMap1.TabIndex = 1;
            this.lblMap1.Text = "Map 1";
            // 
            // txtMap1
            // 
            this.txtMap1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Map1", true));
            this.txtMap1.Location = new System.Drawing.Point(26, 37);
            this.txtMap1.Name = "txtMap1";
            this.txtMap1.Size = new System.Drawing.Size(220, 20);
            this.txtMap1.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(26, 359);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 39;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(29, 375);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(316, 175);
            this.txtDescription.TabIndex = 38;
            // 
            // lblTerritory
            // 
            this.lblTerritory.AutoSize = true;
            this.lblTerritory.Location = new System.Drawing.Point(26, 315);
            this.lblTerritory.Name = "lblTerritory";
            this.lblTerritory.Size = new System.Drawing.Size(45, 13);
            this.lblTerritory.TabIndex = 36;
            this.lblTerritory.Text = "Territory";
            // 
            // cboTerritory
            // 
            this.cboTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Location = new System.Drawing.Point(29, 331);
            this.cboTerritory.Name = "cboTerritory";
            this.cboTerritory.Size = new System.Drawing.Size(316, 21);
            this.cboTerritory.TabIndex = 30;
            this.cboTerritory.SelectedIndexChanged += new System.EventHandler(this.HaveChanges);
            // 
            // grpPhones
            // 
            this.grpPhones.Controls.Add(this.lblPhone2);
            this.grpPhones.Controls.Add(this.lblPhone1);
            this.grpPhones.Controls.Add(this.txtPhone2);
            this.grpPhones.Controls.Add(this.txtPhone1);
            this.grpPhones.Location = new System.Drawing.Point(373, 273);
            this.grpPhones.Name = "grpPhones";
            this.grpPhones.Size = new System.Drawing.Size(304, 124);
            this.grpPhones.TabIndex = 41;
            this.grpPhones.TabStop = false;
            this.grpPhones.Text = "Phones";
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Location = new System.Drawing.Point(23, 67);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblPhone2.TabIndex = 3;
            this.lblPhone2.Text = "Phone 2";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Location = new System.Drawing.Point(23, 23);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(47, 13);
            this.lblPhone1.TabIndex = 2;
            this.lblPhone1.Text = "Phone 1";
            // 
            // txtPhone2
            // 
            this.txtPhone2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Phone2", true));
            this.txtPhone2.Location = new System.Drawing.Point(26, 83);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(253, 20);
            this.txtPhone2.TabIndex = 1;
            // 
            // txtPhone1
            // 
            this.txtPhone1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Phone1", true));
            this.txtPhone1.Location = new System.Drawing.Point(26, 39);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(253, 20);
            this.txtPhone1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(461, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 55);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(553, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 55);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpUbication
            // 
            this.grpUbication.Controls.Add(this.lblHouseData);
            this.grpUbication.Controls.Add(this.txtHouseData);
            this.grpUbication.Controls.Add(this.lblNumber);
            this.grpUbication.Controls.Add(this.lblCity);
            this.grpUbication.Controls.Add(this.lblDepartment);
            this.grpUbication.Controls.Add(this.lblCorner2);
            this.grpUbication.Controls.Add(this.lblCorner1);
            this.grpUbication.Controls.Add(this.lblStreet);
            this.grpUbication.Controls.Add(this.txtCorner2);
            this.grpUbication.Controls.Add(this.txtCorner1);
            this.grpUbication.Controls.Add(this.txtNumber);
            this.grpUbication.Controls.Add(this.cboCity);
            this.grpUbication.Controls.Add(this.cboDepartment);
            this.grpUbication.Controls.Add(this.txtStreet);
            this.grpUbication.Location = new System.Drawing.Point(12, 12);
            this.grpUbication.Name = "grpUbication";
            this.grpUbication.Size = new System.Drawing.Size(355, 291);
            this.grpUbication.TabIndex = 44;
            this.grpUbication.TabStop = false;
            this.grpUbication.Text = "Ubication";
            // 
            // lblHouseData
            // 
            this.lblHouseData.AutoSize = true;
            this.lblHouseData.Location = new System.Drawing.Point(134, 147);
            this.lblHouseData.Name = "lblHouseData";
            this.lblHouseData.Size = new System.Drawing.Size(62, 13);
            this.lblHouseData.TabIndex = 59;
            this.lblHouseData.Text = "House data";
            // 
            // txtHouseData
            // 
            this.txtHouseData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Number", true));
            this.txtHouseData.Location = new System.Drawing.Point(137, 163);
            this.txtHouseData.Name = "txtHouseData";
            this.txtHouseData.Size = new System.Drawing.Size(197, 20);
            this.txtHouseData.TabIndex = 58;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(15, 147);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 57;
            this.lblNumber.Text = "Number";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(15, 60);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 56;
            this.lblCity.Text = "City";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(15, 16);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 55;
            this.lblDepartment.Text = "Department";
            // 
            // lblCorner2
            // 
            this.lblCorner2.AutoSize = true;
            this.lblCorner2.Location = new System.Drawing.Point(15, 233);
            this.lblCorner2.Name = "lblCorner2";
            this.lblCorner2.Size = new System.Drawing.Size(47, 13);
            this.lblCorner2.TabIndex = 54;
            this.lblCorner2.Text = "Corner 2";
            // 
            // lblCorner1
            // 
            this.lblCorner1.AutoSize = true;
            this.lblCorner1.Location = new System.Drawing.Point(15, 190);
            this.lblCorner1.Name = "lblCorner1";
            this.lblCorner1.Size = new System.Drawing.Size(47, 13);
            this.lblCorner1.TabIndex = 53;
            this.lblCorner1.Text = "Corner 1";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(15, 104);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(35, 13);
            this.lblStreet.TabIndex = 52;
            this.lblStreet.Text = "Street";
            // 
            // txtCorner2
            // 
            this.txtCorner2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Corner2", true));
            this.txtCorner2.Location = new System.Drawing.Point(18, 251);
            this.txtCorner2.Name = "txtCorner2";
            this.txtCorner2.Size = new System.Drawing.Size(316, 20);
            this.txtCorner2.TabIndex = 51;
            // 
            // txtCorner1
            // 
            this.txtCorner1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Corner1", true));
            this.txtCorner1.Location = new System.Drawing.Point(18, 208);
            this.txtCorner1.Name = "txtCorner1";
            this.txtCorner1.Size = new System.Drawing.Size(316, 20);
            this.txtCorner1.TabIndex = 50;
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Number", true));
            this.txtNumber.Location = new System.Drawing.Point(18, 163);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 49;
            // 
            // cboCity
            // 
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(18, 78);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(316, 21);
            this.cboCity.TabIndex = 48;
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.HaveChanges);
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(18, 34);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(316, 21);
            this.cboDepartment.TabIndex = 47;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // txtStreet
            // 
            this.txtStreet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Street", true));
            this.txtStreet.Location = new System.Drawing.Point(18, 122);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(316, 20);
            this.txtStreet.TabIndex = 46;
            // 
            // txtField1
            // 
            this.txtField1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDirection, "Description", true));
            this.txtField1.Location = new System.Drawing.Point(399, 428);
            this.txtField1.Multiline = true;
            this.txtField1.Name = "txtField1";
            this.txtField1.Size = new System.Drawing.Size(253, 43);
            this.txtField1.TabIndex = 45;
            // 
            // lblField1
            // 
            this.lblField1.AutoSize = true;
            this.lblField1.Location = new System.Drawing.Point(396, 412);
            this.lblField1.Name = "lblField1";
            this.lblField1.Size = new System.Drawing.Size(38, 13);
            this.lblField1.TabIndex = 46;
            this.lblField1.Text = "Field 1";
            // 
            // frmDirection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 572);
            this.Controls.Add(this.lblField1);
            this.Controls.Add(this.txtField1);
            this.Controls.Add(this.grpUbication);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpPhones);
            this.Controls.Add(this.grpMaps);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTerritory);
            this.Controls.Add(this.cboTerritory);
            this.Name = "frmDirection";
            this.Text = "Direction";
            this.Load += new System.EventHandler(this.frmDirection_Load);
            this.grpMaps.ResumeLayout(false);
            this.grpMaps.PerformLayout();
            this.grpGeoLocation.ResumeLayout(false);
            this.grpGeoLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsGeoposition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDirection)).EndInit();
            this.grpPhones.ResumeLayout(false);
            this.grpPhones.PerformLayout();
            this.grpUbication.ResumeLayout(false);
            this.grpUbication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaps;
        private System.Windows.Forms.GroupBox grpGeoLocation;
        private System.Windows.Forms.Label lblMap2;
        private System.Windows.Forms.TextBox txtMap2;
        private System.Windows.Forms.Label lblMap1;
        private System.Windows.Forms.TextBox txtMap1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTerritory;
        private System.Windows.Forms.ComboBox cboTerritory;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.GroupBox grpPhones;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Label lblPhone1;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource bsDirection;
        private System.Windows.Forms.GroupBox grpUbication;
        private System.Windows.Forms.Label lblHouseData;
        private System.Windows.Forms.TextBox txtHouseData;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCorner2;
        private System.Windows.Forms.Label lblCorner1;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtCorner2;
        private System.Windows.Forms.TextBox txtCorner1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtField1;
        private System.Windows.Forms.Label lblField1;
        private System.Windows.Forms.BindingSource bsGeoposition;
        private System.Windows.Forms.CheckBox chkHaveGeo;


    }
}