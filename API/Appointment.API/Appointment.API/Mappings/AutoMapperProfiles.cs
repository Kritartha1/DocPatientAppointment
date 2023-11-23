using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using AutoMapper;

namespace Appointment.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
        }
    }
}
