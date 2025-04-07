using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IVehicle
    {
        int Speed { get; set; }
        int Wheels { get; set; }
        string Color { get; set; }

        void IncreaseSpeed(int amount);
        void DecreaseSpeed(int amount);
        string DisplaySpeed();
    }

}
