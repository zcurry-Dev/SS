using System.Linq;
using AutoMapper;
using SS.API.Dtos;
using SS.API.Models;

namespace SS.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Artist, ArtistForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).PhotoUrl))
                .ForMember(dest => dest.YearsActive, opt =>
                    opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()));
            CreateMap<Artist, ArtistForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.ArtistPhoto.FirstOrDefault(p => p.IsMain).PhotoUrl))
                .ForMember(dest => dest.Photos, opt =>
                    opt.MapFrom(src => src.ArtistPhoto))
                .ForMember(dest => dest.YearsActive, opt =>
                    opt.MapFrom(src => src.CareerBeginDate.CalculateArtistYearsActive()));
            CreateMap<ArtistPhoto, ArtistPhotosForDetailedDto>();
        }
    }
}