using AutoMapper;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Data.Models;

namespace SS.Helpers.MapperProfiles
{
    public class ArtistPhotoProfile : Profile
    {
        public ArtistPhotoProfile()
        {
            // Data to Dto
            CreateMap<ArtistPhoto, PhotoFileForReturnDto>();
            CreateMap<ArtistPhoto, PhotoforReturnDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ArtistPhotoId))
                .ForMember(dest => dest.FileName, opt =>
                    opt.MapFrom(src => src.PhotoFileName));

            // Dto to Data            
            CreateMap<PhotoForCreationDto, ArtistPhoto>()
                .ForMember(dest => dest.PhotoFileName, opt =>
                    opt.MapFrom(src => src.File.FileName))
                .ForMember(dest => dest.PhotoDescription, opt =>
                    opt.MapFrom(src => src.Description));

            // // Data to Dto -- check??
            // CreateMap<ArtistPhoto, ArtistPhotosForDetailedDto>()
            //     .ForMember(dest => dest.Id, opt =>
            //         opt.MapFrom(src => src.ArtistPhotoId));

            // // Need to Clean
            // CreateMap<ArtistPhoto, ArtistPhotosForDetailedDto>()
            //     .ForMember(dest => dest.Id, opt =>
            //         opt.MapFrom(src => src.ArtistPhotoId));
            // CreateMap<ArtistPhoto, PhotoforReturnDto>()
            //     .ForMember(dest => dest.Id, opt =>
            //         opt.MapFrom(src => src.ArtistPhotoId));
            // CreateMap<PhotoForCreationDto, ArtistPhoto>()
            //     .ForMember(dest => dest.PhotoFileName, opt =>
            //         opt.MapFrom(src => src.File.FileName));
        }
    }
}