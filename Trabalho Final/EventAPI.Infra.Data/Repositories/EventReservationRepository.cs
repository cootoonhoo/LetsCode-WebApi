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

        public List<EventReservation> GetAll()
        {
            var query = "SELECT * FROM EventReservation";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<EventReservation>(query).ToList();
        }

        public List<EventReservation> GetReservationsInEvent(long EventId)
        {
            var query = "SELECT * FROM EventReservation  as er WHERE  er.IdEvent = @EventId";

            var Parameters = new DynamicParameters();
            Parameters.Add("EventId", $"{EventId}");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<EventReservation>(query, Parameters).ToList();
        }

        public List<EventReservation> GetReservationByNameAndEvent(string Name, string EventTitle)
        {
            var query = "SELECT * FROM CityEvent as ce INNER JOIN EventReservation as er ON er.IdEvent = ce.IdEvent WHERE ce.Title LIKE @Title AND er.PersonName LIKE @Name";
            var Parameters = new DynamicParameters();
            Parameters.Add("Title", $"%{EventTitle}%");
            Parameters.Add("Name", Name);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<EventReservation>(query, Parameters).ToList();
        }


        public bool PostReservation(EventReservation newReservation)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReservation(long ReservationId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuantity(long ReservationId, int Quantity)
        {
            throw new NotImplementedException();
        }
    }
}
