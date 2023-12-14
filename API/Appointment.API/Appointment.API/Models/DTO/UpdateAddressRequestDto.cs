using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class UpdateAddressRequestDto
    {
       

        public string? Locality { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
