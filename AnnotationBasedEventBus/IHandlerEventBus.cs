using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationsEventBus
{
    public interface IHandlerEventBus
    {
        void Publish(IEvent e);
        void Subscribe<TEvent>(ISubscriber subscriber) where TEvent : IEvent;
        void Unsubscribe<TEvent>(ISubscriber subscriber) where TEvent : IEvent;
    }
}
