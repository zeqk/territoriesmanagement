/*
 * Based en Merlin Library http://merlin.codeplex.com/
 */

using System;
using Merlin;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    /// <summary>
    /// This step presents a file selection interface.
    /// </summary>
    public class DestinySelectionStep : TemplateStep
    {
        private DestinySelectionStepUI ui;

        /// <summary>
        /// Create a new DestinySelectionStep
        /// </summary>
        public DestinySelectionStep()
            : base()
        {
            ui = new DestinySelectionStepUI(()=>this.BrowseDialogTitle);
            this.UI = ui;
            ui.StateChangeEvent = (object sender, EventArgs args) => { this.StateUpdated(); };
        }

        /// <summary>
        /// Creates a new DestinySelectionStep with the specified title
        /// </summary>
        /// <param name="title"></param>
        public DestinySelectionStep(string title) :
            this()
        {
            this.Title = title;
        }

        /// <summary>
        /// Creates a new DestinySelectionStep with the specified title and question text.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="question"></param>
        public DestinySelectionStep(string title, string question) :
            this(title)
        {
            this.PromptText = question;
        }

        /// <summary>
        /// Gets or sets the full path of the selected file.
        /// </summary>
        public string SelectedFullPath
        {
            get
            {
                return this.ui.SelectedPathFile;
            }
            set
            {
                this.ui.SelectedPathFile = value;
            }
        }

        /// <summary>
        /// Gets or sets the current filename filter string.
        /// The format of the string is the same as that of the Filter
        /// property of System.Windows.Forms.OpenFileDialog
        /// </summary>
        public string Filter
        {
            get
            {
                return this.ui.Filter;
            }
            set
            {
                this.ui.Filter = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected file name
        /// </summary>
        public string SelectedFileName
        {
            get
            {
                return this.ui.FileName;
            }
            set
            {
                this.ui.FileName = value;
            }
        }

        /// <summary>
        /// Gets or sets the question text asking for the file.
        /// </summary>
        public string PromptText
        {
            get
            {
                return this.ui.PromptText;
            }
            set
            {
                this.ui.PromptText = value;
            }
        }

        /// <summary>
        /// Gets or sets the initial directory to be shown in the browse dialog.
        /// </summary>
        public string InitialDirectory
        {
            get
            {
                return this.ui.InitialDirectory;
            }
            set
            {
                this.ui.InitialDirectory = value;
            }
        }

        string _browseDialogTitle = null;
        /// <summary>
        /// Gets or sets the custom title for the browse dialog.
        /// If set to null (default), the title of the step will be 
        /// used for the dialog title.
        /// </summary>
        public string BrowseDialogTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_browseDialogTitle))
                {
                    return this.Title;
                }
                else return _browseDialogTitle;
            }
            set
            {
                _browseDialogTitle = value;
            }
        }
    }
}
