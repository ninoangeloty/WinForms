﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Forms.DependencyInjection
{
    public class InstanceManager
    {
        public object GetInstance(ContainerObjectDescriptor meta)
        {
            if (meta.Lifetime == LifetimePolicy.Default)
            {
                return Activator.CreateInstance(meta.To);
            }
            else
            {
                if (meta.Instance == null)
                {
                    meta.Instance = Activator.CreateInstance(meta.To);
                }

                return meta.Instance;
            }
        }
    }
}
