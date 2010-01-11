using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            List<Item> list = new List<Item>();
            list.Add(new Item(1, "uno"));
            list.Add(new Item(2, "dos"));
            list.Add(new Item(3, "tres"));

            
            //checkedComboBox1.DisplayMember = "Name";
            //checkedComboBox1.ValueMember = "Id";
            checkedComboBox1.DataSource = list;
            userControl11.DataSource = list;

        }




        
    }
}
