using System;
using System.Web.Mvc;
using AutoMapper;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Filters;
using Cars.Administration.Web.Helpers;
using Cars.Administration.Web.Infrastructure;
using Cars.Administration.Web.Infrastructure.Alerts;
using Cars.Administration.Web.Models.FormModels;
using Cars.Administration.Web.Repository;

namespace Cars.Administration.Web.Controllers
{
	public class CarController : CarAdministrationController
	{
		private readonly ICarRepository _carRepository;

		public CarController(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		[HttpGet]
		public ActionResult Create()
		{
			var form = new CreateCarForm();
			return View(form);
		}

		[HttpPost, ValidateAntiForgeryToken, Log("Created car")]
		public ActionResult Create(CreateCarForm form)
		{
			if (!ModelState.IsValid)
				return View(form);

			var car = Mapper.Map<Car>(form);
			_carRepository.Insert(car);

			return RedirectToAction<HomeController>(c => c.Index()).WithSuccess("Car created!");
		}

		[HttpGet, Log("Deleted car {carId}")]
		public ActionResult Delete(string carId)
		{
			var id = Guid.Parse(carId);
			var car = _carRepository.Get(id);
			if (!car.IsNull())
				_carRepository.Delete(car);

			return this.RedirectToAction<HomeController>(c => c.Index()).WithSuccess("Car deleted!");
		}
	}
}