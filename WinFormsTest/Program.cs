using Infrastructure;
using Infrastructure.Forms.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Controllers;

namespace WinFormsTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Container.Instance.RegisterType<ISample, Sample>();
            //Container.Instance.RegisterInstance<ISample>(new Sample());
            Container.Instance.RegisterInstance<ISample, Sample>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormManager.Initialize<Form1, FormOneController>());
        }
    }
}
