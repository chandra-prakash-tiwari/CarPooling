using CarPooling.Models;
using CarPooling.Services;
using CarPooling.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Write(Constant.MainMenuOptions);
            MainMenu option = (MainMenu)Helper.ValidInteger();
            UserServices userServices = new UserServices();
            switch (option)
            {
                case Models.MainMenu.Login:
                    try
                    {
                        User user = userServices.Authentication(UserInput.GetCredential());
                        if (user != null)
                        {
                            Menu menu = new Menu(user.Id);
                            menu.UserMainMenu();
                        }
                        else
                        {
                            Console.WriteLine(Constant.InvalidCredentials);
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine(Constant.ErrorFound);
                    }
                    MainMenu();

                    break;

                case Models.MainMenu.Signup:
                    userServices.AddNewUser(UserInput.NewUser());
                    MainMenu();

                    break;

                case Models.MainMenu.Exit:
                    Environment.Exit(0);

                    break;
            }
        }
    }

    public class Menu
    {
        public BookingServices BookingServices { get; set; }

        public CarServices CarServices { get; set; }

        public RideServices RideServices { get; set; }

        public string Id { get; set; }

        public Menu(string Id)
        {
            this.Id = Id;

            this.BookingServices = new BookingServices(this.Id);

            this.CarServices = new CarServices(this.Id);

            this.RideServices = new RideServices(this.Id, this.BookingServices);
        }

        public void UserMainMenu()
        {
            Console.Write(Constant.UserMainMenuOptions);
            HomeMenu option = (HomeMenu)Helper.ValidInteger();
            var user = AppDataServices.Users.FirstOrDefault(a => a.Id == this.Id);
            if (user != null)
            {
                switch (option)
                {
                    case HomeMenu.CreateRide:
                        List<Car> cars = this.CarServices.GetCar(this.Id);
                        if (cars != null && cars.Any())
                        {
                            foreach (var car in cars)
                            {
                                Console.Write((cars.IndexOf(car) + 1) + ". " + car.Model + " " + car.Number + "\n");
                            }
                            Console.WriteLine(Constant.CarSelection);
                            while (true)
                            {
                                int choice = Helper.ValidInteger();
                                if (choice <= cars.Count && choice != 0)
                                {
                                    Ride ride = UserInput.GetRideDetail();
                                    ride.CarId = cars[choice - 1].Id;

                                    Car carRecord = AppDataServices.Cars.FirstOrDefault(a => a.Id == ride.CarId);
                                    while (true)
                                    {
                                        Console.Write(Constant.AvailableSeats);
                                        ride.AvailableSeats = Helper.ValidInteger();
                                        if (carRecord.NoofSeat >= ride.AvailableSeats)
                                            break;
                                        else
                                            Console.WriteLine(Constant.InvalidAvailableSeats);
                                    }
                                    this.RideServices.CreateRide(ride);
                                    break;
                                }
                                else if (choice == 0)
                                    break;
                                else
                                    Console.WriteLine(Constant.InValidInput);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Constant.NoCarsAdded);
                            if (this.CarServices.AddNewCar(UserInput.GetCarDetails()))
                                Console.WriteLine(Constant.AllowRide);
                        }
                        Console.ReadLine();
                        UserMainMenu();

                        break;

                    case HomeMenu.BookARide:
                        SearchRideRequest bookingRequest = UserInput.GetBooking();
                        List<Ride> rides = this.RideServices.GetRidesOffer(bookingRequest);
                        if (rides != null && rides.Count > 0)
                        {
                            foreach (var ride in rides)
                            {
                                Console.Write(rides.IndexOf(ride) + 1);
                                Display.OfferRide(ride);
                            }
                            Console.WriteLine(Constant.RideSelection);

                            while (true)
                            {
                                int choice = Helper.ValidInteger();
                                if (choice <= rides.Count && choice != 0)
                                {
                                    Booking booking = new Booking();
                                    booking.From = bookingRequest.From;
                                    booking.To = bookingRequest.To;
                                    booking.TravelDate = bookingRequest.TravelDate;
                                    if (this.BookingServices.CreateBooking(booking, rides[choice - 1].Id))
                                        Console.WriteLine(Constant.RequestSentToOwner);
                                    else
                                        Console.WriteLine(Constant.InvalidBookingRequest);

                                    break;
                                }
                                else if (choice == 0)
                                {
                                    Console.WriteLine("Ok select another time");
                                    break;
                                }
                                else
                                    Console.WriteLine(Constant.CorrectSelection);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Constant.NoRequests);
                        }

                        Console.ReadKey();
                        UserMainMenu();

                        break;

                    case HomeMenu.ViewStatus:
                        BookingStatus();
                        UserMainMenu();

                        break;

                    case HomeMenu.AddNewCar:
                        if (this.CarServices.AddNewCar(UserInput.GetCarDetails()))
                            Console.Write("Car added");
                        else
                            Console.WriteLine("Sorry car not added right now");

                        UserMainMenu();

                        break;

                    case HomeMenu.ModifyRide:
                        rides = AppDataServices.Rides.Where(a => a.OwnerId == this.Id).Select(a => a).ToList();
                        foreach (var ride in rides)
                        {
                            Console.Write(rides.IndexOf(ride));
                            Display.OfferRide(ride);
                        }
                        Console.Write("Select ride offer or for exit press 0");

                        while (true)
                        {
                            int choice = Helper.ValidInteger();
                            if (choice <= rides.Count && choice != 0)
                            {
                                Display.OfferRide(rides[choice - 1]);
                                Ride newRide = UserInput.GetRideDetail();
                                if (UserInput.Confirmation() == ConfirmationResponse.Yes && this.BookingServices.GetBookings(this.Id).Count == 0)
                                {
                                    this.RideServices.ModifyRide(newRide, rides[choice - 1].Id);
                                    break;
                                }
                            }
                            else if (choice == 0)
                                break;
                        }

                        break;

                    case HomeMenu.DeleteRide:
                        rides = AppDataServices.Rides.Where(a => a.OwnerId == this.Id).Select(a => a).ToList();
                        foreach (var ride in rides)
                        {
                            Console.Write(rides.IndexOf(ride) + 1);
                            Display.OfferRide(ride);
                        }
                        while (true)
                        {
                            int choice = Helper.ValidInteger();
                            Display.OfferRide(rides[choice - 1]);
                            if (choice <= rides.Count && choice != 0)
                            {
                                Console.WriteLine(Constant.Confirmation);
                                if (UserInput.Confirmation() == ConfirmationResponse.Yes)
                                {
                                    this.RideServices.CancelRide(rides[choice - 1].Id);
                                }
                            }
                            else if (choice == 0)
                                break;
                        }
                        Console.ReadKey();
                        UserMainMenu();

                        break;

                    case HomeMenu.UpdateAccountDetail:
                        UpdateMenu();

                        break;

                    case HomeMenu.DeleteUserAccount:
                        //Console.WriteLine(Constant.Confirmation);
                        //if (UserInput.Confirmation() == ConfirmationResponse.Yes)
                        //{
                        //    if (this.User.DeleteUser(this.Id))
                        //    {
                        //        Console.WriteLine(Constant.DeleteAccoutResponse);
                        //    }
                        //}

                        break;

                    case HomeMenu.SignOut:
                        Program.MainMenu();

                        break;

                    case HomeMenu.Exit:
                        Environment.Exit(0);

                        break;
                }

            }
        }

        public void UpdateMenu()
        {
            Console.WriteLine(Constant.UpdateUserDetailOptions);
            User user = AppDataServices.Users?.FirstOrDefault(a => a.Id == this.Id);
            UpdateUserDetailMenu op = (UpdateUserDetailMenu)Helper.ValidInteger();
            switch (op)
            {
                case UpdateUserDetailMenu.Name:
                    user.Name = Console.ReadLine();
                    break;

                case UpdateUserDetailMenu.Mobile:
                    user.Mobile = Console.ReadLine();
                    break;

                case UpdateUserDetailMenu.Email:
                    user.Email = Helper.GetValidEmail();
                    break;

                case UpdateUserDetailMenu.Address:
                    user.Address = Console.ReadLine();
                    break;

                case UpdateUserDetailMenu.DrivingLicence:
                    user.DrivingLicence = Console.ReadLine();
                    break;

                case UpdateUserDetailMenu.Signout:
                    Program.MainMenu();
                    break;

                case UpdateUserDetailMenu.Exit:
                    Environment.Exit(0);
                    break;
            }
        }

        public void BookingStatus()
        {
            Console.Write(Constant.RequestStatusOptions);
            BookingStatusMenu statusOption = (BookingStatusMenu)Helper.ValidInteger();
            switch (statusOption)
            {
                case BookingStatusMenu.RideOffer:

                    List<Ride> rides = this.RideServices.GetRides(this.Id);
                    foreach (var ride in rides)
                    {
                        var pendingBookings = this.BookingServices.GetAllPendingReviewBookings(ride.Id);

                        foreach (var pendingBooking in pendingBookings)
                        {
                            Display.BookingRequest(AppDataServices.Bookings.FirstOrDefault(a => a.Id == pendingBooking.Id));
                        }
                    }

                    foreach (var ride in rides)
                    {
                        var pendingBookings = this.BookingServices.GetAllPendingReviewBookings(ride.Id);

                        foreach (var pendingBooking in pendingBookings)
                        {

                            Display.BookingRequest(AppDataServices.Bookings.FirstOrDefault(a => a.Id == pendingBooking.Id));
                            this.RideServices.SeatBookingResponse(pendingBooking.Id, UserInput.BookingChoice());
                        }
                    }
                    if (rides.Count < 1)
                    {
                        Console.WriteLine(Constant.NoRequests);
                    }

                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case BookingStatusMenu.RideRequest:
                    List<Booking> bookings = this.BookingServices.GetUserBookings(this.Id);

                    foreach (var offer in bookings)
                    {
                        Console.Write(bookings.IndexOf(offer) + 1);
                        Display.BookingRequest(offer);
                    }
                    Console.Write("Select any of the booking or for exit press 0");

                    while (true)
                    {
                        int choice = Helper.ValidInteger();
                        if (choice <= bookings.Count && choice != 0)
                        {
                            switch (bookings[choice - 1].Status)
                            {
                                case Models.BookingStatus.Confirm:
                                    Console.WriteLine(Constant.ConfirmedBooking);

                                    break;

                                case Models.BookingStatus.Rejected:
                                    Console.WriteLine(Constant.RejectedBooking);

                                    break;

                                case Models.BookingStatus.Pending:
                                    Console.WriteLine(Constant.WaitingBooking);

                                    break;
                            }
                            break;
                        }
                        else if (choice == 0)
                            break;
                    }

                    if (bookings.Count < 1)
                    {
                        Console.Write(Constant.NoRideOfferCreated);
                    }

                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case BookingStatusMenu.RiderDetail:
                    rides = AppDataServices.Rides.Where(a => a.OwnerId == this.Id).Select(a => a).ToList();
                    foreach (var ride in rides)
                    {
                        int travellerCount = this.BookingServices.GetBookings(ride.Id).Count;
                        Console.WriteLine(Constant.NoOfBookedSeats + travellerCount);
                        Display.OfferRide(ride);
                    }
                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case BookingStatusMenu.SignOut:
                    Program.MainMenu();

                    break;

                case BookingStatusMenu.Exit:
                    Environment.Exit(0);

                    break;
            }
        }
    }
}
