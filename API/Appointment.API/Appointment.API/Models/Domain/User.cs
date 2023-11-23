using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    

    public class User
    {

        [Key]
        public Guid Id { get; set; }
       
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }

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

        public  float? Height{  get; set; }

        public float? Weight{  get; set; }

        public string? BloodGrp { get; set; }

        public UserType Type { get; set; }

        public enum UserType
        {
            _User_,
            _Admin_,
            _Doctor_
        }

        public Guid? MedId { get; set; }
        public MedicalRecord? MedicalRecord { get; set; }



        
       

       

        /*public Guid? AppointmentId { get; set; }
        public Appointment? Appointments { get; set; }*/
        

       
    }
}
