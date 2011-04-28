using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AltosTools.WindowsForms;
using TerritoriesManagement.GUI.Interop.Import;
using AltosTools.Data;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    public partial class SetConnStepUI : UserControl
    {
        internal EventHandler StateChangeEvent { get; set; }

        private DataProviders? _provider;

        public SetConnStepUI()
        {
            InitializeComponent();
            
            txtConnectStr.Text = ImportSettings.GetInstance().ConnectionString;
        }

        public string ConnectionString
        {
            get
            {
                return txtConnectStr.Text;
            }
            set
            {
                txtConnectStr.Text = value;
            }
        }

        public DataProviders? Provider
        {
            get
            {
                return _provider;
            }
            set
            {
                _provider = value;
            }
        }

        private void btnConfigureConnection_Click(object sender, EventArgs e)
        {
            using (ConnectionStringMaker myForm = new ConnectionStringMaker())
            {
                myForm.ConnectionString = ImportSettings.GetInstance().ConnectionString;
                myForm.DataProvider = ImportSettings.GetInstance().Provider;

                myForm.ShowDialog();
                if (myForm.DialogResult == DialogResult.OK)
                {
                    txtConnectStr.Text = myForm.ConnectionString;
                    _provider = myForm.DataProvider;
                    StateChangeEvent(sender, EventArgs.Empty);        
                }
            }
        }

        private void txtConnectStr_TextChanged(object sender, EventArgs e)
        {
            if(StateChangeEvent != null)
                StateChangeEvent(sender, EventArgs.Empty);
        }
    }
}
