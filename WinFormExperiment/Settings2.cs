using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExperiment
{
    public partial class Settings2 : Form
    {
        public Settings2()
        {
            InitializeComponent();
        }

        //-Method to handle the event
        public void OnTextChanged(string text)
        {
            label1.Text = text;
        }
    }
}
