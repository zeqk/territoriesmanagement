using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerritoriesManagement.GUI
{
    public class GUIFunctions
    {
        static public void dataGrid_Resize(object sender, ref int PrevWidth)
        {
            DataGridView dataGrid = (DataGridView)sender;

            if (PrevWidth == 0)
                PrevWidth = dataGrid.Width;
            if (PrevWidth == dataGrid.Width)
                return;

            //const int ScrollBarWidth = 18;

            //int FixedWidth = ScrollBarWidth + dataGrid.RowHeadersWidth;


            int FixedWidth = SystemInformation.VerticalScrollBarWidth +
                                             dataGrid.RowHeadersWidth + 2;
            int Mul =
               100 * (dataGrid.Width - FixedWidth) / (PrevWidth - FixedWidth);
            int W;
            int total = 0;
            int LastCol = 0;

            for (int i = 0; i < dataGrid.ColumnCount; i++)
                if (dataGrid.Columns[i].Visible)
                {
                    W = (dataGrid.Columns[i].Width * Mul + 50) / 100;
                    dataGrid.Columns[i].Width =
                                Math.Max(W, dataGrid.Columns[i].MinimumWidth);
                    total += dataGrid.Columns[i].Width;
                    LastCol = i;
                }
            total -= dataGrid.Columns[LastCol].Width;
            W = dataGrid.Width - total - FixedWidth;
            dataGrid.Columns[LastCol].Width =
                        Math.Max(W, dataGrid.Columns[LastCol].MinimumWidth);
            PrevWidth = dataGrid.Width;
        }
    }
}
