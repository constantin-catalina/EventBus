using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    public class NumericDisplay : ISubscriber
    {
        public string id { get; set; }
        public NumericDisplay(string id)
        {
            this.id = id;
        }
        public void DisplayWaterLevel(WaterLevelEvent e)
        {
            WaterLevelSensor s = e.GetWaterLevelSensor();
            Console.WriteLine($"[Numeric Display {id}] {s.location}, km {s.positon}, sensor {s.ID}: {s.getWaterLevelValue()} +/- {s.precision}m");
        }

        public void DisplayTemperature(TemperatureEvent e)
        {
            TemperatureSensor s = e.GetTemperatureSensor();
            Console.WriteLine($"[Numeric Display {id}] {s.location}, sensor {s.ID}: {s.getTemperatureValue()} +/- {s.precision}°C");
        }

        public void DisplayHumidity(HumidityEvent e)
        {
            HumiditySensor s = e.GetHumiditySensor();
            Console.WriteLine($"[Numeric Display {id}] {s.location}, sensor {s.ID}: {s.getHumidityValue()} +/- {s.precision}%");
        }
    }
}
