using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Forms
{
    public interface IEventAggregator
    {
        void Publish<TPayload>(TPayload payload);
        void Subscribe<TPayload>(Action<TPayload> action);
        void Unsubscribe<TPayload>(Action<TPayload> action);
    }
}
