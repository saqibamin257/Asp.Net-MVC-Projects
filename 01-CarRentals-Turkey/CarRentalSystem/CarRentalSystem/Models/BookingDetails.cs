using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalSystem.Models
{
    public class BookingDetails
    {
        public int id { get; set; }
        public string carName { get; set; }
        public string pickupLocation { get; set; }
        public string pickupTime { get; set; }
        public string dropLocation { get; set; }
        public string dropTime { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}