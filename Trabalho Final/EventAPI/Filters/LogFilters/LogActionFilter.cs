using Microsoft.AspNetCore.Mvc.Filters;
namespace CadastroCliente.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Request Path -> {context.HttpContext.Request.Path}");
            Console.WriteLine($"Request Method -> {context.HttpContext.Request.Method}");
        }
        public void OnActionExecuting(ActionExecutingContext context){}
    }
}
