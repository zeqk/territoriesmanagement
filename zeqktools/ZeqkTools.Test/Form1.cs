using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZeqkTools.WindowsForms;

namespace ZeqkTools.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZeqkTools.WindowsForms.Maps.frmGeoPoint myForm = new ZeqkTools.WindowsForms.Maps.frmGeoPoint();
            myForm.Address = "claypole";
            myForm.ShowDialog();
        }
    }
}
