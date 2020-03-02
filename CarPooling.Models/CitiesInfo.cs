using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public static class CitiesInfo
    {
        public static List<Place> Cities { get; set; }

        static CitiesInfo()
        {
            Cities = new List<Place>()
            {
                new Place()
                {
                    City="HYD",
                    Pincode=12345
                },
                new Place()
                {
                    City="Bhilai",
                    Pincode=490023
                },
                new Place()
                {
                    City="Ranchi",
                    Pincode=834001
                },
                new Place()
                {
                    City="Delhi",
                    Pincode=000001
                },
                new Place()
                {
                    City="Gaya",
                    Pincode=12345
                },
                new Place()
                {
                    City="Bokaro",
                    Pincode=834001
                },
                new Place()
                {
                    City="Jamshedpur",
                    Pincode=000001
                },
                new Place()
                {
                    City="Ambikapur",
                    Pincode=12345
                },
                new Place()
                {
                    City="Bero",
                    Pincode=490023
                },
                new Place()
                {
                    City="Manendragarh",
                    Pincode=834001
                },
                new Place()
                {
                    City="Raipur",
                    Pincode=000001
                },
                new Place()
                {
                    City="Mumbai",
                    Pincode=490023
                }
            };
        }
    }

    public static class ViaPointsInfo
    {
        public static List<Point> Points { get; set; }

        static ViaPointsInfo()
        {
            Points = new List<Point>()
            {
                new Point()
                {
                    Id=Guid.NewGuid().ToString(),
                    FromCity="HYD",
                    ToCity="Bhilai",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Bhilai",
                    ToCity="Delhi",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Ranchi",
                    ToCity="Delhi",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Delhi",
                    ToCity="Gaya",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Gaya",
                    ToCity="Bokaro",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Bokaro",
                    ToCity="Jamshedpur",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Jamshedpur",
                    ToCity="Ambikapur",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Ambikapur",
                    ToCity="Bero",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Bero",
                    ToCity="Manendragarh",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Manendragarh",
                    ToCity="Raipur",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Raipur",
                    ToCity="Mumbai",
                    Distance=400
                },
                new Point()
                {
                    Id =Guid.NewGuid().ToString(),
                    FromCity="Mumbai",
                    ToCity="Ranchi",
                    Distance=400
                }
            };
        }
    }
}
