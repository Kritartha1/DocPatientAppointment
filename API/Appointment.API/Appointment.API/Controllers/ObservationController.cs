using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IObservationRepository observationRepository;

        public ObservationController(AppointmentApiDbContext dbContext,IObservationRepository observationRepository)
        {
            this.dbContext = dbContext;
            this.observationRepository = observationRepository;
        }
    }
}
