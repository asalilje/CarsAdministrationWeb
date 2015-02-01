﻿using System;
using AutoMapper;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Infrastructure.Mapping;

namespace Cars.Administration.Web.Models
{
    public class CarViewModel : IHaveCustomMappings
    {
        public string Make { get; set; }
        
        public string RentalPricePerDay { get; set; }

        public string Currency { get; set; }

        public Guid CarId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Car, CarViewModel>()
                .ForMember(vm => vm.RentalPricePerDay, opt => opt.ResolveUsing(ent => ent.RentalPricePerDay.ToString("F")));
        }
    }
}