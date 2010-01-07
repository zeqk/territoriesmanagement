namespace ZeqkTools.WindowsForms.Controls
{
    partial class Search
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
            this.splitControl = new System.Windows.Forms.SplitContainer();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.splitControl.Panel1.SuspendLayout();
            this.splitControl.Panel2.SuspendLayout();
            this.splitControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitControl
            // 
            this.splitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitControl.Location = new System.Drawing.Point(0, 0);
            this.splitControl.Name = "splitControl";
            // 
            // splitControl.Panel1
            // 
            this.splitControl.Panel1.Controls.Add(this.cboCriteria);
            // 
            // splitControl.Panel2
            // 
            this.splitControl.Panel2.Controls.Add(this.txtValue);
            this.splitControl.Size = new System.Drawing.Size(354, 23);
            this.splitControl.SplitterDistance = 118;
            this.splitControl.TabIndex = 3;
            // 
            // cboCriteria
            // 
            this.cboCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Location = new System.Drawing.Point(0, 0);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(118, 21);
            this.cboCriteria.TabIndex = 1;
            this.cboCriteria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCriteria_KeyDown);
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(232, 20);
            this.txtValue.TabIndex = 2;
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.splitControl);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(354, 23);
            this.Load += new System.EventHandler(this.Search_Load);
            this.splitControl.Panel1.ResumeLayout(false);
            this.splitControl.Panel2.ResumeLayout(false);
            this.splitControl.Panel2.PerformLayout();
            this.splitControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitControl;
        private System.Windows.Forms.ComboBox cboCriteria;
        private System.Windows.Forms.TextBox txtValue;

    }
}
