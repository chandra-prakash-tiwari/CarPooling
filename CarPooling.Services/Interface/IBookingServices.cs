using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Interfaces
{
    public interface IBookingService
    {
        bool CreateBooking(Booking booking, string rideId);

        bool CancelRideRequest(string id);

        List<Booking> BookingsStatus();

        bool BookingResponse(string id, BookingStatus status);

        string GetRequester(string id);

        List<Booking> GetUserBookings(string userId);

        List<Booking> GetBookings(string rideId);

        List<Booking> GetAllPendingReviewBookings(string rideId);
    }
}
