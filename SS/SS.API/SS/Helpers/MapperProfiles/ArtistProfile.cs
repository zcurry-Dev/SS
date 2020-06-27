using System.Linq;
using AutoMapper;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Data.Models;

namespace SS.Helpers.MapperProfiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            // Dto to Data
            CreateMap<ArtistForUpdateDto, Artist>()
               .ForMember(dest => dest.ArtistName, opt =>
                  opt.MapFrom(src => src.Name));
            CreateMap<ArtistToCreateDto, Artist>()
               .ForMember(dest => dest.ArtistName, opt =>
                  opt.MapFrom(src => src.Name));
        }
    }
}