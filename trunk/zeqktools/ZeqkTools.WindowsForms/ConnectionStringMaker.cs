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

        private string _connectionString;

        private DataProviders _dataProvider;

        #region Properties

        public string ConnectionString
        {
            get { return _sb.ConnectionString; }
            set 
            {
                _connectionString = value;
            }
        }        

        public DataProviders DataProvider
        {
            get 
            {
                return ((DataProviderItem)cboDataProvider.SelectedValue).Provider;                
            
            }
            set 
            {
                _dataProvider = value;
            }
        }
        #endregion


        public ConnectionStringMaker()
        {
            InitializeComponent();

            List<DataProviderItem> items = new List<DataProviderItem>();
            items.Add(new DataProviderItem("MS Excel", DataProviders.OleDb));
            items.Add(new DataProviderItem("MS Access", DataProviders.OleDb));
            items.Add(new DataProviderItem("OleDb", DataProviders.OleDb));
            items.Add(new DataProviderItem("Odbc", DataProviders.Odbc));
            items.Add(new DataProviderItem("SQL Server", DataProviders.SQLServer));
            cboDataProvider.ValueMember = "Provider";
            cboDataProvider.DisplayMember = "Name";
            cboDataProvider.DataSource = items;
            cboDataProvider.SelectedItem = null;
        }

        private void ConnectionStringMaker_Load(object sender, EventArgs e)
        {
            cboDataProvider.SelectedItem = _dataProvider;
            if (_sb != null) 
                _sb.ConnectionString = _connectionString;
        }

        private void cboDataProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

            grpConnection.Enabled = true;
            if (cboDataProvider.SelectedItem != null)
            {
                switch (((DataProviderItem) cboDataProvider.SelectedItem).Name)
                {
                    case "MS Excel": txtDataSource.Enabled = true;
                        btnSelectSource.Enabled = true;
                        _sb = new System.Data.OleDb.OleDbConnectionStringBuilder();
                        _sb["Provider"] = "Microsoft.Jet.Oledb.4.0";
                        _sb["Extended Properties"] = "Excel 8.0;HDR=Yes;IMEX=1";                        
                        break;
                    case "MS Access": txtDataSource.Enabled = true;
                        btnSelectSource.Enabled = true;
                        _sb = new System.Data.OleDb.OleDbConnectionStringBuilder();
                        _sb["Provider"] = "Microsoft.Jet.Oledb.4.0"; 
                        break;
                    case "OleDb": txtDataSource.Enabled = true;
                        btnSelectSource.Enabled = true;
                        _sb = new System.Data.OleDb.OleDbConnectionStringBuilder();                        
                        break;
                    case "Odbc": txtDataSource.Enabled = false;
                        btnSelectSource.Enabled = false;
                        _sb = new System.Data.Odbc.OdbcConnectionStringBuilder();
                        break;
                    case "SQL Server": txtDataSource.Enabled = false;
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

    public class DataProviderItem
    {
        public string Name;
        public DataProviders Provider;


        public DataProviderItem()
        {
        
        }

        public DataProviderItem(string name, DataProviders provider)
        {
            this.Name = name;
            this.Provider = provider;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
