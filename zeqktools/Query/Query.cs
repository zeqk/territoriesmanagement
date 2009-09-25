using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeqkTools.Query
{
    public class Query
    {
        private List<Filter> _filters;
        public List<Filter> Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }
	
	
    }
}
