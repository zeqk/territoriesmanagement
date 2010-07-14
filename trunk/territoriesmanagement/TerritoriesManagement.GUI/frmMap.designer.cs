namespace TerritoriesManagement.GUI
{
    partial class frmMap
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
            this.btnGenImage = new System.Windows.Forms.Button();
            this.sfdSaveScreen = new System.Windows.Forms.SaveFileDialog();
            this.tableBody = new System.Windows.Forms.TableLayoutPanel();
            this.tableProperties = new System.Windows.Forms.TableLayoutPanel();
            this.panelAdData = new BSE.Windows.Forms.Panel();
            this.splitter1 = new BSE.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xPanderLstAdData = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanTerritories = new BSE.Windows.Forms.XPanderPanel();
            this.chklstTerritories = new AltosTools.WindowsForms.Controls.ExtendedCheckedListBox(this.components);
            this.xPanderAdresses = new BSE.Windows.Forms.XPanderPanel();
            this.xPanderLstAddresses = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderAddressesByTerritory = new BSE.Windows.Forms.XPanderPanel();
            this.chklstTerritory = new AltosTools.WindowsForms.Controls.ExtendedCheckedListBox(this.components);
            this.xPanderAddressesByDepartment = new BSE.Windows.Forms.XPanderPanel();
            this.chklstDepartment = new AltosTools.WindowsForms.Controls.ExtendedCheckedListBox(this.components);
            this.btnViewAdData = new System.Windows.Forms.Button();
            this.panelBase = new System.Windows.Forms.Panel();
            this.tableBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.tableMap = new System.Windows.Forms.TableLayoutPanel();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.panelMap = new System.Windows.Forms.Panel();
            this.MainMap = new AltosTools.WindowsForms.Maps.ExtendedGMapControl(this.components);
            this.tableMapActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnToStaticMap = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelMapType = new System.Windows.Forms.Panel();
            this.cboMapType = new System.Windows.Forms.ComboBox();
            this.lblMapType = new System.Windows.Forms.Label();
            this.splitLatLng = new System.Windows.Forms.SplitContainer();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblLng = new System.Windows.Forms.Label();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panelAdData.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.xPanderLstAdData.SuspendLayout();
            this.xPanTerritories.SuspendLayout();
            this.xPanderAdresses.SuspendLayout();
            this.xPanderLstAddresses.SuspendLayout();
            this.xPanderAddressesByTerritory.SuspendLayout();
            this.xPanderAddressesByDepartment.SuspendLayout();
            this.panelBase.SuspendLayout();
            this.tableBase.SuspendLayout();
            this.tableSearch.SuspendLayout();
            this.tableMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.panelMap.SuspendLayout();
            this.tableMapActions.SuspendLayout();
            this.panelMapType.SuspendLayout();
            this.splitLatLng.Panel1.SuspendLayout();
            this.splitLatLng.Panel2.SuspendLayout();
            this.splitLatLng.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenImage
            // 
            this.btnGenImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenImage.Location = new System.Drawing.Point(12, 3);
            this.btnGenImage.Name = "btnGenImage";
            this.btnGenImage.Size = new System.Drawing.Size(91, 28);
            this.btnGenImage.TabIndex = 12;
            this.btnGenImage.Text = "To image";
            this.btnGenImage.UseVisualStyleBackColor = true;
            this.btnGenImage.Click += new System.EventHandler(this.btnGenImage_Click);
            // 
            // tableBody
            // 
            this.tableBody.ColumnCount = 2;
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBody.Location = new System.Drawing.Point(3, 23);
            this.tableBody.Name = "tableBody";
            this.tableBody.RowCount = 1;
            this.tableBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBody.Size = new System.Drawing.Size(194, 14);
            this.tableBody.TabIndex = 1;
            // 
            // tableProperties
            // 
            this.tableProperties.ColumnCount = 3;
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableProperties.Location = new System.Drawing.Point(3, 3);
            this.tableProperties.Name = "tableProperties";
            this.tableProperties.RowCount = 2;
            this.tableProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.63636F));
            this.tableProperties.Size = new System.Drawing.Size(545, 43);
            this.tableProperties.TabIndex = 16;
            // 
            // panelAdData
            // 
            this.panelAdData.AssociatedSplitter = this.splitter1;
            this.panelAdData.BackColor = System.Drawing.Color.Transparent;
            this.panelAdData.CaptionHeight = 27;
            this.panelAdData.Controls.Add(this.splitContainer1);
            this.panelAdData.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panelAdData.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panelAdData.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelAdData.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelAdData.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panelAdData.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelAdData.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelAdData.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelAdData.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelAdData.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelAdData.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panelAdData.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelAdData.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panelAdData.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAdData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelAdData.Image = null;
            this.panelAdData.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelAdData.Location = new System.Drawing.Point(0, 0);
            this.panelAdData.MinimumSize = new System.Drawing.Size(27, 27);
            this.panelAdData.Name = "panelAdData";
            this.panelAdData.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panelAdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelAdData.ShowExpandIcon = true;
            this.panelAdData.Size = new System.Drawing.Size(200, 628);
            this.panelAdData.TabIndex = 36;
            this.panelAdData.Text = "Additional data";
            this.panelAdData.ToolTipTextCloseIcon = null;
            this.panelAdData.ToolTipTextExpandIconPanelCollapsed = null;
            this.panelAdData.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Transparent;
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 628);
            this.splitter1.TabIndex = 37;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xPanderLstAdData);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnViewAdData);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(198, 599);
            this.splitContainer1.SplitterDistance = 556;
            this.splitContainer1.TabIndex = 0;
            // 
            // xPanderLstAdData
            // 
            this.xPanderLstAdData.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderLstAdData.Controls.Add(this.xPanTerritories);
            this.xPanderLstAdData.Controls.Add(this.xPanderAdresses);
            this.xPanderLstAdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderLstAdData.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderLstAdData.Location = new System.Drawing.Point(0, 0);
            this.xPanderLstAdData.Name = "xPanderLstAdData";
            this.xPanderLstAdData.PanelColors = null;
            this.xPanderLstAdData.ShowExpandIcon = true;
            this.xPanderLstAdData.Size = new System.Drawing.Size(198, 556);
            this.xPanderLstAdData.TabIndex = 1;
            this.xPanderLstAdData.Text = "xPanderPanelList1";
            // 
            // xPanTerritories
            // 
            this.xPanTerritories.Controls.Add(this.chklstTerritories);
            this.xPanTerritories.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanTerritories.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanTerritories.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanTerritories.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanTerritories.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanTerritories.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanTerritories.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanTerritories.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanTerritories.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanTerritories.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanTerritories.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanTerritories.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanTerritories.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanTerritories.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanTerritories.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanTerritories.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanTerritories.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanTerritories.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanTerritories.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanTerritories.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanTerritories.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanTerritories.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanTerritories.Image = null;
            this.xPanTerritories.Name = "xPanTerritories";
            this.xPanTerritories.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanTerritories.Size = new System.Drawing.Size(198, 25);
            this.xPanTerritories.TabIndex = 0;
            this.xPanTerritories.Text = "Territories";
            this.xPanTerritories.ToolTipTextCloseIcon = null;
            this.xPanTerritories.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanTerritories.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // chklstTerritories
            // 
            this.chklstTerritories.CheckOnClick = true;
            this.chklstTerritories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklstTerritories.FormattingEnabled = true;
            this.chklstTerritories.Location = new System.Drawing.Point(1, 25);
            this.chklstTerritories.Name = "chklstTerritories";
            this.chklstTerritories.Size = new System.Drawing.Size(196, 4);
            this.chklstTerritories.TabIndex = 0;
            // 
            // xPanderAdresses
            // 
            this.xPanderAdresses.Controls.Add(this.xPanderLstAddresses);
            this.xPanderAdresses.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderAdresses.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderAdresses.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderAdresses.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderAdresses.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderAdresses.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderAdresses.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderAdresses.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderAdresses.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderAdresses.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderAdresses.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAdresses.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAdresses.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAdresses.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAdresses.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAdresses.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAdresses.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderAdresses.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderAdresses.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderAdresses.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderAdresses.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderAdresses.Expand = true;
            this.xPanderAdresses.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderAdresses.Image = null;
            this.xPanderAdresses.Name = "xPanderAdresses";
            this.xPanderAdresses.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderAdresses.Size = new System.Drawing.Size(198, 531);
            this.xPanderAdresses.TabIndex = 1;
            this.xPanderAdresses.Text = "Addresses";
            this.xPanderAdresses.ToolTipTextCloseIcon = null;
            this.xPanderAdresses.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderAdresses.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // xPanderLstAddresses
            // 
            this.xPanderLstAddresses.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderLstAddresses.Controls.Add(this.xPanderAddressesByTerritory);
            this.xPanderLstAddresses.Controls.Add(this.xPanderAddressesByDepartment);
            this.xPanderLstAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderLstAddresses.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderLstAddresses.Location = new System.Drawing.Point(0, 25);
            this.xPanderLstAddresses.Name = "xPanderLstAddresses";
            this.xPanderLstAddresses.PanelColors = null;
            this.xPanderLstAddresses.ShowExpandIcon = true;
            this.xPanderLstAddresses.Size = new System.Drawing.Size(198, 505);
            this.xPanderLstAddresses.TabIndex = 0;
            this.xPanderLstAddresses.Text = "xPanderPanelList1";
            // 
            // xPanderAddressesByTerritory
            // 
            this.xPanderAddressesByTerritory.Controls.Add(this.chklstTerritory);
            this.xPanderAddressesByTerritory.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderAddressesByTerritory.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderAddressesByTerritory.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderAddressesByTerritory.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderAddressesByTerritory.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByTerritory.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByTerritory.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderAddressesByTerritory.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByTerritory.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByTerritory.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByTerritory.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderAddressesByTerritory.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderAddressesByTerritory.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderAddressesByTerritory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByTerritory.Image = null;
            this.xPanderAddressesByTerritory.Name = "xPanderAddressesByTerritory";
            this.xPanderAddressesByTerritory.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderAddressesByTerritory.Size = new System.Drawing.Size(198, 25);
            this.xPanderAddressesByTerritory.TabIndex = 0;
            this.xPanderAddressesByTerritory.Text = "  by territories";
            this.xPanderAddressesByTerritory.ToolTipTextCloseIcon = null;
            this.xPanderAddressesByTerritory.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderAddressesByTerritory.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // chklstTerritory
            // 
            this.chklstTerritory.CheckOnClick = true;
            this.chklstTerritory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklstTerritory.FormattingEnabled = true;
            this.chklstTerritory.Location = new System.Drawing.Point(1, 25);
            this.chklstTerritory.Name = "chklstTerritory";
            this.chklstTerritory.Size = new System.Drawing.Size(196, 4);
            this.chklstTerritory.TabIndex = 0;
            // 
            // xPanderAddressesByDepartment
            // 
            this.xPanderAddressesByDepartment.Controls.Add(this.chklstDepartment);
            this.xPanderAddressesByDepartment.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderAddressesByDepartment.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderAddressesByDepartment.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderAddressesByDepartment.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderAddressesByDepartment.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByDepartment.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByDepartment.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderAddressesByDepartment.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderAddressesByDepartment.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByDepartment.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByDepartment.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderAddressesByDepartment.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderAddressesByDepartment.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderAddressesByDepartment.Expand = true;
            this.xPanderAddressesByDepartment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderAddressesByDepartment.Image = null;
            this.xPanderAddressesByDepartment.Name = "xPanderAddressesByDepartment";
            this.xPanderAddressesByDepartment.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderAddressesByDepartment.Size = new System.Drawing.Size(198, 480);
            this.xPanderAddressesByDepartment.TabIndex = 1;
            this.xPanderAddressesByDepartment.Text = "  by departments";
            this.xPanderAddressesByDepartment.ToolTipTextCloseIcon = null;
            this.xPanderAddressesByDepartment.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderAddressesByDepartment.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // chklstDepartment
            // 
            this.chklstDepartment.CheckOnClick = true;
            this.chklstDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklstDepartment.FormattingEnabled = true;
            this.chklstDepartment.Location = new System.Drawing.Point(1, 25);
            this.chklstDepartment.Name = "chklstDepartment";
            this.chklstDepartment.Size = new System.Drawing.Size(196, 454);
            this.chklstDepartment.TabIndex = 0;
            // 
            // btnViewAdData
            // 
            this.btnViewAdData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAdData.Location = new System.Drawing.Point(34, 3);
            this.btnViewAdData.Name = "btnViewAdData";
            this.btnViewAdData.Size = new System.Drawing.Size(130, 33);
            this.btnViewAdData.TabIndex = 0;
            this.btnViewAdData.Text = "View additional data";
            this.btnViewAdData.UseVisualStyleBackColor = true;
            this.btnViewAdData.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelBase
            // 
            this.panelBase.Controls.Add(this.tableBase);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(203, 0);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(761, 628);
            this.panelBase.TabIndex = 38;
            // 
            // tableBase
            // 
            this.tableBase.ColumnCount = 1;
            this.tableBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.Controls.Add(this.tableSearch, 0, 0);
            this.tableBase.Controls.Add(this.tableMap, 0, 1);
            this.tableBase.Controls.Add(this.tableMapActions, 0, 2);
            this.tableBase.Controls.Add(this.tableButtons, 0, 3);
            this.tableBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBase.Location = new System.Drawing.Point(0, 0);
            this.tableBase.Name = "tableBase";
            this.tableBase.RowCount = 4;
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBase.Size = new System.Drawing.Size(761, 628);
            this.tableBase.TabIndex = 36;
            // 
            // tableSearch
            // 
            this.tableSearch.ColumnCount = 2;
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableSearch.Controls.Add(this.txtAddress, 0, 0);
            this.tableSearch.Controls.Add(this.btnGo, 1, 0);
            this.tableSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSearch.Location = new System.Drawing.Point(3, 3);
            this.tableSearch.Name = "tableSearch";
            this.tableSearch.RowCount = 1;
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSearch.Size = new System.Drawing.Size(755, 39);
            this.tableSearch.TabIndex = 34;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(3, 9);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(672, 20);
            this.txtAddress.TabIndex = 8;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(681, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(71, 33);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tableMap
            // 
            this.tableMap.ColumnCount = 2;
            this.tableMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableMap.Controls.Add(this.trackBarZoom, 1, 0);
            this.tableMap.Controls.Add(this.panelMap, 0, 0);
            this.tableMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMap.Location = new System.Drawing.Point(3, 48);
            this.tableMap.Name = "tableMap";
            this.tableMap.RowCount = 1;
            this.tableMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMap.Size = new System.Drawing.Size(755, 482);
            this.tableMap.TabIndex = 35;
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trackBarZoom.AutoSize = false;
            this.trackBarZoom.LargeChange = 1;
            this.trackBarZoom.Location = new System.Drawing.Point(713, 3);
            this.trackBarZoom.Maximum = 17;
            this.trackBarZoom.Minimum = 1;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZoom.Size = new System.Drawing.Size(34, 476);
            this.trackBarZoom.TabIndex = 30;
            this.trackBarZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarZoom.Value = 12;
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // panelMap
            // 
            this.panelMap.Controls.Add(this.MainMap);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(3, 3);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(699, 476);
            this.panelMap.TabIndex = 31;
            // 
            // MainMap
            // 
            this.MainMap.AllowDrawPolygon = false;
            this.MainMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.MapType = GMap.NET.MapType.GoogleMap;
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(699, 476);
            this.MainMap.TabIndex = 32;
            this.MainMap.Zoom = 2;
            // 
            // tableMapActions
            // 
            this.tableMapActions.ColumnCount = 4;
            this.tableMapActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableMapActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableMapActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableMapActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMapActions.Controls.Add(this.btnToStaticMap, 0, 0);
            this.tableMapActions.Controls.Add(this.btnClear, 1, 0);
            this.tableMapActions.Controls.Add(this.panelMapType, 3, 0);
            this.tableMapActions.Controls.Add(this.splitLatLng, 2, 0);
            this.tableMapActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMapActions.Location = new System.Drawing.Point(3, 536);
            this.tableMapActions.Name = "tableMapActions";
            this.tableMapActions.RowCount = 1;
            this.tableMapActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMapActions.Size = new System.Drawing.Size(755, 44);
            this.tableMapActions.TabIndex = 36;
            // 
            // btnToStaticMap
            // 
            this.btnToStaticMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToStaticMap.Location = new System.Drawing.Point(3, 3);
            this.btnToStaticMap.Name = "btnToStaticMap";
            this.btnToStaticMap.Size = new System.Drawing.Size(75, 38);
            this.btnToStaticMap.TabIndex = 15;
            this.btnToStaticMap.Text = "To image";
            this.btnToStaticMap.UseVisualStyleBackColor = true;
            this.btnToStaticMap.Click += new System.EventHandler(this.btnGenImage_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Location = new System.Drawing.Point(103, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear area";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelMapType
            // 
            this.panelMapType.Controls.Add(this.cboMapType);
            this.panelMapType.Controls.Add(this.lblMapType);
            this.panelMapType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMapType.Location = new System.Drawing.Point(505, 3);
            this.panelMapType.Name = "panelMapType";
            this.panelMapType.Size = new System.Drawing.Size(247, 38);
            this.panelMapType.TabIndex = 19;
            // 
            // cboMapType
            // 
            this.cboMapType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapType.FormattingEnabled = true;
            this.cboMapType.Location = new System.Drawing.Point(2, 14);
            this.cboMapType.Name = "cboMapType";
            this.cboMapType.Size = new System.Drawing.Size(242, 21);
            this.cboMapType.TabIndex = 16;
            this.cboMapType.SelectedValueChanged += new System.EventHandler(this.cboMapType_SelectedValueChanged);
            // 
            // lblMapType
            // 
            this.lblMapType.AutoSize = true;
            this.lblMapType.Location = new System.Drawing.Point(3, 0);
            this.lblMapType.Name = "lblMapType";
            this.lblMapType.Size = new System.Drawing.Size(51, 13);
            this.lblMapType.TabIndex = 15;
            this.lblMapType.Text = "Map type";
            // 
            // splitLatLng
            // 
            this.splitLatLng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLatLng.Location = new System.Drawing.Point(203, 3);
            this.splitLatLng.Name = "splitLatLng";
            // 
            // splitLatLng.Panel1
            // 
            this.splitLatLng.Panel1.Controls.Add(this.lblLat);
            this.splitLatLng.Panel1.Controls.Add(this.txtLat);
            // 
            // splitLatLng.Panel2
            // 
            this.splitLatLng.Panel2.Controls.Add(this.lblLng);
            this.splitLatLng.Panel2.Controls.Add(this.txtLng);
            this.splitLatLng.Size = new System.Drawing.Size(296, 38);
            this.splitLatLng.SplitterDistance = 142;
            this.splitLatLng.TabIndex = 20;
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(-3, 0);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(45, 13);
            this.lblLat.TabIndex = 16;
            this.lblLat.Text = "Latitude";
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.Location = new System.Drawing.Point(0, 15);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(139, 20);
            this.txtLat.TabIndex = 0;
            // 
            // lblLng
            // 
            this.lblLng.AutoSize = true;
            this.lblLng.Location = new System.Drawing.Point(2, 2);
            this.lblLng.Name = "lblLng";
            this.lblLng.Size = new System.Drawing.Size(54, 13);
            this.lblLng.TabIndex = 18;
            this.lblLng.Text = "Longitude";
            // 
            // txtLng
            // 
            this.txtLng.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLng.Location = new System.Drawing.Point(5, 17);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(144, 20);
            this.txtLng.TabIndex = 17;
            // 
            // tableButtons
            // 
            this.tableButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableButtons.ColumnCount = 2;
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.Controls.Add(this.btnCancel, 0, 0);
            this.tableButtons.Controls.Add(this.btnOk, 1, 0);
            this.tableButtons.Location = new System.Drawing.Point(624, 586);
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.RowCount = 1;
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableButtons.Size = new System.Drawing.Size(134, 39);
            this.tableButtons.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 33);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(70, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 33);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 628);
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelAdData);
            this.Name = "frmMap";
            this.Text = "Area";
            this.Load += new System.EventHandler(this.frmGeoArea_Load);
            this.panelAdData.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.xPanderLstAdData.ResumeLayout(false);
            this.xPanTerritories.ResumeLayout(false);
            this.xPanderAdresses.ResumeLayout(false);
            this.xPanderLstAddresses.ResumeLayout(false);
            this.xPanderAddressesByTerritory.ResumeLayout(false);
            this.xPanderAddressesByDepartment.ResumeLayout(false);
            this.panelBase.ResumeLayout(false);
            this.tableBase.ResumeLayout(false);
            this.tableSearch.ResumeLayout(false);
            this.tableSearch.PerformLayout();
            this.tableMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.panelMap.ResumeLayout(false);
            this.tableMapActions.ResumeLayout(false);
            this.panelMapType.ResumeLayout(false);
            this.panelMapType.PerformLayout();
            this.splitLatLng.Panel1.ResumeLayout(false);
            this.splitLatLng.Panel1.PerformLayout();
            this.splitLatLng.Panel2.ResumeLayout(false);
            this.splitLatLng.Panel2.PerformLayout();
            this.splitLatLng.ResumeLayout(false);
            this.tableButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenImage;
        private System.Windows.Forms.SaveFileDialog sfdSaveScreen;
        private System.Windows.Forms.TableLayoutPanel tableBody;
        private System.Windows.Forms.TableLayoutPanel tableProperties;
        private BSE.Windows.Forms.Panel panelAdData;
        private BSE.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.TableLayoutPanel tableBase;
        private System.Windows.Forms.TableLayoutPanel tableSearch;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TableLayoutPanel tableMap;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Panel panelMap;
        private AltosTools.WindowsForms.Maps.ExtendedGMapControl MainMap;
        private System.Windows.Forms.TableLayoutPanel tableMapActions;
        private System.Windows.Forms.Button btnToStaticMap;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelMapType;
        private System.Windows.Forms.ComboBox cboMapType;
        private System.Windows.Forms.Label lblMapType;
        private System.Windows.Forms.SplitContainer splitLatLng;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label lblLng;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BSE.Windows.Forms.XPanderPanelList xPanderLstAdData;
        private BSE.Windows.Forms.XPanderPanel xPanTerritories;
        private BSE.Windows.Forms.XPanderPanel xPanderAdresses;
        private System.Windows.Forms.Button btnViewAdData;
        private BSE.Windows.Forms.XPanderPanelList xPanderLstAddresses;
        private BSE.Windows.Forms.XPanderPanel xPanderAddressesByTerritory;
        private BSE.Windows.Forms.XPanderPanel xPanderAddressesByDepartment;
        private AltosTools.WindowsForms.Controls.ExtendedCheckedListBox chklstTerritories;
        private AltosTools.WindowsForms.Controls.ExtendedCheckedListBox chklstTerritory;
        private AltosTools.WindowsForms.Controls.ExtendedCheckedListBox chklstDepartment;

    }
}