using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Filters;
using Cars.Administration.Web.Helpers;
using Cars.Administration.Web.Infrastructure;
using Cars.Administration.Web.Repository;

namespace Cars.Administration.Web.Controllers
{
    public class CarController: Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ILog _log;
        private readonly ICurrentUser _currentUser;

        public CarController(ICarRepository carRepository, ILog log, ICurrentUser currentUser)
        {
            _carRepository = carRepository;
            _log = log;
            _currentUser = currentUser;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, Log("Created car")]
        public ActionResult Create(string make, string rentalPricePerDay, string currency)
        {
            var user = _currentUser.User;
            var car = new Car
            {
                CarId = Guid.NewGuid(),
                Make = make,
                RentalPricePerDay = rentalPricePerDay.ToDecimal(),
                Currency = currency
            };
            _carRepository.Insert(car);

            throw new Exception();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet, Log("Deleted car {carId}")]
        public ActionResult Delete(string carId)
        {
            var id = Guid.Parse(carId);
            var car = _carRepository.Get(id);
            if (!car.IsNull())
                _carRepository.Delete(car);
            return RedirectToAction("Index", "Home");
        }
    }
}