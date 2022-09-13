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
            var query = "INSERT INTO EventReservation VALUES (@idEvent, @PersonName, @Quantity)";

            var Parameters = new DynamicParameters();
            Parameters.Add("idEvent", newReservation.IdEvent);
            Parameters.Add("PersonName", newReservation.PersonName);
            Parameters.Add("Quantity", newReservation.Quantity);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

        public bool RemoveReservation(long ReservationId)
        {
            var query = "DELETE FROM EventReservation Where EventReservation.Id = @ReservationId";
            var Parameters = new DynamicParameters();
            Parameters.Add("ReservationId", ReservationId);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

        public bool UpdateQuantity(long ReservationId, int Quantity)
        {
            var query = "UPDATE EventReservation VALUES @Quantity) WHERE EventReservation.Reservation = @ReservationId ";

            var Parameters = new DynamicParameters();
            Parameters.Add("Quantity", Quantity);
            Parameters.Add("ReservationId", ReservationId);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }
    }
}
