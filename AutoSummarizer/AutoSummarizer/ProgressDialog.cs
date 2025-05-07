using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSummarizer
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog(int max)
        {
            InitializeComponent();
            progressbar.Minimum = 0;
            progressbar.Maximum = max;
            progressbar.Value = 0;
        }
        public void Report(int value, string status = null)
        {
            progressbar.Value = value;
            if (status != null) { lblStatus.Text = status; }
        }
    }
   
}
