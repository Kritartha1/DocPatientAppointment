using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Disease
    {
        [Key]
        public Guid Dis_Id { get; set; }
        public string Dis_Name { get; set;}

        //public Guid[] medicationsId { get; set; }

        public Medication[] Medications { get; set; }   
    }
}
