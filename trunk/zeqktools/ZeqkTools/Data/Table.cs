using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeqkTools.Data
{
    [Serializable]
    public class Table
    {
        private string _tableName;

        private List<string> _fields;

        public Table()
        {
            _fields = new List<string>();
        }

        public Table(string tableName)
        {
            _tableName = tableName;
            _fields = new List<string>();
        }

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }



        public List<string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
	
	
    }
    
}
