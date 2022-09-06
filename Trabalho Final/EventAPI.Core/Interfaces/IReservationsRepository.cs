using EventAPI.Core.Model;

namespace EventAPI.Core.Interfaces
{
    public interface IReservationsRepository
    {
        List<Reservation> GetAllReservations();
        List<Reservation> GetReservationsByEventId(long EventId);
        List<Reservation> GetReservationsByReservationId(long ReservId);
        bool InsertNewReservation(Reservation newReservation);
        bool UpdateReservation(Reservation Reservation, long ReservationId);
        bool DeleteReservation(long ReservationId);
    }
}
