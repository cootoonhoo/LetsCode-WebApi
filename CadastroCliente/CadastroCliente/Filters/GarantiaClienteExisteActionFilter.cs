using CadastroCliente.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroCliente.Filters
{
    public class GarantiaClienteExisteActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public GarantiaClienteExisteActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("ACTION FILTER: OnActionExecuting da Garantia Cliente Existe");
            string cpfCliente = (string)context.ActionArguments["cpf"];

            if (_clienteService.ConsultaPorCpf(cpfCliente).Count == 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }
    }
}
