using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    public class HumiditySensor : Sensor
    {
        public float humidityValue { get; set; }
        public HumiditySensor(string id, string location, float precision) : base(id, location, precision)
        {
            this.humidityValue = 0;
        }
        public override void GenerateData()
        {
            this.humidityValue = random.Next(0, 100);
            HandlerEventBus.Instance.Publish(new HumidityEvent(this));
        }
        public float getHumidityValue()
        {
            return this.humidityValue;
        }
    }
}
