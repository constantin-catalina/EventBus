using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationsEventBus
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class EventHandlerAttribute : Attribute
    {
        public Type EventType { get; }
        public EventHandlerAttribute(Type eventType)
        {
            EventType = eventType;
        }
    }
}