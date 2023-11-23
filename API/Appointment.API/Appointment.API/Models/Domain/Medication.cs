using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.API.Models.Domain
{
    public class Medication
    {
        [Key]
        public int MedicationsId { get; set; } 
        public string MedicationName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost {  get; set; }

        public int Quantity {  get; set; }

        public Guid DisId { get; set; }
        public Disease Disease { get; set; }
    }
}
