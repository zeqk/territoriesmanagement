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
            string action = "";
            TablesEnum table;
            string file = "";
            
            List<string> actions = new List<string>();
            actions.Add("Import");
            actions.Add("Export");
            actions.Add("Import (External)");
            actions.Add("Export (External)");


            //Start step - Action selection            
            var actionStep = new SelectionStep("Action selection", "Please select the action:", actions.ToArray());

            var initialStepSequence = new List<IStep>();
            initialStepSequence.Add(actionStep);
            initialStepSequence.Add(new TemplateStep(new TextBox()));

            //Select table step (Internal)
            CheckedListBox chkTables = new CheckedListBox();
            chkTables.Items.AddRange(Enum.GetNames(typeof(TablesEnum)));
            TemplateStep tableSelectionStep = new TemplateStep(chkTables);

            List<IStep> tableSelectionStepList = new List<IStep>();
            tableSelectionStepList.Add(tableSelectionStep);
            tableSelectionStepList.Add(new TemplateStep(new TextBox()));

            //Chose table step (External)
            SelectionStep chooseTableStep = new SelectionStep("Table selection", "Please select the table:", Enum.GetNames(typeof(TablesEnum)));
            
            List<IStep> chooseTableStepList = new List<IStep>();
            chooseTableStepList.Add(chooseTableStep);
            chooseTableStepList.Add(new TemplateStep(new TextBox()));


            WizardController controller = new WizardController(initialStepSequence);

            actionStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                action = (string)actionStep.Selected;
                if (!action.Contains("External")) //Internal
                {
                    controller.AddAfterCurrent(tableSelectionStepList);
                }
                else //External
                {
                    controller.AddAfterCurrent(chooseTableStepList);
                }

                return true;
            };


            tableSelectionStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                if (action == "Import")
                {
                    FileSelectionStep selectFileStep = new FileSelectionStep();
                    controller.AddAfterCurrent(selectFileStep);
                }
                else
                {
                    TemplateStep saveFileStep = new TemplateStep(new TextBox());
                    controller.AddAfterCurrent(saveFileStep);
                }


                return true;
            };

            chooseTableStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                if (action == "Import (External)")
                {
                    InteropConfig.LoadConfig();
                    PropertyGrid propGrid = new PropertyGrid();
                    table = (TablesEnum)Enum.Parse(typeof(TablesEnum), (string)chooseTableStep.Selected);
                    switch (table)
                    {
                        case TablesEnum.Departments:
                            propGrid.SelectedObject = InteropConfig.GetInstance().Departments;
                            break;
                        case TablesEnum.Cities:
                            propGrid.SelectedObject = InteropConfig.GetInstance().Departments;
                            break;
                        case TablesEnum.Territories:
                            propGrid.SelectedObject = InteropConfig.GetInstance().Departments;
                            break;
                        case TablesEnum.Addresses:
                            propGrid.SelectedObject = InteropConfig.GetInstance().Departments;
                            break;
                        case TablesEnum.Publishers:
                            propGrid.SelectedObject = InteropConfig.GetInstance().Departments;
                            break;
                        case TablesEnum.Tours:
                            propGrid.SelectedObject = InteropConfig.GetInstance().Departments;
                            break;
                        default:
                            break;
                    }

                }
                else
                {

                }

                return true;
            };



            var result = controller.StartWizard("Interop");













            ////Table selection step
            //SelectionStep chooseTableStep = new SelectionStep("Table selection", "Please select the table:", Enum.GetNames(typeof(TablesEnum)));

            
            //initialStepSequence.Add(tableSelectionStep);
            

            ////Property selection step
            //TemplateStep propertySelectionStep;

            ////Select file for import step
            //FileSelectionStep fileSelectionStep = new FileSelectionStep();
          
            ////Import (External) step 1
            //List<IStep> externalImportSteps = new List<IStep>();
            //TemplateStep importFromExternal1 = new TemplateStep(new connectionStep(), "Import (External)");
            //importFromExternal1.Subtitle = "Import from external source";
            //externalImportSteps.Add(importFromExternal1);            
            //externalImportSteps.Add(new TemplateStep(new TextBox()));            

            
            

            //tableSelectionStep.NextHandler = () =>
            //{
            //    controller.DeleteAllAfterCurrent();
            //    table = (TablesEnum)tableSelectionStep.Selected;               
                
            //    if (action == "Import (External)")
            //    {
            //        PropertyGrid propGrid = new PropertyGrid();
            //        switch (table)
            //        {
            //            case TablesEnum.Departments:
            //                propGrid.SelectedObject = new ImporterConfig.DepartmentsTable();
            //                break;
            //            case TablesEnum.Cities:
            //                break;
            //            case TablesEnum.Territories:
            //                break;
            //            case TablesEnum.Addresses:
            //                break;
            //            case TablesEnum.Publishers:
            //                break;
            //            case TablesEnum.Tours:
            //                break;
            //            default:
            //                break;
            //        }

            //        controller.AddAfterCurrent(new TemplateStep(new TextBox()));
            //    }
            //    if (action.Contains("Export")) 
            //    {
            //        string entityName = Helper.GetEntityNameByEntitySetName(table.ToString());    
            //        Property[] properties = Helper.GetPropertyListByType(entityName).ToArray();

            //        CheckedListBox entitiesListBox = new CheckedListBox();
            //        entitiesListBox.DisplayMember = "Name";
            //        entitiesListBox.Items.AddRange(properties);

            //        //instantiate property selection step
            //        propertySelectionStep = new TemplateStep(entitiesListBox, table.ToString());

            //        propertySelectionStep.NextHandler = () =>
            //        {
            //            controller.DeleteAllAfterCurrent();
            //            if (action.Contains("Import"))
            //                controller.AddAfterCurrent(fileSelectionStep);
            //            else
            //                controller.AddAfterCurrent(saveFileStep);

            //            return true;
            //        };


            //        controller.AddAfterCurrent(propertySelectionStep);


            //    }
            //    return true;
            //};



            
            //if (result == WizardController.WizardResult.Finish)
            //{
            //    switch (action)
            //    {
            //        case "Import":                        
                        
            //            break;
            //        case "Export":
                        
            //            break;
            //        case "Import (External)":
                        
            //            break;
            //        case "Export (External)":
                        
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
    }
}
