using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    public class TemperatureEvent : IEvent
    {
        TemperatureSensor theSensor;
        public TemperatureEvent(TemperatureSensor temperatureSensor)
        {
            this.theSensor = temperatureSensor;
        }
        public TemperatureSensor GetTemperatureSensor()
        {
            return theSensor;
        }
    }
}
