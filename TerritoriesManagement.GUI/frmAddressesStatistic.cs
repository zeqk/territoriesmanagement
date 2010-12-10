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
    public partial class frmAddressesStatistic : Form
    {
        public frmAddressesStatistic()
        {
            InitializeComponent();
            txtDistance.Text = (1).ToString();
        }       

        public int Distance
        {
            get { return int.Parse(txtDistance.Text); }
        }
	

        private void btnView_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
