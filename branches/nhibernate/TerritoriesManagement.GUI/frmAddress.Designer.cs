namespace TerritoriesManagement.GUI
{
    partial class frmAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddress));
            this.grpMaps = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.bsAddress = new System.Windows.Forms.BindingSource(this.components);
            this.grpGeoLocation = new System.Windows.Forms.GroupBox();
            this.btnSearchGeoPos = new System.Windows.Forms.Button();
            this.chkHaveGeoPos = new System.Windows.Forms.CheckBox();
            this.lblLon = new System.Windows.Forms.Label();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblMap2 = new System.Windows.Forms.Label();
            this.txtMap2 = new System.Windows.Forms.TextBox();
            this.lblMap1 = new System.Windows.Forms.Label();
            this.txtMap1 = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpPhones = new System.Windows.Forms.GroupBox();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpUbication = new System.Windows.Forms.GroupBox();
            this.lblAddressData = new System.Windows.Forms.Label();
            this.txtAddressData = new System.Windows.Forms.TextBox();
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
            this.grpTerritory = new System.Windows.Forms.GroupBox();
            this.txtInternalNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblInternalNumber = new System.Windows.Forms.Label();
            this.btnAutoselectTerritory = new System.Windows.Forms.Button();
            this.cboTerritory = new System.Windows.Forms.ComboBox();
            this.grpAdditional = new System.Windows.Forms.GroupBox();
            this.grpMaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).BeginInit();
            this.grpGeoLocation.SuspendLayout();
            this.grpPhones.SuspendLayout();
            this.grpUbication.SuspendLayout();
            this.grpTerritory.SuspendLayout();
            this.grpAdditional.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaps
            // 
            this.grpMaps.Controls.Add(this.txtId);
            this.grpMaps.Controls.Add(this.grpGeoLocation);
            this.grpMaps.Controls.Add(this.lblMap2);
            this.grpMaps.Controls.Add(this.txtMap2);
            this.grpMaps.Controls.Add(this.lblMap1);
            this.grpMaps.Controls.Add(this.txtMap1);
            this.grpMaps.Location = new System.Drawing.Point(383, 12);
            this.grpMaps.Name = "grpMaps";
            this.grpMaps.Size = new System.Drawing.Size(355, 255);
            this.grpMaps.TabIndex = 2;
            this.grpMaps.TabStop = false;
            this.grpMaps.Text = "Maps";
            // 
            // txtId
            // 
            this.txtId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "IdAddress", true));
            this.txtId.Location = new System.Drawing.Point(249, 0);
            this.txtId.MaxLength = 50;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bsAddress
            // 
            this.bsAddress.DataSource = typeof(TerritoriesManagement.Model.Address);
            this.bsAddress.CurrentItemChanged += new System.EventHandler(this.HasChanges);
            // 
            // grpGeoLocation
            // 
            this.grpGeoLocation.Controls.Add(this.btnSearchGeoPos);
            this.grpGeoLocation.Controls.Add(this.chkHaveGeoPos);
            this.grpGeoLocation.Controls.Add(this.lblLon);
            this.grpGeoLocation.Controls.Add(this.lblLat);
            this.grpGeoLocation.Controls.Add(this.txtLon);
            this.grpGeoLocation.Controls.Add(this.txtLat);
            this.grpGeoLocation.Location = new System.Drawing.Point(26, 113);
            this.grpGeoLocation.Name = "grpGeoLocation";
            this.grpGeoLocation.Size = new System.Drawing.Size(304, 115);
            this.grpGeoLocation.TabIndex = 5;
            this.grpGeoLocation.TabStop = false;
            this.grpGeoLocation.Text = "Geo location";
            // 
            // btnSearchGeoPos
            // 
            this.btnSearchGeoPos.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchGeoPos.Image")));
            this.btnSearchGeoPos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchGeoPos.Location = new System.Drawing.Point(259, 59);
            this.btnSearchGeoPos.Name = "btnSearchGeoPos";
            this.btnSearchGeoPos.Size = new System.Drawing.Size(29, 23);
            this.btnSearchGeoPos.TabIndex = 5;
            this.btnSearchGeoPos.UseVisualStyleBackColor = true;
            this.btnSearchGeoPos.Click += new System.EventHandler(this.btnSearchGeoPos_Click);
            // 
            // chkHaveGeoPos
            // 
            this.chkHaveGeoPos.AutoSize = true;
            this.chkHaveGeoPos.Location = new System.Drawing.Point(189, 17);
            this.chkHaveGeoPos.Name = "chkHaveGeoPos";
            this.chkHaveGeoPos.Size = new System.Drawing.Size(102, 17);
            this.chkHaveGeoPos.TabIndex = 0;
            this.chkHaveGeoPos.Text = "Has geoposition";
            this.chkHaveGeoPos.UseVisualStyleBackColor = true;
            this.chkHaveGeoPos.CheckedChanged += new System.EventHandler(this.chkHasGeoPos_CheckedChanged);
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
            this.lblLat.TabIndex = 1;
            this.lblLat.Text = "Latitude";
            // 
            // txtLon
            // 
            this.txtLon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Lng", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLon.Location = new System.Drawing.Point(23, 80);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(217, 20);
            this.txtLon.TabIndex = 4;
            this.txtLon.TextChanged += new System.EventHandler(this.HasChanges);
            // 
            // txtLat
            // 
            this.txtLat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Lat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLat.Location = new System.Drawing.Point(23, 40);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(217, 20);
            this.txtLat.TabIndex = 2;
            this.txtLat.TextChanged += new System.EventHandler(this.HasChanges);
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
            this.txtMap2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Map2", true));
            this.txtMap2.Location = new System.Drawing.Point(26, 81);
            this.txtMap2.MaxLength = 30;
            this.txtMap2.Name = "txtMap2";
            this.txtMap2.Size = new System.Drawing.Size(304, 20);
            this.txtMap2.TabIndex = 4;
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
            this.txtMap1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Map1", true));
            this.txtMap1.Location = new System.Drawing.Point(26, 37);
            this.txtMap1.MaxLength = 30;
            this.txtMap1.Name = "txtMap1";
            this.txtMap1.Size = new System.Drawing.Size(304, 20);
            this.txtMap1.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 20);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(18, 36);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(316, 135);
            this.txtDescription.TabIndex = 1;
            // 
            // grpPhones
            // 
            this.grpPhones.Controls.Add(this.lblPhone2);
            this.grpPhones.Controls.Add(this.lblPhone1);
            this.grpPhones.Controls.Add(this.txtPhone2);
            this.grpPhones.Controls.Add(this.txtPhone1);
            this.grpPhones.Location = new System.Drawing.Point(383, 398);
            this.grpPhones.Name = "grpPhones";
            this.grpPhones.Size = new System.Drawing.Size(355, 124);
            this.grpPhones.TabIndex = 4;
            this.grpPhones.TabStop = false;
            this.grpPhones.Text = "Phone numbers";
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Location = new System.Drawing.Point(23, 67);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblPhone2.TabIndex = 2;
            this.lblPhone2.Text = "Phone 2";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Location = new System.Drawing.Point(23, 23);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(47, 13);
            this.lblPhone1.TabIndex = 0;
            this.lblPhone1.Text = "Phone 1";
            // 
            // txtPhone2
            // 
            this.txtPhone2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Phone2", true));
            this.txtPhone2.Location = new System.Drawing.Point(26, 83);
            this.txtPhone2.MaxLength = 15;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(304, 20);
            this.txtPhone2.TabIndex = 3;
            // 
            // txtPhone1
            // 
            this.txtPhone1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Phone1", true));
            this.txtPhone1.Location = new System.Drawing.Point(26, 39);
            this.txtPhone1.MaxLength = 15;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(304, 20);
            this.txtPhone1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(560, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 55);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Ok";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(652, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 55);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpUbication
            // 
            this.grpUbication.Controls.Add(this.lblAddressData);
            this.grpUbication.Controls.Add(this.txtAddressData);
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
            this.grpUbication.TabIndex = 0;
            this.grpUbication.TabStop = false;
            this.grpUbication.Text = "Location";
            // 
            // lblAddressData
            // 
            this.lblAddressData.AutoSize = true;
            this.lblAddressData.Location = new System.Drawing.Point(134, 147);
            this.lblAddressData.Name = "lblAddressData";
            this.lblAddressData.Size = new System.Drawing.Size(69, 13);
            this.lblAddressData.TabIndex = 8;
            this.lblAddressData.Text = "Address data";
            // 
            // txtAddressData
            // 
            this.txtAddressData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "AddressData", true));
            this.txtAddressData.Location = new System.Drawing.Point(137, 163);
            this.txtAddressData.MaxLength = 50;
            this.txtAddressData.Name = "txtAddressData";
            this.txtAddressData.Size = new System.Drawing.Size(197, 20);
            this.txtAddressData.TabIndex = 9;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(15, 147);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 6;
            this.lblNumber.Text = "Number";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(15, 60);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 2;
            this.lblCity.Text = "City";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(15, 16);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "Department";
            // 
            // lblCorner2
            // 
            this.lblCorner2.AutoSize = true;
            this.lblCorner2.Location = new System.Drawing.Point(15, 233);
            this.lblCorner2.Name = "lblCorner2";
            this.lblCorner2.Size = new System.Drawing.Size(47, 13);
            this.lblCorner2.TabIndex = 12;
            this.lblCorner2.Text = "Corner 2";
            // 
            // lblCorner1
            // 
            this.lblCorner1.AutoSize = true;
            this.lblCorner1.Location = new System.Drawing.Point(15, 190);
            this.lblCorner1.Name = "lblCorner1";
            this.lblCorner1.Size = new System.Drawing.Size(47, 13);
            this.lblCorner1.TabIndex = 10;
            this.lblCorner1.Text = "Corner 1";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(15, 104);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(35, 13);
            this.lblStreet.TabIndex = 4;
            this.lblStreet.Text = "Street";
            // 
            // txtCorner2
            // 
            this.txtCorner2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Corner2", true));
            this.txtCorner2.Location = new System.Drawing.Point(18, 251);
            this.txtCorner2.MaxLength = 80;
            this.txtCorner2.Name = "txtCorner2";
            this.txtCorner2.Size = new System.Drawing.Size(316, 20);
            this.txtCorner2.TabIndex = 13;
            // 
            // txtCorner1
            // 
            this.txtCorner1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Corner1", true));
            this.txtCorner1.Location = new System.Drawing.Point(18, 208);
            this.txtCorner1.MaxLength = 80;
            this.txtCorner1.Name = "txtCorner1";
            this.txtCorner1.Size = new System.Drawing.Size(316, 20);
            this.txtCorner1.TabIndex = 11;
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Number", true));
            this.txtNumber.Location = new System.Drawing.Point(18, 163);
            this.txtNumber.MaxLength = 50;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 7;
            // 
            // cboCity
            // 
            this.cboCity.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAddress, "City.IdCity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "City.Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(18, 78);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(316, 21);
            this.cboCity.TabIndex = 3;
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.HasChanges);
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(18, 34);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(316, 21);
            this.cboDepartment.TabIndex = 1;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // txtStreet
            // 
            this.txtStreet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Street", true));
            this.txtStreet.Location = new System.Drawing.Point(18, 122);
            this.txtStreet.MaxLength = 80;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(316, 20);
            this.txtStreet.TabIndex = 5;
            // 
            // txtField1
            // 
            this.txtField1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "CustomField1", true));
            this.txtField1.Location = new System.Drawing.Point(18, 197);
            this.txtField1.MaxLength = 200;
            this.txtField1.Multiline = true;
            this.txtField1.Name = "txtField1";
            this.txtField1.Size = new System.Drawing.Size(316, 43);
            this.txtField1.TabIndex = 3;
            // 
            // lblField1
            // 
            this.lblField1.AutoSize = true;
            this.lblField1.Location = new System.Drawing.Point(15, 181);
            this.lblField1.Name = "lblField1";
            this.lblField1.Size = new System.Drawing.Size(73, 13);
            this.lblField1.TabIndex = 2;
            this.lblField1.Text = "Custom field 1";
            // 
            // grpTerritory
            // 
            this.grpTerritory.Controls.Add(this.txtInternalNumber);
            this.grpTerritory.Controls.Add(this.lblInternalNumber);
            this.grpTerritory.Controls.Add(this.btnAutoselectTerritory);
            this.grpTerritory.Controls.Add(this.cboTerritory);
            this.grpTerritory.Location = new System.Drawing.Point(383, 278);
            this.grpTerritory.Name = "grpTerritory";
            this.grpTerritory.Size = new System.Drawing.Size(355, 114);
            this.grpTerritory.TabIndex = 3;
            this.grpTerritory.TabStop = false;
            this.grpTerritory.Text = "Territory";
            // 
            // txtInternalNumber
            // 
            this.txtInternalNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "InternalTerritoryNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.txtInternalNumber.Location = new System.Drawing.Point(26, 74);
            this.txtInternalNumber.Mask = "99999";
            this.txtInternalNumber.Name = "txtInternalNumber";
            this.txtInternalNumber.PromptChar = ' ';
            this.txtInternalNumber.Size = new System.Drawing.Size(121, 20);
            this.txtInternalNumber.TabIndex = 24;
            this.txtInternalNumber.ValidatingType = typeof(int);
            // 
            // lblInternalNumber
            // 
            this.lblInternalNumber.AutoSize = true;
            this.lblInternalNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInternalNumber.Location = new System.Drawing.Point(23, 58);
            this.lblInternalNumber.Name = "lblInternalNumber";
            this.lblInternalNumber.Size = new System.Drawing.Size(80, 13);
            this.lblInternalNumber.TabIndex = 8;
            this.lblInternalNumber.Text = "Internal number";
            // 
            // btnAutoselectTerritory
            // 
            this.btnAutoselectTerritory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoselectTerritory.Location = new System.Drawing.Point(264, 27);
            this.btnAutoselectTerritory.Name = "btnAutoselectTerritory";
            this.btnAutoselectTerritory.Size = new System.Drawing.Size(80, 23);
            this.btnAutoselectTerritory.TabIndex = 6;
            this.btnAutoselectTerritory.Text = "Autoselect";
            this.btnAutoselectTerritory.UseVisualStyleBackColor = true;
            this.btnAutoselectTerritory.Click += new System.EventHandler(this.btnAutoselectTerritory_Click);
            // 
            // cboTerritory
            // 
            this.cboTerritory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAddress, "Territory.IdTerritory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboTerritory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Territory.Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Location = new System.Drawing.Point(26, 29);
            this.cboTerritory.Name = "cboTerritory";
            this.cboTerritory.Size = new System.Drawing.Size(226, 21);
            this.cboTerritory.TabIndex = 0;
            this.cboTerritory.SelectedIndexChanged += new System.EventHandler(this.HasChanges);
            // 
            // grpAdditional
            // 
            this.grpAdditional.Controls.Add(this.lblDescription);
            this.grpAdditional.Controls.Add(this.txtDescription);
            this.grpAdditional.Controls.Add(this.lblField1);
            this.grpAdditional.Controls.Add(this.txtField1);
            this.grpAdditional.Location = new System.Drawing.Point(12, 316);
            this.grpAdditional.Name = "grpAdditional";
            this.grpAdditional.Size = new System.Drawing.Size(355, 256);
            this.grpAdditional.TabIndex = 1;
            this.grpAdditional.TabStop = false;
            this.grpAdditional.Text = "Additional information";
            // 
            // frmAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 595);
            this.Controls.Add(this.grpAdditional);
            this.Controls.Add(this.grpTerritory);
            this.Controls.Add(this.grpUbication);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpPhones);
            this.Controls.Add(this.grpMaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAddress";
            this.Text = "Address";
            this.Load += new System.EventHandler(this.frmAddress_Load);
            this.grpMaps.ResumeLayout(false);
            this.grpMaps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).EndInit();
            this.grpGeoLocation.ResumeLayout(false);
            this.grpGeoLocation.PerformLayout();
            this.grpPhones.ResumeLayout(false);
            this.grpPhones.PerformLayout();
            this.grpUbication.ResumeLayout(false);
            this.grpUbication.PerformLayout();
            this.grpTerritory.ResumeLayout(false);
            this.grpTerritory.PerformLayout();
            this.grpAdditional.ResumeLayout(false);
            this.grpAdditional.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.BindingSource bsAddress;
        private System.Windows.Forms.GroupBox grpUbication;
        private System.Windows.Forms.Label lblAddressData;
        private System.Windows.Forms.TextBox txtAddressData;
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
        private System.Windows.Forms.GroupBox grpTerritory;
        private System.Windows.Forms.ComboBox cboTerritory;
        private System.Windows.Forms.GroupBox grpAdditional;
        private System.Windows.Forms.CheckBox chkHaveGeoPos;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSearchGeoPos;
        private System.Windows.Forms.Button btnAutoselectTerritory;
        private System.Windows.Forms.Label lblInternalNumber;
        private System.Windows.Forms.MaskedTextBox txtInternalNumber;


    }
}