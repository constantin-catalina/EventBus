using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnotationsEventBus;

namespace assignment_2_1_3
{
    public class SensorSimulation
    {
        private readonly List<SensorRunner> sensorRunners;

        public SensorSimulation()
        {
            sensorRunners = new List<SensorRunner>
            {
                new SensorRunner(new TemperatureSensor("TS1", "Arad", 0.1f), 2000),
                new SensorRunner(new TemperatureSensor("TS2", "Timisoara", 0.2f), 3000),
                new SensorRunner(new WaterLevelSensor("WS1", "Mures", 0.5f, 100), 5000),
                new SensorRunner(new HumiditySensor("HS1", "Cluj", 1.0f), 7000)
            };
        }
    }
}
