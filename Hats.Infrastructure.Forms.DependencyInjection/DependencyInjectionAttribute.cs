using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Forms.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DependencyInjectionAttribute : Attribute { }
}
