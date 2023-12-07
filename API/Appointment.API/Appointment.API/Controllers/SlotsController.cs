using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly AppointmentApiDbContext dbContext;
        private readonly ISlotRepository slotRepository;
        private readonly IBookingRepository bookingRepository;

        public SlotsController(IDoctorRepository doctorRepository,IUserRepository userRepository,IMapper mapper,AppointmentApiDbContext dbContext,ISlotRepository slotRepository,IBookingRepository bookingRepository)
        {
            this.doctorRepository = doctorRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.slotRepository = slotRepository;
            this.bookingRepository = bookingRepository;
        }

        //create a slot
        //if Booking table contains same doctor or user in the same Datetime, no slot possible
        //else make a slot and update it to Booking table 

        [HttpPost]
        /*[Authorize(Roles = "Admin")]*/

        public async Task<IActionResult> Create([FromBody] AddSlotRequestDto addSlotRequestDto)
        {

            var slotDomainModel = mapper.Map<Slot>(addSlotRequestDto);


            slotDomainModel.User = await userRepository.GetByIdAsync(addSlotRequestDto.UserId);
            slotDomainModel.Doctor= await doctorRepository.GetByIdAsync(addSlotRequestDto.DoctorId);

            if(slotDomainModel.Doctor == null || slotDomainModel.User == null)
            {
                return BadRequest("No user or doctor found");
            }

           var existingBooking = await bookingRepository.GetByIdAsync(slotDomainModel.StartTime);



            if (existingBooking != null && existingBooking.Users != null && existingBooking.Doctors != null)
            {
                foreach (var doctor in existingBooking.Doctors.ToList())
                {
                    if (doctor.Id.Equals(slotDomainModel.DoctorId))
                    {
                        return BadRequest("Please book a new slot");
                    }
                }
                foreach (var user in existingBooking.Users.ToList())
                {
                    if (user.Id.Equals(slotDomainModel.UserId))
                    {
                        return BadRequest("Please book a new slot");
                    }
                }


            }

            slotDomainModel = await slotRepository.CreateAsync(slotDomainModel);
            if (existingBooking == null)
            {

                var addbookingRequestDto = new AddbookingRequestDto
                {
                    BookingId = slotDomainModel.StartTime,
                    Users = new List<User> { slotDomainModel.User },
                    Doctors = new List<Doctor> { slotDomainModel.Doctor },

                };

                var bookingDomainModel = mapper.Map<Booking>(addbookingRequestDto);
                bookingDomainModel = await bookingRepository.CreateAsync(bookingDomainModel);


            }
            else
            {
                var addbookingRequestDto = new AddbookingRequestDto
                {
                    BookingId = slotDomainModel.StartTime,
                    Users = new List<User>(existingBooking.Users),
                    Doctors = new List<Doctor>(existingBooking.Doctors),

                };

              

                if (addbookingRequestDto.Users!= null && addbookingRequestDto.Doctors!= null)
                {
                    addbookingRequestDto.Users.Add(slotDomainModel.User);
                    addbookingRequestDto.Doctors.Add(slotDomainModel.Doctor);

                    existingBooking = new Booking
                    {
                        BookingId = slotDomainModel.StartTime,
                        Users = addbookingRequestDto.Users.ToList(),
                        Doctors = addbookingRequestDto.Doctors.ToList(),
                    };
                    //await bookingRepository.UpdateAsync(slotDomainModel.StartTime, mapper.Map<Booking>(addbookingRequestDto));
                    await bookingRepository.UpdateAsync(slotDomainModel.StartTime,existingBooking);

                }




            }


            var slotDTO = mapper.Map<SlotDto>(slotDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = slotDTO.Id }, slotDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
       /* [Authorize(Roles = "User,Doctor,Admin")]*/
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var slotDomain = await slotRepository.GetByIdAsync(id);
            if (slotDomain == null)
            {
                return NotFound();
            }

            /* var regionsDto = new List<RegionDto>();

             var regionDto = new RegionDto
             {
                 Id = regionDomain.Id,
                 Code = regionDomain.Code,
                 Name = regionDomain.Name,
                 RegionNameUrl = regionDomain.RegionNameUrl,
             };*/

            var slotDto = mapper.Map<SlotDto>(slotDomain);


            return Ok(slotDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        /*[Authorize(Roles = "Admin,User")]*/

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var slotDomainModel = await slotRepository.DeleteAsync(id);
            if (slotDomainModel == null)
            {
                return NotFound();
            }

            /*var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionNameUrl = regionDomainModel.RegionNameUrl
            };*/

            var slotDto = mapper.Map<SlotDto>(slotDomainModel);



            return Ok(slotDto);
        }

    }
}
