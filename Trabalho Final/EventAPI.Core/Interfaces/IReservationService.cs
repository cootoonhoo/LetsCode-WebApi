using EventAPI.Core.Model;

namespace EventAPI.Core.Interfaces
{
    public interface IReservationService
    {
        List<EventReservation> GetAll();
        List<EventReservation> GetReservationsInEvent(long EventId);
        List<EventReservation> GetReservationByNameAndEvent(string Name, string EventTitle);
        bool PostReservation(EventReservation newReservation);
        bool UpdateQuantity(long ReservationId, int Quantity);
        bool RemoveReservation(long ReservationId);
    }
}
