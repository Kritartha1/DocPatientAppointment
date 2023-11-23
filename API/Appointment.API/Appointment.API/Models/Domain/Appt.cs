using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Appt
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Description { get; set; }
       
        

        public DateTime StartTime { get; set; }
       // public DateTime EndTime { get; private set; }

        public int price { get; set; }  

        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }

        public Guid? PrescriptionId { get; set; }

        public User User { get; set; }  
        public Doctor Doctor { get; set; }
        public Prescription Prescription { get; set;}
    }
}
