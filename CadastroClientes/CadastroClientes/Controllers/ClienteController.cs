using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CadastroClientes.Repositories;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        public ClienteRepository repositoryCliente;
        public ClienteController(ILogger<ClienteController> logger, IConfiguration configuration)
        {
            _logger = logger;
            repositoryCliente = new ClienteRepository(configuration);
        }

        //GET de todos os clientes
        [HttpGet("/Cliente/Consultar")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(repositoryCliente.Consulta());
        }

        //GET por CPF
        [HttpGet("/Cliente/{Cpf}/ConsultarPorCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> GetByCpf(string Cpf)
        {
            if (repositoryCliente.ConsultaPorCpf(Cpf).Count == 0)
            {
                return NotFound();
            }
            return Ok(repositoryCliente.ConsultaPorCpf(Cpf));
        }

        //POST de um novo cliente
        [HttpPost("/Cliente/Inserir")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> Inserir(Cliente novoCliente)
        {
            if (!repositoryCliente.InserirNovoCliente(novoCliente))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Inserir), novoCliente);
        }

        //DELET por CPF
        [HttpDelete("/Cliente/{Cpf}/Deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string Cpf)
        {
            if (!repositoryCliente.DeletarCliente(Cpf))
            {
                return NotFound();
            }
            return NoContent();
        }

        //PUT por CPF
        [HttpPut("/Cliente/{Cpf}/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> Put(string Cpf, [FromBody] Cliente Cliente)
        {
            if (!repositoryCliente.UpdateCliente(Cliente, Cpf))
            {
                return NotFound();
            }
            return Ok(Cliente);
        }
    }
}