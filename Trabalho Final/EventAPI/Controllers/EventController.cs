using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {

        public EventController()
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            
        }
    }
}