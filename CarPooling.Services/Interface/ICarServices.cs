using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Interfaces
{
    public interface ICarService
    {
        bool AddNewCar(Car car);

        List<Car> GetCars(string ownerId);

        Car GetRideCar(string carId);
    }
}
