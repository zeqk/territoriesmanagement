﻿namespace ZeqkTools.WindowsForms.Maps
{
   partial class StaticImage
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
         if(disposing && (components != null))
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
         this.button1 = new System.Windows.Forms.Button();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
         this.button2 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.Location = new System.Drawing.Point(364, 29);
         this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(84, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "Generate";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // progressBar1
         // 
         this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.progressBar1.Location = new System.Drawing.Point(6, 6);
         this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(351, 93);
         this.progressBar1.TabIndex = 2;
         // 
         // numericUpDown1
         // 
         this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.numericUpDown1.Location = new System.Drawing.Point(402, 6);
         this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.numericUpDown1.Name = "numericUpDown1";
         this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
         this.numericUpDown1.TabIndex = 3;
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.Location = new System.Drawing.Point(364, 67);
         this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(84, 32);
         this.button2.TabIndex = 4;
         this.button2.Text = "Cancel";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(361, 8);
         this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(37, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Zoom:";
         // 
         // StaticImage
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(455, 106);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.numericUpDown1);
         this.Controls.Add(this.progressBar1);
         this.Controls.Add(this.button1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.Name = "StaticImage";
         this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Static Map maker";
         ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.NumericUpDown numericUpDown1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Label label1;
   }
}