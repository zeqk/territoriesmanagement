namespace TerritoriesManagement.GUI
{
    partial class frmAddresses
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddresses));
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chklstDepartment = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.chklstCity = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.chklstTerritory = new ZeqkTools.WindowsForms.Controls.CheckedListComboBox(this.components);
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.chkStreet = new System.Windows.Forms.CheckBox();
            this.chkCorners = new System.Windows.Forms.CheckBox();
            this.schStreet = new ZeqkTools.WindowsForms.Controls.Search();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyGoogleMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdGMaps = new System.Windows.Forms.SaveFileDialog();
            this.sfdExcelDestiny = new System.Windows.Forms.SaveFileDialog();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAll.Image")));
            this.btnAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAll.Location = new System.Drawing.Point(833, 65);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(96, 37);
            this.btnAll.TabIndex = 51;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(833, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 45);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnToExcel);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Location = new System.Drawing.Point(839, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 357);
            this.panel1.TabIndex = 54;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToExcel.AutoSize = true;
            this.btnToExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToExcel.Location = new System.Drawing.Point(17, 262);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(65, 26);
            this.btnToExcel.TabIndex = 5;
            this.btnToExcel.Text = "To Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(9, 89);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 37);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(9, 46);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 37);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(9, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 37);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblFiltered
            // 
            this.lblFiltered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.Location = new System.Drawing.Point(792, 147);
            this.lblFiltered.Name = "lblFiltered";
            this.lblFiltered.Size = new System.Drawing.Size(41, 13);
            this.lblFiltered.TabIndex = 57;
            this.lblFiltered.Text = "Filtered";
            this.lblFiltered.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(2, 147);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 56;
            this.lblResult.Text = "Result";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(2, 163);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.Size = new System.Drawing.Size(831, 354);
            this.dgvResult.TabIndex = 55;
            this.dgvResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvResult_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chklstDepartment);
            this.panel2.Controls.Add(this.chklstCity);
            this.panel2.Controls.Add(this.chklstTerritory);
            this.panel2.Controls.Add(this.chkDescription);
            this.panel2.Controls.Add(this.chkStreet);
            this.panel2.Controls.Add(this.chkCorners);
            this.panel2.Controls.Add(this.schStreet);
            this.panel2.Controls.Add(this.lblTerritory);
            this.panel2.Controls.Add(this.lblAddress);
            this.panel2.Controls.Add(this.lblCity);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 139);
            this.panel2.TabIndex = 58;
            // 
            // chklstDepartment
            // 
            this.chklstDepartment.ConcatChar = ", ";
            this.chklstDepartment.DisplayMember = null;
            this.chklstDepartment.FormattingEnabled = true;
            this.chklstDepartment.Location = new System.Drawing.Point(18, 63);
            this.chklstDepartment.Name = "chklstDepartment";
            this.chklstDepartment.Size = new System.Drawing.Size(360, 21);
            this.chklstDepartment.TabIndex = 67;
            this.chklstDepartment.ValueMember = null;
            this.chklstDepartment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstDepartment_ItemCheck);
            // 
            // chklstCity
            // 
            this.chklstCity.ConcatChar = ", ";
            this.chklstCity.DisplayMember = null;
            this.chklstCity.FormattingEnabled = true;
            this.chklstCity.Location = new System.Drawing.Point(18, 104);
            this.chklstCity.Name = "chklstCity";
            this.chklstCity.Size = new System.Drawing.Size(360, 21);
            this.chklstCity.TabIndex = 66;
            this.chklstCity.ValueMember = null;
            // 
            // chklstTerritory
            // 
            this.chklstTerritory.ConcatChar = ", ";
            this.chklstTerritory.DisplayMember = null;
            this.chklstTerritory.FormattingEnabled = true;
            this.chklstTerritory.Location = new System.Drawing.Point(399, 63);
            this.chklstTerritory.Name = "chklstTerritory";
            this.chklstTerritory.Size = new System.Drawing.Size(360, 21);
            this.chklstTerritory.TabIndex = 65;
            this.chklstTerritory.ValueMember = null;
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
            this.chkCorners.Size = new System.Drawing.Size(62, 17);
            this.chkCorners.TabIndex = 62;
            this.chkCorners.Text = "Corners";
            this.chkCorners.UseVisualStyleBackColor = true;
            this.chkCorners.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // schStreet
            // 
            this.schStreet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.schStreet.Columns = null;
            this.schStreet.Criteria = ZeqkTools.Query.Enumerators.Criterias.Contains;
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
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(18, 6);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 55;
            this.lblAddress.Text = "Address";
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
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGoogleMapsToolStripMenuItem,
            this.viewMapToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(172, 48);
            // 
            // copyGoogleMapsToolStripMenuItem
            // 
            this.copyGoogleMapsToolStripMenuItem.Name = "copyGoogleMapsToolStripMenuItem";
            this.copyGoogleMapsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyGoogleMapsToolStripMenuItem.Text = "Copy (Google Maps)";
            this.copyGoogleMapsToolStripMenuItem.Click += new System.EventHandler(this.copyGoogleMapsToolStripMenuItem_Click);
            // 
            // viewMapToolStripMenuItem
            // 
            this.viewMapToolStripMenuItem.Name = "viewMapToolStripMenuItem";
            this.viewMapToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewMapToolStripMenuItem.Text = "View map";
            this.viewMapToolStripMenuItem.Click += new System.EventHandler(this.viewMapToolStripMenuItem_Click);
            // 
            // sfdGMaps
            // 
            this.sfdGMaps.Filter = "xml files (*.xml)|*.xml";
            // 
            // sfdExcelDestiny
            // 
            this.sfdExcelDestiny.Filter = "Excel files (*.xls)|*.xls";
            this.sfdExcelDestiny.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdExcelDestiny_FileOk);
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(46, 147);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(0, 13);
            this.lblResultCount.TabIndex = 59;
            // 
            // frmAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 524);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblFiltered);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmAddresses";
            this.Text = "Addresses";
            this.Load += new System.EventHandler(this.frmAddresses_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ctxMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.CheckBox chkStreet;
        private System.Windows.Forms.CheckBox chkCorners;
        private ZeqkTools.WindowsForms.Controls.Search schStreet;
        private System.Windows.Forms.Label lblTerritory;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem copyGoogleMapsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdGMaps;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.SaveFileDialog sfdExcelDestiny;
        private System.Windows.Forms.ToolStripMenuItem viewMapToolStripMenuItem;
        private System.Windows.Forms.Label lblResultCount;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstTerritory;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstCity;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstDepartment;



    }
}