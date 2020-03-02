using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Place
    {
        public string LandMark { get; set; }

        public string City { get; set; }

        public int Pincode { get; set; }
    }

    public class Point 
    {
        public string Id { get; set; }

        public string FromCity { get; set; }

        public string ToCity { get; set; }

        public float Distance { get; set; }
    }
}
