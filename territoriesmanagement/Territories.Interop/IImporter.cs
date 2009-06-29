using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Territories.Interop
{
    public interface IImporter
    {
        string SetConnectionString(string[] parameters);
        DataSet GetData();
        
    }
}
