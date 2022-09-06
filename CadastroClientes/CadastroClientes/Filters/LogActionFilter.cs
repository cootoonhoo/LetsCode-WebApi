using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroClientes.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Filtro de Action (Após) OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Filtro de Action (Durante) OnActionExecuted");
        }
    }
}
