using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2_2
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
