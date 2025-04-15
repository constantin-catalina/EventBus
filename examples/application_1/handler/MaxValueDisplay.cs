using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    public class MaxValueDisplay : ISubscriber
    {
        public string id { get; set; }
        public float maxTempValue;
        public float maxHumValue;
        public float maxWaterValue;
        public MaxValueDisplay(string id)
        {
            this.id = id;
            this.maxTempValue = float.MinValue;
            this.maxHumValue = float.MinValue;
            this.maxWaterValue = float.MinValue;
        }
        public void DisplayTemperature(TemperatureEvent e)
        {
            var sensor = e.GetTemperatureSensor();
            float newTemp = sensor.getTemperatureValue();

            if (newTemp > maxTempValue)
                maxTempValue = newTemp;

            Console.WriteLine($"[MaxValueDisplay {id}] Max temperature recorded by {sensor.ID} is: {maxTempValue}°C");
        }
        public void DisplayHumidity(HumidityEvent e)
        {
            var sensor = e.GetHumiditySensor();
            float newHum = sensor.getHumidityValue();

            if (newHum > maxHumValue)
                maxHumValue = newHum;

            Console.WriteLine($"[MaxValueDisplay {id}] Max humidity recorded by {sensor.ID} is: {maxHumValue}%");
        }

        public void DisplayWaterLevel(WaterLevelEvent e)
        {
            var sensor = e.GetWaterLevelSensor();
            float newWater = sensor.getWaterLevelValue();

            if (newWater > maxWaterValue)
                maxWaterValue = newWater;

            Console.WriteLine($"[MaxValueDisplay {id}] Max water level recorded by {sensor.ID} is: {maxWaterValue}m");
        }
    }
}
