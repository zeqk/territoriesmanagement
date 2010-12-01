using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merlin;
using MerlinStepLibrary;
using System.Windows.Forms;
using TerritoriesManagement.GUI.Interop.Steps;

namespace TerritoriesManagement.GUI.Interop
{
    static class InteropWizard
    {
        public static void RunInteropWizard()
        {
            //Create a list of steps
            List<IStep> steps = new List<IStep>();


            //Import step 1
            TextBox txtImport = new TextBox();
            txtImport.Text = "Probando importacion";
            txtImport.Multiline = true;
            var import1 = new TemplateStep(txtImport,10,"Import");


            //Export step 1
            TextBox txtExport = new TextBox();
            txtExport.Text = "Probando exportacion";
            txtExport.Multiline = true;
            var export1 = new TemplateStep(txtExport, 10, "Export");

            //Import from external step 1
            var importFromExternal1 = new TemplateStep(new connectionStep());

            //Step 2. Action selection
            List<string> actions = new List<string>();
            actions.Add("Import");
            actions.Add("Export");
            actions.Add("Import from external source");
            actions.Add("Export to external destiny");

            var initialStepSequence = new List<IStep>();
            var actionStep = new SelectionStep("Action selection", "Please select the action:",actions.ToArray());
            
            
            initialStepSequence.Add(actionStep);
            initialStepSequence.Add(new TemplateStep(new TextBox()));

            WizardController controller = new WizardController(initialStepSequence);

            actionStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                switch (actionStep.Selected as string)
                {
                    case "Import":
                        controller.AddAfterCurrent(import1);
                        break;
                    case "Export":
                        controller.AddAfterCurrent(export1);
                        break;
                    case "Import from external source":
                        InteropConfig.LoadConfig();
                        controller.AddAfterCurrent(importFromExternal1);
                        break;
                    default:
                        break;
                }
                return true;
            };

            controller.StartWizard("Interop");
        }
    }
}
