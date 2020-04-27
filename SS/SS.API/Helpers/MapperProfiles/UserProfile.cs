using AutoMapper;
using SS.API.Business.Models;
using SS.API.Dtos.User;
using SS.API.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Data to Business
            CreateMap<Ssuser, UserDto>()
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.Id));

            //Business to Data
            CreateMap<UserDto, Ssuser>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.UserId));

            //Business to Dto
            CreateMap<UserDto, UserForDetailDto>()
                .ForMember(dest => dest.Created, opt =>
                    opt.MapFrom(src => src.CreatedDate));

            //Data to Dto            
            CreateMap<Ssuser, UserForDetailDto>()
                .ForMember(dest => dest.Created, opt =>
                    opt.MapFrom(src => src.CreatedDate));
        }
    }
}