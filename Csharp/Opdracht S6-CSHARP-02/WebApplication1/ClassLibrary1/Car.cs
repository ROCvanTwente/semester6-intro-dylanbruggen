using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Car : IVehicle
    {
        public int Speed { get; set; }
        public int Wheels { get; set; }
        public string Color { get; set; }

        public Car()
        {
            Wheels = 4;
            Speed = 0;
            Color = "Red";
        }

        public void IncreaseSpeed(int amount)
        {
            Speed += amount;
        }

        public void DecreaseSpeed(int amount)
        {
            Speed -= amount;
            if (Speed < 0) Speed = 0;
        }

        public string DisplaySpeed()
        {
            return $"De auto rijdt nu {Speed} km/u.";
        }
    }

}
