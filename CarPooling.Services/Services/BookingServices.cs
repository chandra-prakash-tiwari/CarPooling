using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPooling.Services.Services
{
    public class BookingServices : IBookingServices
    {
        public User CurrentUser { get; set; }

        public BookingServices(string id)
        {
            this.CurrentUser = AppDataServices.Users.FirstOrDefault(a => a.Id == id);
        }

        public bool CreateBooking(Booking booking, string rideId)
        {
            booking.Id = Guid.NewGuid().ToString();
            booking.RideId = rideId;
            booking.RequestorId = this.CurrentUser.Id;
            booking.Status = BookingStatus.Pending;
            AppDataServices.Bookings.Add(booking);
            return true;
        }

        public bool CancelRideRequest(string id)
        {
            Booking booking = AppDataServices.Bookings?.FirstOrDefault(a => a.Id == id);
            if (booking != null && booking.Status == BookingStatus.Pending)
            {
                booking.Status = BookingStatus.Cancel;
                return true;
            }

            return false;
        }

        public List<Booking> BookingsStatus()
        {
            return AppDataServices.Bookings?.Where(a => a.RequestorId == this.CurrentUser.Id && a.Status != BookingStatus.Completed).Select(a => a).ToList();
        }

        public bool BookingResponse(string id,BookingStatus status)
        {
            Booking bookingResponse = AppDataServices.Bookings?.FirstOrDefault(booking => booking.Id == id);
            if (bookingResponse == null)
                return false;

            switch (status)
            {
                case BookingStatus.Confirm:
                    bookingResponse.Status = BookingStatus.Confirm;
                    return true;

                case BookingStatus.Rejected:
                    bookingResponse.Status = BookingStatus.Rejected;
                    return true;

                default:
                    bookingResponse.Status = BookingStatus.Pending;
                    return true;
            }
        }

        public string GetRequester(string id)
        {
            return AppDataServices.Bookings?.FirstOrDefault(a => a.Id == id).RideId;
        }

        public List<Booking> GetUserBookings(string userId)
        {
            return AppDataServices.Bookings?.Where(booking => booking.RequestorId == userId).ToList();
        }

        public List<Booking> GetBookings(string rideId)
        {
            return AppDataServices.Bookings?.Where(booking => booking.RideId == rideId).ToList();
        }

        public List<Booking> GetAllPendingReviewBookings(string rideId)
        {
            return AppDataServices.Bookings?.Where(booking => booking.Status == BookingStatus.Pending && booking.RideId == rideId).ToList();
        }
    }
}
