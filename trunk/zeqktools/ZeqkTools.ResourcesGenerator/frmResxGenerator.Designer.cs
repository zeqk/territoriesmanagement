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
            this.fbdDestiny = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.chklstFiles = new System.Windows.Forms.CheckedListBox();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lblResources = new System.Windows.Forms.Label();
            this.btnSelectDestiny = new System.Windows.Forms.Button();
            this.txtDestiny = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblCultureTag = new System.Windows.Forms.Label();
            this.txtCultureTag = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabMerge = new System.Windows.Forms.TabPage();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLstResxFiles = new System.Windows.Forms.CheckedListBox();
            this.btnSelectMergedSource = new System.Windows.Forms.Button();
            this.txtMergeSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectMergedResx = new System.Windows.Forms.Button();
            this.txtMergedResxFile = new System.Windows.Forms.TextBox();
            this.sfdMergedResx = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabMerge);
            this.tabControl1.Location = new System.Drawing.Point(10, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(399, 422);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblFiles);
            this.tabPage1.Controls.Add(this.lblSource);
            this.tabPage1.Controls.Add(this.chklstFiles);
            this.tabPage1.Controls.Add(this.btnSelectSource);
            this.tabPage1.Controls.Add(this.txtSource);
            this.tabPage1.Controls.Add(this.lblResources);
            this.tabPage1.Controls.Add(this.btnSelectDestiny);
            this.tabPage1.Controls.Add(this.txtDestiny);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtTo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtFrom);
            this.tabPage1.Controls.Add(this.lblCultureTag);
            this.tabPage1.Controls.Add(this.txtCultureTag);
            this.tabPage1.Controls.Add(this.btnGenerate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(391, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(6, 55);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(28, 13);
            this.lblFiles.TabIndex = 36;
            this.lblFiles.Text = "Files";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 12);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(71, 13);
            this.lblSource.TabIndex = 35;
            this.lblSource.Text = "Folder source";
            // 
            // chklstFiles
            // 
            this.chklstFiles.FormattingEnabled = true;
            this.chklstFiles.Location = new System.Drawing.Point(9, 71);
            this.chklstFiles.Name = "chklstFiles";
            this.chklstFiles.Size = new System.Drawing.Size(363, 154);
            this.chklstFiles.TabIndex = 34;
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectSource.Location = new System.Drawing.Point(337, 28);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(35, 20);
            this.btnSelectSource.TabIndex = 33;
            this.btnSelectSource.Text = "...";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(9, 28);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(322, 20);
            this.txtSource.TabIndex = 32;
            // 
            // lblResources
            // 
            this.lblResources.AutoSize = true;
            this.lblResources.Location = new System.Drawing.Point(6, 236);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(87, 13);
            this.lblResources.TabIndex = 31;
            this.lblResources.Text = "Resources folder";
            // 
            // btnSelectDestiny
            // 
            this.btnSelectDestiny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectDestiny.Location = new System.Drawing.Point(337, 252);
            this.btnSelectDestiny.Name = "btnSelectDestiny";
            this.btnSelectDestiny.Size = new System.Drawing.Size(35, 20);
            this.btnSelectDestiny.TabIndex = 30;
            this.btnSelectDestiny.Text = "...";
            this.btnSelectDestiny.UseVisualStyleBackColor = true;
            // 
            // txtDestiny
            // 
            this.txtDestiny.Location = new System.Drawing.Point(9, 252);
            this.txtDestiny.Name = "txtDestiny";
            this.txtDestiny.Size = new System.Drawing.Size(322, 20);
            this.txtDestiny.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "To string";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(248, 300);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(82, 20);
            this.txtTo.TabIndex = 27;
            this.txtTo.Text = "\")";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "From string";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(147, 300);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(92, 20);
            this.txtFrom.TabIndex = 25;
            this.txtFrom.Text = "(\"";
            // 
            // lblCultureTag
            // 
            this.lblCultureTag.AutoSize = true;
            this.lblCultureTag.Location = new System.Drawing.Point(6, 284);
            this.lblCultureTag.Name = "lblCultureTag";
            this.lblCultureTag.Size = new System.Drawing.Size(58, 13);
            this.lblCultureTag.TabIndex = 24;
            this.lblCultureTag.Text = "Culture tag";
            // 
            // txtCultureTag
            // 
            this.txtCultureTag.Location = new System.Drawing.Point(9, 300);
            this.txtCultureTag.Name = "txtCultureTag";
            this.txtCultureTag.Size = new System.Drawing.Size(100, 20);
            this.txtCultureTag.TabIndex = 23;
            this.txtCultureTag.Text = "en-US";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(100, 347);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(158, 40);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // tabMerge
            // 
            this.tabMerge.Controls.Add(this.label3);
            this.tabMerge.Controls.Add(this.label4);
            this.tabMerge.Controls.Add(this.chkLstResxFiles);
            this.tabMerge.Controls.Add(this.btnSelectMergedSource);
            this.tabMerge.Controls.Add(this.txtMergeSource);
            this.tabMerge.Controls.Add(this.label5);
            this.tabMerge.Controls.Add(this.btnSelectMergedResx);
            this.tabMerge.Controls.Add(this.txtMergedResxFile);
            this.tabMerge.Controls.Add(this.btnMerge);
            this.tabMerge.Location = new System.Drawing.Point(4, 22);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Padding = new System.Windows.Forms.Padding(3);
            this.tabMerge.Size = new System.Drawing.Size(391, 396);
            this.tabMerge.TabIndex = 1;
            this.tabMerge.Text = "tabPage2";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(96, 298);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(158, 40);
            this.btnMerge.TabIndex = 21;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Resx files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Folder source";
            // 
            // chkLstResxFiles
            // 
            this.chkLstResxFiles.FormattingEnabled = true;
            this.chkLstResxFiles.Location = new System.Drawing.Point(9, 71);
            this.chkLstResxFiles.Name = "chkLstResxFiles";
            this.chkLstResxFiles.Size = new System.Drawing.Size(363, 154);
            this.chkLstResxFiles.TabIndex = 42;
            // 
            // btnSelectMergedSource
            // 
            this.btnSelectMergedSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectMergedSource.Location = new System.Drawing.Point(337, 28);
            this.btnSelectMergedSource.Name = "btnSelectMergedSource";
            this.btnSelectMergedSource.Size = new System.Drawing.Size(35, 20);
            this.btnSelectMergedSource.TabIndex = 41;
            this.btnSelectMergedSource.Text = "...";
            this.btnSelectMergedSource.UseVisualStyleBackColor = true;
            this.btnSelectMergedSource.Click += new System.EventHandler(this.btnSelectMergedSource_Click);
            // 
            // txtMergeSource
            // 
            this.txtMergeSource.Location = new System.Drawing.Point(9, 28);
            this.txtMergeSource.Name = "txtMergeSource";
            this.txtMergeSource.Size = new System.Drawing.Size(322, 20);
            this.txtMergeSource.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Merged resx file";
            // 
            // btnSelectMergedResx
            // 
            this.btnSelectMergedResx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectMergedResx.Location = new System.Drawing.Point(337, 252);
            this.btnSelectMergedResx.Name = "btnSelectMergedResx";
            this.btnSelectMergedResx.Size = new System.Drawing.Size(35, 20);
            this.btnSelectMergedResx.TabIndex = 38;
            this.btnSelectMergedResx.Text = "...";
            this.btnSelectMergedResx.UseVisualStyleBackColor = true;
            this.btnSelectMergedResx.Click += new System.EventHandler(this.btnSelectMergedResx_Click);
            // 
            // txtMergedResxFile
            // 
            this.txtMergedResxFile.Location = new System.Drawing.Point(9, 252);
            this.txtMergedResxFile.Name = "txtMergedResxFile";
            this.txtMergedResxFile.Size = new System.Drawing.Size(322, 20);
            this.txtMergedResxFile.TabIndex = 37;
            // 
            // frmResxGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 441);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmResxGenerator";
            this.Text = "Resx generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabMerge.ResumeLayout(false);
            this.tabMerge.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdDestiny;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblCultureTag;
        private System.Windows.Forms.TextBox txtCultureTag;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TabPage tabMerge;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.Button btnSelectDestiny;
        private System.Windows.Forms.TextBox txtDestiny;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.CheckedListBox chklstFiles;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkLstResxFiles;
        private System.Windows.Forms.Button btnSelectMergedSource;
        private System.Windows.Forms.TextBox txtMergeSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectMergedResx;
        private System.Windows.Forms.TextBox txtMergedResxFile;
        private System.Windows.Forms.SaveFileDialog sfdMergedResx;

    }
}

