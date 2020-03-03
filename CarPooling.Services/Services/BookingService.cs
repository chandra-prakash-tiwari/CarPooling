using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPooling.Services.Services
{
    public class BookingService : IBookingService
    {

        public bool CreateBooking(Booking booking, string rideId)
        {
            booking.Id = Guid.NewGuid().ToString();
            booking.RideId = rideId;
            booking.RequestorId = AppDataService.CurrentUser.Id;
            booking.Status = BookingStatus.Pending;
            AppDataService.Bookings.Add(booking);
            return true;
        }

        public bool CancelRideRequest(string id)
        {
            Booking booking = AppDataService.Bookings?.FirstOrDefault(a => a.Id == id);
            if (booking != null && booking.Status == BookingStatus.Pending)
            {
                booking.Status = BookingStatus.Cancel;
                return true;
            }

            return false;
        }

        public List<Booking> BookingsStatus()
        {
            return AppDataService.Bookings?.Where(a => a.RequestorId == AppDataService.CurrentUser.Id && a.Status != BookingStatus.Completed).ToList();
        }

        public bool BookingResponse(string id, BookingStatus status)
        {
            Booking bookingResponse = AppDataService.Bookings?.FirstOrDefault(booking => booking.Id == id);
            if (bookingResponse == null)
            {
                return false;
            }

            bookingResponse.Status = status;

            return true;
        }

        public string GetRequester(string id)
        {
            return AppDataService.Bookings?.FirstOrDefault(a => a.Id == id).RideId;
        }

        public List<Booking> GetUserBookings(string userId)
        {
            return AppDataService.Bookings?.Where(booking => booking.RequestorId == userId).ToList();
        }

        public List<Booking> GetBookings(string rideId)
        {
            return AppDataService.Bookings?.Where(booking => booking.RideId == rideId).ToList();
        }

        public List<Booking> GetAllPendingReviewBookings(string rideId)
        {
            return AppDataService.Bookings?.Where(booking => booking.Status == BookingStatus.Pending && booking.RideId == rideId).ToList();
        }
    }
}
