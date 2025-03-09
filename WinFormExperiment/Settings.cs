using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormExperiment
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        //-Method to handle the event
        public void OnTextChanged(string text)
        {
            label1.Text = text;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
