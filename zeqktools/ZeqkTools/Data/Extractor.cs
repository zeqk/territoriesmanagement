using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZeqkTools.Query.Enumerators;

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
                case DataProviders.MSAcces:
                    _importer = new AccesExtractor();
                    break;
                case DataProviders.Oracle:
                    break;
                case DataProviders.SQLServer:
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
