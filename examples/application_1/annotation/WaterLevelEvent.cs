using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_1_3
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
