using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace Territories.GUI
{
    public class Configuration
    {

        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        private string _dbPath;

        public string DbPath
        {
            get { return _dbPath; }
            set 
            { 
                _dbPath = value;
            }
        }
	
	

	
	
    }
}
