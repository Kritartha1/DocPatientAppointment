using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UsersController> logger;

        public UsersController(AppointmentApiDbContext dbContext,IUserRepository userRepository,IMapper mapper,ILogger<UsersController> logger)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
      //  [Authorize(Roles ="User")]
        
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("GetAll users Action method was invoked");

            var usersDomain = await userRepository.GetAllAsync();

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

            logger.LogInformation($"Finished GetAllUsers request with data:{JsonSerializer.Serialize(usersDomain)}");

            var usersDto = mapper.Map<List<UserDto>>(usersDomain);

            return Ok(usersDto);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomain = await userRepository.GetByIdAsync(id);
            if (userDomain == null)
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

            var userDto = mapper.Map<UserDto>(userDomain);


            return Ok(userDto);

        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]

        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            /*var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionNameUrl = addRegionRequestDto.RegionNameUrl,
            };*/
            var userDomainModel = mapper.Map<User>(addUserRequestDto);

            userDomainModel = await userRepository.CreateAsync(userDomainModel);

            /*var regionDTO = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionNameUrl = regionDomainModel.RegionNameUrl,
            };*/

            var userDTO = mapper.Map<UserDto>(userDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = userDTO.Id }, userDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Doctor")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            /*var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionNameUrl = updateRegionRequestDto.RegionNameUrl,
            };*/
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);
            userDomainModel = await userRepository.UpdateAsync(id,userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }
/*
            userDomainModel.Code = updateUserRequestDto.Code;
            userDomainModel.RegionNameUrl = updateUserRequestDto.RegionNameUrl;
            userDomainModel.Name = updateUserRequestDto.Name;*/

            await dbContext.SaveChangesAsync();

            /* var regionDto = new RegionDto
             {
                 Id = regionDomainModel.Id,
                 Code = regionDomainModel.Code,
                 Name = regionDomainModel.Name,
                 RegionNameUrl = regionDomainModel.RegionNameUrl
             };*/
            var userDto = mapper.Map<User>(userDomainModel);
            return Ok(userDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Doctor,User")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await userRepository.DeleteAsync(id);
            if (regionDomainModel == null)
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

            var regionDto = mapper.Map<UserDto>(regionDomainModel);



            return Ok(regionDto);
        }




    }
}
