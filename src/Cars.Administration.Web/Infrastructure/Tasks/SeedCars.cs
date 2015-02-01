using System;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Repository;

namespace Cars.Administration.Web.Infrastructure.Tasks
{
    public class SeedCars: IRunAtStartup
    {
        private readonly ICarRepository _carRepository;

        public SeedCars(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Execute()
        {
            _carRepository.Insert(new Car()
            {
                CarId = Guid.NewGuid(),
                Currency = "USD",
                Make = "Ford Focus",
                RentalPricePerDay = 100m
            });
            _carRepository.Insert(new Car()
            {
                CarId = Guid.NewGuid(),
                Currency = "USD",
                Make = "BMW 320",
                RentalPricePerDay = 120m
            });
            _carRepository.Insert(new Car()
            {
                CarId = Guid.NewGuid(),
                Currency = "USD",
                Make = "Chevrolet Impala",
                RentalPricePerDay = 200m
            });
        }
    }
}