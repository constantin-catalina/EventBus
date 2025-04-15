using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
{
    public class WaterLevelEvent : IEvent
    {
        WaterLevelSensor theSensor;
        public WaterLevelEvent(WaterLevelSensor waterLevelSensor)
        {
            this.theSensor = waterLevelSensor;
        }
        public WaterLevelSensor GetWaterLevelSensor()
        {
            return theSensor;
        }
    }
}
