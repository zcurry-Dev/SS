using System.Threading.Tasks;
using SS.API.Data.Interfaces;
using SS.API.Business.Interfaces;
using AutoMapper;
using SS.API.Business.Dtos.Artist;
using SS.API.Business.Dtos.Photo;

namespace SS.API.Business.Repos
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IArtistDataRepository _artist;
        private readonly IMapper _mapper;

        public ArtistRepository(IArtistDataRepository artist, IMapper mapper)
        {
            _mapper = mapper;
            _artist = artist;
        }

        public async Task<ArtistForDetailedDto> GetArtist(int artistId)
        {
            var artist = await _artist.GetArtist(artistId);
            var artistToReturn = _mapper.Map<ArtistForDetailedDto>(artist);

            return artistToReturn;
        }

        public async Task<ArtistPhotoDto> aaaa(int artistId)
        {
            var artistPhoto = await _artist.GetArtistPhoto(artistId);
            var photo = _mapper.Map<ArtistPhotoDto>(artistPhoto);
            var file = await _artist.GetPhotoFile(artistId);
            photo.File = file;

            return photo;
        }
    }
}