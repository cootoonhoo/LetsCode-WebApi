using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;

namespace EventAPI.Core.Services
{
    public class EventService : IEventService
    {
        public IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public bool DeleteEvent(long id)
        {
            return _eventRepository.DeleteEvent(id);
        }

        public List<Event> GetEventByTitle(string title)
        {
            return _eventRepository.GetEventByTitle(title);
        }

        public List<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        public bool InsertNewEvent(Event newEvent)
        {
            return _eventRepository.InsertNewEvent(newEvent);
        }

        public bool UpdateEvent(Event updatedEvent, long EventId)
        {
            return _eventRepository.UpdateEvent(updatedEvent,EventId);
        }
    }
}
