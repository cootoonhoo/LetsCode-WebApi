using CadastroCliente.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroCliente.Filters
{
    public class TempoDeAplicaçãoResourceFilter : IResourceFilter
    {
        IBenchmarkService _benchMarkService;
        public TempoDeAplicaçãoResourceFilter(IBenchmarkService benchMarkService)
        {
            _benchMarkService = benchMarkService;
        }

        void IResourceFilter.OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("RESOURCE FILTER: OnResourceExecuted - Tempo da Aplicação");
            _benchMarkService.StopStopWatch();
            Console.WriteLine($"Tempo de execução : {_benchMarkService.GetTimeByMiliseconds()}ms");
            Console.WriteLine();
        }

        void IResourceFilter.OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("RESOURCE FILTER: OnResourceExecuting - Tempo da Aplicação");
            _benchMarkService.StartStopWatch();
        }
    }
}
