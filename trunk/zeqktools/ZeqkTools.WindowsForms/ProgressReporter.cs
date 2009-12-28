using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeqkTools.WindowsForms
{
    public partial class ProgressReporter : Form
    {
        public ProgressReporter()
        {
            InitializeComponent();
        }

        public void WriteLine(string text)
        {
            txtReport.Text += text + Environment.NewLine;
        }
    }
}
