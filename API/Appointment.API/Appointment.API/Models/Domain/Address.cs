using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        public string Locality;
        public string City;
        public string State;


    }
}
