using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEventBus
{
    public interface IBasicEventBus
    {
        public void Publish(IEvent e);
        public void Subscribe(Type eventType, ISubscriber subscriber);
        public void Unsubscribe(Type eventType, ISubscriber subscriber);
    }
}
