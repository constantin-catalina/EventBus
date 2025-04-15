using SimpleEventBus;

namespace assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericDisplay numericDisplay1 = new NumericDisplay("ND1");
            NumericDisplay numericDisplay2 = new NumericDisplay("ND2");

            MaxValueDisplay maxValueDisplay1 = new MaxValueDisplay("MVD1");

            TextDisplay textDisplay1 = new TextDisplay("TD1");

            BasicEventBus.Instance.Subscribe(typeof(TemperatureEvent), numericDisplay1);
            BasicEventBus.Instance.Subscribe(typeof(HumidityEvent), numericDisplay1);
            BasicEventBus.Instance.Subscribe(typeof(WaterLevelEvent), numericDisplay1);

            BasicEventBus.Instance.Subscribe(typeof(TemperatureEvent), numericDisplay2);

            BasicEventBus.Instance.Subscribe(typeof(HumidityEvent), maxValueDisplay1);
            BasicEventBus.Instance.Subscribe(typeof(TemperatureEvent), maxValueDisplay1);
            BasicEventBus.Instance.Subscribe(typeof(WaterLevelEvent), maxValueDisplay1);

            BasicEventBus.Instance.Subscribe(typeof(TemperatureEvent), textDisplay1);
            BasicEventBus.Instance.Subscribe(typeof(HumidityEvent), textDisplay1);

            SensorSimulation simulation = new SensorSimulation();

            Console.ReadLine();
        }
    }
}