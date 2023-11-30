using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.API.Models.Domain
{
    public class Medication
    {
        [Key]
        public Guid MedicationsId { get; set; } 
        public string MedicineName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost {  get; set; }

        public int Quantity {  get; set; }

        public bool AfterFood { get; set; }=false; // false means before food
    }
}
