using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoSummarizer;
namespace AutoSummarizer
{
    public partial class Test : Form
    {
        public Test(string TextToShow)
        {
            InitializeComponent();
            textBox_Test.Text = TextToShow;
        }
    }
}
