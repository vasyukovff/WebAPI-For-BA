using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIForBA.Filters.Exceptions
{
    public class ArrayExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception != null && context.Exception is IndexOutOfRangeException)
            {
                context.Result = new BadRequestObjectResult("Индекс элемента массива указан не верно");
            }

            return Task.FromResult<object>(null);
        }
    }
}
