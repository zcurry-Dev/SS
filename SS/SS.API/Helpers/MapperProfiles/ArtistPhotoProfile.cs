using SS.API.Dtos;
using SS.API.Models;
using AutoMapper;
using System.Linq;

namespace SS.API.Helpers.MapperProfiles
{
    public class ArtistPhotoProfile : Profile
    {
        public ArtistPhotoProfile()
        {
            CreateMap<ArtistPhoto, ArtistPhotosForDetailedDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ArtistPhotoId));
            CreateMap<ArtistPhoto, PhotoforReturnDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ArtistPhotoId));
            CreateMap<PhotoForCreationDto, ArtistPhoto>()
                .ForMember(dest => dest.PhotoFileName, opt =>
                    opt.MapFrom(src => src.File.FileName));
        }
    }
}