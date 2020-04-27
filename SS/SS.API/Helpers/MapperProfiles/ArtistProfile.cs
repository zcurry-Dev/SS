using System.Linq;
using AutoMapper;
using SS.API.Business.Dtos.Artist;
using SS.API.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            //Data to Dto
            CreateMap<Artist, ArtistForDetailedDto>()
               .ForMember(dest => dest.Id, opt =>
                  opt.MapFrom(src => src.ArtistId))
               .ForMember(dest => dest.Name, opt =>
                  opt.MapFrom(src => src.ArtistName))
               .ForMember(dest => dest.Photos, opt =>
                  opt.MapFrom(src => src.ArtistPhoto))
               .ForMember(dest => dest.Photos, opt =>
                  opt.MapFrom(src => src.ArtistPhoto))
               .ForMember(dest => dest.PhotoId, opt =>
                  opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).ArtistPhotoId))
               .ForMember(dest => dest.YearsActive, opt =>
                  opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()));

            //Need to Clean
            CreateMap<Artist, ArtistForListDto>()
               .ForMember(dest => dest.Id, opt =>
                  opt.MapFrom(src => src.ArtistId))
               .ForMember(dest => dest.Name, opt =>
                  opt.MapFrom(src => src.ArtistName))
               .ForMember(dest => dest.PhotoId, opt =>
                  opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).ArtistPhotoId))
               .ForMember(dest => dest.YearsActive, opt =>
                  opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()));
            CreateMap<ArtistForUpdateDto, Artist>()
               .ForMember(dest => dest.ArtistName, opt =>
                  opt.MapFrom(src => src.Name));
        }
    }
}