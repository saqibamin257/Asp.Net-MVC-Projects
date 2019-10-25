using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            CarRentalEntities entities = new CarRentalEntities();
            List<BookingDetail> objbooking = entities.BookingDetails.ToList();

            //Add a Dummy Row.
            objbooking.Insert(0, new BookingDetail());
            return View(objbooking);
        }

        [HttpPost]
        public ActionResult DeleteBooking(int id)
        {
            using (CarRentalEntities entities = new CarRentalEntities())
            {
                //delete record from BookingDetail table

                BookingDetail booking = (from c in entities.BookingDetails
                                     where c.id == id
                                     select c).FirstOrDefault();
                string carName = booking.carName;
                entities.BookingDetails.Remove(booking);

                
                //update isbooked status of table cars to false

                var carData = (from t in entities.Cars
                           where t.carName == carName
                           select t).First();

                carData.isBooked = false;

                //save changes to EF

                entities.SaveChanges();
            }
            return new EmptyResult();
        }



    }
}