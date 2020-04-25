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
            CreateMap<Ssuser, User>()
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.Id));

            //Business to Data
            CreateMap<User, Ssuser>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.UserId));

            //Business to Dto
            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.Created, opt =>
                    opt.MapFrom(src => src.CreatedDate));

            //To Clean
            CreateMap<UserForRegisterDto, Ssuser>()
                .ForMember(dest => dest.DisplayName, opt =>
                    opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.CreatedDate, opt =>
                    opt.MapFrom(src => src.Created));
            CreateMap<Ssuser, UserForDetailDto>()
                .ForMember(dest => dest.Created, opt =>
                    opt.MapFrom(src => src.CreatedDate));
            CreateMap<UsersWithRoles, UsersForAdminReturnDto>()
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.Id));
        }
    }
}