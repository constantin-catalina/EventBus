using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace HandlerBasedEventBus
{
    public class HandlerEventBus : IHandlerEventBus
    {
        private class Subscription
        {
            public MethodInfo Method { get; }
            public object Subscriber { get; }
            public Type EventType { get; }

            public Subscription(MethodInfo method, object subscriber, Type eventType)
            {
                Method = method;
                Subscriber = subscriber;
                EventType = eventType;
            }
        }
        private readonly List<Subscription> subscriptions;
        private static HandlerEventBus instance = null;
        public HandlerEventBus()
        {
            subscriptions = new List<Subscription>();
        }
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

            foreach (Subscription subscription in subscriptions)
            {
                if(subscription.EventType == eventType)
                {
                    try
                    {
                        subscription.Method.Invoke(subscription.Subscriber, new object[] { e });
                    }
                    catch (TargetInvocationException tie)
                    {
                        Console.WriteLine($"[Error] Exception in event handler: {tie.InnerException?.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Error] Could not invoke handler: {ex.Message}");
                    }
                }
            }
        }
        public void Subscribe(object subscriber, string methodName, Type eventType)
        {
            if (!typeof(IEvent).IsAssignableFrom(eventType))
                throw new ArgumentException($"Event type {eventType.Name} must implement IEvent.");

            MethodInfo method = subscriber.GetType().GetMethod(methodName, new Type[] { eventType });

            if (method == null)
                throw new ArgumentException($"Method '{methodName}' with parameter '{eventType.Name}' not found on {subscriber.GetType().Name}.");

            if (!method.IsPublic)
                throw new ArgumentException("Handler method must be public.");

            foreach (Subscription sub in subscriptions)
            {
                if (sub.Subscriber == subscriber && sub.EventType == eventType && sub.Method == method)
                {
                    Console.WriteLine($"[Warning] Duplicate subscription ignored for {subscriber.GetType().Name}.");
                    return;
                }
            }

            subscriptions.Add(new Subscription(method, subscriber, eventType));

        }
        public void Unsubscribe(object subscriber, Type eventType)
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
