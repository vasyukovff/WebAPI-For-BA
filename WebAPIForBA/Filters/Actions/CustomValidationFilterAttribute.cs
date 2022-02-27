using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebAPIForBA.Filters.Actions
{
    public class CustomValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("1. OnActionExecuting ---->");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("2. OnActionExecuted <----");
        }
    }
}
