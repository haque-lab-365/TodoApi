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
    public partial class ObserverInitiatorForm : Form
    {

        private Subject subject = new Subject();
        public ObserverInitiatorForm()
        {
            InitializeComponent();
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            //--Notify all registered observers with a message
            subject.Notify("Hello, Observers! Do you see this good morning message?");

        }

        private void btnOpenObserver_Click(object sender, EventArgs e)
        {
            //--Open a new observer form
            ObserverForm observerForm = new ObserverForm(subject);
            observerForm.Show();

        }
    }
}
