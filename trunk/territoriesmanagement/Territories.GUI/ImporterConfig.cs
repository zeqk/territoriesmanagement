using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI
{
    class ImporterConfig
    {

        private Table _departments;

        public ImporterConfig()
        {
            _departments = new Table();
        }

        [Category("Departments"),Browsable(true)]
        public Table Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }
	

    }

    class Table
    {
        private bool _enabled;

        private string _name;

	    public string Name
	    {
		    get { return _name;}
		    set { _name = value;}
	    }
	

        [Description("Enabled"),TypeConverter(typeof(bool)),Browsable(true)]
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
	
    }
}
