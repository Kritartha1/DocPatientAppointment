using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IBookingRepository bookingRepository;

        public BookingController(AppointmentApiDbContext dbContext,IBookingRepository bookingRepository)
        {
            this.dbContext = dbContext;
            this.bookingRepository = bookingRepository;
        }
    }
}
