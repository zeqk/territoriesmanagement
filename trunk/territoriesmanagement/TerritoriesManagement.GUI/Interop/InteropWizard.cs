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
            List<string> entities = new List<string>();
            entities.Add("Departments");
            entities.Add("Cities");
            entities.Add("Territories");
            entities.Add("Addresses");
            entities.Add("Publishers");
            entities.Add("Tours");

            //Import step 1
            //List<IStep> importSteps = new List<IStep>();
            var tableSelectionStep = new SelectionStep("Table selection", "Please select the table:", entities.ToArray());

            TemplateStep propertySelectionStep;

            //Import (External) step 1
            List<IStep> externalImportSteps = new List<IStep>();
            var importFromExternal1 = new TemplateStep(new connectionStep(),"Import (External)");
            importFromExternal1.Subtitle = "Import from external source";
            externalImportSteps.Add(importFromExternal1);
            externalImportSteps.Add(tableSelectionStep);
            //externalImportSteps.Add(new TemplateStep(new TextBox()));


            //Step 2. Action selection
            List<string> actions = new List<string>();
            actions.Add("Import");
            actions.Add("Export");
            actions.Add("Import (External)");
            actions.Add("Export (External)");

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
                        controller.AddAfterCurrent(tableSelectionStep);
                        break;
                    case "Export":
                        controller.AddAfterCurrent(tableSelectionStep);
                        break;
                    case "Import (External)":
                        InteropConfig.LoadConfig();
                        controller.AddAfterCurrent(externalImportSteps);
                        break;
                    case "Export (External)":
                        controller.AddAfterCurrent(tableSelectionStep);
                        break;
                    default:
                        break;
                }
                return true;
            };

            tableSelectionStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();

                if ((string)actionStep.Selected == "Import (External)")
                {
                    controller.AddAfterCurrent(new TemplateStep(new TextBox()));
                }
                else
                {
                    CheckedListBox entitiesListBox = new CheckedListBox();
                    entitiesListBox.DisplayMember = "Name";
                    string entitySetName = (string)tableSelectionStep.Selected;
                    string entityName = Helper.GetEntityNameByEntitySetName(entitySetName);
                    entitiesListBox.Items.AddRange(Helper.GetPropertyListByType(entityName).ToArray());

                    propertySelectionStep = new TemplateStep(entitiesListBox, entitySetName);
                    controller.AddAfterCurrent(propertySelectionStep);

                    propertySelectionStep.NextHandler = () =>
                    {
                        return true;
                    };
                }
                return true;
            };

            

            controller.StartWizard("Interop");
        }
    }
}
