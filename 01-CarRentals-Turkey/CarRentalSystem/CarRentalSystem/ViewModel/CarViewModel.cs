using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalSystem.ViewModel
{
    public class CarViewModel
    {
        public List<Car> GetCars()
        {            
            CarRentalEntities context = new CarRentalEntities();

            var data = from t in context.Cars
                       where t.isBooked == false
                       select t;
            
            List<Car> CarList = new List<Car>();
            foreach (var x in data)
            {
                Car objCar = new Car();
                objCar.id = x.id;
                objCar.carName = x.carName;                
                CarList.Add(objCar);
            }
            return CarList;
        }

        public string AddBooking(string carName, string pickUpLocation, string dropLocation, string pickupTime, string dropTime, string name, string email, string phone)
        {
            using (CarRentalEntities entities = new CarRentalEntities())
            {
                string car = entities.fn_AddBookingDetail(carName, pickUpLocation, pickupTime, dropLocation, dropTime, name, email, phone).Single();               
                return car;
            }
        }
    }
}