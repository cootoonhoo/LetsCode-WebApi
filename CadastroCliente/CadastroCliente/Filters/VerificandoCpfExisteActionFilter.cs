using CadastroCliente.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CadastroClientes.Core.Model;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroCliente.Filters
{
    public class VerificandoCpfExisteActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public VerificandoCpfExisteActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("ACTION FILTER: OnActionExecuting Verificando CPF");
            Cliente novoCliente = (Cliente)context.ActionArguments["novoCliente"];
            if (novoCliente == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            else if (_clienteService.ConsultaPorCpf(novoCliente.Cpf).Count != 0) {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
