using System;
using Cars.Administration.Web.Infrastructure.Mapping;
using Cars.Administration.Web.Models.FormModels;

namespace Cars.Administration.Web.Domain
{
    public class Car : IMapFrom<CreateCarForm>
    {

        public Guid CarId { get; set; }

        public string Make { get; set; }

        public decimal RentalPricePerDay { get; set; }

        public string Currency { get; set; }

        public string Notes { get; set; }

				public TransmissionType TransmissionType { get; set; } 

    }

}