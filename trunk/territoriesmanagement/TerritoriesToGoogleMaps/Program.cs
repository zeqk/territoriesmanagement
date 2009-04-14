using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace TerritoriesToGoogleMaps
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Serialization.WriteMarks();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
