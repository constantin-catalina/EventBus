using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_1_3
{
    public class WaterLevelSensor : Sensor
    {
        public float waterlevelValue { get; set; }
        public float positon { get; set; }
        public WaterLevelSensor(string id, string location, float precision, float positon) : base(id, location, precision)
        {
            this.waterlevelValue = 0;
            this.positon = positon;
        }
        public override void GenerateData()
        {
            this.waterlevelValue = random.Next(0, 1000);
            HandlerEventBus.Instance.Publish(new WaterLevelEvent(this));
        }
        public float getWaterLevelValue()
        {
            return this.waterlevelValue;
        }
    }
}
