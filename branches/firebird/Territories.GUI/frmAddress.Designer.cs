namespace Territories.GUI
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
            this.grpMaps.AccessibleDescription = null;
            this.grpMaps.AccessibleName = null;
            resources.ApplyResources(this.grpMaps, "grpMaps");
            this.grpMaps.BackgroundImage = null;
            this.grpMaps.Controls.Add(this.txtId);
            this.grpMaps.Controls.Add(this.grpGeoLocation);
            this.grpMaps.Controls.Add(this.lblMap2);
            this.grpMaps.Controls.Add(this.txtMap2);
            this.grpMaps.Controls.Add(this.lblMap1);
            this.grpMaps.Controls.Add(this.txtMap1);
            this.grpMaps.Font = null;
            this.grpMaps.Name = "grpMaps";
            this.grpMaps.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.AccessibleDescription = null;
            this.txtId.AccessibleName = null;
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.BackgroundImage = null;
            this.txtId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "IdAddresses", true));
            this.txtId.Font = null;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            // 
            // bsAddress
            // 
            this.bsAddress.DataSource = typeof(Territories.Model.Address);
            this.bsAddress.CurrentItemChanged += new System.EventHandler(this.HaveChanges);
            // 
            // grpGeoLocation
            // 
            this.grpGeoLocation.AccessibleDescription = null;
            this.grpGeoLocation.AccessibleName = null;
            resources.ApplyResources(this.grpGeoLocation, "grpGeoLocation");
            this.grpGeoLocation.BackgroundImage = null;
            this.grpGeoLocation.Controls.Add(this.btnSearchGeoPos);
            this.grpGeoLocation.Controls.Add(this.chkHaveGeoPos);
            this.grpGeoLocation.Controls.Add(this.lblLon);
            this.grpGeoLocation.Controls.Add(this.lblLat);
            this.grpGeoLocation.Controls.Add(this.txtLon);
            this.grpGeoLocation.Controls.Add(this.txtLat);
            this.grpGeoLocation.Font = null;
            this.grpGeoLocation.Name = "grpGeoLocation";
            this.grpGeoLocation.TabStop = false;
            // 
            // btnSearchGeoPos
            // 
            this.btnSearchGeoPos.AccessibleDescription = null;
            this.btnSearchGeoPos.AccessibleName = null;
            resources.ApplyResources(this.btnSearchGeoPos, "btnSearchGeoPos");
            this.btnSearchGeoPos.BackgroundImage = null;
            this.btnSearchGeoPos.Font = null;
            this.btnSearchGeoPos.Name = "btnSearchGeoPos";
            this.btnSearchGeoPos.UseVisualStyleBackColor = true;
            this.btnSearchGeoPos.Click += new System.EventHandler(this.btnSearchGeoPos_Click);
            // 
            // chkHaveGeoPos
            // 
            this.chkHaveGeoPos.AccessibleDescription = null;
            this.chkHaveGeoPos.AccessibleName = null;
            resources.ApplyResources(this.chkHaveGeoPos, "chkHaveGeoPos");
            this.chkHaveGeoPos.BackgroundImage = null;
            this.chkHaveGeoPos.Font = null;
            this.chkHaveGeoPos.Name = "chkHaveGeoPos";
            this.chkHaveGeoPos.UseVisualStyleBackColor = true;
            this.chkHaveGeoPos.CheckedChanged += new System.EventHandler(this.chkHaveGeoPos_CheckedChanged);
            // 
            // lblLon
            // 
            this.lblLon.AccessibleDescription = null;
            this.lblLon.AccessibleName = null;
            resources.ApplyResources(this.lblLon, "lblLon");
            this.lblLon.Font = null;
            this.lblLon.Name = "lblLon";
            // 
            // lblLat
            // 
            this.lblLat.AccessibleDescription = null;
            this.lblLat.AccessibleName = null;
            resources.ApplyResources(this.lblLat, "lblLat");
            this.lblLat.Font = null;
            this.lblLat.Name = "lblLat";
            // 
            // txtLon
            // 
            this.txtLon.AccessibleDescription = null;
            this.txtLon.AccessibleName = null;
            resources.ApplyResources(this.txtLon, "txtLon");
            this.txtLon.BackgroundImage = null;
            this.txtLon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Lng", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLon.Font = null;
            this.txtLon.Name = "txtLon";
            this.txtLon.TextChanged += new System.EventHandler(this.HaveChanges);
            // 
            // txtLat
            // 
            this.txtLat.AccessibleDescription = null;
            this.txtLat.AccessibleName = null;
            resources.ApplyResources(this.txtLat, "txtLat");
            this.txtLat.BackgroundImage = null;
            this.txtLat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Lat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLat.Font = null;
            this.txtLat.Name = "txtLat";
            this.txtLat.TextChanged += new System.EventHandler(this.HaveChanges);
            // 
            // lblMap2
            // 
            this.lblMap2.AccessibleDescription = null;
            this.lblMap2.AccessibleName = null;
            resources.ApplyResources(this.lblMap2, "lblMap2");
            this.lblMap2.Font = null;
            this.lblMap2.Name = "lblMap2";
            // 
            // txtMap2
            // 
            this.txtMap2.AccessibleDescription = null;
            this.txtMap2.AccessibleName = null;
            resources.ApplyResources(this.txtMap2, "txtMap2");
            this.txtMap2.BackgroundImage = null;
            this.txtMap2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Map2", true));
            this.txtMap2.Font = null;
            this.txtMap2.Name = "txtMap2";
            // 
            // lblMap1
            // 
            this.lblMap1.AccessibleDescription = null;
            this.lblMap1.AccessibleName = null;
            resources.ApplyResources(this.lblMap1, "lblMap1");
            this.lblMap1.Font = null;
            this.lblMap1.Name = "lblMap1";
            // 
            // txtMap1
            // 
            this.txtMap1.AccessibleDescription = null;
            this.txtMap1.AccessibleName = null;
            resources.ApplyResources(this.txtMap1, "txtMap1");
            this.txtMap1.BackgroundImage = null;
            this.txtMap1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Map1", true));
            this.txtMap1.Font = null;
            this.txtMap1.Name = "txtMap1";
            // 
            // lblDescription
            // 
            this.lblDescription.AccessibleDescription = null;
            this.lblDescription.AccessibleName = null;
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Font = null;
            this.lblDescription.Name = "lblDescription";
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleDescription = null;
            this.txtDescription.AccessibleName = null;
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.BackgroundImage = null;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Description", true));
            this.txtDescription.Font = null;
            this.txtDescription.Name = "txtDescription";
            // 
            // grpPhones
            // 
            this.grpPhones.AccessibleDescription = null;
            this.grpPhones.AccessibleName = null;
            resources.ApplyResources(this.grpPhones, "grpPhones");
            this.grpPhones.BackgroundImage = null;
            this.grpPhones.Controls.Add(this.lblPhone2);
            this.grpPhones.Controls.Add(this.lblPhone1);
            this.grpPhones.Controls.Add(this.txtPhone2);
            this.grpPhones.Controls.Add(this.txtPhone1);
            this.grpPhones.Font = null;
            this.grpPhones.Name = "grpPhones";
            this.grpPhones.TabStop = false;
            // 
            // lblPhone2
            // 
            this.lblPhone2.AccessibleDescription = null;
            this.lblPhone2.AccessibleName = null;
            resources.ApplyResources(this.lblPhone2, "lblPhone2");
            this.lblPhone2.Font = null;
            this.lblPhone2.Name = "lblPhone2";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AccessibleDescription = null;
            this.lblPhone1.AccessibleName = null;
            resources.ApplyResources(this.lblPhone1, "lblPhone1");
            this.lblPhone1.Font = null;
            this.lblPhone1.Name = "lblPhone1";
            // 
            // txtPhone2
            // 
            this.txtPhone2.AccessibleDescription = null;
            this.txtPhone2.AccessibleName = null;
            resources.ApplyResources(this.txtPhone2, "txtPhone2");
            this.txtPhone2.BackgroundImage = null;
            this.txtPhone2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Phone2", true));
            this.txtPhone2.Font = null;
            this.txtPhone2.Name = "txtPhone2";
            // 
            // txtPhone1
            // 
            this.txtPhone1.AccessibleDescription = null;
            this.txtPhone1.AccessibleName = null;
            resources.ApplyResources(this.txtPhone1, "txtPhone1");
            this.txtPhone1.BackgroundImage = null;
            this.txtPhone1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Phone1", true));
            this.txtPhone1.Font = null;
            this.txtPhone1.Name = "txtPhone1";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = null;
            this.btnSave.Font = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpUbication
            // 
            this.grpUbication.AccessibleDescription = null;
            this.grpUbication.AccessibleName = null;
            resources.ApplyResources(this.grpUbication, "grpUbication");
            this.grpUbication.BackgroundImage = null;
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
            this.grpUbication.Font = null;
            this.grpUbication.Name = "grpUbication";
            this.grpUbication.TabStop = false;
            // 
            // lblAddressData
            // 
            this.lblAddressData.AccessibleDescription = null;
            this.lblAddressData.AccessibleName = null;
            resources.ApplyResources(this.lblAddressData, "lblAddressData");
            this.lblAddressData.Font = null;
            this.lblAddressData.Name = "lblAddressData";
            // 
            // txtAddressData
            // 
            this.txtAddressData.AccessibleDescription = null;
            this.txtAddressData.AccessibleName = null;
            resources.ApplyResources(this.txtAddressData, "txtAddressData");
            this.txtAddressData.BackgroundImage = null;
            this.txtAddressData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "AddressData", true));
            this.txtAddressData.Font = null;
            this.txtAddressData.Name = "txtAddressData";
            // 
            // lblNumber
            // 
            this.lblNumber.AccessibleDescription = null;
            this.lblNumber.AccessibleName = null;
            resources.ApplyResources(this.lblNumber, "lblNumber");
            this.lblNumber.Font = null;
            this.lblNumber.Name = "lblNumber";
            // 
            // lblCity
            // 
            this.lblCity.AccessibleDescription = null;
            this.lblCity.AccessibleName = null;
            resources.ApplyResources(this.lblCity, "lblCity");
            this.lblCity.Font = null;
            this.lblCity.Name = "lblCity";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AccessibleDescription = null;
            this.lblDepartment.AccessibleName = null;
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Font = null;
            this.lblDepartment.Name = "lblDepartment";
            // 
            // lblCorner2
            // 
            this.lblCorner2.AccessibleDescription = null;
            this.lblCorner2.AccessibleName = null;
            resources.ApplyResources(this.lblCorner2, "lblCorner2");
            this.lblCorner2.Font = null;
            this.lblCorner2.Name = "lblCorner2";
            // 
            // lblCorner1
            // 
            this.lblCorner1.AccessibleDescription = null;
            this.lblCorner1.AccessibleName = null;
            resources.ApplyResources(this.lblCorner1, "lblCorner1");
            this.lblCorner1.Font = null;
            this.lblCorner1.Name = "lblCorner1";
            // 
            // lblStreet
            // 
            this.lblStreet.AccessibleDescription = null;
            this.lblStreet.AccessibleName = null;
            resources.ApplyResources(this.lblStreet, "lblStreet");
            this.lblStreet.Font = null;
            this.lblStreet.Name = "lblStreet";
            // 
            // txtCorner2
            // 
            this.txtCorner2.AccessibleDescription = null;
            this.txtCorner2.AccessibleName = null;
            resources.ApplyResources(this.txtCorner2, "txtCorner2");
            this.txtCorner2.BackgroundImage = null;
            this.txtCorner2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Corner2", true));
            this.txtCorner2.Font = null;
            this.txtCorner2.Name = "txtCorner2";
            // 
            // txtCorner1
            // 
            this.txtCorner1.AccessibleDescription = null;
            this.txtCorner1.AccessibleName = null;
            resources.ApplyResources(this.txtCorner1, "txtCorner1");
            this.txtCorner1.BackgroundImage = null;
            this.txtCorner1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Corner1", true));
            this.txtCorner1.Font = null;
            this.txtCorner1.Name = "txtCorner1";
            // 
            // txtNumber
            // 
            this.txtNumber.AccessibleDescription = null;
            this.txtNumber.AccessibleName = null;
            resources.ApplyResources(this.txtNumber, "txtNumber");
            this.txtNumber.BackgroundImage = null;
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Number", true));
            this.txtNumber.Font = null;
            this.txtNumber.Name = "txtNumber";
            // 
            // cboCity
            // 
            this.cboCity.AccessibleDescription = null;
            this.cboCity.AccessibleName = null;
            resources.ApplyResources(this.cboCity, "cboCity");
            this.cboCity.BackgroundImage = null;
            this.cboCity.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAddress, "City.IdCity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "City.Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.Font = null;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Name = "cboCity";
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.HaveChanges);
            // 
            // cboDepartment
            // 
            this.cboDepartment.AccessibleDescription = null;
            this.cboDepartment.AccessibleName = null;
            resources.ApplyResources(this.cboDepartment, "cboDepartment");
            this.cboDepartment.BackgroundImage = null;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = null;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // txtStreet
            // 
            this.txtStreet.AccessibleDescription = null;
            this.txtStreet.AccessibleName = null;
            resources.ApplyResources(this.txtStreet, "txtStreet");
            this.txtStreet.BackgroundImage = null;
            this.txtStreet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Street", true));
            this.txtStreet.Font = null;
            this.txtStreet.Name = "txtStreet";
            // 
            // txtField1
            // 
            this.txtField1.AccessibleDescription = null;
            this.txtField1.AccessibleName = null;
            resources.ApplyResources(this.txtField1, "txtField1");
            this.txtField1.BackgroundImage = null;
            this.txtField1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "CustomField1", true));
            this.txtField1.Font = null;
            this.txtField1.Name = "txtField1";
            // 
            // lblField1
            // 
            this.lblField1.AccessibleDescription = null;
            this.lblField1.AccessibleName = null;
            resources.ApplyResources(this.lblField1, "lblField1");
            this.lblField1.Font = null;
            this.lblField1.Name = "lblField1";
            // 
            // grpTerritory
            // 
            this.grpTerritory.AccessibleDescription = null;
            this.grpTerritory.AccessibleName = null;
            resources.ApplyResources(this.grpTerritory, "grpTerritory");
            this.grpTerritory.BackgroundImage = null;
            this.grpTerritory.Controls.Add(this.cboTerritory);
            this.grpTerritory.Font = null;
            this.grpTerritory.Name = "grpTerritory";
            this.grpTerritory.TabStop = false;
            // 
            // cboTerritory
            // 
            this.cboTerritory.AccessibleDescription = null;
            this.cboTerritory.AccessibleName = null;
            resources.ApplyResources(this.cboTerritory, "cboTerritory");
            this.cboTerritory.BackgroundImage = null;
            this.cboTerritory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAddress, "Territory.IdTerritory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboTerritory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Territory.Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerritory.Font = null;
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Name = "cboTerritory";
            this.cboTerritory.SelectedIndexChanged += new System.EventHandler(this.HaveChanges);
            // 
            // grpAdditional
            // 
            this.grpAdditional.AccessibleDescription = null;
            this.grpAdditional.AccessibleName = null;
            resources.ApplyResources(this.grpAdditional, "grpAdditional");
            this.grpAdditional.BackgroundImage = null;
            this.grpAdditional.Controls.Add(this.lblDescription);
            this.grpAdditional.Controls.Add(this.txtDescription);
            this.grpAdditional.Controls.Add(this.lblField1);
            this.grpAdditional.Controls.Add(this.txtField1);
            this.grpAdditional.Font = null;
            this.grpAdditional.Name = "grpAdditional";
            this.grpAdditional.TabStop = false;
            // 
            // frmAddress
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.grpAdditional);
            this.Controls.Add(this.grpTerritory);
            this.Controls.Add(this.grpUbication);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpPhones);
            this.Controls.Add(this.grpMaps);
            this.Font = null;
            this.Icon = null;
            this.Name = "frmAddress";
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


    }
}