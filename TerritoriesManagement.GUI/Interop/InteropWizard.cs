using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Merlin;
using MerlinStepLibrary;
using TerritoriesManagement.Export;
using TerritoriesManagement.GUI.Interop.Import;
using TerritoriesManagement.GUI.Interop.Steps;
using TerritoriesManagement.Import;

namespace TerritoriesManagement.GUI.Interop
{
    static class InteropWizard
    {
        static bool completed = false;
        
        delegate string StringRetriever();
        static StringRetriever logRetriever; 
        static StringRetriever actionRetriever;

        //Final step - In progress
        static InProgressUI inProgressControl = new InProgressUI(); 
        static TemplateStep stepInProgress = new TemplateStep(inProgressControl);

        static TextBox txtLog = new TextBox();

        public static void RunInteropWizard()
        {
            ImportSettings.GetInstance().LoadConfig();

            
            
            EntitiesEnum table = EntitiesEnum.Departments;
            string entityName = "";
            string file = "";

            string[] actions = new string[4];
            actions[0] = "Import";
            actions[1] = "Export";
            actions[2] = "Import (External)";
            actions[3] = "Export (External)";
            
            //Start step - Select action           
            SelectionStep stepChooseAction = new SelectionStep("Action selection", "Please select the action:", actions);
            actionRetriever = () => (string)stepChooseAction.Selected;

            stepInProgress.Title = "Processing...";
            stepInProgress.AllowCancelStrategy = () => { return false; };
            stepInProgress.AllowPreviousStrategy = () => { return false; };
            stepInProgress.AllowNextStrategy = () => { return completed; };

            //View log step
            txtLog.Multiline = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            TemplateStep stepViewLog = new TemplateStep(txtLog);
            stepViewLog.Title = "Importation errors";
            stepViewLog.AllowCancelStrategy = () => { return false; };
            stepViewLog.AllowPreviousStrategy = () => { return false; };
            stepViewLog.AllowNextStrategy = () => { return true; };
 
            #region Internal

            //Select table step (Import and Export)
            CheckedListBox chkTables = new CheckedListBox();
            chkTables.CheckOnClick = true;
            chkTables.Items.AddRange(Enum.GetNames(typeof(EntitiesEnum)));
            TemplateStep stepSelectTable = new TemplateStep(chkTables);

            //Select source file step (Import)
            FileSelectionStep stepSelectSource = new FileSelectionStep();
            stepSelectSource.Filter = "Territories management exchange file(*.tmx)|*.tmx";
            //Select destiny file step (Export and External export)            
            DestinySelectionStep stepSelectDestiny = new DestinySelectionStep();

            #endregion

            #region External

            //Choose table step (Import and export)
            SelectionStep stepChooseTable = new SelectionStep("Table selection", "Please select the table:", Enum.GetNames(typeof(EntitiesEnum)));
            
            //Set fields step (Import)
            PropertyGrid propGrid = new PropertyGrid();            
            TemplateStep stepSetFields = new TemplateStep(propGrid);

            //Set connection step (Import)
            SetConnStep stepSetConn = new SetConnStep();
            stepSetConn.Title = "Set connection";

            //Select fields step (Export)
            CheckedListBox chkFields = new CheckedListBox();
            chkFields.DisplayMember = "Name";
            chkFields.CheckOnClick = true;
            TemplateStep stepSelectFields = new TemplateStep(chkFields);

            //Select destiny file step (Export and External export)
            //line 46


            List<IStep> stepsExternalImport = new List<IStep>();
            stepsExternalImport.Add(stepSetFields);
            stepsExternalImport.Add(stepSetConn);            
            stepsExternalImport.Add(new TemplateStep(new TextBox()));

            List<IStep> stepsExternalExport = new List<IStep>();
            stepsExternalExport.Add(stepSelectFields);
            stepsExternalExport.Add(stepSelectDestiny);
            stepsExternalExport.Add(new TemplateStep(new TextBox()));
            #endregion             
            
            List<IStep> stepsInitial = new List<IStep>();
            stepsInitial.Add(stepChooseAction);
            stepsInitial.Add(new TemplateStep(new TextBox()));

            List<IStep> stepsSelectTables = new List<IStep>();
            stepsSelectTables.Add(stepSelectTable);
            stepsSelectTables.Add(new TemplateStep(new TextBox()));

            List<IStep> stepsChooseTable = new List<IStep>();
            stepsChooseTable.Add(stepChooseTable);
            stepsChooseTable.Add(new TemplateStep(new TextBox()));

            List<IStep> stepsFinals = new List<IStep>();
            stepsFinals.Add(stepInProgress);
            stepsFinals.Add(stepViewLog);


            WizardController controller = new WizardController(stepsInitial);

            stepChooseAction.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();


                if (!actionRetriever().Contains("External")) //Internal
                    controller.AddAfterCurrent(stepsSelectTables);
                else //External
                    controller.AddAfterCurrent(stepsChooseTable);

                return true;
            };

            //Internal
            stepSelectTable.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                List<IStep> stepsAux = new List<IStep>();
                if (actionRetriever() == "Import")
                    stepsAux.Add(stepSelectSource);
                else
                {
                    stepSelectDestiny.Filter = "Territories management exchange file(*.tmx)|*.tmx";
                    stepsAux.Add(stepSelectDestiny);
                }
                stepsAux.Add(new TemplateStep(new TextBox()));
                controller.AddAfterCurrent(stepsAux);

                return true;
            };

            //External
            stepChooseTable.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();

