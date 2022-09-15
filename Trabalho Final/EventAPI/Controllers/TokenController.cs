using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public class TokenController : ControllerBase
    {
        public ITokenService _tokenService;
        public IClienteService _clientService;

        public TokenController(ITokenService tokenService, IClienteService clientService)
        {
            _tokenService = tokenService;
            _clientService = clientService;
        }

        [HttpGet("/Get")]
        public IActionResult CreateToken(string cpf)
        {
            var client =  _clientService.ConsultaPorCpf(cpf)[0];
            if (client == null) {
                return BadRequest();
            }
            return Ok(_tokenService.GenerateTokenEventAPI(client.Nome, client.permissao));
        }
        [HttpGet("/Get/ClientList")]
        public ActionResult<List<Cliente>> GetClients()
        {
            return Ok(_clientService.Consulta());
        }
    }
}
