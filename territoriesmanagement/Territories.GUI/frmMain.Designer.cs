namespace Territories.GUI
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDepartments = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCities = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGeneral});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(677, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuGeneral
            // 
            this.mnuGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDepartments,
            this.mnuCities});
            this.mnuGeneral.Name = "mnuGeneral";
            this.mnuGeneral.Size = new System.Drawing.Size(81, 20);
            this.mnuGeneral.Text = "General data";
            // 
            // mnuDepartments
            // 
            this.mnuDepartments.Name = "mnuDepartments";
            this.mnuDepartments.Size = new System.Drawing.Size(152, 22);
            this.mnuDepartments.Text = "Departments";
            this.mnuDepartments.Click += new System.EventHandler(this.mnuDepartments_Click);
            // 
            // mnuCities
            // 
            this.mnuCities.Name = "mnuCities";
            this.mnuCities.Size = new System.Drawing.Size(152, 22);
            this.mnuCities.Text = "Cities";
            this.mnuCities.Click += new System.EventHandler(this.mnuCities_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 366);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuGeneral;
        private System.Windows.Forms.ToolStripMenuItem mnuDepartments;
        private System.Windows.Forms.ToolStripMenuItem mnuCities;
    }
}