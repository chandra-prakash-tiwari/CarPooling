using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Services
{
    public class RideServices : IRideServices
    {
        public User CurrentUser { get; set; }

        public BookingServices BookingServices { get; set; }

        public RideServices(string id, BookingServices bookingServices)
        {
            this.CurrentUser = AppDataServices.Users.FirstOrDefault(a => a.Id == id);

            this.BookingServices = bookingServices;
        }

        public bool CreateRide(Ride ride)
        {
            ride.RideDate = DateTime.Now;
            ride.Id = Guid.NewGuid().ToString();
            ride.OwnerId = this.CurrentUser.Id;
            AppDataServices.Rides.Add(ride);

            return true;
        }

        public List<Ride> GetRidesOffer(SearchRideRequest booking)
        {
            var fromCityId = ViaPointsInfo.Points?.FirstOrDefault(via => via.FromCity == booking.From.City);
            var toCityId = ViaPointsInfo.Points?.FirstOrDefault(via => via.ToCity == booking.To.City);

            return AppDataServices.Rides?.Where(ride => ride.TravelDate == booking.TravelDate &&
            ride.AvailableSeats > 0 && fromCityId.FromCity == booking.From.City && toCityId.ToCity == booking.To.City).ToList();
        }

        public bool CancelRide(string rideId)
        {
            Ride ride = AppDataServices.Rides.FirstOrDefault(a => a.Id == rideId);

            if (ride != null && this.BookingServices.GetBookings(rideId).Any())
            {
                ride.status = RideStatus.Cancel;
                return true;
            }

            return false;
        }

        public bool SeatBookingResponse(string bookingId, BookingStatus status)
        {
            Ride ride = GetRide(this.BookingServices.GetRequester(bookingId));

            if (ride.AvailableSeats > 0 && status == BookingStatus.Confirm)
            {
                this.BookingServices.BookingResponse(bookingId, status);
                ride.AvailableSeats--;
                return true;
            }
            else
            {
                this.BookingServices.BookingResponse(bookingId, BookingStatus.Rejected);
                return false;
            }
        }

        public bool ModifyRide(Ride newRide, string id)
        {
            Ride oldRide = this.GetRide(id);

            if (oldRide != null)
            {
                oldRide.RideDate = newRide.RideDate;
                oldRide.From = newRide.From;
                oldRide.CarId = newRide.CarId;
                oldRide.To = newRide.To;

            }

            return true;
        }

        public Ride GetRide(string id)
        {
            return AppDataServices.Rides?.FirstOrDefault(ride => ride.Id == id);
        }

        public List<Ride> GetRides(string ownerId)
        {
            return AppDataServices.Rides?.Where(ride => ride.OwnerId == ownerId).ToList();
        }
    }
}
