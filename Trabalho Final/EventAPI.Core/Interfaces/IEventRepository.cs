using EventAPI.Core.Model;

namespace EventAPI.Core.Interfaces
{
    public interface IEventRepository
    {
        bool PostEvent(CityEvent newEvent);
        bool UpdateEvent(long IdEvent, CityEvent updatedEvent);
        bool RemoveEvent(long IdEvent);
        List<CityEvent> GetEventsByTitle(string Title);
        List<CityEvent> GetEventsByLocalAndDate(string Local, DateTime Date);
        List<CityEvent> GetEventsByRangePriceAndDate(decimal lowestValue, decimal highetsValue, DateTime Date);
    }
}
