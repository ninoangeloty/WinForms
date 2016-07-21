using Hats.Infrastructure.Forms.DependencyInjection;
using Hats.Infrastructure.Forms.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms
{
    public class BaseForm : Form
    {
        public BaseForm() : base() 
        {
            var resolver = new DependencyResolver();
            resolver.EvaluateDependency(this);
        }

        public new virtual IEnumerable<ValidationResult> Validate()
        {
            yield break;
        }
    }
}
