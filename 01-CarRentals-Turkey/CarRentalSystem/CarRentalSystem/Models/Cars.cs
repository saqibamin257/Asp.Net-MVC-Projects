using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalSystem.Models
{
    public class Cars
    {
        public int id { get; set; }
        public string carName { get; set; }
        public bool isBooked { get; set; }

    }
}