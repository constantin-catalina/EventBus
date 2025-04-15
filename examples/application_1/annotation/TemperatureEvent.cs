using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_1_3
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
