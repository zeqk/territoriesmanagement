/*
 * Based en Merlin Library http://merlin.codeplex.com/
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Merlin;

namespace TerritoriesManagement.GUI.Interop.Steps
{
    internal partial class DestinySelectionStepUI : UserControl
    {
        /// <summary>
        /// A function that retrieves a string
        /// </summary>
        /// <returns></returns>
        internal delegate string StringRetriever();
        internal EventHandler StateChangeEvent { get; set; }
        StringRetriever _browseDialogTitleRetriever;

        internal DestinySelectionStepUI(StringRetriever browseDialogTitleRetriever)
        {
            _browseDialogTitleRetriever = browseDialogTitleRetriever;
            InitializeComponent();
        }

        

        internal string SelectedPathFile
        {
            get
            {
                return txtFilePathSelected.Text;
            }
            set
            {
                txtFilePathSelected.Text = value;
                
            }
        }

        internal string Filter
        {
            get
            {
                return dlgDestinySelection.Filter;
            }
            set
            {
                dlgDestinySelection.Filter = value;
            }
        }

        internal string FileName
        {
            get
            {
                return dlgDestinySelection.FileName;
            }
            set
            {
                dlgDestinySelection.FileName = value;
            }
        }

        internal string PromptText
        {
            get
            {
                return lblSelectFile.Text;
            }
            set
            {
                lblSelectFile.Text = value;
            }
        }

        internal string InitialDirectory
        {
            get
            {
                return dlgDestinySelection.InitialDirectory;
            }
            set
            {
                dlgDestinySelection.InitialDirectory = value;
            }
        }

        /// <summary>
        /// The title of the "browse" dialog box.
        /// </summary>
        internal string BrowseDialogTitle { get; set; }

        #region Event Members

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgDestinySelection.Title = _browseDialogTitleRetriever();
            if (dlgDestinySelection.ShowDialog() == DialogResult.OK)
            {
                txtFilePathSelected.Text = dlgDestinySelection.FileName;
                StateChangeEvent(sender, EventArgs.Empty);
            }
        }

        private void DestinySelectionStepUI_Resize(object sender, EventArgs e)
        {
            int margin = 10;
            pnlControlsFileSelection.Height = pnlControlsFileSelection.Parent.ClientRectangle.Height - 2 * margin;
            pnlControlsFileSelection.Width = pnlControlsFileSelection.Parent.ClientRectangle.Width - 2 * margin;
            pnlControlsFileSelection.Top = margin;
            pnlControlsFileSelection.Left = margin;
            btnBrowse.Left = pnlControlsFileSelection.ClientRectangle.Width - btnBrowse.Width - 20;
            txtFilePathSelected.Width = btnBrowse.Left - txtFilePathSelected.Left - 5;
        }

        private void txtFilePathSelected_KeyUp(object sender, KeyEventArgs e)
        {
            StateChangeEvent(sender, EventArgs.Empty);
        }

        private void txtFilePathSelected_TextChanged(object sender, EventArgs e)
        {
            StateChangeEvent(sender, EventArgs.Empty);
        }

        #endregion


    }
}
