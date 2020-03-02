using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Car
    {
        public string Id { get; set; }

        public string Number { get; set; }

        public string Model { get; set; }

        public int NoofSeat { get; set; }

        public string OwnerId { get; set; }
    }
}
