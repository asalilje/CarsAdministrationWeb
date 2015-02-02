using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Cars.Administration.Web.Helpers.HtmlHelpers
{
	public static class BootstrapHelpers
	{
		public static IHtmlString BootstrapLabelFor<TModel, TValue>(
			this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> propertyExpression)
		{
			return htmlHelper.LabelFor(propertyExpression, new {@class = "control-label"});
		}

		public static IHtmlString BootstrapLabel<TModel>(
			this HtmlHelper<TModel> htmlHelper, string propertyName)
		{
			return htmlHelper.Label(propertyName, new { @class = "control-label" });
		}
	}
}