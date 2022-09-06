using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace EventAPI.Infra.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IConfiguration _configuration;
        public EventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Event> GetEvents()
        {
            var query = "SELECT * FROM CityEvent";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Event>(query).ToList();
        }
        public List<Event> GetEventByTitle(string title)
        {
            var query = "SELECT * FROM CityEvent WHERE CityEvent.Title = @title";

            var Parameters = new DynamicParameters();
            Parameters.Add("title", title);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Event>(query, Parameters).ToList();
        }

        public bool InsertNewEvent(Event newEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Adress, @Price)";

            var Parameters = new DynamicParameters();
            Parameters.Add("Title", newEvent.Title);
            Parameters.Add("Description", newEvent.Description);
            Parameters.Add("DateHourEvent", newEvent.DateHourEvent.ToString("yyyy-MM-dd"));
            Parameters.Add("Local", newEvent.Local);
            Parameters.Add("Adress", newEvent.Adress);
            Parameters.Add("Price", newEvent.Price);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

        public bool UpdateEvent(Event updateEvent, long EventId)
        {
            var query = "UPDATE CityEvent SET Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Adress = @Adress, Price = @Price WHERE CityEvent.IdEvent = @EventId ";

            var Parameters = new DynamicParameters();
            Parameters.Add("Title", updateEvent.Title);
            Parameters.Add("Description", updateEvent.Description);
            Parameters.Add("DateHourEvent", updateEvent.DateHourEvent.ToString("yyyy-MM-dd"));
            Parameters.Add("Local", updateEvent.Local);
            Parameters.Add("Adress", updateEvent.Adress);
            Parameters.Add("Price", updateEvent.Price);
            Parameters.Add("EventId", EventId);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }
        public bool DeleteEvent(long id)
        {
            var query = "DELETE FROM CityEvent Where CityEvent.IdEvent = @id";
            var Parameters = new DynamicParameters();
            Parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }
    }
}
