using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure
{
    internal class EventAggregatorMeta
    {
        public object SubscriberAction { get; set; }
        public Type Payload { get; set; }        
    }
}
