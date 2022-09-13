using EventAPI.Core.Model;

namespace EventAPI.Core.Interfaces
{
    public interface IReservationsRepository
    {
        List<EventReservation> GetReservationsInEvent(long EventId);
    }
}
