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
            this.btnAddress = new System.Windows.Forms.Button();
            this.btnCities = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.bntTerritories = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInteroperabilty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(185, 64);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(247, 75);
            this.btnAddress.TabIndex = 0;
            this.btnAddress.Text = "Address";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // btnCities
            // 
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
            this.menu.TabIndex = 6;
            this.menu.Text = "menuStrip1";
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInteroperabilty,
            this.toolStripSeparator1,
            this.menuConfiguration});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(44, 20);
            this.menuTools.Text = "Tools";
            // 
            // menuInteroperabilty
            // 
            this.menuInteroperabilty.Name = "menuInteroperabilty";
            this.menuInteroperabilty.Size = new System.Drawing.Size(146, 22);
            this.menuInteroperabilty.Text = "Interoperabilty";
            this.menuInteroperabilty.Click += new System.EventHandler(this.menuInteroperabilty_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // menuConfiguration
            // 
            this.menuConfiguration.Name = "menuConfiguration";
            this.menuConfiguration.Size = new System.Drawing.Size(146, 22);
            this.menuConfiguration.Text = "Configuration";
            this.menuConfiguration.Click += new System.EventHandler(this.menuConfiguration_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(220, 22);
            this.menuAbout.Text = "About Territories Management";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 213);
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
        private System.Windows.Forms.ToolStripMenuItem menuInteroperabilty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}