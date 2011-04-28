using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merlin;
using AltosTools.Data;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    public class SetConnStep : TemplateStep
    {
        private SetConnStepUI ui;

        public SetConnStep()
            : base()
        {
            ui = new SetConnStepUI();
            this.UI = ui;
            ui.StateChangeEvent = (object sender, EventArgs args) => 
                this.StateUpdated();
        }

        public string ConnectionString
        {
            get
            {
                return this.ui.ConnectionString;
            }
            set
            {
                this.ui.ConnectionString = value;
            }
        }

        public DataProviders? Provider
        {
            get
            {
                return this.ui.Provider;
            }
            set
            {
                this.ui.Provider = value;
            }
        }
    }
}
