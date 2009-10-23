namespace Territories.GUI
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
            this.schStreet = new ZeqkTools.Controls.Search();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.cboTerritory = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyGoogleMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel2.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.AccessibleDescription = null;
            this.btnAll.AccessibleName = null;
            resources.ApplyResources(this.btnAll, "btnAll");
            this.btnAll.BackgroundImage = null;
            this.btnAll.Font = null;
            this.btnAll.Name = "btnAll";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleDescription = null;
            this.btnSearch.AccessibleName = null;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.BackgroundImage = null;
            this.btnSearch.Font = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = null;
            this.btnDelete.AccessibleName = null;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.BackgroundImage = null;
            this.btnDelete.Font = null;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleDescription = null;
            this.btnEdit.AccessibleName = null;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.BackgroundImage = null;
            this.btnEdit.Font = null;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleDescription = null;
            this.btnNew.AccessibleName = null;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.BackgroundImage = null;
            this.btnNew.Font = null;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblFiltered
            // 
            this.lblFiltered.AccessibleDescription = null;
            this.lblFiltered.AccessibleName = null;
            resources.ApplyResources(this.lblFiltered, "lblFiltered");
            this.lblFiltered.Font = null;
            this.lblFiltered.Name = "lblFiltered";
            // 
            // lblResults
            // 
            this.lblResults.AccessibleDescription = null;
            this.lblResults.AccessibleName = null;
            resources.ApplyResources(this.lblResults, "lblResults");
            this.lblResults.Font = null;
            this.lblResults.Name = "lblResults";
            // 
            // dgvResults
            // 
            this.dgvResults.AccessibleDescription = null;
            this.dgvResults.AccessibleName = null;
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.BackgroundImage = null;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Font = null;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvResults_MouseClick);
            // 
            // panel2
            // 
            this.panel2.AccessibleDescription = null;
            this.panel2.AccessibleName = null;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackgroundImage = null;
            this.panel2.Controls.Add(this.chkDescription);
            this.panel2.Controls.Add(this.chkStreet);
            this.panel2.Controls.Add(this.chkCorners);
            this.panel2.Controls.Add(this.schStreet);
            this.panel2.Controls.Add(this.lblTerritory);
            this.panel2.Controls.Add(this.cboTerritory);
            this.panel2.Controls.Add(this.lblAddress);
            this.panel2.Controls.Add(this.lblCity);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.cboCity);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Font = null;
            this.panel2.Name = "panel2";
            // 
            // chkDescription
            // 
            this.chkDescription.AccessibleDescription = null;
            this.chkDescription.AccessibleName = null;
            resources.ApplyResources(this.chkDescription, "chkDescription");
            this.chkDescription.BackgroundImage = null;
            this.chkDescription.Font = null;
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.UseVisualStyleBackColor = true;
            this.chkDescription.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // chkStreet
            // 
            this.chkStreet.AccessibleDescription = null;
            this.chkStreet.AccessibleName = null;
            resources.ApplyResources(this.chkStreet, "chkStreet");
            this.chkStreet.BackgroundImage = null;
            this.chkStreet.Font = null;
            this.chkStreet.Name = "chkStreet";
            this.chkStreet.UseVisualStyleBackColor = true;
            this.chkStreet.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // chkCorners
            // 
            this.chkCorners.AccessibleDescription = null;
            this.chkCorners.AccessibleName = null;
            resources.ApplyResources(this.chkCorners, "chkCorners");
            this.chkCorners.BackgroundImage = null;
            this.chkCorners.Font = null;
            this.chkCorners.Name = "chkCorners";
            this.chkCorners.UseVisualStyleBackColor = true;
            this.chkCorners.CheckedChanged += new System.EventHandler(this.fields_CheckedChanged);
            // 
            // schStreet
            // 
            this.schStreet.AccessibleDescription = null;
            this.schStreet.AccessibleName = null;
            resources.ApplyResources(this.schStreet, "schStreet");
            this.schStreet.BackgroundImage = null;
            this.schStreet.Columns = null;
            this.schStreet.Criteria = ZeqkTools.Query.Enumerators.Criterias.EqualTo;
            this.schStreet.Font = null;
            this.schStreet.Name = "schStreet";
            this.schStreet.Parameters = null;
            this.schStreet.Query = null;
            this.schStreet.VariableNames = null;
            // 
            // lblTerritory
            // 
            this.lblTerritory.AccessibleDescription = null;
            this.lblTerritory.AccessibleName = null;
            resources.ApplyResources(this.lblTerritory, "lblTerritory");
            this.lblTerritory.Font = null;
            this.lblTerritory.Name = "lblTerritory";
            // 
            // cboTerritory
            // 
            this.cboTerritory.AccessibleDescription = null;
            this.cboTerritory.AccessibleName = null;
            resources.ApplyResources(this.cboTerritory, "cboTerritory");
            this.cboTerritory.BackgroundImage = null;
            this.cboTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerritory.Font = null;
            this.cboTerritory.FormattingEnabled = true;
            this.cboTerritory.Name = "cboTerritory";
            // 
            // lblAddress
            // 
            this.lblAddress.AccessibleDescription = null;
            this.lblAddress.AccessibleName = null;
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Font = null;
            this.lblAddress.Name = "lblAddress";
            // 
            // lblCity
            // 
            this.lblCity.AccessibleDescription = null;
            this.lblCity.AccessibleName = null;
            resources.ApplyResources(this.lblCity, "lblCity");
            this.lblCity.Font = null;
            this.lblCity.Name = "lblCity";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AccessibleDescription = null;
            this.lblDepartment.AccessibleName = null;
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Font = null;
            this.lblDepartment.Name = "lblDepartment";
            // 
            // cboCity
            // 
            this.cboCity.AccessibleDescription = null;
            this.cboCity.AccessibleName = null;
            resources.ApplyResources(this.cboCity, "cboCity");
            this.cboCity.BackgroundImage = null;
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.Font = null;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Name = "cboCity";
            // 
            // cboDepartment
            // 
            this.cboDepartment.AccessibleDescription = null;
            this.cboDepartment.AccessibleName = null;
            resources.ApplyResources(this.cboDepartment, "cboDepartment");
            this.cboDepartment.BackgroundImage = null;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = null;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // ctxMenu
            // 
            this.ctxMenu.AccessibleDescription = null;
            this.ctxMenu.AccessibleName = null;
            resources.ApplyResources(this.ctxMenu, "ctxMenu");
            this.ctxMenu.BackgroundImage = null;
            this.ctxMenu.Font = null;
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGoogleMapsToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            // 
            // copyGoogleMapsToolStripMenuItem
            // 
            this.copyGoogleMapsToolStripMenuItem.AccessibleDescription = null;
            this.copyGoogleMapsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyGoogleMapsToolStripMenuItem, "copyGoogleMapsToolStripMenuItem");
            this.copyGoogleMapsToolStripMenuItem.BackgroundImage = null;
            this.copyGoogleMapsToolStripMenuItem.Name = "copyGoogleMapsToolStripMenuItem";
            this.copyGoogleMapsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.copyGoogleMapsToolStripMenuItem.Click += new System.EventHandler(this.copyGoogleMapsToolStripMenuItem_Click);
            // 
            // frmAddresses
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lblFiltered);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSearch);
            this.Font = null;
            this.Icon = null;
            this.Name = "frmAddresses";
            this.Load += new System.EventHandler(this.frmAddresses_Load);
            this.panel1.ResumeLayout(false);
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
        private ZeqkTools.Controls.Search schStreet;
        private System.Windows.Forms.Label lblTerritory;
        private System.Windows.Forms.ComboBox cboTerritory;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem copyGoogleMapsToolStripMenuItem;



    }
}