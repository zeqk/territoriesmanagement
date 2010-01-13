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
            for (int i = 0; i < 40; i++)
            {
                list.Add(new Item(i,i.ToString()));
            }
            checkedListComboBox1.DisplayMember = "Name";
            checkedListComboBox1.DataSource = list;


        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }




        
    }
}
