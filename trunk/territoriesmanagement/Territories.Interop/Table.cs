using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My;

namespace Territories.Interop
{
    [Serializable]
    public class Table
    {
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        private List<string> _fields;

        public List<string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
	
	
    }
    
}
