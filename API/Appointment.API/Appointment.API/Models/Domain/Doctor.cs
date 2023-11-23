using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Doctor
    {
        [Key]
        public Guid Id { get; set; }
        public string qualifications { get; set; }  

        public string Hospital {  get; set; } 
        
       // public Guid[] ApptIds { get; set; }
        public Appt[] Appts { get; set; }
    }
}
