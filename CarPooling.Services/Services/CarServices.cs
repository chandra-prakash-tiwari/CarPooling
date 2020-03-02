
using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Services
{
    public class CarServices : ICarServices
    {
        public User CurrentUser { get; set; }

        public CarServices(string id)
        {
            this.CurrentUser = AppDataServices.Users.FirstOrDefault(a => a.Id == id);
        }

        public bool AddNewCar(Car car)
        {
            car.Id = Guid.NewGuid().ToString();
            car.OwnerId = this.CurrentUser.Id;
            AppDataServices.Cars.Add(car);
            return true;
        }

        public bool RemoveCar(string id)
        {
            Car car = AppDataServices.Cars.FirstOrDefault(a => a.Id == id);
            AppDataServices.Cars.Remove(car);
            return true;
        }

        public List<Car> GetCar(string ownerId)
        {
            return AppDataServices.Cars.Where(car => car.OwnerId == ownerId).ToList();
        }

        public Car GetRideCar(string carId)
        {
            return AppDataServices.Cars.FirstOrDefault(a=>a.Id==carId);
        }
    }
}
