using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroCliente.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //Console.WriteLine("Filtro de Recurso -> {DEPOIS} OnResourceExecuted ");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //Console.WriteLine("Filtro de Recurso -> {ANTES} OnResourceExecuting ");
        }
    }
}
