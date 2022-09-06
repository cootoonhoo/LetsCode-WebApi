using EventAPI.Core.Model;

namespace EventAPI.Core.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetEvents();
        List<Event> GetEventByTitle(string title);
        bool InsertNewEvent(Event newEvent);
        bool UpdateEvent(Event updatedEvent, long EventId);
        bool DeleteEvent(long id);
    }
}
