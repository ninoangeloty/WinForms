using Hats.Infrastructure.Forms.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms
{
    public abstract class Controller
    {
        public Controller()
        {
            var resolver = new DependencyResolver();
            resolver.EvaluateDependency(this);            
        }
    }
}
