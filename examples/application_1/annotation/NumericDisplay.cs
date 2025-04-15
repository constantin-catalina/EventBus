using AnnotationsEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2_1_3
{
    public class NumericDisplay : ISubscriber
    {
        public string id { get; set; }

        public NumericDisplay(string id)
        {
            this.id = id;
        }

        [EventHandler(typeof(WaterLevelEvent))]
        private void OnWaterLevelEvent(WaterLevelEvent e)
        {
            var sensor = e.GetWaterLevelSensor();
            var value = sensor.getWaterLevelValue();
            Console.WriteLine($"[Numeric Display {id}] {sensor.location}, km {sensor.positon}, sensor {sensor.ID}: {value} +/- {sensor.precision}m");
        }
        [EventHandler(typeof(TemperatureEvent))]
        private void OnTemperatureEvent(TemperatureEvent e)
        {
            var sensor = e.GetTemperatureSensor();
            var value = sensor.getTemperatureValue();
            Console.WriteLine($"[Numeric Display {id}] {sensor.location}, sensor {sensor.ID}: {value} +/- {sensor.precision}°C");
        }

        [EventHandler(typeof(HumidityEvent))]
        private void OnHumidityEvent(HumidityEvent e)
        {
            var sensor = e.GetHumiditySensor();
            var value = sensor.getHumidityValue();
            Console.WriteLine($"[Numeric Display {id}] {sensor.location}, sensor {sensor.ID}: {value} +/- {sensor.precision}%");
        }
    }
}
