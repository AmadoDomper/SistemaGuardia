using GuardiaAPI.DTOs;
using GuardiaAPI.Entities;
using AutoMapper;

namespace GuardiaAPI.Helper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ContactDTO,Contact>().ReverseMap();
            CreateMap<ContactCreationDTO, Contact>();

            CreateMap<SedeDTO, Sede>().ReverseMap();
            CreateMap<SedeCreationDTO, Sede>();

            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserCreationDTO, User>();

            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<PersonCreationDTO, Person>();

            CreateMap<GuardDutyDTO, GuardDuty>().ReverseMap();
            CreateMap<GuardDutyCreationDTO, GuardDuty>();

            CreateMap<AttendanceDTO, Attendance>().ReverseMap();
            CreateMap<AttendanceCreationDTO, Attendance>();
        }
    }
}
