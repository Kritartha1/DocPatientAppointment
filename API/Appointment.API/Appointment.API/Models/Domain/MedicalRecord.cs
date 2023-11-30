using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class MedicalRecord
    {
        [Key]
        public Guid MedicalRecordId { get; set; }
        
       // public Guid[]? ApptIds { get; set; }
       public ICollection<Observation>? Observations { get; set; }   

        

    }
}
