using CarPooling.Models;
using CarPooling.Services.Services;
using System;
using System.Linq;

namespace CarPooling
{
    public class Display
    {
        public static void OfferRide(Ride ride)
        {
            Console.WriteLine(Constant.TravellingDate + ride.RideDate);
            Console.WriteLine(Constant.AvailableSeats + ride.AvailableSeats);
            Console.WriteLine(Constant.From + ride.From.City);
            Console.WriteLine(Constant.Pincode + ride.To.Pincode);
            Console.WriteLine(Constant.LandMark + ride.From.LandMark);
            Console.WriteLine(Constant.ViaPoint + ride.ViaPoints.Count);
            foreach (var viaPoint in ride.ViaPoints)
            {
                Console.WriteLine($"{viaPoint.FromCity} to {viaPoint.ToCity} : {viaPoint.Distance}");
            }

            Console.WriteLine(Constant.From + ride.To.City + Constant.Distance + ride.TotalDistance);
            Console.WriteLine(Constant.TravellingRate + ride.RatePerKM);
            CarDetail(ride.CarId);

        }

        public static void CarDetail(string carId)
        {
            var car = AppDataService.Cars.FirstOrDefault(a => a.Id == carId);
            Console.WriteLine(Constant.CarDetails);
            Console.WriteLine(Constant.CarNumber + car.Number);
            Console.WriteLine(Constant.CarModel + car.Model);
            Console.WriteLine(Constant.CarMaxSeats + car.NoofSeat);
        }

        public static void BookingRequest(Booking booking)
        {
            Console.WriteLine(Constant.From + booking.From.City);
            Console.WriteLine(Constant.LandMark + booking.From.LandMark);
            Console.WriteLine(Constant.Pincode + booking.From.Pincode);
            Console.WriteLine(Constant.To + booking.To.City);
            Console.WriteLine(Constant.LandMark + booking.To.LandMark);
            Console.WriteLine(Constant.Pincode + booking.To.Pincode);
            Console.WriteLine(Constant.TravellingDate + booking.TravelDate);
        }
    }
}
