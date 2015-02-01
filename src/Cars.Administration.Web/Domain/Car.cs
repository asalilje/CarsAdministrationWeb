using System;

namespace Cars.Administration.Web.Domain
{
    public class Car
    {

        public Guid CarId { get; set; }

        public string Make { get; set; }

        public decimal RentalPricePerDay { get; set; }

        public string Currency { get; set; }


    }

}