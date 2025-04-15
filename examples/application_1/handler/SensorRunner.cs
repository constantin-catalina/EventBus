using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    public class SensorRunner
    {
        private readonly Sensor sensor;
        private readonly Timer timer;
        private readonly int interval;

        public SensorRunner(Sensor sensor, int intervalMilliseconds)
        {
            this.sensor = sensor;
            this.interval = intervalMilliseconds;
            timer = new Timer(GenerateSensorData, null, 0, intervalMilliseconds);
        }

        private void GenerateSensorData(object state)
        {
            sensor.GenerateData();
        }
    }
}
