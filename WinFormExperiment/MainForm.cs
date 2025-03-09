using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormExperiment
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Form1 form1 = new Form1();
            Settings form2 = new Settings();
            Settings2 form3 = new Settings2();

            // Subscribe Form2's method to Form1's event
            form1.TextChangedEvent += form2.OnTextChanged;
            form1.TextChangedEvent += form3.OnTextChanged;

            form1.Show();
            form2.Show();
            form3.Show();
        }
    }
}
