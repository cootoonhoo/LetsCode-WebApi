using EventAPI.Core.Model;

namespace EventAPI.Core.Interfaces
{
    public interface IReservationService
    {
        List<EventReservation> GetReservationsInEvent(long EventId);
    }
}
