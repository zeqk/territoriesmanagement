namespace TerritoriesManagement.GUI
{
    partial class frmConfigureMap
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
            this.grpAddresses = new System.Windows.Forms.GroupBox();
            this.lblTerritories = new System.Windows.Forms.Label();
            this.lblCities = new System.Windows.Forms.Label();
            this.lblDepartments = new System.Windows.Forms.Label();
            this.chklstDepartment = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.chklstCity = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.chklstTerritory = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.grpTerritories = new System.Windows.Forms.GroupBox();
            this.lblTerritories2 = new System.Windows.Forms.Label();
            this.chklstTerritory2 = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.btnViewMap = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAddresses.SuspendLayout();
            this.grpTerritories.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddresses
            // 
            this.grpAddresses.Controls.Add(this.lblTerritories);
            this.grpAddresses.Controls.Add(this.lblCities);
            this.grpAddresses.Controls.Add(this.lblDepartments);
            this.grpAddresses.Controls.Add(this.chklstDepartment);
            this.grpAddresses.Controls.Add(this.chklstCity);
            this.grpAddresses.Controls.Add(this.chklstTerritory);
            this.grpAddresses.Location = new System.Drawing.Point(12, 113);
            this.grpAddresses.Name = "grpAddresses";
            this.grpAddresses.Size = new System.Drawing.Size(405, 176);
            this.grpAddresses.TabIndex = 71;
            this.grpAddresses.TabStop = false;
            this.grpAddresses.Text = "Select addresses marks to see";
            // 
            // lblTerritories
            // 
            this.lblTerritories.AutoSize = true;
            this.lblTerritories.Location = new System.Drawing.Point(18, 110);
            this.lblTerritories.Name = "lblTerritories";
            this.lblTerritories.Size = new System.Drawing.Size(53, 13);
            this.lblTerritories.TabIndex = 76;
            this.lblTerritories.Text = "Territories";
            // 
            // lblCities
            // 
            this.lblCities.AutoSize = true;
            this.lblCities.Location = new System.Drawing.Point(18, 62);
            this.lblCities.Name = "lblCities";
            this.lblCities.Size = new System.Drawing.Size(32, 13);
            this.lblCities.TabIndex = 75;
            this.lblCities.Text = "Cities";
            // 
            // lblDepartments
            // 
            this.lblDepartments.AutoSize = true;
            this.lblDepartments.Location = new System.Drawing.Point(18, 20);
            this.lblDepartments.Name = "lblDepartments";
            this.lblDepartments.Size = new System.Drawing.Size(67, 13);
            this.lblDepartments.TabIndex = 74;
            this.lblDepartments.Text = "Departments";
            // 
            // chklstDepartment
            // 
            this.chklstDepartment.ConcatChar = ", ";
            this.chklstDepartment.DisplayMember = null;
            this.chklstDepartment.FormattingEnabled = true;
            this.chklstDepartment.Location = new System.Drawing.Point(21, 36);
            this.chklstDepartment.Name = "chklstDepartment";
            this.chklstDepartment.Size = new System.Drawing.Size(360, 21);
            this.chklstDepartment.TabIndex = 73;
            this.chklstDepartment.ValueMember = null;
            this.chklstDepartment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstDepartment_ItemCheck);
            // 
            // chklstCity
            // 
            this.chklstCity.ConcatChar = ", ";
            this.chklstCity.DisplayMember = null;
            this.chklstCity.FormattingEnabled = true;
            this.chklstCity.Location = new System.Drawing.Point(21, 78);
            this.chklstCity.Name = "chklstCity";
            this.chklstCity.Size = new System.Drawing.Size(360, 21);
            this.chklstCity.TabIndex = 72;
            this.chklstCity.ValueMember = null;
            // 
            // chklstTerritory
            // 
            this.chklstTerritory.ConcatChar = ", ";
            this.chklstTerritory.DisplayMember = null;
            this.chklstTerritory.FormattingEnabled = true;
            this.chklstTerritory.Location = new System.Drawing.Point(21, 126);
            this.chklstTerritory.Name = "chklstTerritory";
            this.chklstTerritory.Size = new System.Drawing.Size(360, 21);
            this.chklstTerritory.TabIndex = 71;
            this.chklstTerritory.ValueMember = null;
            // 
            // grpTerritories
            // 
            this.grpTerritories.Controls.Add(this.lblTerritories2);
            this.grpTerritories.Controls.Add(this.chklstTerritory2);
            this.grpTerritories.Location = new System.Drawing.Point(12, 295);
            this.grpTerritories.Name = "grpTerritories";
            this.grpTerritories.Size = new System.Drawing.Size(405, 100);
            this.grpTerritories.TabIndex = 72;
            this.grpTerritories.TabStop = false;
            this.grpTerritories.Text = "Select territories polygons to see";
            // 
            // lblTerritories2
            // 
            this.lblTerritories2.AutoSize = true;
            this.lblTerritories2.Location = new System.Drawing.Point(18, 31);
            this.lblTerritories2.Name = "lblTerritories2";
            this.lblTerritories2.Size = new System.Drawing.Size(53, 13);
            this.lblTerritories2.TabIndex = 76;
            this.lblTerritories2.Text = "Territories";
            // 
            // chklstTerritory2
            // 
            this.chklstTerritory2.ConcatChar = ", ";
            this.chklstTerritory2.DisplayMember = null;
            this.chklstTerritory2.FormattingEnabled = true;
            this.chklstTerritory2.Location = new System.Drawing.Point(21, 47);
            this.chklstTerritory2.Name = "chklstTerritory2";
            this.chklstTerritory2.Size = new System.Drawing.Size(360, 21);
            this.chklstTerritory2.TabIndex = 71;
            this.chklstTerritory2.ValueMember = null;
            // 
            // btnViewMap
            // 
            this.btnViewMap.Location = new System.Drawing.Point(123, 30);
            this.btnViewMap.Name = "btnViewMap";
            this.btnViewMap.Size = new System.Drawing.Size(186, 58);
            this.btnViewMap.TabIndex = 73;
            this.btnViewMap.Text = "View map";
            this.btnViewMap.UseVisualStyleBackColor = true;
            this.btnViewMap.Click += new System.EventHandler(this.btnViewMap_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(342, 410);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 46);
            this.btnOk.TabIndex = 74;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 46);
            this.btnCancel.TabIndex = 75;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConfigureMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 467);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnViewMap);
            this.Controls.Add(this.grpTerritories);
            this.Controls.Add(this.grpAddresses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmConfigureMap";
            this.Text = "Configure map";
            this.Load += new System.EventHandler(this.frmConfigureMap_Load);
            this.grpAddresses.ResumeLayout(false);
            this.grpAddresses.PerformLayout();
            this.grpTerritories.ResumeLayout(false);
            this.grpTerritories.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddresses;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstDepartment;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstCity;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstTerritory;
        private System.Windows.Forms.Label lblTerritories;
        private System.Windows.Forms.Label lblCities;
        private System.Windows.Forms.Label lblDepartments;
        private System.Windows.Forms.GroupBox grpTerritories;
        private System.Windows.Forms.Label lblTerritories2;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstTerritory2;
        private System.Windows.Forms.Button btnViewMap;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}