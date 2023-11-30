using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Observation
    {
        [Key]
        public Guid Id { get; set; } 

        public string? Symptoms { get; set; }    
        public string? TreatmentPlan { get; set; }

        public string? Recommendedtests { get; set; }   
        public Guid? PrescriptionId { get; set; }   
        public Prescription? Prescription { get; set;}

    }
}
