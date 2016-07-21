using Hats.Infrastructure.Forms.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms
{
    public static class FormManager
    {
        /// <summary>
        /// Show form using the specified View Template.
        /// </summary>
        /// <typeparam name="T">The View Template to use for the form.</typeparam>
        /// <param name="form">The form to show.</param>
        public static void Show<T>(Form form)
            where T : IViewTemplate
        {
            FormManager.SetupViewTemplate<T>(form);

            form.Show();
        }

        /// <summary>
        /// Show form as a child to a MDI parent using the specified View Template.
        /// </summary>
        /// <typeparam name="T">The View Template to use for the form.</typeparam>
        /// <param name="form">The form to show.</param>
        /// <param name="parent">The MDI form to use as parent.</param>
        public static void Show<T>(Form form, Form parent)
            where T : IViewTemplate
        {
            FormManager.SetupViewTemplate<T>(form);

            form.MdiParent = parent;
            form.Show();
        }

        /// <summary>
        /// Show form as dialog using the specified View Template.
        /// </summary>
        /// <typeparam name="T">The View Template to use for the form.</typeparam>
        /// <param name="form">The form to show.</param>
        public static void ShowDialog<T>(Form form)
            where T : IViewTemplate
        {
            FormManager.SetupViewTemplate<T>(form);

            form.ShowDialog();
        }

        private static void SetupViewTemplate<T>(Form form)
            where T : IViewTemplate
        {
            var viewTemplate = Activator.CreateInstance<T>();
            viewTemplate.Setup(form);
        }
    }
}
