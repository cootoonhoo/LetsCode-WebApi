using EventAPI.Core.Services;
using EventAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Core.Model;
using EventAPI.Filters.ActionFilter;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventController : ControllerBase
    {
        public IEventService _eventService;
        public IReservationService _reservationService;
        public EventController(IEventService eventService, IReservationService reservationService)
        {
            _eventService = eventService;
            _reservationService = reservationService;
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

        #region "Get evento por range de preço e data"
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

        #region "Get todos as reservas"
        [HttpGet("/Reservation/Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<EventReservation>> GetAllReservations(){
            return Ok(_reservationService.GetAll());
        }
        #endregion

        #region"Get todas reservas por evento"
        [HttpGet("/Reservation/AllReservationsInEvent/{EventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<EventReservation>> GetReservationsInEvent(long EventId)
        {
            if (_reservationService.GetReservationsInEvent(EventId).Count == 0)
            {
                return NoContent();
            }
            return Ok(_reservationService.GetReservationsInEvent(EventId));
        }
        #endregion

        #region "Get por NomePessoa e Titulo evento"
        [HttpGet("/Reservation/GetByPersonNameAndEventTitle/{Name},{EventTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<EventReservation>> GetReservationsByEventId(string Name, string EventTitle)
        {
            if (_reservationService.GetReservationByNameAndEvent(Name, EventTitle).Count == 0)
            {
                return NotFound();
            }
            return Ok(_reservationService.GetReservationByNameAndEvent(Name, EventTitle));
        }
        #endregion

        //[HttpGet("/Reservation/GetReservationByPersonAndTitle/{PersonName},{EventTitle}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<List<EventReservation>> GetReservationByPersonAndTitle(string PersonName, string EventTitle)
        //{
        //    if (_reservationService.GetReservationByPersonAndTitle(PersonName, EventTitle).Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(GetReservationByPersonAndTitle(PersonName, EventTitle));
        //}

        //[HttpPost("/Reservation/Insert")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<EventReservation> InsertReservation([FromBody]EventReservation newReserv)
        //{
        //    if (!_reservationService.InsertNewReservation(newReserv))
        //    {
        //        return BadRequest();
        //    }
        //    //TODO: Atualizar o ID pelos Filters 
        //    return CreatedAtAction(nameof(InsertReservation), newReserv);
        //}
        //[HttpPut("/Reservation/Update/{ReservationId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<CityEvent> UpdateReserv(long ReservationId, [FromBody] EventReservation Reserv)
        //{
        //    if (!_reservationService.UpdateReservation(Reserv, ReservationId))
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_reservationService.GetReservationsByReservationId(ReservationId));
        //}

        //[HttpDelete("/Reservation/Delete/{ReservationId}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult DeleteReservation(long ReservationId)
        //{
        //    if (!_reservationService.DeleteReservation(ReservationId))
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}