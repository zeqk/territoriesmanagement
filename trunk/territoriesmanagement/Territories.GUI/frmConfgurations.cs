using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Territories.BLL;

namespace Territories.GUI
{
    public partial class frmConfgurations : Form
    {
        public frmConfgurations()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (chkAddresses.Checked)
            {
                Addresses server = new Addresses();
                server.DeleteAll();                
            }
        }
    }
}
