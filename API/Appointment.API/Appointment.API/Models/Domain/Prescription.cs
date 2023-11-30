using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Prescription
    {
        [Key]
        public Guid Id { get; set; }
       // public Guid[] Dis_Id {  get; set; } 
        public ICollection<Medication> Medications { get; set; } 


    }
}
