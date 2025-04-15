using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace AnnotationsEventBus
{
    public class HandlerEventBus : IHandlerEventBus
    {
        private class Subscription
        {
            public Type EventType { get; }
            public ISubscriber Subscriber { get; }
            public MethodInfo HandlerMethod { get; }

            public Subscription(Type eventType, ISubscriber subscriber, MethodInfo method)
            {
                EventType = eventType;
                Subscriber = subscriber;
                HandlerMethod = method;
            }
            public override bool Equals(object obj)
            {
                if (obj is Subscription other)
                {
                    return EventType == other.EventType &&
                           Subscriber == other.Subscriber &&
                           HandlerMethod == other.HandlerMethod;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(EventType, Subscriber, HandlerMethod);
            }
        }

        private static HandlerEventBus instance = null;
        private readonly List<Subscription> subscriptions = new List<Subscription>();
        public static HandlerEventBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HandlerEventBus();
                }
                return instance;
            }
        }
        public void Publish(IEvent e)
        {
            Type eventType = e.GetType();

            for (int i = 0; i < subscriptions.Count; i++)
            {
                if (subscriptions[i].EventType.IsAssignableFrom(eventType))
                {
                    subscriptions[i].HandlerMethod.Invoke(subscriptions[i].Subscriber, new object[] { e });
                }
            }
        }
        public void Subscribe<TEvent>(ISubscriber subscriber) where TEvent : IEvent
        {
            MethodInfo[] methods = subscriber.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                var attr = method.GetCustomAttribute<EventHandlerAttribute>();
                if (attr == null) continue;

                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length != 1)
                {
                    throw new InvalidEventTypeException();
                }

                Type eventType = parameters[0].ParameterType;

                if (!typeof(IEvent).IsAssignableFrom(eventType))
                {
                    throw new InvalidEventTypeException();
                }

                if (eventType == typeof(TEvent))
                {
                    var subscription = new Subscription(eventType, subscriber, method);

                    if (!subscriptions.Contains(subscription))
                    {
                        subscriptions.Add(subscription);
                    }
                }
            }
        }

        public void Unsubscribe<TEvent>(ISubscriber subscriber) where TEvent : IEvent
        {
            for (int i = 0; i < subscriptions.Count; i++)
            {
                if (subscriptions[i].EventType.IsAssignableFrom(typeof(TEvent)) &&
                   subscriptions[i].Subscriber == subscriber)
                {
                    subscriptions.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}