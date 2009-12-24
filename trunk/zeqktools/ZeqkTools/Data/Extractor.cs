using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZeqkTools.Data
{
    public class Extractor
    {
        

        private IExtractor _importer;

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


        public Extractor(DataProviders provider)
        {
            switch (provider)
            {
                case DataProviders.MSExcel:
                    _importer = new ExcelExtractor();
                    break;
                case DataProviders.MSAccess:
                    _importer = new AccessExtractor();
                    break;
                case DataProviders.OleDb:
                    break;
                case DataProviders.SQLServer:
                    break;
                default:
                    break;
            }
        }

        public DataSet GetData()
        {
            return _importer.GetData();
        }


	


    }
}
