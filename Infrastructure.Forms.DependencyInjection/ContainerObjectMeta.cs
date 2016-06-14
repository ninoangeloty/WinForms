using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Forms.DependencyInjection
{
    public class ContainerObjectMeta
    {
        public ContainerObjectMeta() { }

        public ContainerObjectMeta(Type from, Type to, object instance, LifetimePolicy lifetime)
        {
            this.From = from;
            this.To = to;
            this.Instance = instance;
            this.Lifetime = lifetime;
        }

        public Type From { get; set; }
        public Type To { get; set; }
        public LifetimePolicy Lifetime { get; set; }
        public object Instance { get; set; }
    }
}
