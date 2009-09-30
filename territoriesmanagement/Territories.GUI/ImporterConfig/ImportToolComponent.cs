using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Territories.BLL.Import;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    [Serializable]
    public class ImportToolComponent : BLL.Import.Config
    {
        public ImportTable Departments
        {
            get { return base.Departments; }
            set { base.Departments = value; }
        }
    }
}
