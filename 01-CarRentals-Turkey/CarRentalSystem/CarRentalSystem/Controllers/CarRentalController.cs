using CarRentalSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalSystem.Controllers
{
    public class CarRentalController : Controller
    {
        // GET: CarRental
        public ActionResult Index()
        {
            //Load Index View with data
            List<Car> objCar = new List<Car>();
            CarViewModel objCarView = new CarViewModel();

            objCar = objCarView.GetCars();

            List<SelectListItem> ddlCarList = new List<SelectListItem>();
            foreach (var x in objCar)
            {
                ddlCarList.Add(new SelectListItem { Value = x.id.ToString(), Text = x.carName.ToString() });
            }            
            ViewData["CarNames"] = (IEnumerable<SelectListItem>)ddlCarList;
            return View();
        }

        [HttpPost]
        public ActionResult AddBooking(string ddlPickUpLocation, string ddlDropLocation, string pickupdatepicker, string dropdatepicker, string name, string email, string phone)
        {
            
            string carName = Request.Form["ddlCar"].ToString();
            
            //save booking to database using entity framework
            CarViewModel objCarView = new CarViewModel();
            string car = objCarView.AddBooking(carName, ddlPickUpLocation, ddlDropLocation, pickupdatepicker, dropdatepicker, name, email, phone);

           
            //Load Index View with data

            List<Car> objCar = new List<Car>();
            objCar = objCarView.GetCars();
            List<SelectListItem> ddlCarList = new List<SelectListItem>();
            foreach (var x in objCar)
            {
                ddlCarList.Add(new SelectListItem { Value = x.id.ToString(), Text = x.carName.ToString() });
            }
            ViewData["CarNames"] = (IEnumerable<SelectListItem>)ddlCarList;

            return View();
        }
    }
}