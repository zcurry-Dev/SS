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
            CreateMap<ArtistPhoto, ArtistPhotosForDetailedDto>();
            CreateMap<ArtistPhoto, PhotoforReturnDto>();
            CreateMap<PhotoForCreationDto, ArtistPhoto>();
        }
    }
}