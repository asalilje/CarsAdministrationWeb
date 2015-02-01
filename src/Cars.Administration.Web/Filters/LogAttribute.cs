using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Infrastructure;
using Cars.Administration.Web.Repository;
using StructureMap.Attributes;

namespace Cars.Administration.Web.Filters
{
    public class LogAttribute: ActionFilterAttribute
    {
        private IDictionary<string, object> _parameters;
        public string Description { get; set; }
        
        [SetterProperty]
        public ILog Log { get; set; }

        [SetterProperty]
        public ICurrentUser CurrentUser { get; set; }

        public LogAttribute(string description)
        {
            Description = description;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var user = CurrentUser.User;

            var description = Description;

            foreach (var item in _parameters)
            {
                description = description.Replace("{" + item.Key + "}", item.Value.ToString());
            }

            Log.Add(new LogAction(user, filterContext.ActionDescriptor.ActionName,
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                description));

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _parameters = filterContext.ActionParameters;
            base.OnActionExecuting(filterContext);
        }
    }

}