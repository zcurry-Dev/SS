using AutoMapper;
using SS.API.Dtos;
using SS.API.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Ssuser, UserforDetailDto>();
            CreateMap<UserForRegisterDto, Ssuser>()
                .ForMember(dest => dest.DisplayName, opt =>
                        opt.MapFrom(src => src.FirstName));
        }
    }
}