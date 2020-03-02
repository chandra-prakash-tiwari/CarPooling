using CarPooling.Models;
using System;
using System.Linq;

namespace CarPooling
{
    public class UserInput
    {
        public static User NewUser()
        {
            User user = new User();

            Console.Write(Constant.UserId);
            user.UserName = Helper.GetValidUserName();

            Console.Write(Constant.Password);
            user.Password = Helper.ValidString();

            Console.Write(Constant.Name);
            user.Name = Helper.ValidString();

            Console.Write(Constant.MobileNumber);
            user.Mobile = Helper.ValidString();

            Console.Write(Constant.Email);
            user.Email = Helper.GetValidEmail();

            Console.Write(Constant.Address);
            user.Address = Helper.ValidString();

            Console.Write(Constant.DrivingLicence);
            user.DrivingLicence = Console.ReadLine();

            return user;
        }

        public static Login GetCredential()
        {
            Login login = new Login();

            Console.Write(Constant.UserId);
            login.UserName = Helper.ValidString();

            Console.Write(Constant.Password);
            login.Password = Helper.ValidString();

            return login;
        }

        public static Ride GetRideDetail()
        {
            Ride ride = new Ride();

            Console.Write(Constant.TravellingDate);
            ride.TravelDate = Helper.ValidDate();

            Console.Write(Constant.From);
            string city = Helper.GetValidCity();
            ride.From = CitiesInfo.Cities.FirstOrDefault(a => a.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));
            ride.TotalDistance = 0;

            Console.Write(Constant.LandMark);
            ride.From.LandMark = Console.ReadLine();

            while (true)
            {
                Console.Write(Constant.To);
                city = Helper.GetValidCity();
                ride.To = CitiesInfo.Cities.FirstOrDefault(a => a.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));

                var fromCityIndex = ViaPointsInfo.Points.IndexOf(ViaPointsInfo.Points.FirstOrDefault(a => a.FromCity == ride.From.City));
                var toCityIndex = ViaPointsInfo.Points.IndexOf(ViaPointsInfo.Points.FirstOrDefault(a => a.ToCity == ride.To.City));
                int viaPointCount = toCityIndex - fromCityIndex + 1;
                if (viaPointCount > 0)
                {
                    for (int viaPoint = 0; viaPoint < viaPointCount; viaPoint++)
                    {
                        Point via = new Point();
                        via = ViaPointsInfo.Points[fromCityIndex + viaPoint];
                        ride.TotalDistance = ride.TotalDistance + via.Distance;
                        ride.ViaPoints.Add(via);
                    }
                        break;
                }
                else
                {
                    Console.WriteLine(Constant.InValidInput);
                }
            }

            Console.WriteLine(Constant.Distance + ride.TotalDistance);

            Console.Write(Constant.TravellingRate);
            ride.RatePerKM = Helper.GetValidFloat();

            return ride;
        }

        public static Car GetCarDetails()
        {
            Car car = new Car();

            Console.WriteLine(Constant.CarDetails);
            Console.Write(Constant.CarNumber);
            car.Number = Helper.ValidString();

            Console.Write(Constant.CarModel);
            car.Model = Helper.ValidString();

            Console.Write(Constant.CarMaxSeats);
            car.NoofSeat = Helper.ValidInteger();

            return car;
        }

        public static SearchRideRequest GetBooking()
        {
            SearchRideRequest booking = new SearchRideRequest();

            Console.Write(Constant.TravellingDate);
            booking.TravelDate = Helper.ValidDate();

            Console.Write(Constant.From);
            string city = Helper.GetValidCity();
            booking.From = CitiesInfo.Cities.FirstOrDefault(a => a.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));
            float TravellingDistance = 0;

            Console.Write(Constant.LandMark);
            booking.From.LandMark = Console.ReadLine();

            while (true)
            {
                Console.Write(Constant.To);
                city = Helper.GetValidCity();
                booking.To = CitiesInfo.Cities.FirstOrDefault(a => a.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));

                var fromCityIndex = ViaPointsInfo.Points.IndexOf(ViaPointsInfo.Points.FirstOrDefault(a => a.FromCity == booking.From.City));
                var toCityIndex = ViaPointsInfo.Points.IndexOf(ViaPointsInfo.Points.FirstOrDefault(a => a.ToCity == booking.To.City));
                int viaPointCount = toCityIndex - fromCityIndex + 1;
                if (viaPointCount > 0)
                {
                    for (int viaPoint = 0; viaPoint < viaPointCount; viaPoint++)
                    {
                        Point via = new Point();
                        via = ViaPointsInfo.Points[fromCityIndex + viaPoint];
                        TravellingDistance = TravellingDistance + via.Distance;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine(Constant.InValidInput);
                }
            }

            Console.WriteLine(Constant.Distance + TravellingDistance);
            Console.ReadKey();
            return booking;
        }

        public static ConfirmationResponse Confirmation()
        {
            Console.WriteLine(Constant.Confirmation);

            ConfirmationResponse option = (ConfirmationResponse)Helper.ValidInteger();

            switch (option)
            {
                case ConfirmationResponse.Yes:
                    return ConfirmationResponse.Yes;

                case ConfirmationResponse.No:
                    return ConfirmationResponse.No;

                default:
                    Console.WriteLine(Constant.InValidInput);
                    option = Confirmation();
                    return option;

            }
        }

        public static ConfirmationResponse Response()
        {
            Console.WriteLine(Constant.Confirmation);

            ConfirmationResponse option = (ConfirmationResponse)Helper.ValidInteger();

            switch (option)
            {
                case ConfirmationResponse.Yes:
                    return ConfirmationResponse.Yes;

                case ConfirmationResponse.No:
                    return ConfirmationResponse.No;

                default:
                    Console.WriteLine(Constant.InValidInput);
                    option = Confirmation();
                    return option;

            }
        }

        public static BookingStatus BookingChoice()
        {
            Console.WriteLine(Constant.RideResponseOptions);

            BookingStatus option = (BookingStatus)Helper.ValidInteger();

            switch (option)
            {
                case BookingStatus.Confirm:
                    return BookingStatus.Confirm;

                case BookingStatus.Rejected:
                    return BookingStatus.Rejected;

                case BookingStatus.Pending:
                    return BookingStatus.Pending;

                default:
                    Console.WriteLine(Constant.InValidInput);
                    option = BookingChoice();
                    return option;
            }
        }
    }
}
