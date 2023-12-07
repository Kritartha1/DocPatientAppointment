using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointment.API.Models.Domain
{
    public class MedicalRecord
    {
        [Key]
        public Guid MedicalRecordId { get; set; }

        // public Guid[]? ApptIds { get; set; }

        [JsonIgnore]
        public ICollection<Observation>? Observations { get; set; }   

        

    }
}
