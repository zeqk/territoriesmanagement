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

        private void button3_Click(object sender, EventArgs e)
        {
            System.Data.Odbc.OdbcConnectionStringBuilder odbc = new System.Data.Odbc.OdbcConnectionStringBuilder();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sql = new System.Data.SqlClient.SqlConnectionStringBuilder();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder oledb = new System.Data.OleDb.OleDbConnectionStringBuilder();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectionStringMaker form = new ConnectionStringMaker();
            form.ShowDialog();
        }
    }
}
