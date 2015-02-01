using System.Linq;
using System.Web.Mvc;
using Cars.Administration.Web.Models;
using Cars.Administration.Web.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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
            var carList = _carRepository.List().Select(Mapper.Map<CarViewModel>);
            return View(carList);
        }

       
    }
}