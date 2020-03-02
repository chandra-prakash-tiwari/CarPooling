using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Ride
    {
        public string Id { get; set; }

        public Place From { get; set; }

        public Place To { get; set; }

        public float TotalDistance { get; set; }

        public DateTime TravelDate { get; set; }

        public int AvailableSeats { get; set; }

        public DateTime RideDate { get; set; }

        public float RatePerKM { get; set; }

        public List<Point> ViaPoints { get; set; }

        public string OwnerId { get; set; }

        public string CarId { get; set; }

        public RideStatus status { get; set; }

        public Ride()
        {
            ViaPoints = new List<Point>();
        }
    }
}
