using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
{
    public class TemperatureSensor : Sensor
    {
        public float temperatureValue { get; set; }
        public TemperatureSensor(string id, string location, float precision) : base(id, location, precision)
        {
            this.temperatureValue = 0;
        }
        public override void GenerateData()
        {
            this.temperatureValue = random.Next(-20, 50);
            BasicEventBus.Instance.Publish(new TemperatureEvent(this));
        }
        public float getTemperatureValue()
        {
            return this.temperatureValue;
        }
    }
}
