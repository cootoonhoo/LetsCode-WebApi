using Microsoft.AspNetCore.Mvc;
using CadastroClientes.Core.Model;
using CadastroCliente.Core.Interfaces;
using CadastroCliente.Filters;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogAuthorizationFilter))]
    [TypeFilter(typeof(TempoDeAplicaçãoResourceFilter))]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        public IClienteService _clienteService;
        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        //GET de todos os clientes
        [HttpGet("/Cliente/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(_clienteService.Consulta());
        }

        //GET por CPF
        [HttpGet("/Cliente/{Cpf}/ConsultarPorCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(GarantiaClienteExisteActionFilter))]
        public ActionResult<Cliente> GetByCpf(string Cpf)
        {
            if (_clienteService.ConsultaPorCpf(Cpf) == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Ok(_clienteService.ConsultaPorCpf(Cpf));
        }

        //POST de um novo cliente
        [HttpPost("/Cliente/Inserir")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(VerificandoCpfExisteActionFilter))]
        public ActionResult<Cliente> Inserir(Cliente novoCliente)
        {
            if (!_clienteService.InserirNovoCliente(novoCliente))
            {
                return BadRequest();
            }
            novoCliente.Id = _clienteService.ConsultaPorCpf(novoCliente.Cpf)[0].Id;
            return CreatedAtAction(nameof(Inserir), novoCliente);
        }

        //DELET por CPF
        [HttpDelete("/Cliente/{Cpf}/Deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(GarantiaClienteExisteActionFilter))]
        public ActionResult Delete(string Cpf)
        {
            if (!_clienteService.DeletarCliente(Cpf))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }

        //PUT por CPF
        [HttpPut("/Cliente/{Cpf}/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(GarantiaClienteExisteActionFilter))]
        public ActionResult<Cliente> Put(string Cpf, [FromBody] Cliente Cliente)
        {
            if (!_clienteService.UpdateCliente(Cliente, Cpf))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Ok(_clienteService.ConsultaPorCpf(Cliente.Cpf));
        }
    }
}