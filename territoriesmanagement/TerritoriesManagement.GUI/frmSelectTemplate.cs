using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerritoriesManagement.GUI
{
    public partial class frmSelectTemplate : Form
    {
        public frmSelectTemplate()
        {
            InitializeComponent();
        }

        public string TemplatePath = "";


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            TemplatePath = txtTemplate.Text;    

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
