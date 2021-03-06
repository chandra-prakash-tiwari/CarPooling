﻿using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPooling.Services.Services
{
    public class AppDataService
    {
        public static List<User> Users { get; set; }

        public static List<Booking> Bookings { get; set; }

        public static List<Ride> Rides { get; set; }

        public static List<Car> Cars { get; set; }

        public static User CurrentUser { get; set; }

        static AppDataService()
        {
            Users = new List<User>();

            Bookings = new List<Booking>();

            Rides = new List<Ride>();

            Cars = new List<Car>();

            CurrentUser = new User();
        }  
    }
}
