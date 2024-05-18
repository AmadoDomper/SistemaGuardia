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
        }
    }
}
