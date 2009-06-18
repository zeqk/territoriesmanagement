namespace Territories.GUI
{
    partial class frmMain
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
            this.btnDirections = new System.Windows.Forms.Button();
            this.btnCities = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.bntTerritories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDirections
            // 
            this.btnDirections.Location = new System.Drawing.Point(115, 106);
            this.btnDirections.Name = "btnDirections";
            this.btnDirections.Size = new System.Drawing.Size(175, 64);
            this.btnDirections.TabIndex = 0;
            this.btnDirections.Text = "Directions";
            this.btnDirections.UseVisualStyleBackColor = true;
            this.btnDirections.Click += new System.EventHandler(this.btnDirections_Click);
            // 
            // btnCities
            // 
            this.btnCities.Location = new System.Drawing.Point(387, 54);
            this.btnCities.Name = "btnCities";
            this.btnCities.Size = new System.Drawing.Size(138, 46);
            this.btnCities.TabIndex = 1;
            this.btnCities.Text = "Cities";
            this.btnCities.UseVisualStyleBackColor = true;
            this.btnCities.Click += new System.EventHandler(this.btnCities_Click);
            // 
            // btnDepartments
            // 
            this.btnDepartments.Location = new System.Drawing.Point(387, 106);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(138, 46);
            this.btnDepartments.TabIndex = 2;
            this.btnDepartments.Text = "Departments";
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);
            // 
            // bntTerritories
            // 
            this.bntTerritories.Location = new System.Drawing.Point(387, 158);
            this.bntTerritories.Name = "bntTerritories";
            this.bntTerritories.Size = new System.Drawing.Size(138, 46);
            this.bntTerritories.TabIndex = 3;
            this.bntTerritories.Text = "Territories";
            this.bntTerritories.UseVisualStyleBackColor = true;
            this.bntTerritories.Click += new System.EventHandler(this.bntTerritories_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 290);
            this.Controls.Add(this.bntTerritories);
            this.Controls.Add(this.btnDepartments);
            this.Controls.Add(this.btnCities);
            this.Controls.Add(this.btnDirections);
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDirections;
        private System.Windows.Forms.Button btnCities;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button bntTerritories;

    }
}