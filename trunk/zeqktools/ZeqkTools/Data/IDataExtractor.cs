using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZeqkTools.Data
{
    public interface IExtractor
    {
        DataSet GetData();
        List<Table> Tables {get;set;}
        string ConnectionStr {get;set;}
    }
}
