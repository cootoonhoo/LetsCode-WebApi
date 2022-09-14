using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;


namespace EventAPI.Core.Services
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> Consulta()
        {
            return _clienteRepository.Consulta();
        }

        public List<Cliente> ConsultaPorCpf(string cpf)
        {
            return _clienteRepository.ConsultaPorCpf(cpf);
        }
    }
}
