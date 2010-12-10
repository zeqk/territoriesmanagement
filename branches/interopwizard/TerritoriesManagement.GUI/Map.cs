using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerritoriesManagement.GUI
{
    static public class Map
    {
        public static frmMap MapForm;

        static public void Initiate()
        {
            MapForm = new frmMap();            
        }

        static public void Close()
        {
            MapForm.Dispose();
        }
    }
}
