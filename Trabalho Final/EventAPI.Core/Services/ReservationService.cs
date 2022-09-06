using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;

namespace EventAPI.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationsRepository _reservationRepository;
        public ReservationService(IReservationsRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public bool DeleteReservation(long ReservationId)
        {
            return _reservationRepository.DeleteReservation(ReservationId);
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public List<Reservation> GetReservationsByEventId(long EventId)
        {
            return _reservationRepository.GetReservationsByEventId(EventId);
        }

        public List<Reservation> GetReservationsByReservationId(long ReservId)
        {
            return _reservationRepository.GetReservationsByReservationId(ReservId);
        }

        public bool InsertNewReservation(Reservation newReservation)
        {
            return _reservationRepository.InsertNewReservation(newReservation);
        }

        public bool UpdateReservation(Reservation Reservation, long ReservationId)
        {
            return _reservationRepository.UpdateReservation(Reservation, ReservationId);
        }
    }
}
