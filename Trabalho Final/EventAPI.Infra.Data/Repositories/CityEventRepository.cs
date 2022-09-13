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
            throw new NotImplementedException();
        }

        public List<CityEvent> GetEventsByTitle(string Title)
        {
            var query = "SELECT * FROM CityEvent WHERE CityEvent.Title LIKE @Title";

            var Parameters = new DynamicParameters();
            Parameters.Add("Title", $"%{Title}%");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<CityEvent>(query, Parameters).ToList();
        }

        public bool PostEvent(CityEvent newEvent)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEvent(long IdEvent)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(long IdEvent, CityEvent updatedEvent)
        {   
            throw new NotImplementedException();
        }
    }
}
