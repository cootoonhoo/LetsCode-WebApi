using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroCliente.Filters
{
    public class LogResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //Console.WriteLine("Filtro de Resultado -> {Depois} OnResultExecuted ");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //Console.WriteLine("Filtro de Resultado -> {Antes} OnResultExecuting ");
        }
    }
}
