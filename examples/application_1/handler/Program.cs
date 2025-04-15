using System;
using HandlerBasedEventBus;

namespace assignment_2_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericDisplay numericDisplay1 = new NumericDisplay("ND1");
            NumericDisplay numericDisplay2 = new NumericDisplay("ND2");

            MaxValueDisplay maxValueDisplay1 = new MaxValueDisplay("MVD1");

            TextDisplay textDisplay1 = new TextDisplay("TD1");
            
            HandlerEventBus.Instance.Subscribe(numericDisplay1, nameof(NumericDisplay.DisplayTemperature), typeof(TemperatureEvent));
            HandlerEventBus.Instance.Subscribe(numericDisplay1, nameof(NumericDisplay.DisplayHumidity), typeof(HumidityEvent));
            HandlerEventBus.Instance.Subscribe(numericDisplay1, nameof(NumericDisplay.DisplayWaterLevel), typeof(WaterLevelEvent));
            
            HandlerEventBus.Instance.Subscribe(numericDisplay2, nameof(NumericDisplay.DisplayTemperature), typeof(TemperatureEvent));
            
            HandlerEventBus.Instance.Subscribe(maxValueDisplay1, nameof(MaxValueDisplay.DisplayHumidity), typeof(HumidityEvent));
            HandlerEventBus.Instance.Subscribe(maxValueDisplay1, nameof(MaxValueDisplay.DisplayTemperature), typeof(TemperatureEvent));
            HandlerEventBus.Instance.Subscribe(maxValueDisplay1, nameof(MaxValueDisplay.DisplayWaterLevel), typeof(WaterLevelEvent));

            HandlerEventBus.Instance.Subscribe(textDisplay1, nameof(TextDisplay.DisplayTemperature), typeof(TemperatureEvent));
            HandlerEventBus.Instance.Subscribe(textDisplay1, nameof(TextDisplay.DisplayHumidity), typeof(HumidityEvent));
            

            SensorSimulation simulation = new SensorSimulation();

            Console.ReadLine();
        }
    }
}
