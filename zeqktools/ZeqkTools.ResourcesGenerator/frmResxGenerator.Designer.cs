namespace ZeqkTools.ResourcesGenerator
{
    partial class frmResxGenerator
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
            this.grpResxGenerator = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblCultureTag = new System.Windows.Forms.Label();
            this.txtCultureTag = new System.Windows.Forms.TextBox();
            this.lblResources = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.chklstFiles = new System.Windows.Forms.CheckedListBox();
            this.btnSelectDestiny = new System.Windows.Forms.Button();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtDestiny = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.fbdDestiny = new System.Windows.Forms.FolderBrowserDialog();
            this.grpResxGenerator.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResxGenerator
            // 
            this.grpResxGenerator.Controls.Add(this.label2);
            this.grpResxGenerator.Controls.Add(this.txtTo);
            this.grpResxGenerator.Controls.Add(this.label1);
            this.grpResxGenerator.Controls.Add(this.txtFrom);
            this.grpResxGenerator.Controls.Add(this.lblCultureTag);
            this.grpResxGenerator.Controls.Add(this.txtCultureTag);
            this.grpResxGenerator.Controls.Add(this.lblResources);
            this.grpResxGenerator.Controls.Add(this.lblFiles);
            this.grpResxGenerator.Controls.Add(this.lblSource);
            this.grpResxGenerator.Controls.Add(this.chklstFiles);
            this.grpResxGenerator.Controls.Add(this.btnSelectDestiny);
            this.grpResxGenerator.Controls.Add(this.btnSelectSource);
            this.grpResxGenerator.Controls.Add(this.btnGenerate);
            this.grpResxGenerator.Controls.Add(this.txtDestiny);
            this.grpResxGenerator.Controls.Add(this.txtSource);
            this.grpResxGenerator.Location = new System.Drawing.Point(12, 3);
            this.grpResxGenerator.Name = "grpResxGenerator";
            this.grpResxGenerator.Size = new System.Drawing.Size(399, 409);
            this.grpResxGenerator.TabIndex = 0;
            this.grpResxGenerator.TabStop = false;
            this.grpResxGenerator.Text = "Generate resx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "To string";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(263, 308);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(82, 20);
            this.txtTo.TabIndex = 17;
            this.txtTo.Text = "\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "From string";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(162, 308);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(92, 20);
            this.txtFrom.TabIndex = 15;
            this.txtFrom.Text = "\"";
            // 
            // lblCultureTag
            // 
            this.lblCultureTag.AutoSize = true;
            this.lblCultureTag.Location = new System.Drawing.Point(19, 292);
            this.lblCultureTag.Name = "lblCultureTag";
            this.lblCultureTag.Size = new System.Drawing.Size(58, 13);
            this.lblCultureTag.TabIndex = 14;
            this.lblCultureTag.Text = "Culture tag";
            // 
            // txtCultureTag
            // 
            this.txtCultureTag.Location = new System.Drawing.Point(22, 308);
            this.txtCultureTag.Name = "txtCultureTag";
            this.txtCultureTag.Size = new System.Drawing.Size(100, 20);
            this.txtCultureTag.TabIndex = 13;
            this.txtCultureTag.Text = "en-US";
            // 
            // lblResources
            // 
            this.lblResources.AutoSize = true;
            this.lblResources.Location = new System.Drawing.Point(19, 239);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(87, 13);
            this.lblResources.TabIndex = 12;
            this.lblResources.Text = "Resources folder";
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(19, 61);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(28, 13);
            this.lblFiles.TabIndex = 11;
            this.lblFiles.Text = "Files";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(19, 18);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(71, 13);
            this.lblSource.TabIndex = 10;
            this.lblSource.Text = "Folder source";
            // 
            // chklstFiles
            // 
            this.chklstFiles.FormattingEnabled = true;
            this.chklstFiles.Location = new System.Drawing.Point(22, 77);
            this.chklstFiles.Name = "chklstFiles";
            this.chklstFiles.Size = new System.Drawing.Size(363, 154);
            this.chklstFiles.TabIndex = 9;
            // 
            // btnSelectDestiny
            // 
            this.btnSelectDestiny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectDestiny.Location = new System.Drawing.Point(350, 255);
            this.btnSelectDestiny.Name = "btnSelectDestiny";
            this.btnSelectDestiny.Size = new System.Drawing.Size(35, 20);
            this.btnSelectDestiny.TabIndex = 8;
            this.btnSelectDestiny.Text = "...";
            this.btnSelectDestiny.UseVisualStyleBackColor = true;
            this.btnSelectDestiny.Click += new System.EventHandler(this.btnSelectDestiny_Click);
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectSource.Location = new System.Drawing.Point(350, 34);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(35, 20);
            this.btnSelectSource.TabIndex = 7;
            this.btnSelectSource.Text = "...";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(22, 351);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(158, 40);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtDestiny
            // 
            this.txtDestiny.Location = new System.Drawing.Point(22, 255);
            this.txtDestiny.Name = "txtDestiny";
            this.txtDestiny.Size = new System.Drawing.Size(322, 20);
            this.txtDestiny.TabIndex = 5;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(22, 34);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(322, 20);
            this.txtSource.TabIndex = 4;
            // 
            // frmResxGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 424);
            this.Controls.Add(this.grpResxGenerator);
            this.Name = "frmResxGenerator";
            this.Text = "Resx generator";
            this.grpResxGenerator.ResumeLayout(false);
            this.grpResxGenerator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpResxGenerator;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtDestiny;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnSelectDestiny;
        private System.Windows.Forms.FolderBrowserDialog fbdDestiny;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.CheckedListBox chklstFiles;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblCultureTag;
        private System.Windows.Forms.TextBox txtCultureTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;

    }
}

