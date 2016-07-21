using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms
{
    public interface IViewTemplate
    {
        void Setup(Form form);
    }
}
