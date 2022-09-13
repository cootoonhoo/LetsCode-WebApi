using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventAPI.Filters.ActionFilter
{
    public class AudienceVerifyActionFilter : ActionFilterAttribute
    {
        IReservationService _reservationRepository;
        public AudienceVerifyActionFilter(IReservationService reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var EventId = (long)context.ActionArguments["EventId"];

            if (EventId == null) {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            else if (_reservationRepository.GetReservationsInEvent(EventId).Count != 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
