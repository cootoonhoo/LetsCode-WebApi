using EventAPI.Core.Model;


namespace EventAPI.Core.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> Consulta();
        List<Cliente> ConsultaPorCpf(string cpf);
        bool InserirNovoCliente(Cliente novoCliente);
        bool UpdateCliente(Cliente cliente, string CpfCon);
        bool DeletarCliente(string Cpf);
    }
}
