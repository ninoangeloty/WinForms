using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DefaultTemplates
{
    public class DialogViewTemplate : IViewTemplate
    {
        public void Setup(System.Windows.Forms.Form form)
        {
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
        }
    }
}
