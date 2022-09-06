using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroClientes.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource (Após) OnResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Filtro de Resource(Durante) OnResourceExecuted");
        }
    }
}
