using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;

namespace EventAPI.Core.Services
{
    public class CityEventService : IEventService
    {
        public IEventRepository _eventRepository;
        public CityEventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<CityEvent> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public List<CityEvent> GetEventsByLocalAndDate(string Local, DateTime Date)
        {
            return _eventRepository.GetEventsByLocalAndDate(Local,Date);
        }

        public List<CityEvent> GetEventsByRangePriceAndDate(decimal lowestValue, decimal highetsValue, DateTime Date)
        {
            return _eventRepository.GetEventsByRangePriceAndDate(lowestValue, highetsValue, Date);
        }

        public List<CityEvent> GetEventsByTitle(string Title)
        {
            return _eventRepository.GetEventsByTitle(Title);
        }

        public bool PostEvent(CityEvent newEvent)
        {
            return _eventRepository.PostEvent(newEvent);
        }

        public bool RemoveEvent(long IdEvent)
        {
            return _eventRepository.RemoveEvent(IdEvent);
        }

        public bool UpdateEvent(long IdEvent, CityEvent updatedEvent)
        {
            return _eventRepository.UpdateEvent(IdEvent, updatedEvent);
        }
    }
}
