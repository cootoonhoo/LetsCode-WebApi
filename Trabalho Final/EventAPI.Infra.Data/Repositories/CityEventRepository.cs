using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace EventAPI.Infra.Data.Repositories
{
    public class CityEventRepository : IEventRepository
    {
        private readonly IConfiguration _configuration;
        public CityEventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CityEvent> GetAllEvents()
        {
                var query = "SELECT * FROM CityEvent";
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Query<CityEvent>(query).ToList();
        }

        public List<CityEvent> GetEventsByTitle(string Title)
        {
            var query = "SELECT * FROM CityEvent WHERE CityEvent.Title LIKE @Title";

            var Parameters = new DynamicParameters();
            Parameters.Add("Title", $"%{Title}%");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<CityEvent>(query, Parameters).ToList();
        }

        public List<CityEvent> GetEventsByLocalAndDate(string Local, DateTime Date)
        {
            var query = "SELECT * FROM CityEvent WHERE CityEvent.Local LIKE @Local AND CityEvent.DateHourEvent = @Date";

            var Parameters = new DynamicParameters();
            Parameters.Add("Local", $"%{Local}%");
            Parameters.Add("Date", Date.ToString("yyyy-MM-dd"));

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<CityEvent>(query, Parameters).ToList();
        }

        public List<CityEvent> GetEventsByRangePriceAndDate(decimal lowestValue, decimal highetsValue, DateTime Date)
        {
            var query = "SELECT * FROM CityEvent WHERE CityEvent.Price BETWEEN @Lowest AND @Highest AND CityEvent.DateHourEvent = @Date";

            var Parameters = new DynamicParameters();
            Parameters.Add("Lowest", $"%{lowestValue}%");
            Parameters.Add("Highest", $"%{highetsValue}%");
            Parameters.Add("Date", Date.ToString("yyyy-MM-dd"));

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<CityEvent>(query, Parameters).ToList();
        }

        public bool PostEvent(CityEvent newEvent)
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

        public bool RemoveEvent(long IdEvent)
        {
            var query = "DELETE FROM CityEvent Where CityEvent.IdEvent = @id";
            var Parameters = new DynamicParameters();
            Parameters.Add("id", IdEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

        public bool UpdateEvent(long IdEvent, CityEvent updateEvent)
        {
            var query = "UPDATE CityEvent SET Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Adress = @Adress, Price = @Price WHERE CityEvent.IdEvent = @EventId ";

            var Parameters = new DynamicParameters();
            Parameters.Add("Title", updateEvent.Title);
            Parameters.Add("Description", updateEvent.Description);
            Parameters.Add("DateHourEvent", updateEvent.DateHourEvent.ToString("yyyy-MM-dd"));
            Parameters.Add("Local", updateEvent.Local);
            Parameters.Add("Adress", updateEvent.Adress);
            Parameters.Add("Price", updateEvent.Price);
            Parameters.Add("EventId", IdEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, Parameters) == 1;
        }

    }
}
