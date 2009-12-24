namespace ZeqkTools.WindowsForms
{
    partial class ConnectionStringMaker
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
            this.grpProvider = new System.Windows.Forms.GroupBox();
            this.cboDataProvider = new System.Windows.Forms.ComboBox();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.propConnection = new System.Windows.Forms.PropertyGrid();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdSlectSource = new System.Windows.Forms.OpenFileDialog();
            this.grpProvider.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProvider
            // 
            this.grpProvider.Controls.Add(this.cboDataProvider);
            this.grpProvider.Location = new System.Drawing.Point(12, 12);
            this.grpProvider.Name = "grpProvider";
            this.grpProvider.Size = new System.Drawing.Size(390, 73);
            this.grpProvider.TabIndex = 0;
            this.grpProvider.TabStop = false;
            this.grpProvider.Text = "Select data provider";
            // 
            // cboDataProvider
            // 
            this.cboDataProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataProvider.FormattingEnabled = true;
            this.cboDataProvider.Location = new System.Drawing.Point(20, 30);
            this.cboDataProvider.Name = "cboDataProvider";
            this.cboDataProvider.Size = new System.Drawing.Size(350, 21);
            this.cboDataProvider.TabIndex = 0;
            this.cboDataProvider.SelectedIndexChanged += new System.EventHandler(this.cboDataProvider_SelectedIndexChanged);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.propConnection);
            this.grpConnection.Controls.Add(this.btnSelectSource);
            this.grpConnection.Controls.Add(this.lblDataSource);
            this.grpConnection.Controls.Add(this.txtDataSource);
            this.grpConnection.Location = new System.Drawing.Point(13, 92);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(389, 351);
            this.grpConnection.TabIndex = 1;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Configure connection";
            // 
            // propConnection
            // 
            this.propConnection.Location = new System.Drawing.Point(19, 66);
            this.propConnection.Name = "propConnection";
            this.propConnection.Size = new System.Drawing.Size(350, 268);
            this.propConnection.TabIndex = 3;
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Location = new System.Drawing.Point(334, 38);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(35, 21);
            this.btnSelectSource.TabIndex = 2;
            this.btnSelectSource.Text = "...";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(16, 23);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(65, 13);
            this.lblDataSource.TabIndex = 1;
            this.lblDataSource.Text = "Data source";
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(19, 39);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(309, 20);
            this.txtDataSource.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(327, 449);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(236, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofdSlectSource
            // 
            this.ofdSlectSource.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdSlectSource_FileOk);
            // 
            // ConnectionStringMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 486);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.grpProvider);
            this.Name = "ConnectionStringMaker";
            this.Text = "Make connection string";
            this.Load += new System.EventHandler(this.ConnectionStringMaker_Load);
            this.grpProvider.ResumeLayout(false);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProvider;
        private System.Windows.Forms.ComboBox cboDataProvider;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.PropertyGrid propConnection;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog ofdSlectSource;
    }
}