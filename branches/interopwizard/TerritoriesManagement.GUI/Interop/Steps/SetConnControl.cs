using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AltosTools.WindowsForms;

namespace TerritoriesManagement.GUI.ImporterConfig.Steps
{
    public partial class SetConnControl : UserControl
    {
        public SetConnControl()
        {
            InitializeComponent();
            txtConnectStr.Text = ImporterConfig.GetInstance().ConnectionString;
        }

        private void btnConfigureConnection_Click(object sender, EventArgs e)
        {
            using (ConnectionStringMaker myForm = new ConnectionStringMaker())
            {
                myForm.ConnectionString = ImporterConfig.GetInstance().ConnectionString;
                myForm.DataProvider = ImporterConfig.GetInstance().Provider;

                myForm.ShowDialog();
                if (myForm.DialogResult == DialogResult.OK)
                {
                    txtConnectStr.Text = myForm.ConnectionString;
                    ImporterConfig.GetInstance().ConnectionString = txtConnectStr.Text;
                    ImporterConfig.GetInstance().Provider = myForm.DataProvider;
                }
            }
        }
    }
}
