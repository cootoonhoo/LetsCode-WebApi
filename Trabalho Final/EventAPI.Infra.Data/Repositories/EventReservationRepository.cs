using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace EventAPI.Infra.Data.Repositories
{
    public class EventReservationRepository : IReservationsRepository
    {
        private readonly IConfiguration _configuration;
        public EventReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
