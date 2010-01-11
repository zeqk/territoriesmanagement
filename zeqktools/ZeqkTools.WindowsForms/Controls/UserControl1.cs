using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeqkTools.WindowsForms.Controls
{
    public partial class UserControl1 : UserControl
    {
        Popup pop;

        public object DataSource
        {
            get { return checkedListBox.DataSource; }
            set { checkedListBox.DataSource = value; }
        }

        public UserControl1()
        {
            InitializeComponent();
            pop = new Popup(checkedListBox);
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            pop.Show(textBox);
        }
    }
}
