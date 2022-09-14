using EventAPI.Core.Services;
using EventAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Core.Model;
using EventAPI.Filters.ActionFilter;
using EventAPI.Filters;

namespace EventAPI.Controllers
{
    public class ReservationController : ControllerBase
    {
        public IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        #region "Get todos as reservas"
        [HttpGet("/Reservation/Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<EventReservation>> GetAllReservations()
        {
            return Ok(_reservationService.GetAll());
        }
        #endregion

        #region"Get todas reservas por evento"
        [HttpGet("/Reservation/AllReservationsInEvent/{EventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        #region"Insert de nova reserva"
        [HttpPost("/Reservation/Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EventReservation> PostReservation(EventReservation newReservation)
        {
            if (!_reservationService.PostReservation(newReservation))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostReservation), newReservation);
        }
        #endregion

        #region"Update quantidade de reservas"
        [HttpPut("/Reservation/UpdateQuantity/{ReservationId},{Quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityEvent> UpdateQuantity(long ReservationId, int Quantity)
        {
            if (!_reservationService.UpdateQuantity(ReservationId, Quantity))
            {
                return NotFound();
            }
            return Ok(_reservationService.UpdateQuantity(ReservationId, Quantity));
        }
        #endregion

        #region"Delte reserva"
        [HttpDelete("/Reservation/Delete/{ReservationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult RemoveReservation(long ReservationId)
        {
            if (!_reservationService.RemoveReservation(ReservationId))
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

    }
}
