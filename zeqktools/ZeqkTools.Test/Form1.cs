using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZeqkTools.WindowsForms;
using ZeqkTools.WindowsForms.Controls;

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

            List<Item> items = new List<Item>();
            items.Add(new Item(1, "uno"));
            items.Add(new Item(2, "dos"));
            items.Add(new Item(3, "tres"));
            ListSelectionWrapper<Item> list = new ListSelectionWrapper<Item>(items, "Name");
            cboTest.DataSource = list;
            cboTest.DisplayMemberSingleItem = "Name";
            cboTest.DisplayMember = "NameConcatenated";
            cboTest.ValueMember = "Selected";

            cboTest.CheckBoxItems[2].DataBindings.DefaultDataSourceUpdateMode
                = DataSourceUpdateMode.OnPropertyChanged;
            cboTest.DataBindings.DefaultDataSourceUpdateMode
                = DataSourceUpdateMode.OnPropertyChanged;

            //cboTest.DisplayMember = "Name";
            //cboTest.ValueMember = "Id";
            //cboTest.DataSource = items;
            
           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ZeqkTools.WindowsForms.Maps.frmGeoPoint myForm = new ZeqkTools.WindowsForms.Maps.frmGeoPoint();
            //myForm.Address = "claypole";
            //myForm.ShowDialog();

            //ZeqkTools.WindowsForms.ConnectionStringMaker myForm = new ConnectionStringMaker();
            //myForm.ShowDialog();
            //var aux = myForm.DataProvider;
        }
    }

    public class Item
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
	
	

        public Item()
        {

        }

        public Item(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
    }
}
