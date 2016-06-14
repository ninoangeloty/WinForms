using Infrastructure;
using Infrastructure.Forms.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Payloads;

namespace WinFormsTest
{
    public partial class Form2 : BaseForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventAggregator.GetInstance().Publish(new ChangeLabelPayload() { Label = "Label changed!" });
        }

        [DependencyInjection]
        public ISample Sample { get; set; }
    }
}
