namespace TerritoriesManagement.GUI.Interop.Steps
{
    partial class SelectDestinyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDestiny = new System.Windows.Forms.TextBox();
            this.brnBrowse = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtDestiny);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.brnBrowse);
            this.splitContainer1.Size = new System.Drawing.Size(467, 215);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtDestiny
            // 
            this.txtDestiny.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestiny.Location = new System.Drawing.Point(14, 95);
            this.txtDestiny.Name = "txtDestiny";
            this.txtDestiny.Size = new System.Drawing.Size(333, 20);
            this.txtDestiny.TabIndex = 0;
            // 
            // brnBrowse
            // 
            this.brnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.brnBrowse.Location = new System.Drawing.Point(3, 92);
            this.brnBrowse.Name = "brnBrowse";
            this.brnBrowse.Size = new System.Drawing.Size(92, 24);
            this.brnBrowse.TabIndex = 0;
            this.brnBrowse.Text = "Browse...";
            this.brnBrowse.UseVisualStyleBackColor = true;
            this.brnBrowse.Click += new System.EventHandler(this.brnBrowse_Click);
            // 
            // SelectDestinyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SelectDestinyControl";
            this.Size = new System.Drawing.Size(467, 215);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtDestiny;
        private System.Windows.Forms.Button brnBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
