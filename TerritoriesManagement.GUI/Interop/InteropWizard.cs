﻿using System;
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
using TerritoriesManagement.Export;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    static class InteropWizard
    {
        static ImportTool _importer;
        static InProgressControl inProgressControl = new InProgressControl();

        public static void RunInteropWizard()
        {
            string action = "";
            EntitiesEnum table = EntitiesEnum.Departments;
            string file = "";

            string[] actions = new string[4];
            actions[0] = "Import";
            actions[1] = "Export";
            actions[2] = "Import (External)";
            actions[3] = "Export (External)";
            
            //Start step - Select action           
            SelectionStep stepChooseAction = new SelectionStep("Action selection", "Please select the action:", actions);

            //Final step - In progress            
            TemplateStep stepInProgress = new TemplateStep(inProgressControl);

            #region Internal

            //Select table step (Import and Export)
            CheckedListBox chkTables = new CheckedListBox();
            chkTables.Items.AddRange(Enum.GetNames(typeof(EntitiesEnum)));
            TemplateStep stepSelectTable = new TemplateStep(chkTables);

            //Select source file step (Import)
            FileSelectionStep stepSelectSource = new FileSelectionStep();            
            //Select destiny file step (Export and External export)            
            SelectDestinyStep stepSelectDestiny = new SelectDestinyStep();

            #endregion

            #region External

            //Choose table step (Import and export)
            SelectionStep stepChooseTable = new SelectionStep("Table selection", "Please select the table:", Enum.GetNames(typeof(EntitiesEnum)));
            
            //Set fields step (Import)
            PropertyGrid propGrid = new PropertyGrid();
            TemplateStep stepSetFields = new TemplateStep(propGrid);

            //Set connection step (Import)
            SetConnControl setConnControl = new SetConnControl();
            TemplateStep stepSetConn = new TemplateStep(setConnControl);

            //Select fields step (Export)
            CheckedListBox chkFields = new CheckedListBox();
            chkFields.DisplayMember = "Name";
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


            WizardController controller = new WizardController(stepsInitial);

            stepChooseAction.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                action = (string)stepChooseAction.Selected;

                if (!action.Contains("External")) //Internal
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
                if (action == "Import")
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

                if (action == "Import (External)")
                {
                    ImporterConfig.LoadConfig();
                    table = (EntitiesEnum)Enum.Parse(typeof(EntitiesEnum), (string)stepChooseTable.Selected);
                    var tables = ImporterConfig.GetInstance().Tables;
                    foreach (ExternalTable item in tables)
                    {
                        if (item.RelatedEntitySet == table)
                        {
                            propGrid.SelectedObject = item;
                            break;
                        }
                    }

                    controller.AddAfterCurrent(stepsExternalImport);
                }
                else //Export (External)
                {
                    string entity = Helper.GetEntityNameByEntitySetName(Enum.GetName(typeof(EntitiesEnum),table));
                    IList<Property> props = Helper.GetPropertyListByType(entity);
                    chkFields.Items.AddRange(props.ToArray());

                    stepSelectDestiny.Filter = "Excel files (*.xls)|*.xls";
                    controller.AddAfterCurrent(stepsExternalExport);
                }

                return true;
            };

            //External import final
            stepSetConn.NextHandler = () =>
            {
                controller.DeleteAllAfterCurrent();
                //TODO: poner prev next y cancel en false
                controller.AddAfterCurrent(stepInProgress);                

                _importer = new ImportTool();
                SetConfig(table);
                _importer.bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportCompleted);
                _importer.bg.ProgressChanged += new ProgressChangedEventHandler(ImportProgressChanged);
                _importer.ImportData();                

                return true;
            };

            //External export final
            stepSelectDestiny.NextHandler = () =>
            {
                file = stepSelectDestiny.SelectedFullPath;
                ExportTool exporter = new ExportTool();
                if (action.Contains("External"))
                {
                    string[] props = chkFields.CheckedItems.Cast<Property>().Select(p => p.Name).ToArray();
                    switch (table)
                    {
                        case EntitiesEnum.Departments:
                            exporter.ExportToExcel<Department>(file, props, "");
                            break;
                        case EntitiesEnum.Cities:
                            exporter.ExportToExcel<City>(file, props, "");
                            break;
                        case EntitiesEnum.Territories:
                            exporter.ExportToExcel<Territory>(file, props, "");
                            break;
                        case EntitiesEnum.Addresses:
                            exporter.ExportToExcel<Address>(file, props, "");
                            break;
                        case EntitiesEnum.Publishers:
                            exporter.ExportToExcel<Publisher>(file, props, "");
                            break;
                        case EntitiesEnum.Tours:
                            exporter.ExportToExcel<Tour>(file, props, "");
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