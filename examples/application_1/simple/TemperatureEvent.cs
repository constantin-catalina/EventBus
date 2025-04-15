using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
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
