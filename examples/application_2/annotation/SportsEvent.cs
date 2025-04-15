using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_2_3
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
