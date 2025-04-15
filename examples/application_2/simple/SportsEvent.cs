using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2_2
{
    public class SportsEvent : IEvent
    {
        public Sports News { get; private set; }

        public SportsEvent(Sports news)
        {
            News = news;
        }
    }
}
