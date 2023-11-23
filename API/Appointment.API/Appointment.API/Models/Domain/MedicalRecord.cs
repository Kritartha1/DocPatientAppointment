using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class MedicalRecord
    {
        [Key]
        public Guid MedId { get; set; }
        
       // public Guid[]? ApptIds { get; set; }
        public Appt[] Appts { get; set; }

    }
}
