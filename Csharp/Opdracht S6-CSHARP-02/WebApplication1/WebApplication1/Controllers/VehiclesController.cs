using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicle _car;
        private readonly IVehicle _bicycle;
        public VehiclesController()
        {
            _car = new Car();        // Maak een nieuwe auto
            _bicycle = new Bicycle(); // Maak een nieuwe fiets
        }

        public IActionResult Index()
        {
            // Voorbeeld: we geven de objecten door aan de View
            var vehicles = new List<IVehicle> { _car, _bicycle };
            return View(vehicles);
        }

        [HttpPost]
        public IActionResult IncreaseSpeed(string vehicleType)
        {
            // Eenvoudige manier om de juiste vehicle te vinden
            if (vehicleType == "Car")
            {
                _car.IncreaseSpeed(10);
            }
            else if (vehicleType == "Bicycle")
            {
                _bicycle.IncreaseSpeed(5);
            }
            var vehicles = new List<IVehicle> { _car, _bicycle };
            return View("Index", vehicles);
        }

        [HttpPost]
        public IActionResult DecreaseSpeed(string vehicleType)
        {
            if (vehicleType == "Car")
            {
                _car.DecreaseSpeed(10);
            }
            else if (vehicleType == "Bicycle")
            {
                _bicycle.DecreaseSpeed(5);
            }
            var vehicles = new List<IVehicle> { _car, _bicycle };
            return View("Index", vehicles);
        }
    }
}
