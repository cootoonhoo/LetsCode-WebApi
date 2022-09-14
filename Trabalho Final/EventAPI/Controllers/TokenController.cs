using EventAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        public ITokenService _tokenService;
        public IClienteService _clientService;

        public TokenController(ITokenService tokenService, IClienteService clientService)
        {
            _tokenService = tokenService;
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult CreateToken(string cpf)
        {
            var client = _clientService.ConsultaPorCpf(cpf)[0];
            if (client == null) {
                return BadRequest();
            }
            return Ok(_tokenService.GenerateTokenEventAPI(client.Nome, client.permissao));
        }
    }
}
