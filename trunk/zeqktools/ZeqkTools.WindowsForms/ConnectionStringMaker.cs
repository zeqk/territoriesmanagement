using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using ZeqkTools.Data;
using System.IO;

namespace ZeqkTools.WindowsForms
{
    public partial class ConnectionStringMaker : Form
    {
        DbConnectionStringBuilder _sb;        

        public string ConnectionString
        {
            get { return _sb.ConnectionString; }
            set { _sb.ConnectionString = value; }
        }        

        public DataProviders DataProvider
        {
            get 
            {
                return (DataProviders)cboDataProvider.SelectedValue;                
            
            }
            set 
            {
                cboDataProvider.SelectedValue = value;
            }
        }
	


        public ConnectionStringMaker()
        {
            InitializeComponent();
        }

        private void ConnectionStringMaker_Load(object sender, EventArgs e)
        {
            cboDataProvider.DataSource = Enum.GetValues(typeof(DataProviders));
            cboDataProvider.SelectedItem = null;
        }

        private void cboDataProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

            grpConnection.Enabled = true;
            if (cboDataProvider.SelectedItem != null)
            {
                switch ((DataProviders)cboDataProvider.SelectedValue)
                {
                    case DataProviders.MSExcel: txtDataSource.Enabled = true;
                        btnSelectSource.Enabled = true;
                        _sb = new System.Data.OleDb.OleDbConnectionStringBuilder();
                        _sb["Provider"] = "Microsoft.Jet.Oledb.4.0";
                        _sb["Extended Properties"] = "Excel 8.0;HDR=Yes;IMEX=1";
                        break;
                    case DataProviders.MSAcces: txtDataSource.Enabled = true;
                        btnSelectSource.Enabled = true;
                        _sb = new System.Data.OleDb.OleDbConnectionStringBuilder();
                        _sb["Provider"] = "Microsoft.Jet.Oledb.4.0"; 
                        break;
                    case DataProviders.OleDb: txtDataSource.Enabled = true;
                        btnSelectSource.Enabled = true;
                        _sb = new System.Data.OleDb.OleDbConnectionStringBuilder();                        
                        break;
                    case DataProviders.Odbc: txtDataSource.Enabled = false;
                        btnSelectSource.Enabled = false;
                        _sb = new System.Data.Odbc.OdbcConnectionStringBuilder();
                        break;
                    case DataProviders.SQLServer: txtDataSource.Enabled = false;
                        btnSelectSource.Enabled = false;
                        _sb = new System.Data.SqlClient.SqlConnectionStringBuilder();                 
                        break;
                    default:
                        break;
                }
                propConnection.SelectedObject = _sb;
                propConnection.Refresh();
            }
            else
            {
                propConnection.SelectedObject = null;
                grpConnection.Enabled = false;
            }
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            ofdSlectSource.ShowDialog();
        }

        private void ofdSlectSource_FileOk(object sender, CancelEventArgs e)
        {
            txtDataSource.Text = Path.GetFullPath(ofdSlectSource.FileName);
            _sb["DataSource"] = txtDataSource.Text;
            propConnection.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (propConnection.SelectedObject != null)
            {
                if (!string.IsNullOrEmpty(_sb.ConnectionString))
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
