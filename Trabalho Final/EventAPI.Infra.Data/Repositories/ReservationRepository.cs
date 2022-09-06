using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace EventAPI.Infra.Data.Repositories
{
    public class ReservationRepository : IReservationsRepository
    {
        private readonly IConfiguration _configuration;
        public ReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<Reservation> GetAllReservations()
        {
            var query = "SELECT * FROM EventReservation";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Reservation>(query).ToList();
        }

        public List<Reservation> GetReservationsByEventId(long EventId)
        {
            var query = "SELECT * FROM EventReservation WHERE EventReservation.EventId = @EventId";

            var Parameters = new DynamicParameters();
            Parameters.Add("EventId", EventId);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Reservation>(query, Parameters).ToList();
        }

        public List<Reservation> GetReservationsByReservationId(long ReservId)
        {
            var query = "SELECT * FROM EventReservation WHERE EventReservation.IdReservation = @ReservId";

            var Parameters = new DynamicParameters();
            Parameters.Add("ReservId", ReservId);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Reservation>(query, Parameters).ToList();
        }

        public bool InsertNewReservation(Reservation newReservation)
        {
            var query = "INSERT INTO EventReservation VALUES (@idEvent, @PersonName, @Quantity)";

            var Parameters = new DynamicParameters();
            Parameters.Add("idEvent", newReservation.IdEvent);
            Parameters.Add("PersonName", newReservation.PersonName);
            Parameters.Add("Quantity", newReservation.Quantity);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

        public bool UpdateReservation(Reservation Reservation, long ReservationId)
        {
            var query = "UPDATE EventReservation VALUES (@IdEvent, @PersonName, @Quantity) WHERE EventReservation.Reservation = @ReservationId ";

            var Parameters = new DynamicParameters();
            Parameters.Add("IdEvent", Reservation.IdEvent);
            Parameters.Add("PersonName", Reservation.PersonName);
            Parameters.Add("Quantity", Reservation.Quantity);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }
        public bool DeleteReservation(long ReservationId)
        {
            var query = "DELETE FROM EventReservation Where EventReservation.Id = @ReservationId";
            var Parameters = new DynamicParameters();
            Parameters.Add("ReservationId", ReservationId);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }
    }
}
