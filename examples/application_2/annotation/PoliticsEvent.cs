using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_2_3
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
