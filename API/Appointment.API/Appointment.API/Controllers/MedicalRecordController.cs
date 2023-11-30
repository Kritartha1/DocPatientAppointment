using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IMedicalRecordRepository medicalRecordRepository;

        public MedicalRecordController(AppointmentApiDbContext dbContext,IMedicalRecordRepository medicalRecordRepository)
        {
            this.dbContext = dbContext;
            this.medicalRecordRepository = medicalRecordRepository;
        }
    }
}
