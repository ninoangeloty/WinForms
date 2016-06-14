using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EventAggregator : IEventAggregator
    {
        #region Singleton Implementation

        private static object myLock = new object();
        private static volatile EventAggregator instance = null; // 'volatile' is unnecessary in .NET 2.0 and later

        private EventAggregator()
        {
        }

        public static EventAggregator GetInstance()
        {
            if (instance == null)
            {
                lock (myLock)
                {
                    if (instance == null)
                    {
                        instance = new EventAggregator();
                    }
                }
            }
            return instance;
        }

        #endregion

        private List<EventAggregatorMeta> Subscribers { get; set; }

        /// <summary>
        /// Publish to subscribers with the payload object.
        /// </summary>
        /// <param name="payload">The payload to transmit to subscribers.</param>
        public void Publish<TPayload>(TPayload payload)
        {
            if (Subscribers == null)
            {
                return;
            }

            foreach (var item in Subscribers.Where(_ => _.Payload == typeof(TPayload)))
            {
                var action = (Action<TPayload>)item.SubscriberAction;

                action.Invoke(payload);
            }
        }

        /// <summary>
        /// Subscribe to an event using the action.
        /// </summary>
        /// <typeparam name="TPayload">The payload object the publisher will transmit.</typeparam>
        /// <param name="action">The action to raise when published.</param>
        public void Subscribe<TPayload>(Action<TPayload> action)
        {
            if (Subscribers == null)
            {
                Subscribers = new List<EventAggregatorMeta>();
            }

            var meta = new EventAggregatorMeta();
            meta.Payload = typeof(TPayload);
            meta.SubscriberAction = action;

            Subscribers.Add(meta);
        }

        /// <summary>
        /// Unsubscribe to an event using the action.
        /// </summary>
        /// <typeparam name="TPayload">The payload object the publisher will transmit.</typeparam>
        /// <param name="action">The action to raise when published.</param>
        public void Unsubscribe<TPayload>(Action<TPayload> action)
        {
            var itemsToRemove = Subscribers.Where(_ => (Action<TPayload>)_.SubscriberAction == action).ToList();

            foreach (var item in itemsToRemove)
            {
                Subscribers.Remove(item);
            }
        }
    }
}
