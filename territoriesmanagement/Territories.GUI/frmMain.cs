﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Territories.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuDepartments_Click(object sender, EventArgs e)
        {
            frmDepartments myForm = new frmDepartments();
            myForm.MdiParent = this;
            myForm.Show();
                
        }

        private void mnuCities_Click(object sender, EventArgs e)
        {
            
        }
    }
}