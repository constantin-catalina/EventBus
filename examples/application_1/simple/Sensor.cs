using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2
{
    public abstract class Sensor
    {
        public string ID { get; set; }
        public string location { get; set; }
        public float precision { get; set; }
        protected Random random;
        protected Sensor(string id, string location, float precision) { 
            this.ID = id;
            this.location = location;
            this.precision = precision;
            random = new Random();
        }
        public abstract void GenerateData();
    }
}
