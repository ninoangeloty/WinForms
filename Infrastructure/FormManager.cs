using Infrastructure.DefaultTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infrastructure
{
    public static class FormManager
    {
        /// <summary>
        /// Initialize form with the Controller.
        /// </summary>
        /// <typeparam name="T">The form to be initialized.</typeparam>
        /// <typeparam name="TController">The controller to assign to the form.</typeparam>
        /// <returns>Returns the instance of the form initialized using the generics specified.</returns>
        public static T Initialize<T, TController>()
            where T : Form, IView<TController>
            where TController : class, new()
        {
            var presenter = Activator.CreateInstance<TController>();
            var form = Activator.CreateInstance<T>();

            form.Controller = presenter;

            return form;
        }

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
