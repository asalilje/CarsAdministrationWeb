using System;
using System.Linq.Expressions;
using System.Web.Mvc;
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
    }
}