namespace TerritoriesManagement.GUI.Interop.Steps
{
    partial class SetConnStepUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetConnStepUI));
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.btnConfigureConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConnectStr
            // 
            this.txtConnectStr.Location = new System.Drawing.Point(27, 29);
            this.txtConnectStr.Multiline = true;
            this.txtConnectStr.Name = "txtConnectStr";
            this.txtConnectStr.Size = new System.Drawing.Size(289, 84);
            this.txtConnectStr.TabIndex = 16;
            this.txtConnectStr.TextChanged += new System.EventHandler(this.txtConnectStr_TextChanged);
            // 
            // btnConfigureConnection
            // 
            this.btnConfigureConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigureConnection.Image")));
            this.btnConfigureConnection.Location = new System.Drawing.Point(97, 119);
            this.btnConfigureConnection.Name = "btnConfigureConnection";
            this.btnConfigureConnection.Size = new System.Drawing.Size(125, 39);
            this.btnConfigureConnection.TabIndex = 18;
            this.btnConfigureConnection.Text = "Configure";
            this.btnConfigureConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfigureConnection.UseVisualStyleBackColor = true;
            this.btnConfigureConnection.Click += new System.EventHandler(this.btnConfigureConnection_Click);
            // 
            // SetConnUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfigureConnection);
            this.Controls.Add(this.txtConnectStr);
            this.Name = "SetConnUI";
            this.Size = new System.Drawing.Size(343, 175);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfigureConnection;
        private System.Windows.Forms.TextBox txtConnectStr;
    }
}
