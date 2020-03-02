using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Interfaces
{
    public interface ICarServices
    {
        bool AddNewCar(Car car);

        bool RemoveCar(string id);

        List<Car> GetCar(string ownerId);

        Car GetRideCar(string carId);
    }
}
