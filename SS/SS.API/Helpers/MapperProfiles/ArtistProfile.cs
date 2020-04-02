using SS.API.Dtos;
using SS.API.Models;
using AutoMapper;
using System.Linq;

namespace SS.API.Helpers.MapperProfiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistForListDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.ArtistName))
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).PhotoUrl))
                .ForMember(dest => dest.YearsActive, opt =>
                    opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()));
            CreateMap<Artist, ArtistForDetailedDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.ArtistName))
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).PhotoUrl))
                .ForMember(dest => dest.Photos, opt =>
                    opt.MapFrom(src => src.ArtistPhoto))
                .ForMember(dest => dest.YearsActive, opt =>
                    opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()));
        }
    }
}