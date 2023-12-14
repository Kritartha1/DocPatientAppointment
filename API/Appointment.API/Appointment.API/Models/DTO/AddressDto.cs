using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class AddressDto
    {
        [Key]
        public Guid AddressId { get; set; }

        public string? Locality { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
