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
    }
}
