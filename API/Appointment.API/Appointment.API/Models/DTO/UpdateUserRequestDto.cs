using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class UpdateUserRequestDto
    {
        

        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Password { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string? ContactNo { get; set; }


        //Address
        public string? City { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
        public string? ZipCode { get; set; }

        //



        public int? Age { get; set; }

        public float? Height { get; set; }

        public float? Weight { get; set; }

        public string? BloodGrp { get; set; }

       

       
    }
}
