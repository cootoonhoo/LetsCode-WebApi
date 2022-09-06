using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroClientes.Filters
{
    public class LogResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Filtro de Result (Após) OnResultExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Filtro de Result (Durante) OnResultExecuted");
        }
    }
}
