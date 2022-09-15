using EventAPI.Core.Services;
using EventAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Core.Model;
using EventAPI.Filters.ActionFilter;
using EventAPI.Filters;
using Microsoft.AspNetCore.Authorization;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public ActionResult<List<EventReservation>> GetAllReservations()
        {
            return Ok(_reservationService.GetAll());
        }
        #endregion

        #region"Get todas reservas por evento"
        [HttpGet("/Reservation/Get/{EventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
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
        [HttpGet("/Reservation/Get/{Name}/{EventTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public ActionResult<List<EventReservation>> GetReservationsByEventId(string Name, string EventTitle)
        {
            if (_reservationService.GetReservationByNameAndEvent(Name, EventTitle).Count == 0)
            {
                return NotFound();
            }
            return Ok(_reservationService.GetReservationByNameAndEvent(Name, EventTitle));
        }
        #endregion

        #region"Insert de nova reserva | AUTENTICADO"
        [HttpPost("/Reservation/Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public ActionResult<EventReservation> PostReservation(EventReservation newReservation)
        {
            if (!_reservationService.PostReservation(newReservation))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostReservation), newReservation);
        }
        #endregion

        #region"Update quantidade de reservas | AUTENTICADO E AUTORIZADO(admin)"
        [HttpPut("/Reservation/Update/{ReservationId}/{Quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize (Roles = "admin")]
        public ActionResult<CityEvent> UpdateQuantity(long ReservationId, int Quantity)
        {
            if (!_reservationService.UpdateQuantity(ReservationId, Quantity))
            {
                return NotFound();
            }
            return Ok(_reservationService.UpdateQuantity(ReservationId, Quantity));
        }
        #endregion

        #region"Delte reserva | AUTENTICADO E AUTORIZADO(admin)"
        [HttpDelete("/Reservation/Delete/{ReservationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "admin")]
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
