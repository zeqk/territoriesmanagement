using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeqkTools.Test
{
    public class Item
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Item()
        {

        }

        public Item(int id, string name)
        {
            _id = id;
            _name = name;
        }

        


    }
}
