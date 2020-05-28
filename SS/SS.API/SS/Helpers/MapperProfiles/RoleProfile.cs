using AutoMapper;
using SS.Business.Dtos.Return;
using SS.Data.Models;

namespace SS.Helpers.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            // Data to Dto
            CreateMap<Ssrole, RolesToReturnDto>()
               .ForMember(dest => dest.Id, opt =>
                   opt.MapFrom(src => src.Id));
        }
    }
}