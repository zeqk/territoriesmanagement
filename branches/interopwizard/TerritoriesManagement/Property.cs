using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerritoriesManagement
{
    public class Property
    {

        private string _name;

        private Type _type;


        public Property()
        {

        }

        public Property(string name, Type type)
        {
            _name = name;
            _type = type;
        }

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }
	

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
	
    }
}
