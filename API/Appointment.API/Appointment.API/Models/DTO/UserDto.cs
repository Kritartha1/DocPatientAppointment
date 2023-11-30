using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointment.API.Models.DTO
{
    public class UserDto
    {

        /*public Guid Id { get; set; }*/
        public string Id { get; set; }  

        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        /*public string Password { get; set; }*/

      
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        //Address
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public Guid? MedicalRecordId { get; set; }

        public MedicalRecord? MedicalRecord { get; set; }
        public ICollection<Appt>? Appts { get; set; }
    }
}
