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
            this.btnToGMaps = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
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
            this.lblResultsCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel2.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            resources.ApplyResources(this.btnAll, "btnAll");
            this.btnAll.Name = "btnAll";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnToExcel);
            this.panel1.Controls.Add(this.btnToGMaps);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Name = "panel1";
            // 
            // btnToExcel
            // 
            resources.ApplyResources(this.btnToExcel, "btnToExcel");
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnToGMaps
            // 
            resources.ApplyResources(this.btnToGMaps, "btnToGMaps");
            this.btnToGMaps.Name = "btnToGMaps";
            this.btnToGMaps.UseVisualStyleBackColor = true;
            this.btnToGMaps.Click += new System.EventHandler(this.btnToGMaps_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblFiltered
            // 
            resources.ApplyResources(this.lblFiltered, "lblFiltered");
            this.lblFiltered.Name = "lblFiltered";
            // 
            // lblResults
            // 
            resources.ApplyResources(this.lblResults, "lblResults");
            this.lblResults.Name = "lblResults";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvResults_MouseClick);
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
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // chklstDepartment
            // 
            this.chklstDepartment.ConcatChar = ", ";
            this.chklstDepartment.DisplayMember = null;
            this.chklstDepartment.FormattingEnabled = true;
            resources.ApplyResources(this.chklstDepartment, "chklstDepartment");
            this.chklstDepartment.Name = "chklstDepartment";
            this.chklstDepartment.ValueMember = null;
            this.chklstDepartment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstDepartment_ItemCheck);
            // 
            // chklstCity
            // 
            this.chklstCity.ConcatChar = ", ";
            this.chklstCity.DisplayMember = null;
            this.chklstCity.FormattingEnabled = true;
            resources.ApplyResources(this.chklstCity, "chklstCity");
            this.chklstCity.Name = "chklstCity";
            this.chklstCity.ValueMember = null;
            // 
            // chklstTerritory
            // 
            this.chklstTerritory.ConcatChar = ", ";
            this.chklstTerritory.DisplayMember = null;
            this.chklstTerritory.FormattingEnabled = true;
            resources.ApplyResources(this.chklstTerritory, "chklstTerritory");
            this.chklstTerritory.Name = "chklstTerritory";
            this.chklstTerritory.ValueMember = null;
            // 
            // chkDescription
            // 
            resources.ApplyResources(this.chkDescription, "chkDescription");
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.UseVisualStyleBackColor = true;
            this.chkDescription.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // chkStreet
            // 
            resources.ApplyResources(this.chkStreet, "chkStreet");
            this.chkStreet.Name = "chkStreet";
            this.chkStreet.UseVisualStyleBackColor = true;
            this.chkStreet.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // chkCorners
            // 
            resources.ApplyResources(this.chkCorners, "chkCorners");
            this.chkCorners.Name = "chkCorners";
            this.chkCorners.UseVisualStyleBackColor = true;
            this.chkCorners.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // schStreet
            // 
            resources.ApplyResources(this.schStreet, "schStreet");
            this.schStreet.Columns = null;
            this.schStreet.Criteria = ZeqkTools.Query.Enumerators.Criterias.Contains;
            this.schStreet.Name = "schStreet";
            this.schStreet.Parameters = null;
            this.schStreet.Query = null;
            this.schStreet.VariableNames = null;
            // 
            // lblTerritory
            // 
            resources.ApplyResources(this.lblTerritory, "lblTerritory");
            this.lblTerritory.Name = "lblTerritory";
            // 
            // lblAddress
            // 
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Name = "lblAddress";
            // 
            // lblCity
            // 
            resources.ApplyResources(this.lblCity, "lblCity");
            this.lblCity.Name = "lblCity";
            // 
            // lblDepartment
            // 
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Name = "lblDepartment";
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGoogleMapsToolStripMenuItem,
            this.viewMapToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            resources.ApplyResources(this.ctxMenu, "ctxMenu");
            // 
            // copyGoogleMapsToolStripMenuItem
            // 
            this.copyGoogleMapsToolStripMenuItem.Name = "copyGoogleMapsToolStripMenuItem";
            resources.ApplyResources(this.copyGoogleMapsToolStripMenuItem, "copyGoogleMapsToolStripMenuItem");
            this.copyGoogleMapsToolStripMenuItem.Click += new System.EventHandler(this.copyGoogleMapsToolStripMenuItem_Click);
            // 
            // viewMapToolStripMenuItem
            // 
            this.viewMapToolStripMenuItem.Name = "viewMapToolStripMenuItem";
            resources.ApplyResources(this.viewMapToolStripMenuItem, "viewMapToolStripMenuItem");
            this.viewMapToolStripMenuItem.Click += new System.EventHandler(this.viewMapToolStripMenuItem_Click);
            // 
            // sfdGMaps
            // 
            resources.ApplyResources(this.sfdGMaps, "sfdGMaps");
            this.sfdGMaps.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdGMaps_FileOk);
            // 
            // sfdExcelDestiny
            // 
            resources.ApplyResources(this.sfdExcelDestiny, "sfdExcelDestiny");
            this.sfdExcelDestiny.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdExcelDestiny_FileOk);
            // 
            // lblResultsCount
            // 
            resources.ApplyResources(this.lblResultsCount, "lblResultsCount");
            this.lblResultsCount.Name = "lblResultsCount";
            // 
            // frmAddresses
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblResultsCount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lblFiltered);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmAddresses";
            this.Load += new System.EventHandler(this.frmAddresses_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
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
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvResults;
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
   
        private System.Windows.Forms.Button btnToGMaps;
        private System.Windows.Forms.SaveFileDialog sfdGMaps;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.SaveFileDialog sfdExcelDestiny;
        private System.Windows.Forms.ToolStripMenuItem viewMapToolStripMenuItem;
        private System.Windows.Forms.Label lblResultsCount;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstTerritory;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstCity;
        private ZeqkTools.WindowsForms.Controls.CheckedListComboBox chklstDepartment;



    }
}