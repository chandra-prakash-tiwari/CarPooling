using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Services
{
    public class RideService : IRideService
    {
        public BookingService BookingService { get; set; }

        public RideService(BookingService BookingService)
        {
            this.BookingService = BookingService;
        }

        public bool CreateRide(Ride ride)
        {
            ride.RideDate = DateTime.Now;
            ride.Id = Guid.NewGuid().ToString();
            ride.OwnerId = AppDataService.CurrentUser.Id;
            AppDataService.Rides.Add(ride);

            return true;
        }

        public List<Ride> GetRidesOffer(SearchRideRequest booking)
        {
            var from = ViaPointsInfo.Points?.FirstOrDefault(via => via.FromCity == booking.From.City);
            var to = ViaPointsInfo.Points?.FirstOrDefault(via => via.ToCity == booking.To.City);

            return AppDataService.Rides?.Where(ride => ride.TravelDate == booking.TravelDate &&
            ride.AvailableSeats > 0 && from.FromCity == booking.From.City && to.ToCity == booking.To.City).ToList();
        }

        public bool CancelRide(string rideId)
        {
            Ride ride = AppDataService.Rides.FirstOrDefault(a => a.Id == rideId);
            if (ride != null && this.BookingService.GetBookings(rideId).Any())
            {
                ride.Status = RideStatus.Cancel;
                return true;
            }

            return false;
        }

        public bool SeatBookingResponse(string rideId)
        {
            Ride ride = GetRide(rideId);
            if (ride.AvailableSeats > 0)
            {
                ride.AvailableSeats--;
                return true;
            }

            return false;
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
            return AppDataService.Rides?.FirstOrDefault(ride => ride.Id == id);
        }

        public List<Ride> GetRides(string ownerId)
        {
            return AppDataService.Rides?.Where(ride => ride.OwnerId == ownerId).ToList();
        }
    }
}
