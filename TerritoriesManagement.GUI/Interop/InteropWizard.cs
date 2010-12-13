using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merlin;
using MerlinStepLibrary;
using System.Windows.Forms;
using TerritoriesManagement.GUI.ImporterConfig.Steps;
using TerritoriesManagement.GUI.ImporterConfig;
using TerritoriesManagement.Import;
using System.ComponentModel;
using TerritoriesManagement.GUI.Interop.Steps;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    static class InteropWizard
    {
        static ImportTool _importer;
        static InProgressControl inProgressControl = new InProgressControl();
        static SetConnControl setConnControl = new SetConnControl();




        public static void RunInteropWizard()
        {
            string action = "";
            EntitiesEnum table = EntitiesEnum.Departments;
            string file = "";
            
            List<string> actions = new List<string>();
            actions.Add("Import");
            actions.Add("Export");
            actions.Add("Import (External)");
            actions.Add("Export (External)");


            //Start step - Select action           
            var actionStep = new SelectionStep("Action selection", "Please select the action:", actions.ToArray());

            var initialStepSequence = new List<IStep>();
            initialStepSequence.Add(actionStep);
            initialStepSequence.Add(new TemplateStep(new TextBox()));

            //Select table step (Internal)
            CheckedListBox chkTables = new CheckedListBox();
            chkTables.Items.AddRange(Enum.GetNames(typeof(EntitiesEnum)));
            TemplateStep tableSelectionStep = new TemplateStep(chkTables);            

            //Chose table step (External)
            SelectionStep chooseTableStep = new SelectionStep("Table selection", "Please select the table:", Enum.GetNames(typeof(EntitiesEnum)));

            //Configure connection step (External import)
            TemplateStep configConnStep = new TemplateStep(setConnControl);

            //In progress step
            TemplateStep inProgressStep = new TemplateStep(inProgressControl);

            FileSelectionStep selectFileStep = new FileSelectionStep();
            TemplateStep saveFileStep = new TemplateStep(new TextBox());
                        
            PropertyGrid propGrid = new PropertyGrid();
            TemplateStep configTableStep = new TemplateStep(propGrid);

            List<IStep> tableSelectionStepList = new List<IStep>();
            tableSelectionStepList.Add(tableSelectionStep);
            tableSelectionStepList.Add(new TemplateStep(new TextBox()));

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
                    
                    controller.AddAfterCurrent(selectFileStep);
                }
                else
                {
                    
                    controller.AddAfterCurrent(saveFileStep);
                }


                return true;
            };

            chooseTableStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                if (action == "Import (External)")
                {
                    ImporterConfig.LoadConfig();
                    table = (EntitiesEnum)Enum.Parse(typeof(EntitiesEnum), (string)chooseTableStep.Selected);
                    var tables = ImporterConfig.GetInstance().Tables;
                    foreach (ExternalTable item in tables)
                    {
                        if (item.RelatedEntitySet == table)
                        {
                            propGrid.SelectedObject = item;
                            break;
                        }
                    } 
                    List<IStep> externalImportList = new List<IStep>();
                    externalImportList.Add(configTableStep);
                    externalImportList.Add(configConnStep);
                    externalImportList.Add(new TemplateStep(new TextBox()));

                    controller.AddAfterCurrent(externalImportList);
                }
                else
                {

                }

                return true;
            };

            //External import final
            configConnStep.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                //TODO: poner prev next y cancel en false
                controller.AddAfterCurrent(inProgressStep);
                

                _importer = new ImportTool();
                SetConfig(table);
                _importer.bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportCompleted);
                _importer.bg.ProgressChanged += new ProgressChangedEventHandler(ImportProgressChanged);
                _importer.ImportData();                

                return true;
            };


            var result = controller.StartWizard("Interop");

            if (result == WizardController.WizardResult.Finish)
            {
                switch (action)
                {
                    case "Import":

                        break;
                    case "Export":

                        break;
                    case "Import (External)":

                        break;
                    case "Export (External)":
                                           
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (action == "Import (External)")
                    ImporterConfig.SaveConfig();
            }

        }

        private static void SetConfig(EntitiesEnum entity)
        {
            var cfg = ImporterConfig.GetInstance();
            _importer.Config.ConnectionString = cfg.ConnectionString;
            _importer.Config.Provider = cfg.Provider;

            ExternalTable table = cfg.Tables.Where(t => t.RelatedEntitySet == entity).First();
            

            _importer.Config.Departments.Fields.Clear();
            _importer.Config.Cities.Fields.Clear();
            switch (entity)
            {
                case EntitiesEnum.Departments:
                    _importer.Config.Departments.TableName = table.ExternalTableName;
                    foreach (Field item in table.Fields)
                    {
                        if(item.Import)
                            _importer.Config.Departments.Fields.Add(item.RelatedProperty, item.ColumnName);
                    }
                    break;
                case EntitiesEnum.Cities:
                    _importer.Config.Cities.TableName = table.ExternalTableName;
                    foreach (Field item in table.Fields)
                    {
                        if (item.Import)
                            _importer.Config.Cities.Fields.Add(item.RelatedProperty, item.ColumnName);
                    }
                    break;
                case EntitiesEnum.Territories:
                    break;
                case EntitiesEnum.Addresses:
                    break;
                case EntitiesEnum.Publishers:
                    break;
                case EntitiesEnum.Tours:
                    break;
                default:
                    break;
            }


        }

        private static void ImportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_importer.SuccessfulImport)
                MessageBox.Show(GetString("The importation has been successful.") + Environment.NewLine + _importer.ImportMessage);
            else
                MessageBox.Show(GetString("The importation has problems. Check the settings and see the log.") + Environment.NewLine + _importer.ImportMessage);

            
        }

        private static string GetString(string p)
        {
            return p;
        }

        private static void ImportProgressChanged(object sender, ProgressChangedEventArgs e)
        {           
            inProgressControl.progressBar.Value = e.ProgressPercentage;            
        }
    }
}
