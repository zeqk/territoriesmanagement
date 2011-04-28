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
    public partial class frmAddressesStatistics : Form
    {
        public frmAddressesStatistics()
        {
            InitializeComponent();
        }       

        public double Distance
        {
            get { return double.Parse(txtDistance.Text); }
        }
	

        private void btnView_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
