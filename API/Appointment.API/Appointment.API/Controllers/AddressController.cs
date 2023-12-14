using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public AddressController(AppointmentApiDbContext dbContext,IAddressRepository addressRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            

            var addressDomain = await addressRepository.GetAllAsync();

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

            var addressDto = mapper.Map<List<AddressDto>>(addressDomain);

            return Ok(addressDto);

        }


        /*[HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomain = await userRepository.GetByIdAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }

            *//* var regionsDto = new List<RegionDto>();

             var regionDto = new RegionDto
             {
                 Id = regionDomain.Id,
                 Code = regionDomain.Code,
                 Name = regionDomain.Name,
                 RegionNameUrl = regionDomain.RegionNameUrl,
             };*//*

            var userDto = mapper.Map<UserDto>(userDomain);


            return Ok(userDto);

        }*/

        [HttpGet]
        [Route("{id:Guid}")]
        /* [Authorize(Roles = "User,Doctor,Admin")]*/
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var addressDomain = await addressRepository.GetByIdAsync(id);
            if (addressDomain == null)
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

            var addressDto = mapper.Map<AddressDto>(addressDomain);


            return Ok(addressDto);

        }


        /// ////////////////////////////////////////////////////////////////////////////////////   

        /* [HttpPost]
         [Authorize(Roles = "User")]

         public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
         {
             *//*var regionDomainModel = new Region
             {
                 Code = addRegionRequestDto.Code,
                 Name = addRegionRequestDto.Name,
                 RegionNameUrl = addRegionRequestDto.RegionNameUrl,
             };*//*
             var userDomainModel = mapper.Map<User>(addUserRequestDto);

             userDomainModel = await userRepository.CreateAsync(userDomainModel);

             *//*var regionDTO = new RegionDto
             {
                 Id = regionDomainModel.Id,
                 Code = regionDomainModel.Code,
                 Name = regionDomainModel.Name,
                 RegionNameUrl = regionDomainModel.RegionNameUrl,
             };*//*

             var userDTO = mapper.Map<UserDto>(userDomainModel);

             return CreatedAtAction(nameof(GetById), new { id = userDTO.Id }, userDTO);
         }*/

        /// ////////////////////////////////////////////////////////////////////////////////////  


        [HttpPut]
        [Route("{id:Guid}")]
        /*[Authorize(Roles = "User")]*/

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAddressRequestDto updateAddressRequestDto)
        {

            var addressDomainModel = mapper.Map<Address>(updateAddressRequestDto);
            addressDomainModel = await addressRepository.UpdateAsync(id, addressDomainModel);

            if (addressDomainModel == null)
            {
                return NotFound();
            }
            var addressDto = mapper.Map<AddressDto>(addressDomainModel);
            return Ok(addressDto);

        }

        /// ////////////////////////////////////////////////////////////////////////////////////  



        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var addressDomainModel = await addressRepository.DeleteAsync(id);
            if (addressDomainModel == null)
            {
                return NotFound();
            }
            var addressDto = mapper.Map<AddressDto>(addressDomainModel);
            return Ok(addressDto);
        }



    }
}
