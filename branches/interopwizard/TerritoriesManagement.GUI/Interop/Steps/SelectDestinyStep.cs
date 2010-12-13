using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merlin;
using System.IO;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    class SelectDestinyStep : TemplateStep
    {
        SelectDestinyControl control;

        public string SelectedFullPath
        {
            get { return control.FileName; }
        }
        public string SelectedFileName
        {
            get { return Path.GetFileName(control.FileName); }
        }
        public string Filter
        {
            get { return control.Filter; }
            set { control.Filter = value; }
        }

        public SelectDestinyStep()
        {
            control = new SelectDestinyControl();
            this.UI = control;
            
        }
    }
}
