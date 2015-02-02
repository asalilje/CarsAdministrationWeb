using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Filters;

namespace Cars.Administration.Web.Models.FormModels
{
	public class CreateCarForm : IHaveCurrencySelectList
		{
				
			[Required]
			public string Make { get; set; }

			[Required]
			[Range(1, 10000000, ErrorMessage = "Rental price must be greater than 0")]
			
			public decimal RentalPricePerDay { get; set; }

			public string Currency { get; set; }

			public string Notes { get; set; }

			public TransmissionType TransmissionType { get; set; }

			public SelectListItem[] AvailableCurrencies { get; set; }

		}
}