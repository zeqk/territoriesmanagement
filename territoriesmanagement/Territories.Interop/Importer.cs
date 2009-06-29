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
	

        public string SetConnectionString(string[] parameters)
        {
            return _importer.SetConnectionString(parameters);
        }

        public DataSet GetData()
        {
            return _importer.GetData();
        }


	


    }
}