                if (actionRetriever() == "Import (External)") //Import (External)
                {
                    //load data for the stepSetFields
                    table = (EntitiesEnum)Enum.Parse(typeof(EntitiesEnum), (string)stepChooseTable.Selected);
                    var tables = ImportSettings.GetInstance().Tables;
                    foreach (ExternalTable item in tables)
                    {
                        if (item.RelatedEntitySet == table)
                        {
                            propGrid.SelectedObject = item;
                            break;
                        }
                    }

                    stepSetFields.Title = Enum.GetName(typeof(EntitiesEnum), table);


                    //load data for stepSetConn
                    stepSetConn.ConnectionString = ImportSettings.GetInstance().ConnectionString;
                    stepSetConn.Provider = ImportSettings.GetInstance().Provider;

                    controller.AddAfterCurrent(stepsExternalImport);
                }
                else //Export (External)
                {
                    entityName = Helper.GetEntityNameByEntitySetName(Enum.GetName(typeof(EntitiesEnum),table));
                    IList<Property> props = Helper.GetPropertyListByType(entityName);
                    chkFields.Items.AddRange(props.ToArray());
                    stepSelectDestiny.Title = entityName;
                    stepSelectDestiny.Filter = "Excel files (*.xls)|*.xls";
                    controller.AddAfterCurrent(stepsExternalExport);
                }

                return true;
            };


            //External import final
            stepSetConn.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();                
                controller.AddAfterCurrent(stepsFinals);

                ImportSettings.GetInstance().ConnectionString = stepSetConn.ConnectionString;
                ImportSettings.GetInstance().Provider = stepSetConn.Provider;

                ImportTool importer = new ImportTool();
                SetConfig(ref importer, table);

                importer.bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompleted);
                importer.bg.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);

                logRetriever = () => importer.Log;
                importer.ImportExternalData();
                return true;
            };

            stepSetConn.AllowNextStrategy = () => 
                !string.IsNullOrEmpty(stepSetConn.ConnectionString);

            //Export final
            stepSelectDestiny.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                controller.AddAfterCurrent(stepInProgress); 

                file = stepSelectDestiny.SelectedFullPath;

                ExportTool exporter = new ExportTool();

                exporter.bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompleted);
                exporter.bg.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);

                if (actionRetriever().Contains("External"))//External export final
                {
                    string[] props = chkFields.CheckedItems.Cast<Property>().Select(p => p.Name).ToArray();
                    
                    //exporter.ExportToExcel(file, entityName, props, "");
                }
                else //Export final
                {
                    List<string> entityList = new List<string>();
                    foreach (string item in chkTables.CheckedItems)
                    {
                        entityList.Add(Helper.GetEntityNameByEntitySetName(item)); 
                    }
                    exporter.ExportToExchangeData(file,entityList,true);
                }
                return true;
            };

            stepSelectDestiny.AllowNextStrategy = () => !string.IsNullOrEmpty(stepSelectDestiny.SelectedFullPath);

            //Import final
            stepSelectSource.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                controller.AddAfterCurrent(stepInProgress);

                file = stepSelectSource.SelectedFullPath;

                List<string> entitySetList = new List<string>();
                foreach (string item in chkTables.CheckedItems)
                {
                    entitySetList.Add(item); 
                }

                ImportTool importer = new ImportTool();
                importer.bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcessCompleted);
                importer.bg.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                
                importer.ImportExchangeData(file, entitySetList, true);

                return true;
            };
            stepSelectSource.AllowNextStrategy = () => !string.IsNullOrEmpty(stepSelectSource.SelectedFullPath);

            var result = controller.StartWizard("Interop");

            if (result == WizardController.WizardResult.Finish)
            {
                switch (actionRetriever())
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
                if (actionRetriever() == "Import (External)")
                {
                    ImportSettings.GetInstance().ConnectionString = stepSetConn.ConnectionString;
                    ImportSettings.GetInstance().Provider = stepSetConn.Provider;
                    ImportSettings.GetInstance().SaveConfig();
                }
            }

        }

        private static void SetConfig(ref ImportTool importer, EntitiesEnum entity)
        {
            var cfg = ImportSettings.GetInstance();
            importer.Config.ConnectionString = cfg.ConnectionString;
            importer.Config.Provider = cfg.Provider;

            ExternalTable table = cfg.Tables.Where(t => t.RelatedEntitySet == entity).First();
            

            importer.Config.Departments.Fields.Clear();
            importer.Config.Cities.Fields.Clear();
            switch (entity)
            {
                case EntitiesEnum.Departments:
                    importer.Config.Departments.TableName = table.ExternalTableName;
                    foreach (Field item in table.Fields)
                    {
                        if(item.Import)
                            importer.Config.Departments.Fields.Add(item.RelatedProperty, item.ColumnName);
                    }
                    break;
                case EntitiesEnum.Cities:
                    importer.Config.Cities.TableName = table.ExternalTableName;
                    foreach (Field item in table.Fields)
                    {
                        if (item.Import)
                            importer.Config.Cities.Fields.Add(item.RelatedProperty, item.ColumnName);
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

        private static void ProcessCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso completado");
            completed = true;
            stepInProgress.StateUpdated();
            //if(actionRetriever() == "Import (External)")
            if(logRetriever != null)
                txtLog.Text = logRetriever();
            var hola = true;
        }

        private static string GetString(string p)
        {
            return p;
        }

        private static void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {           
            inProgressControl.progressBar.Value = e.ProgressPercentage;
            
        }
    }
}
