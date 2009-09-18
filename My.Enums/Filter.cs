using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My;

namespace My.Queries
{
    public class Filter
    {
        private Enumerators.Criterias _criteria;

        private Enumerators.ValueTypes _valueTypes;

        private object _value;

        private string _columnName;

        
        

        public Filter() { }

        public Filter(string columnName, Enumerators.Criterias criteria, object value, Enumerators.ValueTypes valueType)
        {
            this._columnName = columnName;
            this._criteria = criteria;
            this._value = value;
            this._valueTypes = valueType;
        }
            



        public Enumerators.Criterias Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        
        public Enumerators.ValueTypes ValueTypes
        {
            get { return _valueTypes; }
            set { _valueTypes = value; }
        }

        
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
	
	
	
	
	
    }
}
