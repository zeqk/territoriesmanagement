namespace TerritoriesManagement.GUI
{
    partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnAddress = new System.Windows.Forms.Button();
			this.btnCities = new System.Windows.Forms.Button();
			this.btnDepartments = new System.Windows.Forms.Button();
			this.bntTerritories = new System.Windows.Forms.Button();
			this.menu = new System.Windows.Forms.MenuStrip();
			this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.menuInteropWizard = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuConfiguration = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblConnectionStatusValue = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuImportKML = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExportKML = new System.Windows.Forms.ToolStripMenuItem();
			this.menu.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAddress
			// 
			this.btnAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnAddress.Image")));
			this.btnAddress.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnAddress.Location = new System.Drawing.Point(185, 64);
			this.btnAddress.Name = "btnAddress";
			this.btnAddress.Size = new System.Drawing.Size(220, 75);
			this.btnAddress.TabIndex = 4;
			this.btnAddress.Text = "Addresses";
			this.btnAddress.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAddress.UseVisualStyleBackColor = true;
			this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
			// 
			// btnCities
			// 
			this.btnCities.Image = ((System.Drawing.Image)(resources.GetObject("btnCities.Image")));
			this.btnCities.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCities.Location = new System.Drawing.Point(16, 41);
			this.btnCities.Name = "btnCities";
			this.btnCities.Size = new System.Drawing.Size(138, 46);
			this.btnCities.TabIndex = 1;
			this.btnCities.Text = "Cities";
			this.btnCities.UseVisualStyleBackColor = true;
			this.btnCities.Click += new System.EventHandler(this.btnCities_Click);
			// 
			// btnDepartments
			// 
			this.btnDepartments.Image = ((System.Drawing.Image)(resources.GetObject("btnDepartments.Image")));
			this.btnDepartments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDepartments.Location = new System.Drawing.Point(16, 93);
			this.btnDepartments.Name = "btnDepartments";
			this.btnDepartments.Size = new System.Drawing.Size(138, 46);
			this.btnDepartments.TabIndex = 2;
			this.btnDepartments.Text = "Departments";
			this.btnDepartments.UseVisualStyleBackColor = true;
			this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);
			// 
			// bntTerritories
			// 
			this.bntTerritories.Image = ((System.Drawing.Image)(resources.GetObject("bntTerritories.Image")));
			this.bntTerritories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntTerritories.Location = new System.Drawing.Point(16, 145);
			this.bntTerritories.Name = "bntTerritories";
			this.bntTerritories.Size = new System.Drawing.Size(138, 46);
			this.bntTerritories.TabIndex = 3;
			this.bntTerritories.Text = "Territories";
			this.bntTerritories.UseVisualStyleBackColor = true;
			this.bntTerritories.Click += new System.EventHandler(this.bntTerritories_Click);
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTools,
            this.helpToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(453, 24);
			this.menu.TabIndex = 0;
			this.menu.Text = "Menu";
			// 
			// menuTools
			// 
			this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInteropWizard,
            this.toolStripSeparator1,
            this.menuConfiguration,
            this.menuImportKML,
            this.menuExportKML});
			this.menuTools.Name = "menuTools";
			this.menuTools.Size = new System.Drawing.Size(48, 20);
			this.menuTools.Text = "Tools";
			// 
			// menuInteropWizard
			// 
			this.menuInteropWizard.Image = ((System.Drawing.Image)(resources.GetObject("menuInteropWizard.Image")));
			this.menuInteropWizard.Name = "menuInteropWizard";
			this.menuInteropWizard.Size = new System.Drawing.Size(154, 22);
			this.menuInteropWizard.Text = "Interop wizzard";
			this.menuInteropWizard.Click += new System.EventHandler(this.menuInteropWizard_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
			// 
			// menuConfiguration
			// 
			this.menuConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("menuConfiguration.Image")));
			this.menuConfiguration.Name = "menuConfiguration";
			this.menuConfiguration.Size = new System.Drawing.Size(154, 22);
			this.menuConfiguration.Text = "Configuration";
			this.menuConfiguration.Click += new System.EventHandler(this.menuConfiguration_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuAbout.Image")));
			this.menuAbout.Name = "menuAbout";
			this.menuAbout.Size = new System.Drawing.Size(237, 22);
			this.menuAbout.Text = "About Territories Management";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus,
            this.lblConnectionStatusValue});
			this.statusStrip.Location = new System.Drawing.Point(0, 202);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(453, 22);
			this.statusStrip.TabIndex = 5;
			// 
			// lblConnectionStatus
			// 
			this.lblConnectionStatus.Name = "lblConnectionStatus";
			this.lblConnectionStatus.Size = new System.Drawing.Size(106, 17);
			this.lblConnectionStatus.Text = "Connection status:";
			// 
			// lblConnectionStatusValue
			// 
			this.lblConnectionStatusValue.Name = "lblConnectionStatusValue";
			this.lblConnectionStatusValue.Size = new System.Drawing.Size(0, 17);
			// 
			// menuImportKML
			// 
			this.menuImportKML.Name = "menuImportKML";
			this.menuImportKML.Size = new System.Drawing.Size(219, 22);
			this.menuImportKML.Text = "Import territories from KML";
			this.menuImportKML.Click += new System.EventHandler(this.menuImportKML_Click);
			// 
			// menuExportKML
			// 
			this.menuExportKML.Name = "menuExportKML";
			this.menuExportKML.Size = new System.Drawing.Size(154, 22);
			this.menuExportKML.Text = "Export KML";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 224);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.bntTerritories);
			this.Controls.Add(this.btnDepartments);
			this.Controls.Add(this.btnCities);
			this.Controls.Add(this.btnAddress);
			this.Controls.Add(this.menu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menu;
			this.Name = "frmMain";
			this.Text = "Territories Management";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnCities;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button bntTerritories;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatusValue;
        private System.Windows.Forms.ToolStripMenuItem menuInteropWizard;
		private System.Windows.Forms.ToolStripMenuItem menuImportKML;
		private System.Windows.Forms.ToolStripMenuItem menuExportKML;

    }
}