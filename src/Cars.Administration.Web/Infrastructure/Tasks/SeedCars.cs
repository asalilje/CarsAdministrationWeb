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
                RentalPricePerDay = 100m,
								TransmissionType = TransmissionType.Manual,
                Notes = "Some notes about the car"
            });
            _carRepository.Insert(new Car()
            {
                CarId = Guid.NewGuid(),
                Currency = "USD",
                Make = "BMW 320",
                RentalPricePerDay = 120m,
								TransmissionType = TransmissionType.Manual,
                Notes = "This is a nice car"
            });
            _carRepository.Insert(new Car()
            {
                CarId = Guid.NewGuid(),
                Currency = "USD",
                Make = "Chevrolet Impala",
								TransmissionType = TransmissionType.Automatic,
                RentalPricePerDay = 200m,
                Notes = "This car is old and ugly"
            });
        }
    }
}