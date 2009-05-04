using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Territories.BLL
{
    class KeyListItem
    {
        private int _id;

        private string _name;


        public KeyListItem()
        {

        }

        public KeyListItem(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
	
    }
}
