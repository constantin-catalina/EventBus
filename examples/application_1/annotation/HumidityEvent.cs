using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_1_3
{
    public class HumidityEvent : IEvent
    {
        private readonly HumiditySensor theSensor;

        public HumidityEvent(HumiditySensor humiditySensor)
        {
            this.theSensor = humiditySensor;
        }

        public HumiditySensor GetHumiditySensor()
        {
            return theSensor;
        }
    }
}
