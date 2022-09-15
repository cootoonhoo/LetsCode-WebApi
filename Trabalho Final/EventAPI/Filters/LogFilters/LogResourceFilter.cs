using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CadastroCliente.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public Stopwatch sw; 
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            sw.Stop();
            Console.WriteLine($"Tempo de execução:{sw.ElapsedMilliseconds} ms");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            sw = Stopwatch.StartNew();
        }
    }
}
