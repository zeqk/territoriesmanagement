namespace ZeqkTools.Test
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkedComboBox1 = new ZeqkTools.WindowsForms.Controls.CheckedComboBox();
            this.userControl11 = new ZeqkTools.WindowsForms.Controls.UserControl1();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "uno",
            "dos",
            "tres"});
            this.comboBox1.Location = new System.Drawing.Point(51, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // checkedComboBox1
            // 
            this.checkedComboBox1.DataSource = ((object)(resources.GetObject("checkedComboBox1.DataSource")));
            this.checkedComboBox1.FormattingEnabled = true;
            this.checkedComboBox1.Location = new System.Drawing.Point(180, 239);
            this.checkedComboBox1.Name = "checkedComboBox1";
            this.checkedComboBox1.Size = new System.Drawing.Size(179, 21);
            this.checkedComboBox1.TabIndex = 1;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(236, 134);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(236, 28);
            this.userControl11.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 394);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.checkedComboBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private ZeqkTools.WindowsForms.Controls.CheckedComboBox checkedComboBox1;
        private ZeqkTools.WindowsForms.Controls.UserControl1 userControl11;
    }
}