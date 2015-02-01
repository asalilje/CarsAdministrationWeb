using System;
using System.Collections.Generic;
using System.Linq;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Helpers;
using Microsoft.Ajax.Utilities;

namespace Cars.Administration.Web.Repository
{
    public class CarRepository : ICarRepository
    {

        private readonly IList<Car> _cars;
 
        public CarRepository()
        {
            _cars = new List<Car>();
        }


        public Car Insert(Car car)
        {
            if (_cars.All(x => x.CarId != car.CarId))
                _cars.Add(car);
            return car;
        }


        public Car Update(Car car)
        {
            var savedCar = Get(car.CarId);
            Delete(savedCar);
            Insert(car);
            return car;
        }

        public void Delete(Car car)
        {
            if (_cars.Contains(car))
                _cars.Remove(car);
        }

        public Car Get(Guid id)
        {
            return _cars.SingleOrDefault(x => x.CarId == id);
        }

        public IEnumerable<Car> List()
        {
            return _cars;
        }
    }
}