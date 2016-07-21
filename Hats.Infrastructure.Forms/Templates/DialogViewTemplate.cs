using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Forms.Templates
{
    public class DialogViewTemplate : IViewTemplate
    {
        public void Setup(System.Windows.Forms.Form form)
        {
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ShowIcon = false;
        }
    }
}
