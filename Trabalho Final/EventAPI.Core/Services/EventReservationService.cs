using EventAPI.Core.Interfaces;
using EventAPI.Core.Model;

namespace EventAPI.Core.Services
{
    public class EventReservationService : IReservationService
    {
        private readonly IReservationsRepository _reservationRepository;
        public EventReservationService(IReservationsRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<EventReservation> GetAll()
        {
            try
            {
                return _reservationRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetAll");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public List<EventReservation> GetReservationByNameAndEvent(string Name, string EventTitle)
        {
            try
            {
                return _reservationRepository.GetReservationByNameAndEvent(Name, EventTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetReservationByNameAndEvent");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public List<EventReservation> GetReservationsInEvent(long EventId)
        {
            try
            {
                return _reservationRepository.GetReservationsInEvent(EventId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo GetReservationsInEvent");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public bool PostReservation(EventReservation newReservation)
        {
            try
            {
                return _reservationRepository.PostReservation(newReservation);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo PostReservation");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public bool RemoveReservation(long ReservationId)
        {
            try
            {
                return _reservationRepository.RemoveReservation(ReservationId);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo RemoveReservation");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }

        public bool UpdateQuantity(long ReservationId, int Quantity)
        {
            try
            {
                return _reservationRepository.UpdateQuantity(ReservationId, Quantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. Metodo UpdateQuantity");
                Console.WriteLine($"Mensagem: {ex.Message} ");
                Console.WriteLine($"Site: {ex.TargetSite}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                throw;
            }
        }
    }
}
