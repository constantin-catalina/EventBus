using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerBasedEventBus
{
    public interface IHandlerEventBus
    {
        public void Publish(IEvent e);
        public void Subscribe(object subscriber, string methodName, Type eventType);
        public void Unsubscribe(object subscriber, Type eventType);
    }
}
