namespace Territories.GUI
{
    partial class frmDirections
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkCorners = new System.Windows.Forms.CheckBox();
            this.schStreet = new My.Controls.Search();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.schCorners = new My.Controls.Search();
            this.cboTerritory = new System.Windows.Forms.ComboBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCorners = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.chkCorners);
            this.splitContainer1.Panel1.Controls.Add(this.schStreet);
            this.splitContainer1.Panel1.Controls.Add(this.lblTerritory);
            this.splitContainer1.Panel1.Controls.Add(this.schCorners);
            this.splitContainer1.Panel1.Controls.Add(this.cboTerritory);
            this.splitContainer1.Panel1.Controls.Add(this.lblStreet);
            this.splitContainer1.Panel1.Controls.Add(this.lblCity);
            this.splitContainer1.Panel1.Controls.Add(this.lblCorners);
            this.splitContainer1.Panel1.Controls.Add(this.lblDepartment);
            this.splitContainer1.Panel1.Controls.Add(this.cboCity);
            this.splitContainer1.Panel1.Controls.Add(this.cboDepartment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(822, 638);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(527, 86);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 37);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(634, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 64);
            this.btnSearch.TabIndex = 39;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkCorners
            // 
            this.chkCorners.AutoSize = true;
            this.chkCorners.Location = new System.Drawing.Point(197, 11);
            this.chkCorners.Name = "chkCorners";
            this.chkCorners.Size = new System.Drawing.Size(68, 17);
            this.chkCorners.TabIndex = 38;
            this.chkCorners.Text = "So corns";
            this.chkCorners.UseVisualStyleBackColor = true;
            // 
            // schStreet
            // 
            this.schStreet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.schStreet.Columns = null;
            this.schStreet.Criteria = My.Enumerators.Criterias.EqualTo;
            this.schStreet.Location = new System.Drawing.Point(12, 31);
            this.schStreet.Name = "schStreet";
            this.schStreet.Parameters = null;
            this.schStreet.Query = null;
            this.schStreet.Size = new System.Drawing.Size(380, 22);
            this.schStreet.TabIndex = 28;
            this.schStreet.VariableNames = null;
            // 
            // lblTerritory
            // 
            this.lblTerritory.AutoSize = true;
            this.lblTerritory.Location = new System.Drawing.Point(12, 142);
            this.lblTerritory.Name = "lblTerritory";
            this.lblTerritory.Size = new System.Drawing.Size(45, 13);
            this.lblTerritory.TabIndex = 37;
            this.lblTerritory.Text = "Territory";
            // 
            // schCorners
            // 
            this.schCorners.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.schCorners.Columns = null;
            this.schCorners.Criteria = My.Enumerators.Criterias.EqualTo;
            this.schCorners.Location = new System.Drawing.Point(415, 31);
            this.schCorners.Name = "schCorners";
            this.schCorners.Parameters = null;
            this.schCorners.Query = null;
            this.schCorners.Size = new System.Drawing.Size(380, 22);
            this.schCorners.TabIndex = 29;
            this.schCorners.VariableNames = null;
            // 
            // cboTerritory
            // 
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Location = new System.Drawing.Point(12, 156);
            this.cboTerritory.Name = "cboTerritory";
            this.cboTerritory.Size = new System.Drawing.Size(380, 21);
            this.cboTerritory.TabIndex = 36;
            this.cboTerritory.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(12, 15);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(94, 13);
            this.lblStreet.TabIndex = 30;
            this.lblStreet.Text = "Street and number";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(12, 96);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 35;
            this.lblCity.Text = "City";
            // 
            // lblCorners
            // 
            this.lblCorners.AutoSize = true;
            this.lblCorners.Location = new System.Drawing.Point(412, 15);
            this.lblCorners.Name = "lblCorners";
            this.lblCorners.Size = new System.Drawing.Size(43, 13);
            this.lblCorners.TabIndex = 31;
            this.lblCorners.Text = "Corners";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(12, 56);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 34;
            this.lblDepartment.Text = "Department";
            // 
            // cboCity
            // 
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(12, 112);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(380, 21);
            this.cboCity.TabIndex = 32;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(12, 72);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(380, 21);
            this.cboDepartment.TabIndex = 33;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer2.Panel2.Controls.Add(this.btnNew);
            this.splitContainer2.Size = new System.Drawing.Size(822, 421);
            this.splitContainer2.SplitterDistance = 748;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblFiltered);
            this.splitContainer3.Panel1.Controls.Add(this.lblResults);
            this.splitContainer3.Panel1MinSize = 15;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvResults);
            this.splitContainer3.Size = new System.Drawing.Size(748, 421);
            this.splitContainer3.SplitterDistance = 15;
            this.splitContainer3.TabIndex = 0;
            // 
            // lblFiltered
            // 
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.Location = new System.Drawing.Point(684, 0);
            this.lblFiltered.Name = "lblFiltered";
            this.lblFiltered.Size = new System.Drawing.Size(41, 13);
            this.lblFiltered.TabIndex = 1;
            this.lblFiltered.Text = "Filtered";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(3, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(42, 13);
            this.lblResults.TabIndex = 0;
            this.lblResults.Text = "Results";
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(748, 402);
            this.dgvResults.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(12, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 47);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "D";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(11, 69);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(47, 47);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "E";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(12, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(47, 47);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "N";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // frmDirections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 638);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDirections";
            this.Text = "Departments";
            this.Load += new System.EventHandler(this.frmDirections_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkCorners;
        private My.Controls.Search schStreet;
        private System.Windows.Forms.Label lblTerritory;
        private My.Controls.Search schCorners;
        private System.Windows.Forms.ComboBox cboTerritory;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCorners;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblFiltered;


    }
}