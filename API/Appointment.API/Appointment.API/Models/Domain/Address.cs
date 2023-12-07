using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }


    }
}
