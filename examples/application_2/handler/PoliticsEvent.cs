using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandlerBasedEventBus;

namespace assignment_2_2_2
{
    public class PoliticsEvent : IEvent
    {
        public Politics News { get; private set; }

        public PoliticsEvent(Politics news)
        {
            News = news;
        }
    }
}
