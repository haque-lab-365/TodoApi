using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormExperiment.Observer;

namespace WinFormExperiment
{
    public partial class ObserverForm : Form, IObserver
    {
        private Subject subject;
        public ObserverForm(Subject subject)
        {
            InitializeComponent();
            this.subject = subject;
            this.subject.Attach(this);
        }

        public void Update(string message)
        {
            this.lblMessage.Text = message;
            //--throw new NotImplementedException();
        }

        private void ObserverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //--Detach from the subject when the form is closing
            this.subject.Detach(this);

        }
    }
}
