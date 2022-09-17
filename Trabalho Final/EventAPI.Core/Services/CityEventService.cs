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
            try
            {
                return _eventRepository.GetAllEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetAllEvents");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public List<CityEvent> GetEventsByLocalAndDate(string Local, DateTime Date)
        {
            try
            {
                return _eventRepository.GetEventsByLocalAndDate(Local, Date);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetEventsByLocalAndDate");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public List<CityEvent> GetEventsByRangePriceAndDate(decimal lowestValue, decimal highetsValue, DateTime Date)
        {
            try
            {
                return _eventRepository.GetEventsByRangePriceAndDate(lowestValue, highetsValue, Date);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetEventsByRangePriceAndDate");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public List<CityEvent> GetEventsByTitle(string Title)
        {
            try
            {
                return _eventRepository.GetEventsByTitle(Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetEventsByTitle");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public bool PostEvent(CityEvent newEvent)
        {
            try
            {
                return _eventRepository.PostEvent(newEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo PostEvent");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public bool RemoveEvent(long IdEvent)
        {
            try
            {
                return _eventRepository.RemoveEvent(IdEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo RemoveEvent");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public bool UpdateEvent(long IdEvent, CityEvent updatedEvent)
        {
            try
            {
                return _eventRepository.UpdateEvent(IdEvent, updatedEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo UpdateEvent");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }
    }
}
