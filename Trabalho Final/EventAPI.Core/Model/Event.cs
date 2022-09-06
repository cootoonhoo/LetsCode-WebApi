using System.ComponentModel.DataAnnotations;
namespace EventAPI.Core.Model
{
    public class Event
    {
        [Required]
        public long IdEvent { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateHourEvent { get; set; }
        [Required]
        public string Local { get; set; }
        public string Adress { get; set; }
        public decimal Price { get; set; }
    }
}
