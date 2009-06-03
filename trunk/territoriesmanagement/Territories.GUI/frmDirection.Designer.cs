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
            this.grpUbication = new System.Windows.Forms.GroupBox();
            this.lblMap2 = new System.Windows.Forms.Label();
            this.txtMap2 = new System.Windows.Forms.TextBox();
            this.lblMap1 = new System.Windows.Forms.Label();
            this.txtMap1 = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCorner2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.cboTerritory = new System.Windows.Forms.ComboBox();
            this.txtCorner2 = new System.Windows.Forms.TextBox();
            this.txtCorner1 = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.cboCities = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.grpGeoLocation = new System.Windows.Forms.GroupBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblLat = new System.Windows.Forms.Label();
            this.lblLon = new System.Windows.Forms.Label();
            this.grpPhones = new System.Windows.Forms.GroupBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bsDepartment = new System.Windows.Forms.BindingSource(this.components);
            this.grpUbication.SuspendLayout();
            this.grpGeoLocation.SuspendLayout();
            this.grpPhones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // grpUbication
            // 
            this.grpUbication.Controls.Add(this.grpGeoLocation);
            this.grpUbication.Controls.Add(this.lblMap2);
            this.grpUbication.Controls.Add(this.txtMap2);
            this.grpUbication.Controls.Add(this.lblMap1);
            this.grpUbication.Controls.Add(this.txtMap1);
            this.grpUbication.Location = new System.Drawing.Point(463, 12);
            this.grpUbication.Name = "grpUbication";
            this.grpUbication.Size = new System.Drawing.Size(266, 255);
            this.grpUbication.TabIndex = 40;
            this.grpUbication.TabStop = false;
            this.grpUbication.Text = "Ubication";
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
            this.txtMap2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Map2", true));
            this.txtMap2.Location = new System.Drawing.Point(26, 81);
            this.txtMap2.Name = "txtMap2";
            this.txtMap2.Size = new System.Drawing.Size(220, 20);
            this.txtMap2.TabIndex = 2;
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
            this.txtMap1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Map1", true));
            this.txtMap1.Location = new System.Drawing.Point(26, 37);
            this.txtMap1.Name = "txtMap1";
            this.txtMap1.Size = new System.Drawing.Size(220, 20);
            this.txtMap1.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 283);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 39;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(12, 299);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(316, 227);
            this.txtDescription.TabIndex = 38;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(354, 103);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 37;
            this.lblNumber.Text = "Number";
            // 
            // lblTerritory
            // 
            this.lblTerritory.AutoSize = true;
            this.lblTerritory.Location = new System.Drawing.Point(9, 234);
            this.lblTerritory.Name = "lblTerritory";
            this.lblTerritory.Size = new System.Drawing.Size(45, 13);
            this.lblTerritory.TabIndex = 36;
            this.lblTerritory.Text = "Territory";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(9, 56);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 35;
            this.lblCity.Text = "City";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(9, 12);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 34;
            this.lblDepartment.Text = "Department";
            // 
            // lblCorner2
            // 
            this.lblCorner2.AutoSize = true;
            this.lblCorner2.Location = new System.Drawing.Point(9, 190);
            this.lblCorner2.Name = "lblCorner2";
            this.lblCorner2.Size = new System.Drawing.Size(47, 13);
            this.lblCorner2.TabIndex = 33;
            this.lblCorner2.Text = "Corner 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Corner 1";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(9, 103);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(35, 13);
            this.lblStreet.TabIndex = 31;
            this.lblStreet.Text = "Street";
            // 
            // cboTerritory
            // 
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Location = new System.Drawing.Point(12, 250);
            this.cboTerritory.Name = "cboTerritory";
            this.cboTerritory.Size = new System.Drawing.Size(316, 21);
            this.cboTerritory.TabIndex = 30;
            // 
            // txtCorner2
            // 
            this.txtCorner2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Corner2", true));
            this.txtCorner2.Location = new System.Drawing.Point(12, 206);
            this.txtCorner2.Name = "txtCorner2";
            this.txtCorner2.Size = new System.Drawing.Size(316, 20);
            this.txtCorner2.TabIndex = 29;
            // 
            // txtCorner1
            // 
            this.txtCorner1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Corner1", true));
            this.txtCorner1.Location = new System.Drawing.Point(12, 162);
            this.txtCorner1.Name = "txtCorner1";
            this.txtCorner1.Size = new System.Drawing.Size(316, 20);
            this.txtCorner1.TabIndex = 28;
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Number", true));
            this.txtNumber.Location = new System.Drawing.Point(357, 118);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 27;
            // 
            // cboCities
            // 
            this.cboCities.FormattingEnabled = true;
            this.cboCities.Location = new System.Drawing.Point(12, 73);
            this.cboCities.Name = "cboCities";
            this.cboCities.Size = new System.Drawing.Size(316, 21);
            this.cboCities.TabIndex = 26;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(12, 28);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(316, 21);
            this.cboDepartment.TabIndex = 25;
            // 
            // txtStreet
            // 
            this.txtStreet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Street", true));
            this.txtStreet.Location = new System.Drawing.Point(12, 118);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(316, 20);
            this.txtStreet.TabIndex = 24;
            // 
            // grpGeoLocation
            // 
            this.grpGeoLocation.Controls.Add(this.lblLon);
            this.grpGeoLocation.Controls.Add(this.lblLat);
            this.grpGeoLocation.Controls.Add(this.textBox2);
            this.grpGeoLocation.Controls.Add(this.txtLat);
            this.grpGeoLocation.Location = new System.Drawing.Point(26, 113);
            this.grpGeoLocation.Name = "grpGeoLocation";
            this.grpGeoLocation.Size = new System.Drawing.Size(220, 125);
            this.grpGeoLocation.TabIndex = 4;
            this.grpGeoLocation.TabStop = false;
            this.grpGeoLocation.Text = "Geo location";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(23, 40);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(176, 20);
            this.txtLat.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(23, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 20);
            this.textBox2.TabIndex = 1;
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
            // lblLon
            // 
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new System.Drawing.Point(20, 64);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(54, 13);
            this.lblLon.TabIndex = 3;
            this.lblLon.Text = "Longitude";
            // 
            // grpPhones
            // 
            this.grpPhones.Controls.Add(this.lblPhone2);
            this.grpPhones.Controls.Add(this.lblPhone1);
            this.grpPhones.Controls.Add(this.txtPhone2);
            this.grpPhones.Controls.Add(this.txtPhone1);
            this.grpPhones.Location = new System.Drawing.Point(463, 283);
            this.grpPhones.Name = "grpPhones";
            this.grpPhones.Size = new System.Drawing.Size(266, 124);
            this.grpPhones.TabIndex = 41;
            this.grpPhones.TabStop = false;
            this.grpPhones.Text = "Phones";
            // 
            // txtPhone1
            // 
            this.txtPhone1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Phone1", true));
            this.txtPhone1.Location = new System.Drawing.Point(26, 39);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(220, 20);
            this.txtPhone1.TabIndex = 0;
            // 
            // txtPhone2
            // 
            this.txtPhone2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDepartment, "Phone2", true));
            this.txtPhone2.Location = new System.Drawing.Point(26, 83);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(220, 20);
            this.txtPhone2.TabIndex = 1;
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
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Location = new System.Drawing.Point(23, 67);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblPhone2.TabIndex = 3;
            this.lblPhone2.Text = "Phone 2";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(540, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 55);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(643, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 55);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // bsDepartment
            // 
            this.bsDepartment.DataSource = typeof(Territories.Model.Direction);
            this.bsDepartment.CurrentChanged += new System.EventHandler(this.bsDepartment_CurrentChanged);
            // 
            // frmDirection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 538);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpPhones);
            this.Controls.Add(this.grpUbication);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblTerritory);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblCorner2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.cboTerritory);
            this.Controls.Add(this.txtCorner2);
            this.Controls.Add(this.txtCorner1);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.cboCities);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.txtStreet);
            this.Name = "frmDirection";
            this.Text = "frmDirection";
            this.grpUbication.ResumeLayout(false);
            this.grpUbication.PerformLayout();
            this.grpGeoLocation.ResumeLayout(false);
            this.grpGeoLocation.PerformLayout();
            this.grpPhones.ResumeLayout(false);
            this.grpPhones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUbication;
        private System.Windows.Forms.GroupBox grpGeoLocation;
        private System.Windows.Forms.Label lblMap2;
        private System.Windows.Forms.TextBox txtMap2;
        private System.Windows.Forms.Label lblMap1;
        private System.Windows.Forms.TextBox txtMap1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblTerritory;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCorner2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.ComboBox cboTerritory;
        private System.Windows.Forms.TextBox txtCorner2;
        private System.Windows.Forms.TextBox txtCorner1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ComboBox cboCities;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.GroupBox grpPhones;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Label lblPhone1;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource bsDepartment;


    }
}