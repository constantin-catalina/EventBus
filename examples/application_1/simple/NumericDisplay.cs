using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
{
    public class NumericDisplay : ISubscriber
    {
        public string id { get; set; }
        public NumericDisplay(string id) {
            this.id = id;
        }
        public void Inform(IEvent e)
        {
            if (e is WaterLevelEvent)
            {
                WaterLevelEvent waterLevelEvent = (WaterLevelEvent)e;
                WaterLevelSensor waterLevelMonitor = waterLevelEvent.GetWaterLevelSensor();
                var value = waterLevelMonitor.getWaterLevelValue();
                Console.WriteLine($"[Numeric Display {id}] {waterLevelMonitor.location}, km {waterLevelMonitor.positon}, sensor {waterLevelMonitor.ID}: {value} +/- {waterLevelMonitor.precision}m");
            }
            else if (e is TemperatureEvent)
            {
                TemperatureEvent temperatureEvent = (TemperatureEvent)e;
                TemperatureSensor temperatureMonitor = temperatureEvent.GetTemperatureSensor();
                var value = temperatureMonitor.getTemperatureValue();
                Console.WriteLine($"[Numeric Display {id}] {temperatureMonitor.location}, sensor {temperatureMonitor.ID}: {value} +/- {temperatureMonitor.precision}°C");
            }
            else if (e is HumidityEvent)
            {
                HumidityEvent humidityEvent = (HumidityEvent)e;
                HumiditySensor humidityMonitor = humidityEvent.GetHumiditySensor();
                var value = humidityMonitor.getHumidityValue();
                Console.WriteLine($"[Numeric Display {id}] {humidityMonitor.location}, sensor {humidityMonitor.ID}: {value} +/- {humidityMonitor.precision}%");
            }
        }
    }
}
