using System.Linq;
using AutoMapper;
using SS.API.Business.Dtos.Accept;
using SS.API.Business.Dtos.Return;
using SS.API.Data.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            // Data to Dto
            CreateMap<Artist, ArtistForDetailedDto>()
               .ForMember(dest => dest.Id, opt =>
                  opt.MapFrom(src => src.ArtistId))
               .ForMember(dest => dest.Name, opt =>
                  opt.MapFrom(src => src.ArtistName))
               .ForMember(dest => dest.MainPhotoId, opt =>
                  opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).ArtistPhotoId))
               .ForMember(dest => dest.YearsActive, opt =>
                  opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()))
               .ForMember(dest => dest.StatusId, opt =>
                  opt.MapFrom(src => src.ArtistStatusId))
               .ForMember(dest => dest.PhotoIds, opt =>
                  opt.MapFrom(src => src.ArtistPhoto.Select(p => p.ArtistPhotoId)))
               .ForMember(dest => dest.Photos, opt =>
                  opt.MapFrom(src => src.ArtistPhoto))
               .ForMember(dest => dest.HomeCity, opt =>
                  opt.MapFrom(src => src.UshomeCity.HasValue
                     ? src.UshomeCityNavigation.CityName + ", " + src.UshomeCityNavigation.State.StateAbbreviation
                     : src.WorldHomeCityNavigation.CityName + ", " + src.WorldHomeCityNavigation.WorldRegion.WorldRegionAbbreviation));
            CreateMap<Artist, ArtistForListDto>()
               .ForMember(dest => dest.Id, opt =>
                  opt.MapFrom(src => src.ArtistId))
               .ForMember(dest => dest.Name, opt =>
                  opt.MapFrom(src => src.ArtistName))
               .ForMember(dest => dest.MainPhotoId, opt =>
                  opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).ArtistPhotoId))
               .ForMember(dest => dest.YearsActive, opt =>
                  opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()))
               .ForMember(dest => dest.CurrentCity, opt =>
                  opt.MapFrom(src => src.CurrentCity))
               .ForMember(dest => dest.HomeCity, opt =>
                  opt.MapFrom(src => src.UshomeCity.HasValue
                     ? src.UshomeCityNavigation.CityName + ", " + src.UshomeCityNavigation.State.StateAbbreviation
                     : src.WorldHomeCityNavigation.CityName + ", " + src.WorldHomeCityNavigation.WorldRegion.WorldRegionAbbreviation));

            // Dto to Data
            CreateMap<ArtistForUpdateDto, Artist>()
               .ForMember(dest => dest.ArtistName, opt =>
                  opt.MapFrom(src => src.Name));
            CreateMap<ArtistToCreate, Artist>()
               .ForMember(dest => dest.ArtistName, opt =>
                  opt.MapFrom(src => src.Name));
        }
    }
}