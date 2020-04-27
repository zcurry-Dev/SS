using AutoMapper;
using SS.API.Business.Dtos.Artist;
using SS.API.Business.Dtos.Photo;
using SS.API.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class ArtistPhotoProfile : Profile
    {
        public ArtistPhotoProfile()
        {
            //Data to Dto
            CreateMap<ArtistPhoto, ArtistPhotosForDetailedDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ArtistPhotoId));


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