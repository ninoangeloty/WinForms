using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infrastructure
{
    public interface IViewTemplate
    {
        void Setup(Form form);
    }
}
