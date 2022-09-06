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

        [HttpGet(Name = "Event/GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Event>> GetAllEvents()
        {
            return Ok(_eventService.GetEvents());
        }

        [HttpGet("/Event/GetEventByTilte/{Title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Event>> GetEventByTitle(string Title) {
            if (_eventService.GetEventByTitle(Title).Count == 0)
            {
                return NotFound();
            }
            return Ok(_eventService.GetEventByTitle(Title));
        }
        [HttpPost("/Event/Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Event> InsertEvent(Event newEvent)
        {
            if (!_eventService.InsertNewEvent(newEvent))
            {
                return BadRequest();
            }
            //TODO: Atualizar o ID pelos Filters 
            return CreatedAtAction(nameof(InsertEvent), newEvent);
        }
        [HttpPut("/Event/UpdateEvent/{EventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event> Put(long EventId, [FromBody] Event Event)
        {
            if (!_eventService.UpdateEvent(Event, EventId))
            {
                return NotFound();
            }
            return Ok(_eventService.GetEventByTitle(Event.Title));
        }

        [HttpDelete("/Event/DeletEvent/{EventId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long EventId)
        {
            if (!_eventService.DeleteEvent(EventId))
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("/Event/GetAllReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Reservation>> GetAllReservations(){
            return Ok(_reservationService.GetAllReservations());
        }
        [HttpGet("/Event/GetAllReservationsByEventId/{EventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Reservation>> GetReservationsByEventId(long EventId)
        {
            if (_reservationService.GetReservationsByEventId(EventId).Count == 0)
            {
                return NotFound();
            }
            return Ok(_reservationService.GetReservationsByEventId(EventId));
        }

        [HttpGet("/Event/GetReservationsById/{ReservId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Reservation>> GetReservationsByReservationId(long ReservId)
        {
            if (_reservationService.GetReservationsByReservationId(ReservId).Count == 0)
            {
                return NotFound();
            }
            return Ok(_reservationService.GetReservationsByReservationId(ReservId));
        }
        [HttpPost("/Event/InsertReservation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Reservation> InsertReservation([FromBody]Reservation newReserv)
        {
            if (!_reservationService.InsertNewReservation(newReserv))
            {
                return BadRequest();
            }
            //TODO: Atualizar o ID pelos Filters 
            return CreatedAtAction(nameof(InsertReservation), newReserv);
        }
        [HttpPut("/Event/UpdateReserv/{ReservId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event> UpdateReserv(long ReservId, [FromBody] Reservation Resev)
        {
            if (!_reservationService.UpdateReservation(Resev, ReservId))
            {
                return NotFound();
            }
            return Ok(_reservationService.GetReservationsByReservationId(ReservId));
        }
        [HttpDelete("/Event/DeletReservation/{ReservId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteReservation(long ReservId)
        {
            if (!_reservationService.DeleteReservation(ReservId))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}