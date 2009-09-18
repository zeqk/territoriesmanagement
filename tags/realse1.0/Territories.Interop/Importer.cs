using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using My;

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


        public Importer(Enumerators.Provider provider)
        {
            switch (provider)
            {
                case Enumerators.Provider.MSExcel:
                    _importer = new ExcelImporter();
                    break;
                case Enumerators.Provider.MSAcces:
                    break;
                case Enumerators.Provider.Oracle:
                    break;
                case Enumerators.Provider.SQLServer:
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
