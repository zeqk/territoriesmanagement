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
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.chkStreet = new System.Windows.Forms.CheckBox();
            this.chkCorners = new System.Windows.Forms.CheckBox();
            this.schStreet = new My.Controls.Search();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.cboTerritory = new System.Windows.Forms.ComboBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.Location = new System.Drawing.Point(790, 65);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(96, 37);
            this.btnAll.TabIndex = 51;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(790, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 45);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Location = new System.Drawing.Point(796, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 357);
            this.panel1.TabIndex = 54;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(9, 128);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 37);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(9, 73);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 37);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(9, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 37);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblFiltered
            // 
            this.lblFiltered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.Location = new System.Drawing.Point(700, 144);
            this.lblFiltered.Name = "lblFiltered";
            this.lblFiltered.Size = new System.Drawing.Size(41, 13);
            this.lblFiltered.TabIndex = 57;
            this.lblFiltered.Text = "Filtered";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(5, 144);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(42, 13);
            this.lblResults.TabIndex = 56;
            this.lblResults.Text = "Results";
            // 
            // dgvResults
            // 
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(2, 160);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(788, 357);
            this.dgvResults.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkDescription);
            this.panel2.Controls.Add(this.chkStreet);
            this.panel2.Controls.Add(this.chkCorners);
            this.panel2.Controls.Add(this.schStreet);
            this.panel2.Controls.Add(this.lblTerritory);
            this.panel2.Controls.Add(this.cboTerritory);
            this.panel2.Controls.Add(this.lblDirection);
            this.panel2.Controls.Add(this.lblCity);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.cboCity);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 139);
            this.panel2.TabIndex = 58;
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.Location = new System.Drawing.Point(518, 22);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Size = new System.Drawing.Size(79, 17);
            this.chkDescription.TabIndex = 64;
            this.chkDescription.Text = "Description";
            this.chkDescription.UseVisualStyleBackColor = true;
            this.chkDescription.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // chkStreet
            // 
            this.chkStreet.AutoSize = true;
            this.chkStreet.Location = new System.Drawing.Point(399, 23);
            this.chkStreet.Name = "chkStreet";
            this.chkStreet.Size = new System.Drawing.Size(54, 17);
            this.chkStreet.TabIndex = 63;
            this.chkStreet.Text = "Street";
            this.chkStreet.UseVisualStyleBackColor = true;
            this.chkStreet.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // chkCorners
            // 
            this.chkCorners.AutoSize = true;
            this.chkCorners.Location = new System.Drawing.Point(459, 22);
            this.chkCorners.Name = "chkCorners";
            this.chkCorners.Size = new System.Drawing.Size(53, 17);
            this.chkCorners.TabIndex = 62;
            this.chkCorners.Text = "Corns";
            this.chkCorners.UseVisualStyleBackColor = true;
            this.chkCorners.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // schStreet
            // 
            this.schStreet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.schStreet.Columns = null;
            this.schStreet.Criteria = My.Enumerators.Criterias.EqualTo;
            this.schStreet.Location = new System.Drawing.Point(18, 22);
            this.schStreet.Name = "schStreet";
            this.schStreet.Parameters = null;
            this.schStreet.Query = null;
            this.schStreet.Size = new System.Drawing.Size(360, 22);
            this.schStreet.TabIndex = 54;
            this.schStreet.VariableNames = null;
            // 
            // lblTerritory
            // 
            this.lblTerritory.AutoSize = true;
            this.lblTerritory.Location = new System.Drawing.Point(396, 48);
            this.lblTerritory.Name = "lblTerritory";
            this.lblTerritory.Size = new System.Drawing.Size(45, 13);
            this.lblTerritory.TabIndex = 61;
            this.lblTerritory.Text = "Territory";
            // 
            // cboTerritory
            // 
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Location = new System.Drawing.Point(399, 63);
            this.cboTerritory.Name = "cboTerritory";
            this.cboTerritory.Size = new System.Drawing.Size(360, 21);
            this.cboTerritory.TabIndex = 60;
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(18, 6);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(49, 13);
            this.lblDirection.TabIndex = 55;
            this.lblDirection.Text = "Direction";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(18, 88);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 59;
            this.lblCity.Text = "City";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(18, 47);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 58;
            this.lblDepartment.Text = "Department";
            // 
            // cboCity
            // 
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(18, 104);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(360, 21);
            this.cboCity.TabIndex = 56;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(18, 63);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(360, 21);
            this.cboDepartment.TabIndex = 57;
            // 
            // frmDirections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFiltered);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmDirections";
            this.Text = "Directions";
            this.Load += new System.EventHandler(this.frmDirections_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblFiltered;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.CheckBox chkStreet;
        private System.Windows.Forms.CheckBox chkCorners;
        private My.Controls.Search schStreet;
        private System.Windows.Forms.Label lblTerritory;
        private System.Windows.Forms.ComboBox cboTerritory;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ComboBox cboDepartment;



    }
}