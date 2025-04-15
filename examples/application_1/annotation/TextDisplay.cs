using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnotationsEventBus;

namespace assignment_2_1_3
{
    public class TextDisplay : ISubscriber
    {
        public string id { get; set; }

        public TextDisplay(string id)
        {
            this.id = id;
        }

        [EventHandler(typeof(WaterLevelEvent))]
        private void OnWaterLevelEvent(WaterLevelEvent e)
        {
            var sensor = e.GetWaterLevelSensor();
            var value = sensor.getWaterLevelValue();
            Console.WriteLine($"[Text Display {id}] Water level on river {sensor.location} at km {sensor.positon} from sensor {sensor.ID} is: {value} +/- {sensor.precision}m");
        }

        [EventHandler(typeof(TemperatureEvent))]
        private void OnTemperatureEvent(TemperatureEvent e)
        {
            var sensor = e.GetTemperatureSensor();
            var value = sensor.getTemperatureValue();
            Console.WriteLine($"[Text Display {id}] Temperature in {sensor.location} from sensor {sensor.ID} is: {value} +/- {sensor.precision}°C");
        }

        [EventHandler(typeof(HumidityEvent))]
        private void OnHumidityEvent(HumidityEvent e)
        {
            var sensor = e.GetHumiditySensor();
            var value = sensor.getHumidityValue();
            Console.WriteLine($"[Text Display {id}] Humidity in {sensor.location} from sensor {sensor.ID} is: {value} +/- {sensor.precision}%");
        }
    }
}
