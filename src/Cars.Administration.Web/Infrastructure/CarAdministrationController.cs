using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Cars.Administration.Web.ActionResults;
using Cars.Administration.Web.Filters;
using Microsoft.Web.Mvc;

namespace Cars.Administration.Web.Infrastructure
{
		[CurrencySelectListPopulator]
		public abstract class CarAdministrationController : Controller
		{
				protected ActionResult RedirectToAction<TController>(
						Expression<Action<TController>> action) where TController : Controller
				{
						return ControllerExtensions.RedirectToAction(this, action);
				}

			protected StandardJsonResult JsonValidationError()
			{
				var result = new StandardJsonResult();
				foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
				{
					result.AddError(validationError.ErrorMessage);
				}
				return result;
			}

			protected StandardJsonResult JsonError(string errorMessage)
			{
				var result = new StandardJsonResult();
				result.AddError(errorMessage);
				return result;
			}

			protected StandardJsonResult<T> JsonSuccess<T>(T data)
			{
				return new StandardJsonResult<T> {Data = data};
			}
		}
}