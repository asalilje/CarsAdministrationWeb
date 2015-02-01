using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Administration.Web.Repository;

namespace Cars.Administration.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public ActionResult Index()
        {
            var carList = _carRepository.List();
            return View(carList);
        }

       
    }
}