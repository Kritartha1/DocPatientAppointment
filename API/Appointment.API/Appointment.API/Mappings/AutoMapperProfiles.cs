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
            CreateMap<Appt, ApptDto>().ReverseMap();
            CreateMap<AddAppointmentRequestDto,Appt>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<AddDoctorRequestDto, Doctor>().ReverseMap();
            CreateMap<UpdateDoctorRequestDto, Doctor>().ReverseMap();
            CreateMap<AddSlotRequestDto, Slot>().ReverseMap();
            CreateMap<Slot, SlotDto>().ReverseMap();
            CreateMap<AddbookingRequestDto, Booking>().ReverseMap();
            CreateMap<BookingDto, Booking>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressRequestDto, Address>().ReverseMap();
        }
    }
}
