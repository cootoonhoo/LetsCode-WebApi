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
        public bool DeletarCliente(string Cpf)
        {
            return _clienteRepository.DeletarCliente(Cpf);
        }

        public bool InserirNovoCliente(Cliente novoCliente)
        {
            return _clienteRepository.InserirNovoCliente(novoCliente);
        }

        public bool UpdateCliente(Cliente cliente, string CpfCon)
        {
            return _clienteRepository.UpdateCliente(cliente, CpfCon);
        }
    }
}
