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
        private string _valueMember;   
	
        #endregion

        #region Properties
        public ICollection DataSource
        {
            get { return checkedListBox.Items; }
            set 
            {
                
                ////1-4
                //if (Enumerable.Range(1, 4).Contains(value.Count))
                //    h = 20 * value.Count;
                //else
                //    h = 17 * value.Count;
                //////5-20
                ////if (Enumerable.Range(5, 16).Contains(value.Count) && h == 0)
                ////    h = 17 * value.Count;
                ////20-
                //if (Enumerable.Range(21, 100).Contains(value.Count) && h == 0)
                //    h = 16 * value.Count;

                //if (Enumerable.Range(15, 5).Contains(value.Count) && h == 0)
                //    h = 16 * value.Count;

                int h = 20 * value.Count;

                ResizeCheckedListBox(this.Width, h);

                foreach (var item in value)
                    checkedListBox.Items.Add(item);
                int aux = checkedListBox.ItemHeight;
            }
        }

        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; }
        }

        public string ValueMember
        {
            get { return _valueMember; }
            set { _valueMember = value; }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return checkedListBox.CheckedItems; }
        }

        public List<object> CheckedItemsValues
        {
            get 
            {
                List<object> rv = new List<object>();
                if(!string.IsNullOrEmpty(_valueMember))
                {
                    foreach (var item in checkedListBox.CheckedItems)
                    {
                        object value;
                        value = item.GetType().GetProperty(_valueMember).GetValue(item, null);
                        rv.Add(value);
                    }
                }
                return rv; 
            }
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
            {
                if (h.Value >= SystemInformation.PrimaryMonitorSize.Height)
                    h = SystemInformation.PrimaryMonitorSize.Height - SystemInformation.PrimaryMonitorSize.Height / 2;

                checkedListBox.Height = h.Value;
            }
            checkedListBox.AutoSize = true;
            checkedListBox.DrawMode = DrawMode.OwnerDrawVariable;
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
                int index = -1;

                index = this.Text.IndexOf(_concatChar + checkedStr);

                if (index < 0)
                    index = this.Text.IndexOf(checkedStr +_concatChar);

                if(index < 0)
                    index = this.Text.IndexOf(checkedStr);

                this.Text = this.Text.Remove(index, checkedStr.Length);
            }
            
        }

        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 100;

            //// Cast the sender object back to ListBox type.
            //ListBox theListBox = (ListBox)sender;

            //// Get the string contained in each item.
            //string itemString = (string)theListBox.Items[e.Index];

            //// Split the string at the " . "  character.
            //string[] resultStrings = itemString.Split('.');

            //// If the string contains more than one period, increase the 
            //// height by ten pixels; otherwise, increase the height by 
            //// five pixels.
            //if (resultStrings.Length > 2)
            //{
            //    e.ItemHeight += 10;
            //}
            //else
            //{
            //    e.ItemHeight += 5;
            //}

        }
    }
}
