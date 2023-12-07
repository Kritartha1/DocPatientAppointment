using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppointmentApiDbContext dbContext;
        private readonly IBookingRepository bookingRepository;

        public BookingController(IMapper mapper,AppointmentApiDbContext dbContext,IBookingRepository bookingRepository)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.bookingRepository = bookingRepository;
        }

        [HttpGet]
        /* [Authorize(Roles ="User,Admin")]*/
        public async Task<IActionResult> GetAll()
        {
            //  logger.LogInformation("GetAll doctors Action method was invoked");

            var bookingsDomain = await bookingRepository.GetAllAsync();



            //  logger.LogInformation($"Finished GetAllDoctors request with data:{JsonSerializer.Serialize(doctorsDomain)}");

            var bookingsDto = mapper.Map<List<BookingDto>>(bookingsDomain);

            return Ok(bookingsDto);

        }

        [HttpGet]
        
        [Route("{id:DateTime}")]
        /*[Authorize(Roles = "User,Doctor,Admin")]*/
        public async Task<IActionResult> GetById([FromRoute] DateTime id)
        {
            /*var existingBooking = await bookingRepository.GetByIdAsync(slotDomainModel.StartTime);
            return BadRequest(existingBooking);*/

            /*var doctorDomain = await dbContext.Bookings
    .Include(b => b.Users) 
    .Include(b=>b.Doctors)
    .FirstOrDefaultAsync(b => b.BookingId == id);*/

           var doctorDomain = await bookingRepository.GetByIdAsync(id);
           
            if (doctorDomain == null)
            {
                return NotFound();
            }

            

            var doctorDto = mapper.Map<BookingDto>(doctorDomain);


            return Ok(doctorDto);

        }
    }
}
