using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Territories.Interop
{
    public class Importer
    {
        private IImporter _importer;

        public List<Table> Tables   
        {
            get { return _importer.Tables; }
            set { _importer.Tables = value; }
        }




        public string ConnectStr 
        {
            get { return _importer.ConnectionStr;} 
            set{_importer.ConnectionStr = value;}
        }


        public Importer(Provider provider)
        {
            switch (provider)
            {
                case Provider.MSExcel:
                    _importer = new ExcelImporter();
                    break;
                case Provider.MSAcces:
                    break;
                case Provider.Oracle:
                    break;
                case Provider.SQLServer:
                    break;
                default:
                    break;
            }
        }


        public string MakeConnectStr(string[] parameters)
        {
            return _importer.MakeConnectStr(parameters);
        }

        public DataSet GetData()
        {
            return _importer.GetData();
        }


	


    }
}
