using AutoMapper;
using SS.API.Business.Models;
using SS.API.Dtos.User;
using SS.API.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            //Data to Business
            CreateMap<Ssrole, RoleDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.RoleId)); // or is it src.Id?
        }
    }
}