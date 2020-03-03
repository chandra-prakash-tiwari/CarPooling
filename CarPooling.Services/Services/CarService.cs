
using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Services
{
    public class CarService : ICarService
    {
        public bool AddNewCar(Car car)
        {
            car.Id = Guid.NewGuid().ToString();
            car.OwnerId = AppDataService.CurrentUser.Id;
            AppDataService.Cars.Add(car);
            return true;
        }

        public List<Car> GetCars(string ownerId)
        {
            return AppDataService.Cars.Where(car => car.OwnerId == ownerId).ToList();
        }

        public Car GetRideCar(string carId)
        {
            return AppDataService.Cars.FirstOrDefault(a=>a.Id==carId);
        }
    }
}
