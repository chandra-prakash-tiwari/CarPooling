using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Booking
    {
        public string Id { get; set; }

        public string RideId { get; set; }

        public string RequestorId { get; set; }

        public Place From { get; set; }

        public Place To { get; set; }

        public BookingStatus Status { get; set; }

        public float TravellingDistance { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime TravelDate { get; set; }
    }

    public class SearchRideRequest
    {
        public Place From { get; set; }

        public Place To { get; set; }

        public DateTime TravelDate { get; set; }
    }
}
