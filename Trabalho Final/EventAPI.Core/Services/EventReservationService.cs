using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;

namespace EventAPI.Core.Services
{
    public class EventReservationService : IReservationService
    {
        private readonly IReservationsRepository _reservationRepository;
        public EventReservationService(IReservationsRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<EventReservation> GetReservationsInEvent(long EventId)
        {
            throw new NotImplementedException();
        }
    }
}
