using CadastroCliente.Core.Interfaces;
using CadastroClientes.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CadastroClientes.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;
        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> Consulta()
        {
            var query = "SELECT * FROM Clientes";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cliente>(query).ToList();
        }
        public List<Cliente> ConsultaPorCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE Clientes.cpf = @cpf";

            var Parameters = new DynamicParameters();
            Parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cliente>(query, Parameters).ToList();
        }

        public bool InserirNovoCliente(Cliente novoCliente)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var Parameters = new DynamicParameters();
            Parameters.Add("cpf", novoCliente.Cpf);
            Parameters.Add("nome", novoCliente.Nome);
            Parameters.Add("dataNascimento", novoCliente.dataNascimento.ToString("yyyy-MM-dd"));
            Parameters.Add("idade", novoCliente.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }
        public bool UpdateCliente(Cliente cliente, string CpfCon)
        {
            var query = "UPDATE Clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento WHERE Clientes.cpf = @cpfCon";
            var Parameters = new DynamicParameters();
            Parameters.Add("cpf", cliente.Cpf);
            Parameters.Add("nome", cliente.Nome);
            Parameters.Add("dataNascimento", cliente.dataNascimento);
            Parameters.Add("cpfCon", CpfCon);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

        public bool DeletarCliente(string Cpf)
        {
            var query = "DELETE FROM Clientes Where clientes.cpf = @cpf";
            var Parameters = new DynamicParameters();
            Parameters.Add("cpf", Cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

    }
}