using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Interfaces
{
    public interface IRideService
    {
        bool CreateRide(Ride ride);

        List<Ride> GetRidesOffer(SearchRideRequest booking);

        bool CancelRide(string rideId);

        bool SeatBookingResponse(string bookingId, BookingStatus status);

        bool ModifyRide(Ride newRide, string id);

        Ride GetRide(string id);

        List<Ride> GetRides(string ownerId);
    }
}
