using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEventBus
{
    public class BasicEventBus : IBasicEventBus
    {
        private class Subscription
        {
            public Type EventType { get; }
            public ISubscriber Subscriber { get; }

            public Subscription(Type eventType, ISubscriber subscriber)
            {
                EventType = eventType;
                Subscriber = subscriber;
            }

            public override bool Equals(object obj)
            {
                if (obj is Subscription other)
                {
                    return EventType == other.EventType && Subscriber == other.Subscriber;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(EventType, Subscriber);
            }
        }
        private static BasicEventBus instance = null;
        private readonly List<Subscription> subscriptions;
        private readonly Type eventClass = typeof(IEvent);
        public BasicEventBus()
        {
            subscriptions = new List<Subscription>();
        }
        public static BasicEventBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BasicEventBus();
                }
                return instance;
            }
        }
        public void Publish(IEvent e)
        {
            Type eventType = e.GetType();
            foreach (Subscription subscription in subscriptions)
            {
                if (subscription.EventType.IsAssignableFrom(eventType))
                {
                    subscription.Subscriber.Inform(e);
                }
            }
        }
        public void Subscribe(Type eventType, ISubscriber subscriber)
        {
            if (!eventClass.IsAssignableFrom(eventType))
            {
                throw new InvalidEventTypeException();
            }

            Subscription subscription = new Subscription(eventType, subscriber);
            if (!subscriptions.Contains(subscription))
            {
                subscriptions.Add(subscription);
            }
        }
        public void Unsubscribe(Type eventType, ISubscriber subscriber)
        {
            for (int i = 0; i < subscriptions.Count; i++)
            {
                if (subscriptions[i].EventType == eventType && subscriptions[i].Subscriber == subscriber)
                {
                    subscriptions.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}
