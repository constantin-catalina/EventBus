using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
{
    public class TextDisplay : ISubscriber
    {
        public string id { get; set; }
        public TextDisplay(string id)
        {
            this.id = id;
        }
        public void Inform(IEvent e)
        {
            if (e is WaterLevelEvent)
            {
                WaterLevelEvent waterLevelEvent = (WaterLevelEvent)e;
                WaterLevelSensor waterLevelMonitor = waterLevelEvent.GetWaterLevelSensor();
                var value = waterLevelMonitor.getWaterLevelValue();
                Console.WriteLine($"[Text Display {id}] Water level on river {waterLevelMonitor.location} at km {waterLevelMonitor.positon} from sensor {waterLevelMonitor.ID} is: {value} +/- {waterLevelMonitor.precision}m");
            }
            else if (e is TemperatureEvent)
            {
                TemperatureEvent temperatureEvent = (TemperatureEvent)e;
                TemperatureSensor temperatureMonitor = temperatureEvent.GetTemperatureSensor();
                var value = temperatureMonitor.getTemperatureValue();
                Console.WriteLine($"[Text Display {id}] Temperature in {temperatureMonitor.location} from sensor {temperatureMonitor.ID} is: {value} +/- {temperatureMonitor.precision}°C");
            }
            else if (e is HumidityEvent)
            {
                HumidityEvent humidityEvent = (HumidityEvent)e;
                HumiditySensor humidityMonitor = humidityEvent.GetHumiditySensor();
                var value = humidityMonitor.getHumidityValue();
                Console.WriteLine($"[Text Display {id}] Humidity in {humidityMonitor.location} from sensor {humidityMonitor.ID} is: {value} +/- {humidityMonitor.precision}%");
            }
        }
    }
}
