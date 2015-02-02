using System.Linq;
using System.Web.Mvc;
using Cars.Administration.Web.Helpers;

namespace Cars.Administration.Web.Filters
{
    public class CurrencySelectListPopulatorAttribute: ActionFilterAttribute
    {
        private SelectListItem[] GetAvailableCurrencies()
        {
            return new[] {"USD", "EUR", "SEK"}
                .Select(x => new SelectListItem {Text = x, Value = x}).ToArray();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (!viewResult.IsNull() && viewResult.Model is IHaveCurrencySelectList)
            {
                ((IHaveCurrencySelectList) viewResult.Model).AvailableCurrencies = GetAvailableCurrencies();
            }
        }
    }


  

    public interface IHaveCurrencySelectList
    {
        SelectListItem[] AvailableCurrencies { get; set; }
    }
}