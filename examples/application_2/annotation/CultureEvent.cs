using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_2_3
{
    public class CultureEvent : IEvent
    {
        public Culture News { get; private set; }

        public CultureEvent(Culture news)
        {
            News = news;
        }
    }
}
