using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    public partial class SelectDestinyControl : UserControl
    {

        public string FileName
        {
            get { return Path.GetFullPath(txtDestiny.Text); }
        }
        public string Filter
        {
            get { return saveFileDialog.Filter; }
            set { saveFileDialog.Filter = value; }
        }
	
	

        public SelectDestinyControl()
        {
            InitializeComponent();
        }

        private void brnBrowse_Click(object sender, EventArgs e)
        {            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDestiny.Text = Path.GetFullPath(saveFileDialog.FileName);
            }
        }
    }
}
