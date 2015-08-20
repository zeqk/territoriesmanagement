using Localizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Reporting;

namespace TerritoriesManagement.GUI
{
    public partial class frmTerritoriesPrinting : Form
    {
        public frmTerritoriesPrinting()
        {
            InitializeComponent();
            this.chklstTerritories.DisplayMember = "Text";

            Globalization.RefreshUI(this);
        }

        private string GetString(string text)
        {
            return Globalization.GetString(text);
        }

        private void frmTerritoriesPrinting_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadTerritories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadTerritories()
        {
            var bridge = new Territories();
            var list = bridge.SearchSimpleObject(string.Empty, this.chkHasAddresses.Checked);
            this.chklstTerritories.Items.AddRange(list.ToArray());            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var myForm = new SaveFileDialog();
                myForm.Filter = "PDF Files (*.pdf)|*.pdf";                
                myForm.FileName = DateTime.Today.ToString("yyyy.MM.dd dddd") + ".pdf";
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    var items = this.chklstTerritories.CheckedItems.OfType<SimpleObject>().ToList();

                    var ids = items.Select(i => Convert.ToInt32(i.Value)).ToList();

                    ReportsHelper.GenerateMultipleTerritoriesReport(ids, myForm.FileName);

                    MessageBox.Show("El archivo " + myForm.FileName + " se generó exitosamente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chkHasAddresses_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadTerritories();
        }
    }
}
