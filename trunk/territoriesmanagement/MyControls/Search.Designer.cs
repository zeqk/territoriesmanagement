namespace My.Controls
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
            this.cmbCriteria = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCriteria
            // 
            this.cmbCriteria.FormattingEnabled = true;
            this.cmbCriteria.Location = new System.Drawing.Point(0, 17);
            this.cmbCriteria.Name = "cmbCriteria";
            this.cmbCriteria.Size = new System.Drawing.Size(97, 21);
            this.cmbCriteria.TabIndex = 0;            
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(103, 17);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(136, 20);
            this.txtValue.TabIndex = 1;
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Location = new System.Drawing.Point(3, 1);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(39, 13);
            this.lblCriteria.TabIndex = 2;
            this.lblCriteria.Text = "Criteria";            
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lblCriteria);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbCriteria);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(241, 42);
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCriteria;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblCriteria;
    }
}
