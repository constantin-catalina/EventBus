using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationsEventBus
{
    class InvalidEventTypeException : Exception
    {
        public InvalidEventTypeException() : base("Invalid event type!") { }
    }
}
