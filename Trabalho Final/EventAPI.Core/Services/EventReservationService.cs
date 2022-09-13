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

        public List<EventReservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public List<EventReservation> GetReservationByNameAndEvent(string Name, string EventTitle)
        {
            return _reservationRepository.GetReservationByNameAndEvent(Name,EventTitle);
        }

        public List<EventReservation> GetReservationsInEvent(long EventId)
        {
            return _reservationRepository.GetReservationsInEvent(EventId);
        }

        public bool PostReservation(EventReservation newReservation)
        {
            return _reservationRepository.PostReservation(newReservation);
        }

        public bool RemoveReservation(long ReservationId)
        {
            return _reservationRepository.RemoveReservation(ReservationId);
        }

        public bool UpdateQuantity(long ReservationId, int Quantity)
        {
            return _reservationRepository.UpdateQuantity(ReservationId, Quantity);
        }
    }
}
