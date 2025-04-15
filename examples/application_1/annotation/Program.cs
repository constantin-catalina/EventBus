using System;
using AnnotationsEventBus;
using assignment_2_1_3;

namespace assignment_2_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericDisplay numericDisplay1 = new NumericDisplay("ND1");
            NumericDisplay numericDisplay2 = new NumericDisplay("ND2");

            MaxValueDisplay maxValueDisplay1 = new MaxValueDisplay("MVD1");

            TextDisplay textDisplay1 = new TextDisplay("TD1");

            HandlerEventBus.Instance.Subscribe<TemperatureEvent>(numericDisplay1);
            HandlerEventBus.Instance.Subscribe<HumidityEvent>(numericDisplay1);
            HandlerEventBus.Instance.Subscribe<WaterLevelEvent>(numericDisplay1);

            HandlerEventBus.Instance.Subscribe<TemperatureEvent>(numericDisplay2);

            HandlerEventBus.Instance.Subscribe<TemperatureEvent>(maxValueDisplay1);
            HandlerEventBus.Instance.Subscribe<HumidityEvent>(maxValueDisplay1);
            HandlerEventBus.Instance.Subscribe<WaterLevelEvent>(maxValueDisplay1);

            HandlerEventBus.Instance.Subscribe<TemperatureEvent>(textDisplay1);
            HandlerEventBus.Instance.Subscribe<HumidityEvent>(textDisplay1);

            SensorSimulation simulation = new SensorSimulation();
            Console.ReadLine();
        }
    }
}