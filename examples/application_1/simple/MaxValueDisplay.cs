using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
{
    public class MaxValueDisplay : ISubscriber
    {
        public string id { get; set; }
        public float maxTempValue;
        public float maxHumValue;
        public float maxWaterValue;
        public MaxValueDisplay(string id) { 
            this.id = id;
            this.maxTempValue = float.MinValue;
            this.maxHumValue = float.MinValue;
            this.maxWaterValue = float.MinValue;
        }
        public void Inform(IEvent e)
        {
            if (e is TemperatureEvent)
            {
                TemperatureEvent temperatureEvent = (TemperatureEvent)e;
                TemperatureSensor temperatureMonitor = temperatureEvent.GetTemperatureSensor();
                float newTemp = temperatureMonitor.getTemperatureValue();

                if (newTemp > maxTempValue)
                {
                    maxTempValue = newTemp;
                }
                Console.WriteLine($"[MaxValueDisplay {id}] Max temperature recorded by {temperatureMonitor.ID} is: {maxTempValue}°C");
            }
            else if (e is HumidityEvent) 
            {
                HumidityEvent humidityEvent = (HumidityEvent)e;
                HumiditySensor humidityMonitor = humidityEvent.GetHumiditySensor();
                float newHum = humidityMonitor.getHumidityValue();

                if (newHum > maxHumValue)
                {
                    maxHumValue = newHum;
                }
                Console.WriteLine($"[MaxValueDisplay {id}] Max humidity recorded by {humidityMonitor.ID} is: {maxHumValue}%");
            }
            else if (e is WaterLevelEvent) 
            {
                WaterLevelEvent waterLevelEvent = (WaterLevelEvent)e;
                WaterLevelSensor waterMonitor = waterLevelEvent.GetWaterLevelSensor();
                float newWater = waterMonitor.getWaterLevelValue();

                if (newWater > maxWaterValue)
                {
                    maxWaterValue = newWater;
                }
                Console.WriteLine($"[MaxValueDisplay {id}] Max water level recorded by {waterMonitor.ID} is: {maxWaterValue}m");
            }
        }
    }
}
