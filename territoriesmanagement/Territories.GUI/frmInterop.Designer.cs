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
            this.btnImport = new System.Windows.Forms.Button();
            this.grpTerritories = new System.Windows.Forms.GroupBox();
            this.txtTerritoryName = new System.Windows.Forms.TextBox();
            this.chkTerritoryName = new System.Windows.Forms.CheckBox();
            this.txtIdTerritory = new System.Windows.Forms.TextBox();
            this.chkIdTerritory = new System.Windows.Forms.CheckBox();
            this.txtTerritories = new System.Windows.Forms.TextBox();
            this.chkTerritories = new System.Windows.Forms.CheckBox();
            this.grpCities = new System.Windows.Forms.GroupBox();
            this.txtCities = new System.Windows.Forms.TextBox();
            this.chkCities = new System.Windows.Forms.CheckBox();
            this.txtIdCity = new System.Windows.Forms.TextBox();
            this.chkIdCity = new System.Windows.Forms.CheckBox();
            this.chkCityName = new System.Windows.Forms.CheckBox();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.chkCityDepartment = new System.Windows.Forms.CheckBox();
            this.txtCityDepartment = new System.Windows.Forms.TextBox();
            this.grpDepartments = new System.Windows.Forms.GroupBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.chkDepartmentName = new System.Windows.Forms.CheckBox();
            this.txtIdDepartment = new System.Windows.Forms.TextBox();
            this.chkIdDepartment = new System.Windows.Forms.CheckBox();
            this.txtDepartments = new System.Windows.Forms.TextBox();
            this.chkDepartments = new System.Windows.Forms.CheckBox();
            this.grpDirections = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.txtGeoposition = new System.Windows.Forms.TextBox();
            this.chkGeoposition = new System.Windows.Forms.CheckBox();
            this.txtMap2 = new System.Windows.Forms.TextBox();
            this.chkMap2 = new System.Windows.Forms.CheckBox();
            this.txtMap1 = new System.Windows.Forms.TextBox();
            this.chkMap1 = new System.Windows.Forms.CheckBox();
            this.txtDirectionTerritory = new System.Windows.Forms.TextBox();
            this.chkDirectionTerritory = new System.Windows.Forms.CheckBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.chkPhone2 = new System.Windows.Forms.CheckBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.chkPhone1 = new System.Windows.Forms.CheckBox();
            this.txtDirectionCity = new System.Windows.Forms.TextBox();
            this.chkDirectionCity = new System.Windows.Forms.CheckBox();
            this.txtCorner2 = new System.Windows.Forms.TextBox();
            this.chkCorner2 = new System.Windows.Forms.CheckBox();
            this.txtCorner1 = new System.Windows.Forms.TextBox();
            this.chkCorner1 = new System.Windows.Forms.CheckBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.chkNumber = new System.Windows.Forms.CheckBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.chkStreet = new System.Windows.Forms.CheckBox();
            this.txtIdDirection = new System.Windows.Forms.TextBox();
            this.chkIdDirection = new System.Windows.Forms.CheckBox();
            this.txtDirections = new System.Windows.Forms.TextBox();
            this.chkDirections = new System.Windows.Forms.CheckBox();
            this.odfRssSource = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPanel.SuspendLayout();
            this.tabGeoRss.SuspendLayout();
            this.tabDataImport.SuspendLayout();
            this.grpTerritories.SuspendLayout();
            this.grpCities.SuspendLayout();
            this.grpDepartments.SuspendLayout();
            this.grpDirections.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabGeoRss);
            this.tabPanel.Controls.Add(this.tabDataImport);
            this.tabPanel.Controls.Add(this.tabPage1);
            this.tabPanel.Location = new System.Drawing.Point(8, 11);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(767, 665);
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
            this.tabGeoRss.Size = new System.Drawing.Size(759, 639);
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
            this.tabDataImport.Controls.Add(this.btnImport);
            this.tabDataImport.Controls.Add(this.grpTerritories);
            this.tabDataImport.Controls.Add(this.grpCities);
            this.tabDataImport.Controls.Add(this.grpDepartments);
            this.tabDataImport.Controls.Add(this.grpDirections);
            this.tabDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabDataImport.Name = "tabDataImport";
            this.tabDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataImport.Size = new System.Drawing.Size(759, 639);
            this.tabDataImport.TabIndex = 1;
            this.tabDataImport.Text = "Data import";
            this.tabDataImport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(545, 51);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(113, 23);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "button1";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // grpTerritories
            // 
            this.grpTerritories.Controls.Add(this.txtTerritoryName);
            this.grpTerritories.Controls.Add(this.chkTerritoryName);
            this.grpTerritories.Controls.Add(this.txtIdTerritory);
            this.grpTerritories.Controls.Add(this.chkIdTerritory);
            this.grpTerritories.Controls.Add(this.txtTerritories);
            this.grpTerritories.Controls.Add(this.chkTerritories);
            this.grpTerritories.Location = new System.Drawing.Point(527, 104);
            this.grpTerritories.Name = "grpTerritories";
            this.grpTerritories.Size = new System.Drawing.Size(202, 186);
            this.grpTerritories.TabIndex = 7;
            this.grpTerritories.TabStop = false;
            this.grpTerritories.Text = "Territories";
            // 
            // txtTerritoryName
            // 
            this.txtTerritoryName.Location = new System.Drawing.Point(40, 144);
            this.txtTerritoryName.Name = "txtTerritoryName";
            this.txtTerritoryName.Size = new System.Drawing.Size(141, 20);
            this.txtTerritoryName.TabIndex = 15;
            // 
            // chkTerritoryName
            // 
            this.chkTerritoryName.AutoSize = true;
            this.chkTerritoryName.Location = new System.Drawing.Point(40, 121);
            this.chkTerritoryName.Name = "chkTerritoryName";
            this.chkTerritoryName.Size = new System.Drawing.Size(54, 17);
            this.chkTerritoryName.TabIndex = 14;
            this.chkTerritoryName.Text = "Name";
            this.chkTerritoryName.UseVisualStyleBackColor = true;
            // 
            // txtIdTerritory
            // 
            this.txtIdTerritory.Location = new System.Drawing.Point(40, 95);
            this.txtIdTerritory.Name = "txtIdTerritory";
            this.txtIdTerritory.Size = new System.Drawing.Size(141, 20);
            this.txtIdTerritory.TabIndex = 13;
            // 
            // chkIdTerritory
            // 
            this.chkIdTerritory.AutoSize = true;
            this.chkIdTerritory.Location = new System.Drawing.Point(40, 72);
            this.chkIdTerritory.Name = "chkIdTerritory";
            this.chkIdTerritory.Size = new System.Drawing.Size(73, 17);
            this.chkIdTerritory.TabIndex = 12;
            this.chkIdTerritory.Text = "IdTerritory";
            this.chkIdTerritory.UseVisualStyleBackColor = true;
            // 
            // txtTerritories
            // 
            this.txtTerritories.Location = new System.Drawing.Point(21, 46);
            this.txtTerritories.Name = "txtTerritories";
            this.txtTerritories.Size = new System.Drawing.Size(160, 20);
            this.txtTerritories.TabIndex = 11;
            // 
            // chkTerritories
            // 
            this.chkTerritories.AutoSize = true;
            this.chkTerritories.Location = new System.Drawing.Point(21, 23);
            this.chkTerritories.Name = "chkTerritories";
            this.chkTerritories.Size = new System.Drawing.Size(53, 17);
            this.chkTerritories.TabIndex = 10;
            this.chkTerritories.Text = "Table";
            this.chkTerritories.UseVisualStyleBackColor = true;
            // 
            // grpCities
            // 
            this.grpCities.Controls.Add(this.txtCities);
            this.grpCities.Controls.Add(this.chkCities);
            this.grpCities.Controls.Add(this.txtIdCity);
            this.grpCities.Controls.Add(this.chkIdCity);
            this.grpCities.Controls.Add(this.chkCityName);
            this.grpCities.Controls.Add(this.txtCityName);
            this.grpCities.Controls.Add(this.chkCityDepartment);
            this.grpCities.Controls.Add(this.txtCityDepartment);
            this.grpCities.Location = new System.Drawing.Point(265, 103);
            this.grpCities.Name = "grpCities";
            this.grpCities.Size = new System.Drawing.Size(202, 228);
            this.grpCities.TabIndex = 6;
            this.grpCities.TabStop = false;
            this.grpCities.Text = "Cities";
            // 
            // txtCities
            // 
            this.txtCities.Location = new System.Drawing.Point(21, 46);
            this.txtCities.Name = "txtCities";
            this.txtCities.Size = new System.Drawing.Size(160, 20);
            this.txtCities.TabIndex = 11;
            // 
            // chkCities
            // 
            this.chkCities.AutoSize = true;
            this.chkCities.Location = new System.Drawing.Point(21, 23);
            this.chkCities.Name = "chkCities";
            this.chkCities.Size = new System.Drawing.Size(53, 17);
            this.chkCities.TabIndex = 10;
            this.chkCities.Text = "Table";
            this.chkCities.UseVisualStyleBackColor = true;
            // 
            // txtIdCity
            // 
            this.txtIdCity.Location = new System.Drawing.Point(40, 95);
            this.txtIdCity.Name = "txtIdCity";
            this.txtIdCity.Size = new System.Drawing.Size(141, 20);
            this.txtIdCity.TabIndex = 13;
            // 
            // chkIdCity
            // 
            this.chkIdCity.AutoSize = true;
            this.chkIdCity.Location = new System.Drawing.Point(40, 72);
            this.chkIdCity.Name = "chkIdCity";
            this.chkIdCity.Size = new System.Drawing.Size(52, 17);
            this.chkIdCity.TabIndex = 12;
            this.chkIdCity.Text = "IdCity";
            this.chkIdCity.UseVisualStyleBackColor = true;
            // 
            // chkCityName
            // 
            this.chkCityName.AutoSize = true;
            this.chkCityName.Location = new System.Drawing.Point(40, 121);
            this.chkCityName.Name = "chkCityName";
            this.chkCityName.Size = new System.Drawing.Size(54, 17);
            this.chkCityName.TabIndex = 14;
            this.chkCityName.Text = "Name";
            this.chkCityName.UseVisualStyleBackColor = true;
            // 
            // txtCityName
            // 
            this.txtCityName.Location = new System.Drawing.Point(40, 144);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(141, 20);
            this.txtCityName.TabIndex = 15;
            // 
            // chkCityDepartment
            // 
            this.chkCityDepartment.AutoSize = true;
            this.chkCityDepartment.Location = new System.Drawing.Point(40, 170);
            this.chkCityDepartment.Name = "chkCityDepartment";
            this.chkCityDepartment.Size = new System.Drawing.Size(81, 17);
            this.chkCityDepartment.TabIndex = 16;
            this.chkCityDepartment.Text = "Department";
            this.chkCityDepartment.UseVisualStyleBackColor = true;
            // 
            // txtCityDepartment
            // 
            this.txtCityDepartment.Location = new System.Drawing.Point(40, 193);
            this.txtCityDepartment.Name = "txtCityDepartment";
            this.txtCityDepartment.Size = new System.Drawing.Size(141, 20);
            this.txtCityDepartment.TabIndex = 17;
            // 
            // grpDepartments
            // 
            this.grpDepartments.Controls.Add(this.txtDepartmentName);
            this.grpDepartments.Controls.Add(this.chkDepartmentName);
            this.grpDepartments.Controls.Add(this.txtIdDepartment);
            this.grpDepartments.Controls.Add(this.chkIdDepartment);
            this.grpDepartments.Controls.Add(this.txtDepartments);
            this.grpDepartments.Controls.Add(this.chkDepartments);
            this.grpDepartments.Location = new System.Drawing.Point(3, 103);
            this.grpDepartments.Name = "grpDepartments";
            this.grpDepartments.Size = new System.Drawing.Size(202, 186);
            this.grpDepartments.TabIndex = 5;
            this.grpDepartments.TabStop = false;
            this.grpDepartments.Text = "Departments";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(40, 144);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(141, 20);
            this.txtDepartmentName.TabIndex = 15;
            // 
            // chkDepartmentName
            // 
            this.chkDepartmentName.AutoSize = true;
            this.chkDepartmentName.Location = new System.Drawing.Point(40, 121);
            this.chkDepartmentName.Name = "chkDepartmentName";
            this.chkDepartmentName.Size = new System.Drawing.Size(54, 17);
            this.chkDepartmentName.TabIndex = 14;
            this.chkDepartmentName.Text = "Name";
            this.chkDepartmentName.UseVisualStyleBackColor = true;
            // 
            // txtIdDepartment
            // 
            this.txtIdDepartment.Location = new System.Drawing.Point(40, 95);
            this.txtIdDepartment.Name = "txtIdDepartment";
            this.txtIdDepartment.Size = new System.Drawing.Size(141, 20);
            this.txtIdDepartment.TabIndex = 13;
            // 
            // chkIdDepartment
            // 
            this.chkIdDepartment.AutoSize = true;
            this.chkIdDepartment.Location = new System.Drawing.Point(40, 72);
            this.chkIdDepartment.Name = "chkIdDepartment";
            this.chkIdDepartment.Size = new System.Drawing.Size(87, 17);
            this.chkIdDepartment.TabIndex = 12;
            this.chkIdDepartment.Text = "IdDeparment";
            this.chkIdDepartment.UseVisualStyleBackColor = true;
            // 
            // txtDepartments
            // 
            this.txtDepartments.Location = new System.Drawing.Point(21, 46);
            this.txtDepartments.Name = "txtDepartments";
            this.txtDepartments.Size = new System.Drawing.Size(160, 20);
            this.txtDepartments.TabIndex = 11;
            // 
            // chkDepartments
            // 
            this.chkDepartments.AutoSize = true;
            this.chkDepartments.Location = new System.Drawing.Point(21, 23);
            this.chkDepartments.Name = "chkDepartments";
            this.chkDepartments.Size = new System.Drawing.Size(53, 17);
            this.chkDepartments.TabIndex = 10;
            this.chkDepartments.Text = "Table";
            this.chkDepartments.UseVisualStyleBackColor = true;
            this.chkDepartments.CheckedChanged += new System.EventHandler(this.chkDepartments_CheckedChanged);
            // 
            // grpDirections
            // 
            this.grpDirections.Controls.Add(this.txtDescription);
            this.grpDirections.Controls.Add(this.chkDescription);
            this.grpDirections.Controls.Add(this.txtGeoposition);
            this.grpDirections.Controls.Add(this.chkGeoposition);
            this.grpDirections.Controls.Add(this.txtMap2);
            this.grpDirections.Controls.Add(this.chkMap2);
            this.grpDirections.Controls.Add(this.txtMap1);
            this.grpDirections.Controls.Add(this.chkMap1);
            this.grpDirections.Controls.Add(this.txtDirectionTerritory);
            this.grpDirections.Controls.Add(this.chkDirectionTerritory);
            this.grpDirections.Controls.Add(this.txtPhone2);
            this.grpDirections.Controls.Add(this.chkPhone2);
            this.grpDirections.Controls.Add(this.txtPhone1);
            this.grpDirections.Controls.Add(this.chkPhone1);
            this.grpDirections.Controls.Add(this.txtDirectionCity);
            this.grpDirections.Controls.Add(this.chkDirectionCity);
            this.grpDirections.Controls.Add(this.txtCorner2);
            this.grpDirections.Controls.Add(this.chkCorner2);
            this.grpDirections.Controls.Add(this.txtCorner1);
            this.grpDirections.Controls.Add(this.chkCorner1);
            this.grpDirections.Controls.Add(this.txtNumber);
            this.grpDirections.Controls.Add(this.chkNumber);
            this.grpDirections.Controls.Add(this.txtStreet);
            this.grpDirections.Controls.Add(this.chkStreet);
            this.grpDirections.Controls.Add(this.txtIdDirection);
            this.grpDirections.Controls.Add(this.chkIdDirection);
            this.grpDirections.Controls.Add(this.txtDirections);
            this.grpDirections.Controls.Add(this.chkDirections);
            this.grpDirections.Location = new System.Drawing.Point(6, 337);
            this.grpDirections.Name = "grpDirections";
            this.grpDirections.Size = new System.Drawing.Size(724, 296);
            this.grpDirections.TabIndex = 4;
            this.grpDirections.TabStop = false;
            this.grpDirections.Text = "Directions";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(563, 96);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(141, 20);
            this.txtDescription.TabIndex = 51;
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.Location = new System.Drawing.Point(563, 73);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Size = new System.Drawing.Size(79, 17);
            this.chkDescription.TabIndex = 50;
            this.chkDescription.Text = "Description";
            this.chkDescription.UseVisualStyleBackColor = true;
            // 
            // txtGeoposition
            // 
            this.txtGeoposition.Location = new System.Drawing.Point(388, 248);
            this.txtGeoposition.Name = "txtGeoposition";
            this.txtGeoposition.Size = new System.Drawing.Size(141, 20);
            this.txtGeoposition.TabIndex = 49;
            // 
            // chkGeoposition
            // 
            this.chkGeoposition.AutoSize = true;
            this.chkGeoposition.Location = new System.Drawing.Point(388, 225);
            this.chkGeoposition.Name = "chkGeoposition";
            this.chkGeoposition.Size = new System.Drawing.Size(82, 17);
            this.chkGeoposition.TabIndex = 48;
            this.chkGeoposition.Text = "Geoposition";
            this.chkGeoposition.UseVisualStyleBackColor = true;
            // 
            // txtMap2
            // 
            this.txtMap2.Location = new System.Drawing.Point(388, 194);
            this.txtMap2.Name = "txtMap2";
            this.txtMap2.Size = new System.Drawing.Size(141, 20);
            this.txtMap2.TabIndex = 47;
            // 
            // chkMap2
            // 
            this.chkMap2.AutoSize = true;
            this.chkMap2.Location = new System.Drawing.Point(388, 171);
            this.chkMap2.Name = "chkMap2";
            this.chkMap2.Size = new System.Drawing.Size(56, 17);
            this.chkMap2.TabIndex = 46;
            this.chkMap2.Text = "Map 2";
            this.chkMap2.UseVisualStyleBackColor = true;
            // 
            // txtMap1
            // 
            this.txtMap1.Location = new System.Drawing.Point(388, 145);
            this.txtMap1.Name = "txtMap1";
            this.txtMap1.Size = new System.Drawing.Size(141, 20);
            this.txtMap1.TabIndex = 45;
            // 
            // chkMap1
            // 
            this.chkMap1.AutoSize = true;
            this.chkMap1.Location = new System.Drawing.Point(388, 122);
            this.chkMap1.Name = "chkMap1";
            this.chkMap1.Size = new System.Drawing.Size(56, 17);
            this.chkMap1.TabIndex = 44;
            this.chkMap1.Text = "Map 1";
            this.chkMap1.UseVisualStyleBackColor = true;
            // 
            // txtDirectionTerritory
            // 
            this.txtDirectionTerritory.Location = new System.Drawing.Point(388, 96);
            this.txtDirectionTerritory.Name = "txtDirectionTerritory";
            this.txtDirectionTerritory.Size = new System.Drawing.Size(141, 20);
            this.txtDirectionTerritory.TabIndex = 43;
            // 
            // chkDirectionTerritory
            // 
            this.chkDirectionTerritory.AutoSize = true;
            this.chkDirectionTerritory.Location = new System.Drawing.Point(388, 73);
            this.chkDirectionTerritory.Name = "chkDirectionTerritory";
            this.chkDirectionTerritory.Size = new System.Drawing.Size(64, 17);
            this.chkDirectionTerritory.TabIndex = 42;
            this.chkDirectionTerritory.Text = "Territory";
            this.chkDirectionTerritory.UseVisualStyleBackColor = true;
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(216, 248);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(141, 20);
            this.txtPhone2.TabIndex = 41;
            // 
            // chkPhone2
            // 
            this.chkPhone2.AutoSize = true;
            this.chkPhone2.Location = new System.Drawing.Point(216, 225);
            this.chkPhone2.Name = "chkPhone2";
            this.chkPhone2.Size = new System.Drawing.Size(66, 17);
            this.chkPhone2.TabIndex = 40;
            this.chkPhone2.Text = "Phone 2";
            this.chkPhone2.UseVisualStyleBackColor = true;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(216, 194);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(141, 20);
            this.txtPhone1.TabIndex = 39;
            // 
            // chkPhone1
            // 
            this.chkPhone1.AutoSize = true;
            this.chkPhone1.Location = new System.Drawing.Point(216, 171);
            this.chkPhone1.Name = "chkPhone1";
            this.chkPhone1.Size = new System.Drawing.Size(66, 17);
            this.chkPhone1.TabIndex = 38;
            this.chkPhone1.Text = "Phone 1";
            this.chkPhone1.UseVisualStyleBackColor = true;
            // 
            // txtDirectionCity
            // 
            this.txtDirectionCity.Location = new System.Drawing.Point(216, 145);
            this.txtDirectionCity.Name = "txtDirectionCity";
            this.txtDirectionCity.Size = new System.Drawing.Size(141, 20);
            this.txtDirectionCity.TabIndex = 37;
            // 
            // chkDirectionCity
            // 
            this.chkDirectionCity.AutoSize = true;
            this.chkDirectionCity.Location = new System.Drawing.Point(216, 122);
            this.chkDirectionCity.Name = "chkDirectionCity";
            this.chkDirectionCity.Size = new System.Drawing.Size(43, 17);
            this.chkDirectionCity.TabIndex = 36;
            this.chkDirectionCity.Text = "City";
            this.chkDirectionCity.UseVisualStyleBackColor = true;
            // 
            // txtCorner2
            // 
            this.txtCorner2.Location = new System.Drawing.Point(216, 96);
            this.txtCorner2.Name = "txtCorner2";
            this.txtCorner2.Size = new System.Drawing.Size(141, 20);
            this.txtCorner2.TabIndex = 35;
            // 
            // chkCorner2
            // 
            this.chkCorner2.AutoSize = true;
            this.chkCorner2.Location = new System.Drawing.Point(216, 73);
            this.chkCorner2.Name = "chkCorner2";
            this.chkCorner2.Size = new System.Drawing.Size(66, 17);
            this.chkCorner2.TabIndex = 34;
            this.chkCorner2.Text = "Corner 2";
            this.chkCorner2.UseVisualStyleBackColor = true;
            // 
            // txtCorner1
            // 
            this.txtCorner1.Location = new System.Drawing.Point(37, 248);
            this.txtCorner1.Name = "txtCorner1";
            this.txtCorner1.Size = new System.Drawing.Size(141, 20);
            this.txtCorner1.TabIndex = 33;
            // 
            // chkCorner1
            // 
            this.chkCorner1.AutoSize = true;
            this.chkCorner1.Location = new System.Drawing.Point(37, 225);
            this.chkCorner1.Name = "chkCorner1";
            this.chkCorner1.Size = new System.Drawing.Size(66, 17);
            this.chkCorner1.TabIndex = 32;
            this.chkCorner1.Text = "Corner 1";
            this.chkCorner1.UseVisualStyleBackColor = true;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(37, 194);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(141, 20);
            this.txtNumber.TabIndex = 31;
            // 
            // chkNumber
            // 
            this.chkNumber.AutoSize = true;
            this.chkNumber.Location = new System.Drawing.Point(37, 171);
            this.chkNumber.Name = "chkNumber";
            this.chkNumber.Size = new System.Drawing.Size(63, 17);
            this.chkNumber.TabIndex = 30;
            this.chkNumber.Text = "Number";
            this.chkNumber.UseVisualStyleBackColor = true;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(37, 145);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(141, 20);
            this.txtStreet.TabIndex = 29;
            // 
            // chkStreet
            // 
            this.chkStreet.AutoSize = true;
            this.chkStreet.Location = new System.Drawing.Point(37, 122);
            this.chkStreet.Name = "chkStreet";
            this.chkStreet.Size = new System.Drawing.Size(54, 17);
            this.chkStreet.TabIndex = 28;
            this.chkStreet.Text = "Street";
            this.chkStreet.UseVisualStyleBackColor = true;
            // 
            // txtIdDirection
            // 
            this.txtIdDirection.Location = new System.Drawing.Point(37, 96);
            this.txtIdDirection.Name = "txtIdDirection";
            this.txtIdDirection.Size = new System.Drawing.Size(141, 20);
            this.txtIdDirection.TabIndex = 27;
            // 
            // chkIdDirection
            // 
            this.chkIdDirection.AutoSize = true;
            this.chkIdDirection.Location = new System.Drawing.Point(37, 73);
            this.chkIdDirection.Name = "chkIdDirection";
            this.chkIdDirection.Size = new System.Drawing.Size(77, 17);
            this.chkIdDirection.TabIndex = 26;
            this.chkIdDirection.Text = "IdDirection";
            this.chkIdDirection.UseVisualStyleBackColor = true;
            // 
            // txtDirections
            // 
            this.txtDirections.Location = new System.Drawing.Point(18, 47);
            this.txtDirections.Name = "txtDirections";
            this.txtDirections.Size = new System.Drawing.Size(160, 20);
            this.txtDirections.TabIndex = 25;
            // 
            // chkDirections
            // 
            this.chkDirections.AutoSize = true;
            this.chkDirections.Location = new System.Drawing.Point(18, 24);
            this.chkDirections.Name = "chkDirections";
            this.chkDirections.Size = new System.Drawing.Size(53, 17);
            this.chkDirections.TabIndex = 24;
            this.chkDirections.Text = "Table";
            this.chkDirections.UseVisualStyleBackColor = true;
            // 
            // odfRssSource
            // 
            this.odfRssSource.Filter = "xml files (*.xml)|*.xml";
            this.odfRssSource.InitialDirectory = "C:\\\\";
            this.odfRssSource.FileOk += new System.ComponentModel.CancelEventHandler(this.odfRssSource_FileOk);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.propertyGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(759, 639);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(0, 191);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.SelectedObject = this.button1;
            this.propertyGrid1.Size = new System.Drawing.Size(753, 442);
            this.propertyGrid1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmInterop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 682);
            this.Controls.Add(this.tabPanel);
            this.Name = "frmInterop";
            this.Text = "frmInterop";
            this.Load += new System.EventHandler(this.frmInterop_Load);
            this.tabPanel.ResumeLayout(false);
            this.tabGeoRss.ResumeLayout(false);
            this.tabGeoRss.PerformLayout();
            this.tabDataImport.ResumeLayout(false);
            this.grpTerritories.ResumeLayout(false);
            this.grpTerritories.PerformLayout();
            this.grpCities.ResumeLayout(false);
            this.grpCities.PerformLayout();
            this.grpDepartments.ResumeLayout(false);
            this.grpDepartments.PerformLayout();
            this.grpDirections.ResumeLayout(false);
            this.grpDirections.PerformLayout();
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpDirections;
        private System.Windows.Forms.TextBox txtCityDepartment;
        private System.Windows.Forms.CheckBox chkCityDepartment;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.CheckBox chkCityName;
        private System.Windows.Forms.TextBox txtIdCity;
        private System.Windows.Forms.CheckBox chkIdCity;
        private System.Windows.Forms.GroupBox grpTerritories;
        private System.Windows.Forms.TextBox txtTerritoryName;
        private System.Windows.Forms.CheckBox chkTerritoryName;
        private System.Windows.Forms.TextBox txtIdTerritory;
        private System.Windows.Forms.CheckBox chkIdTerritory;
        private System.Windows.Forms.TextBox txtTerritories;
        private System.Windows.Forms.CheckBox chkTerritories;
        private System.Windows.Forms.GroupBox grpCities;
        private System.Windows.Forms.TextBox txtCities;
        private System.Windows.Forms.CheckBox chkCities;
        private System.Windows.Forms.GroupBox grpDepartments;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.CheckBox chkDepartmentName;
        private System.Windows.Forms.TextBox txtIdDepartment;
        private System.Windows.Forms.CheckBox chkIdDepartment;
        private System.Windows.Forms.TextBox txtDepartments;
        private System.Windows.Forms.CheckBox chkDepartments;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.CheckBox chkStreet;
        private System.Windows.Forms.TextBox txtIdDirection;
        private System.Windows.Forms.CheckBox chkIdDirection;
        private System.Windows.Forms.TextBox txtDirections;
        private System.Windows.Forms.CheckBox chkDirections;
        private System.Windows.Forms.TextBox txtGeoposition;
        private System.Windows.Forms.CheckBox chkGeoposition;
        private System.Windows.Forms.TextBox txtMap2;
        private System.Windows.Forms.CheckBox chkMap2;
        private System.Windows.Forms.TextBox txtMap1;
        private System.Windows.Forms.CheckBox chkMap1;
        private System.Windows.Forms.TextBox txtDirectionTerritory;
        private System.Windows.Forms.CheckBox chkDirectionTerritory;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.CheckBox chkPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.CheckBox chkPhone1;
        private System.Windows.Forms.TextBox txtDirectionCity;
        private System.Windows.Forms.CheckBox chkDirectionCity;
        private System.Windows.Forms.TextBox txtCorner2;
        private System.Windows.Forms.CheckBox chkCorner2;
        private System.Windows.Forms.TextBox txtCorner1;
        private System.Windows.Forms.CheckBox chkCorner1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.CheckBox chkNumber;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button button1;
    }
}