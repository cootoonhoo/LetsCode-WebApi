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
            try
            {
                return _clienteRepository.Consulta();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo Cliente Consulta");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public List<Cliente> ConsultaPorCpf(string cpf)
        {
            try
            {
                return _clienteRepository.ConsultaPorCpf(cpf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo Cliente ConsultaPorCpf");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }
    }
}
