using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IView<T>
        where T : class, new()
    {
        T Controller { get; set; }
    }
}
