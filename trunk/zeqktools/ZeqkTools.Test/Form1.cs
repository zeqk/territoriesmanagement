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
            checkedListComboBox1.DisplayMember = "Name";


        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             int total = (int) numericUpDown1.Value;

             List<Item> list = new List<Item>();
             for (int i = 0; i < total; i++)
             {
                 list.Add(new Item(i, i.ToString()));
             }
             checkedListComboBox1.DataSource = list;
        }




        
    }
}
