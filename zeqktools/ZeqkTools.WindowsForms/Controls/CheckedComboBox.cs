using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeqkTools.WindowsForms.Controls
{
    public partial class CheckedComboBox : PopupComboBox
    {
        public object DataSource
        {
            get { return checkedListBox.DataSource; }
            set { checkedListBox.DataSource = value; }
        }

        public string DisplayMember
        {
            get { return checkedListBox.DisplayMember; }
            set { checkedListBox.DisplayMember = value; }
        }
        public string ValueMember
        {
            get { return checkedListBox.ValueMember; }
            set { checkedListBox.ValueMember = value; }
        }
	

        public CheckedComboBox()
        {
            InitializeComponent();
            //base.DropDownHeight = this.Height;
            base.DropDownControl = checkedListBox;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
