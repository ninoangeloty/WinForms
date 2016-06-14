using Infrastructure;
using Infrastructure.DefaultTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Controllers;
using WinFormsTest.Payloads;

namespace WinFormsTest
{
    public partial class Form1 : Form, IView<FormOneController>
    {
        public Form1()
        {
            InitializeComponent();

            EventAggregator.GetInstance().Subscribe<ChangeLabelPayload>(ChangeLabel);
        }

        public FormOneController Controller { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            FormManager.ShowDialog<DialogViewTemplate>(new Form2());
        }

        private void ChangeLabel(ChangeLabelPayload payload)
        {
            label1.Text = payload.Label;
        }
    }
}
