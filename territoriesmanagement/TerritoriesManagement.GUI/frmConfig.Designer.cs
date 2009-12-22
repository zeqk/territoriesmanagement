namespace TerritoriesManagement.GUI
{
    partial class frmConfig
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
            this.tabConfigs = new System.Windows.Forms.TabControl();
            this.tabCultures = new System.Windows.Forms.TabPage();
            this.grpCulture = new System.Windows.Forms.GroupBox();
            this.cmbCulture = new System.Windows.Forms.ComboBox();
            this.tabMaps = new System.Windows.Forms.TabPage();
            this.grpMaps = new System.Windows.Forms.GroupBox();
            this.cboMapType = new System.Windows.Forms.ComboBox();
            this.tabData = new System.Windows.Forms.TabPage();
            this.chkDepartments = new System.Windows.Forms.CheckBox();
            this.chkCities = new System.Windows.Forms.CheckBox();
            this.chkAddresses = new System.Windows.Forms.CheckBox();
            this.chkTerritories = new System.Windows.Forms.CheckBox();
            this.chkPublishers = new System.Windows.Forms.CheckBox();
            this.chkTours = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabConfigs.SuspendLayout();
            this.tabCultures.SuspendLayout();
            this.grpCulture.SuspendLayout();
            this.tabMaps.SuspendLayout();
            this.grpMaps.SuspendLayout();
            this.tabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConfigs
            // 
            this.tabConfigs.Controls.Add(this.tabCultures);
            this.tabConfigs.Controls.Add(this.tabMaps);
            this.tabConfigs.Controls.Add(this.tabData);
            this.tabConfigs.Location = new System.Drawing.Point(7, 12);
            this.tabConfigs.Name = "tabConfigs";
            this.tabConfigs.SelectedIndex = 0;
            this.tabConfigs.Size = new System.Drawing.Size(316, 189);
            this.tabConfigs.TabIndex = 3;
            // 
            // tabCultures
            // 
            this.tabCultures.Controls.Add(this.grpCulture);
            this.tabCultures.Location = new System.Drawing.Point(4, 22);
            this.tabCultures.Name = "tabCultures";
            this.tabCultures.Padding = new System.Windows.Forms.Padding(3);
            this.tabCultures.Size = new System.Drawing.Size(308, 163);
            this.tabCultures.TabIndex = 1;
            this.tabCultures.Text = "Cultures";
            this.tabCultures.UseVisualStyleBackColor = true;
            // 
            // grpCulture
            // 
            this.grpCulture.Controls.Add(this.cmbCulture);
            this.grpCulture.Location = new System.Drawing.Point(48, 49);
            this.grpCulture.Name = "grpCulture";
            this.grpCulture.Size = new System.Drawing.Size(206, 59);
            this.grpCulture.TabIndex = 1;
            this.grpCulture.TabStop = false;
            this.grpCulture.Text = "Select culture";
            // 
            // cmbCulture
            // 
            this.cmbCulture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCulture.FormattingEnabled = true;
            this.cmbCulture.Location = new System.Drawing.Point(28, 24);
            this.cmbCulture.Name = "cmbCulture";
            this.cmbCulture.Size = new System.Drawing.Size(148, 21);
            this.cmbCulture.TabIndex = 0;
            // 
            // tabMaps
            // 
            this.tabMaps.Controls.Add(this.grpMaps);
            this.tabMaps.Location = new System.Drawing.Point(4, 22);
            this.tabMaps.Name = "tabMaps";
            this.tabMaps.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaps.Size = new System.Drawing.Size(308, 163);
            this.tabMaps.TabIndex = 2;
            this.tabMaps.Text = "Maps";
            this.tabMaps.UseVisualStyleBackColor = true;
            // 
            // grpMaps
            // 
            this.grpMaps.Controls.Add(this.cboMapType);
            this.grpMaps.Location = new System.Drawing.Point(45, 49);
            this.grpMaps.Name = "grpMaps";
            this.grpMaps.Size = new System.Drawing.Size(206, 59);
            this.grpMaps.TabIndex = 2;
            this.grpMaps.TabStop = false;
            this.grpMaps.Text = "Select map type";
            // 
            // cboMapType
            // 
            this.cboMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapType.FormattingEnabled = true;
            this.cboMapType.Location = new System.Drawing.Point(28, 24);
            this.cboMapType.Name = "cboMapType";
            this.cboMapType.Size = new System.Drawing.Size(148, 21);
            this.cboMapType.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.chkDepartments);
            this.tabData.Controls.Add(this.chkCities);
            this.tabData.Controls.Add(this.chkAddresses);
            this.tabData.Controls.Add(this.chkTerritories);
            this.tabData.Controls.Add(this.chkPublishers);
            this.tabData.Controls.Add(this.chkTours);
            this.tabData.Controls.Add(this.btnReset);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(308, 163);
            this.tabData.TabIndex = 0;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // chkDepartments
            // 
            this.chkDepartments.AutoSize = true;
            this.chkDepartments.Location = new System.Drawing.Point(48, 72);
            this.chkDepartments.Name = "chkDepartments";
            this.chkDepartments.Size = new System.Drawing.Size(86, 17);
            this.chkDepartments.TabIndex = 13;
            this.chkDepartments.Text = "Departments";
            this.chkDepartments.UseVisualStyleBackColor = true;
            // 
            // chkCities
            // 
            this.chkCities.AutoSize = true;
            this.chkCities.Location = new System.Drawing.Point(48, 49);
            this.chkCities.Name = "chkCities";
            this.chkCities.Size = new System.Drawing.Size(51, 17);
            this.chkCities.TabIndex = 12;
            this.chkCities.Text = "Cities";
            this.chkCities.UseVisualStyleBackColor = true;
            // 
            // chkAddresses
            // 
            this.chkAddresses.AutoSize = true;
            this.chkAddresses.Location = new System.Drawing.Point(48, 26);
            this.chkAddresses.Name = "chkAddresses";
            this.chkAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkAddresses.TabIndex = 11;
            this.chkAddresses.Text = "Addresses";
            this.chkAddresses.UseVisualStyleBackColor = true;
            // 
            // chkTerritories
            // 
            this.chkTerritories.AutoSize = true;
            this.chkTerritories.Location = new System.Drawing.Point(174, 49);
            this.chkTerritories.Name = "chkTerritories";
            this.chkTerritories.Size = new System.Drawing.Size(72, 17);
            this.chkTerritories.TabIndex = 10;
            this.chkTerritories.Text = "Territories";
            this.chkTerritories.UseVisualStyleBackColor = true;
            // 
            // chkPublishers
            // 
            this.chkPublishers.AutoSize = true;
            this.chkPublishers.Location = new System.Drawing.Point(174, 72);
            this.chkPublishers.Name = "chkPublishers";
            this.chkPublishers.Size = new System.Drawing.Size(74, 17);
            this.chkPublishers.TabIndex = 9;
            this.chkPublishers.Text = "Publishers";
            this.chkPublishers.UseVisualStyleBackColor = true;
            // 
            // chkTours
            // 
            this.chkTours.AutoSize = true;
            this.chkTours.Location = new System.Drawing.Point(174, 26);
            this.chkTours.Name = "chkTours";
            this.chkTours.Size = new System.Drawing.Size(53, 17);
            this.chkTours.TabIndex = 8;
            this.chkTours.Text = "Tours";
            this.chkTours.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(92, 108);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 29);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(140, 210);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 29);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(233, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 251);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tabConfigs);
            this.Name = "frmConfig";
            this.Text = "Confguration";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.tabConfigs.ResumeLayout(false);
            this.tabCultures.ResumeLayout(false);
            this.grpCulture.ResumeLayout(false);
            this.tabMaps.ResumeLayout(false);
            this.grpMaps.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConfigs;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.CheckBox chkDepartments;
        private System.Windows.Forms.CheckBox chkCities;
        private System.Windows.Forms.CheckBox chkAddresses;
        private System.Windows.Forms.CheckBox chkTerritories;
        private System.Windows.Forms.CheckBox chkPublishers;
        private System.Windows.Forms.CheckBox chkTours;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabPage tabCultures;
        private System.Windows.Forms.ComboBox cmbCulture;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpCulture;
        private System.Windows.Forms.TabPage tabMaps;
        private System.Windows.Forms.GroupBox grpMaps;
        private System.Windows.Forms.ComboBox cboMapType;


    }
}