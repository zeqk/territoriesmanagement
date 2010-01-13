using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeqkTools.WindowsForms.Controls
{
    public partial class CheckedListComboBox : PopupComboBox
    {
        #region Fields
        private string _concatChar;
        private string _displayMember;    
	
        #endregion

        #region Properties
        public ICollection DataSource
        {
            get { return checkedListBox.Items; }
            set 
            {
                foreach (var item in value)
                    checkedListBox.Items.Add(item);
            }
        }

        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; }
        }

        /// <summary>
        /// A character to concatenate the list of checked items. Default value: comma
        /// </summary>
        public string ConcatChar
        {
            get { return _concatChar; }
            set { _concatChar = value; }
        }
        #endregion

        #region Contructors
        public CheckedListComboBox()
        {
            InitializeComponent();

            this.DropDownControl = checkedListBox;


            _concatChar = ", ";
        }

        public CheckedListComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            this.DropDownControl = checkedListBox;
            _concatChar = ", ";
        }
        #endregion


        private void ResizeCheckedListBox(int? w, int? h)
        {
            checkedListBox = new CheckedListBox();
            if (w.HasValue)
                checkedListBox.Width = w.Value;
            if (h.HasValue)
                checkedListBox.Height = h.Value;

            checkedListBox.DisplayMember = _displayMember;

            checkedListBox.CheckOnClick = true;
            checkedListBox.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_ItemCheck);

            this.DropDownControl = checkedListBox;
        }

        private void CheckedListComboBox_Resize(object sender, EventArgs e)
        {
            ResizeCheckedListBox(this.Width, null);
        }


        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = checkedListBox.Items[e.Index];
            string checkedStr = item.GetType().GetProperty(checkedListBox.DisplayMember).GetValue(item, null).ToString();

            if (e.NewValue == CheckState.Checked)
            {
                if (this.Text != "")
                    checkedStr = _concatChar + checkedStr;
                this.Text += checkedStr;   
            }

            if (e.NewValue == CheckState.Unchecked)
            {
                if (this.Text.Contains(_concatChar))
                    checkedStr = _concatChar + checkedStr;

                int index = this.Text.IndexOf(checkedStr);
                this.Text = this.Text.Remove(index, checkedStr.Length);
            }
            
        }
    }
}
