using EventAPI.Core.Services;
using EventAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Core.Model;

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

        //[HttpGet("/Event/EventByTilte/{Title}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<List<CityEvent>> GetEventByTitle(string Title) {
        //    if (_eventService.GetEventByTitle(Title).Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_eventService.GetEventByTitle(Title));
        //}
        //[HttpPost("/Event/Insert")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<CityEvent> InsertEvent(CityEvent newEvent)
        //{
        //    if (!_eventService.InsertNewEvent(newEvent))
        //    {
        //        return BadRequest();
        //    }
        //    //TODO: Atualizar o ID pelos Filters 
        //    return CreatedAtAction(nameof(InsertEvent), newEvent);
        //}
        //[HttpPut("/Event/Update/{EventId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<CityEvent> Put(long EventId, [FromBody] CityEvent Event)
        //{
        //    if (!_eventService.UpdateEvent(Event, EventId))
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_eventService.GetEventByTitle(Event.Title));
        //}

        //[HttpDelete("/Event/Delete/{EventId}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult Delete(long EventId)
        //{
        //    if (!_eventService.DeleteEvent(EventId))
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        //[HttpGet("/Reservation/AllReservations")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public ActionResult<List<EventReservation>> GetAllReservations(){
        //    return Ok(_reservationService.GetAllReservations());
        //}
        //[HttpGet("/Reservation/ReservationsById/{ReservationId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<List<EventReservation>> GetReservationsByReservationId(long ReservationId)
        //{
        //    if (_reservationService.GetReservationsByReservationId(ReservationId).Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_reservationService.GetReservationsByReservationId(ReservationId));
        //}

        //[HttpGet("/Reservation/AllReservationsByEventId/{EventId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<List<EventReservation>> GetReservationsByEventId(long EventId)
        //{
        //    if (_reservationService.GetReservationsByEventId(EventId).Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_reservationService.GetReservationsByEventId(EventId));
        //}

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