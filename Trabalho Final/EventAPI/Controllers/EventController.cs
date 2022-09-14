using EventAPI.Core.Services;
using EventAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Core.Model;
using EventAPI.Filters.ActionFilter;
using EventAPI.Filters;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventController : ControllerBase
    {
        public IEventService _eventService;
        
        public EventController(IEventService eventService)
        {
            _eventService = eventService;            
        }
        #region "Get todos os eventos"
        [HttpGet("/Event/Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> Get()
        {
            return Ok(_eventService.GetAllEvents());
        }
        #endregion

        #region "Get evento por titulo"
        [HttpGet("/Event/GetByTitle/{EventTilte}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetByTitle(string EventTilte)
        {
            if (_eventService.GetEventsByTitle(EventTilte).Count == 0) {
                return NotFound();
            }
            return Ok(_eventService.GetEventsByTitle(EventTilte));
        }
        #endregion

        #region"Get evento por Local e Data"
        [HttpGet("/Event/GetByLocalAndDate/{Local},{Date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByLocalAndDate(string Local, DateTime Date)
        {
            if (_eventService.GetEventsByLocalAndDate(Local,Date).Count == 0)
            {
                return NotFound();
            }
            return Ok(_eventService.GetEventsByLocalAndDate(Local, Date));
        }
        #endregion

        #region "Get evento por range de pre�o e data"
        [HttpGet("/Event/GetByRangePriceAndAndDate/{lowestValue},{highetsValue},{Date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(VerifyHighLowPriceActionFilter))]
        public ActionResult<List<CityEvent>> GetEventsByRangePriceAndDate(decimal lowestValue, decimal highetsValue, DateTime Date)
        {
            if (_eventService.GetEventsByRangePriceAndDate(lowestValue, highetsValue,Date).Count == 0)
            {
                return NotFound();
            }
            return Ok(_eventService.GetEventsByRangePriceAndDate(lowestValue, highetsValue, Date));
        }
        #endregion

        #region"Post de evento"
        [HttpPost("/Event/Post")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> InsertEvent(CityEvent newEvent)
        {
            if (!_eventService.PostEvent(newEvent))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(InsertEvent), newEvent);
        }
        #endregion

        #region "Update de evento"
        [HttpPut("/Event/Update/{EventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityEvent> Put(long EventId, [FromBody] CityEvent Event)
        {
            if (!_eventService.UpdateEvent(EventId, Event))
            {
                return NotFound();
            }
            return Ok(_eventService.UpdateEvent(EventId, Event));
        }
        #endregion

        #region "Remove evento"
        [HttpDelete("/Event/Remove/{EventId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(AudienceVerifyActionFilter))]
        public ActionResult Delete(long EventId)
        {
            if (!_eventService.RemoveEvent(EventId))
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion
    }
}