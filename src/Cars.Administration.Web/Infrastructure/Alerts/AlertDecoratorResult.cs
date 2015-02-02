using System.Web.Mvc;

namespace Cars.Administration.Web.Infrastructure.Alerts
{
    public class AlertDecoratorResult: ActionResult
    {
        private ActionResult InnerResult { get; set; }

        private string AlertClass { get; set; }

        private string Message { get; set; }

        public AlertDecoratorResult(ActionResult innerResult, string alertClass, string message)
        {
            InnerResult = innerResult;
            AlertClass = alertClass;
            Message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertClass, Message));
            InnerResult.ExecuteResult(context);
        }
    }
}