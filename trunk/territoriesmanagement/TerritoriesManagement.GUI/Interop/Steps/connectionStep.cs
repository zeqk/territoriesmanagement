using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AltosTools.WindowsForms;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    public partial class connectionStep : UserControl
    {
        public connectionStep()
        {
            InitializeComponent();
        }

        private void btnConfigureConnection_Click(object sender, EventArgs e)
        {
            using (ConnectionStringMaker myForm = new ConnectionStringMaker())
            {
                myForm.ConnectionString = InteropConfig.GetInstance().ConnectionString;
                myForm.DataProvider = InteropConfig.GetInstance().Provider;

                myForm.ShowDialog();
                if (myForm.DialogResult == DialogResult.OK)
                {
                    txtConnectStr.Text = myForm.ConnectionString;
                    InteropConfig.GetInstance().ConnectionString = txtConnectStr.Text;
                    InteropConfig.GetInstance().Provider = myForm.DataProvider;
                }
            }
        }
    }
}
