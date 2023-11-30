using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly AppointmentApiDbContext dbContext;

        public AppointmentController(IAppointmentRepository appointmentRepository,IMapper mapper,IUserRepository userRepository,AppointmentApiDbContext dbContext)
        {
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles ="User,Doctor")]

        public async Task<IActionResult> GetAll()
        {
            /*logger.LogInformation("GetAll users Action method was invoked");*/

            var apptsDomain = await appointmentRepository.GetAllAsync();

            /*var regionsDto = new List<RegionDto>();

            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionNameUrl = regionDomain.RegionNameUrl,

                });

            }*/

            /*logger.LogInformation($"Finished GetAllUsers request with data:{JsonSerializer.Serialize(apptsDomain)}");*/

            var apptsDto = mapper.Map<List<ApptDto>>(apptsDomain);

            //ApptDto       apptsDomain

            return Ok(apptsDto);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "User,Doctor")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var apptDomain = await appointmentRepository.GetByIdAsync(id);
            if (apptDomain == null)
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

            var apptDto = mapper.Map<ApptDto>(apptDomain);


            return Ok(apptDto);

        }


        [HttpPost]
        [Authorize(Roles = "User")]

        public async Task<IActionResult> Create([FromBody] AddAppointmentRequestDto addAppointmentRequestDto)
        {
           
            var apptDomainModel = mapper.Map<Appt>(addAppointmentRequestDto);

            apptDomainModel = await appointmentRepository.CreateAsync(apptDomainModel);

            //////////////////////////////////////////////////////////////////////////////
            var userDomain = await userRepository.GetByIdAsync(addAppointmentRequestDto.UserId);
            if (userDomain == null)
            {
                return NotFound();
            }
           
            /*var userDto = mapper.Map<UserDto>(userDomain);*/


           // userDomain.Appt.Add(apptDomainModel);
            

            userDomain=await userRepository.UpdateAsync(addAppointmentRequestDto.UserId, userDomain);
            await dbContext.SaveChangesAsync();
            var userDto = mapper.Map<UserDto>(userDomain);
            return Ok(userDto.Appts);


            //////////////////////////////////////////////////////////////////////////////


/*
            var apptDTO = mapper.Map<ApptDto>(apptDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = apptDTO.Id }, apptDTO);*/


        }
    }
}
