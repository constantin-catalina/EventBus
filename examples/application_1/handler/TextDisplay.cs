using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    public class TextDisplay : ISubscriber
    {
        public string id { get; set; }
        public TextDisplay(string id)
        {
            this.id = id;
        }
        public void DisplayWaterLevel(WaterLevelEvent e)
        {
            WaterLevelSensor s = e.GetWaterLevelSensor();
            Console.WriteLine($"[Text Display {id}] Water level on river {s.location} at km {s.positon} from sensor {s.ID} is: {s.getWaterLevelValue()} +/- {s.precision}m");
        }
        public void DisplayTemperature(TemperatureEvent e)
        {
            TemperatureSensor s = e.GetTemperatureSensor();
            Console.WriteLine($"[Text Display {id}] Temperature in {s.location} from sensor {s.ID} is: {s.getTemperatureValue()} +/- {s.precision}°C");
        }
        public void DisplayHumidity(HumidityEvent e)
        {
            HumiditySensor s = e.GetHumiditySensor();
            Console.WriteLine($"[Text Display {id}] Humidity in {s.location} from sensor {s.ID} is: {s.getHumidityValue()} +/- {s.precision}%");
        }
    }
}
