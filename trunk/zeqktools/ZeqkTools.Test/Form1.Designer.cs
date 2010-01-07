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
            ZeqkTools.WindowsForms.Controls.CheckBoxProperties checkBoxProperties1 = new ZeqkTools.WindowsForms.Controls.CheckBoxProperties();
            this.button4 = new System.Windows.Forms.Button();
            this.cboTest = new ZeqkTools.WindowsForms.Controls.CheckBoxComboBox();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(296, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cboTest
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboTest.CheckBoxProperties = checkBoxProperties1;
            this.cboTest.DisplayMemberSingleItem = "";
            this.cboTest.FormattingEnabled = true;
            this.cboTest.Location = new System.Drawing.Point(76, 63);
            this.cboTest.Name = "cboTest";
            this.cboTest.Size = new System.Drawing.Size(145, 21);
            this.cboTest.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 459);
            this.Controls.Add(this.cboTest);
            this.Controls.Add(this.button4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private ZeqkTools.WindowsForms.Controls.CheckBoxComboBox cboTest;
    }
}

