using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventAPI.Filters.ActionFilter
{
    public class VerifyHighLowPriceActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var minV = (decimal)context.ActionArguments["lowestValue"];
            var maxV = (decimal)context.ActionArguments["highetsValue"];

            if (minV == 0 || maxV == 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            else if (minV > maxV) {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
