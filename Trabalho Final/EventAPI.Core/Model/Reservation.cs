using System.ComponentModel.DataAnnotations;

namespace EventAPI.Core.Model
{
    public class Reservation
    {
        public long IdReservation { get; set; }
        [Required]
        public long IdEvent { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
