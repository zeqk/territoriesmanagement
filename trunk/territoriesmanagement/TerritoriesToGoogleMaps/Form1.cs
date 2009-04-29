using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TerritoriesToGoogleMaps
{
    public partial class frmToGoogleMaps : Form
    {
        string fileIn;
        string fileOut;
        public frmToGoogleMaps()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdTerritoriesSheet.ShowDialog();
        }

        private void ofdTerritoriesSheet_FileOk(object sender, CancelEventArgs e)
        {

            fileIn = Path.GetFullPath(ofdTerritoriesSheet.FileName);
            txtPath.Text = fileIn;
        }

        private void btnSelectDestiny_Click(object sender, EventArgs e)
        {
            sfdXml.ShowDialog();
        }

        private void btnConvertToXml_Click(object sender, EventArgs e)
        {
            Serialization.WriteMarks(fileIn, fileOut);
        }

        private void sfdXml_FileOk(object sender, CancelEventArgs e)
        {
            fileOut = Path.GetFullPath(sfdXml.FileName);
            txtPathOut.Text = fileOut;
        }
    }
}
