using System;
using System.Collections.Generic;
using Cars.Administration.Web.Domain;

namespace Cars.Administration.Web.Repository
{
    public interface ICarRepository
    {
        Car Insert(Car car);

        Car Update(Car car);

        void Delete(Car car);

        Car Get(Guid id);

        IEnumerable<Car> List();

    }
}