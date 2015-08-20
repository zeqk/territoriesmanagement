namespace TerritoriesManagement.GUI
{
    partial class frmTerritoriesPrinting
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
            this.chklstTerritories = new System.Windows.Forms.CheckedListBox();
            this.chkHasAddresses = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklstTerritories
            // 
            this.chklstTerritories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstTerritories.CheckOnClick = true;
            this.chklstTerritories.FormattingEnabled = true;
            this.chklstTerritories.HorizontalScrollbar = true;
            this.chklstTerritories.Location = new System.Drawing.Point(12, 44);
            this.chklstTerritories.MultiColumn = true;
            this.chklstTerritories.Name = "chklstTerritories";
            this.chklstTerritories.Size = new System.Drawing.Size(683, 364);
            this.chklstTerritories.TabIndex = 0;
            // 
            // chkHasAddresses
            // 
            this.chkHasAddresses.AutoSize = true;
            this.chkHasAddresses.Location = new System.Drawing.Point(12, 21);
            this.chkHasAddresses.Name = "chkHasAddresses";
            this.chkHasAddresses.Size = new System.Drawing.Size(75, 17);
            this.chkHasAddresses.TabIndex = 1;
            this.chkHasAddresses.Text = "Addresses";
            this.chkHasAddresses.UseVisualStyleBackColor = true;
            this.chkHasAddresses.CheckedChanged += new System.EventHandler(this.chkHasAddresses_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(620, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmTerritoriesPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 453);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkHasAddresses);
            this.Controls.Add(this.chklstTerritories);
            this.Name = "frmTerritoriesPrinting";
            this.Text = "Territories printing";
            this.Load += new System.EventHandler(this.frmTerritoriesPrinting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklstTerritories;
        private System.Windows.Forms.CheckBox chkHasAddresses;
        private System.Windows.Forms.Button btnPrint;
    }
}