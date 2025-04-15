using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandlerBasedEventBus;

namespace assignment_2_1_2
{   
    public class HumidityEvent : IEvent
    {
        HumiditySensor theSensor;
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
