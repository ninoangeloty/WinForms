using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Forms.Templates
{
    public class ChildViewTemplate : IViewTemplate
    {
        public void Setup(System.Windows.Forms.Form form)
        {
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
