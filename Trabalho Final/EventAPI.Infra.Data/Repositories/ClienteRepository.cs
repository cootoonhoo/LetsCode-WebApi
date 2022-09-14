using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EventAPI.Infra.Data.Repositories
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
            using var conn = new SqlConnection(_configuration.GetConnectionString("ClientDataBase"));
            return conn.Query<Cliente>(query).ToList();
        }
        public List<Cliente> ConsultaPorCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE Clientes.cpf = @cpf";

            var Parameters = new DynamicParameters();
            Parameters.Add("cpf", cpf);

            // No appsettings.json criar uma ClientDataBase com os dados do db da turma para que o token funciona 
            using var conn = new SqlConnection(_configuration.GetConnectionString("ClientDataBase"));
            return conn.Query<Cliente>(query, Parameters).ToList();
        }
    }
}