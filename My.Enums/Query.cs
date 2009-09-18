using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Queries;

namespace My.Queries
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
