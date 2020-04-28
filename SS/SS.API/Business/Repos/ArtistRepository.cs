using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SS.API.Business.Dtos.Artist;
using SS.API.Business.Dtos.Photo;
using SS.API.Business.Interfaces;
using SS.API.Data.Interfaces;
using SS.API.Data.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;

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

        public async Task<PagedList<ArtistDto>> GetArtists(ArtistParams artistParams)
        {
            var listArtists = await _artist.GetArtists();
            var listDto = _mapper.Map<List<ArtistDto>>(listArtists); //need to look into this
            var artists = listDto.OrderByDescending(a => a.CareerBeginDate).AsQueryable();

            if (!string.IsNullOrEmpty(artistParams.OrderBy))
            {
                switch (artistParams.OrderBy)
                {
                    case "created":
                        artists = artists.OrderByDescending(a => a.CreatedDate);
                        break;
                    default:
                        artists = artists.OrderByDescending(a => a.CareerBeginDate);
                        break;
                }
            }

            return await PagedList<ArtistDto>.CreateAsync(artists,
                artistParams.PN, artistParams.PS);
        }

        public IEnumerable<ArtistForListDto> MapArtistsToDto(PagedList<ArtistDto> artists)
        {
            var artistsToReturn = _mapper.Map<IEnumerable<ArtistForListDto>>(artists);

            return artistsToReturn;
        }


        public async Task<ArtistForDetailedDto> GetArtistById(int artistId)
        {
            var artist = await _artist.GetArtistById(artistId);
            var artistToReturn = _mapper.Map<ArtistForDetailedDto>(artist);

            return artistToReturn;
        }

        public async Task<ArtistPhotoDto> GetArtistPhotoByArtistId(int artistId)
        {
            var artistPhoto = await _artist.GetArtistPhotoByPhotoId(artistId);
            var photo = _mapper.Map<ArtistPhotoDto>(artistPhoto);
            var file = await _artist.GetArtistPhotoFile(artistId);
            photo.File = file;

            return photo;
        }

        public async Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = await _artist.GetArtistById(artistId);
            _mapper.Map(artistForUpdateDto, artist);
            var result = await _artist.SaveAll();

            return result;
        }

        public async Task<PhotoforReturnDto> GetArtistPhotoByPhotoId(int artistPhotoId)
        {
            var photo = await _artist.GetArtistPhotoByPhotoId(artistPhotoId);
            var photoToReturn = _mapper.Map<PhotoforReturnDto>(photo);

            return photoToReturn;
        }

        public async Task<bool> UploadPhoto(int artistId, PhotoForCreationDto photoForCreationDto)
        {
            var artistPhoto = _mapper.Map<ArtistPhoto>(photoForCreationDto);
            var result = await _artist.UploadArtistPhoto(artistId, artistPhoto, photoForCreationDto.File);

            return result;
        }

        public async Task<PhotoforReturnDto> GetMostRecentArtistPhoto(int artistId)
        {
            var artistPhoto = await _artist.GetMostRecentArtistPhoto(artistId);
            var photoToReturn = _mapper.Map<PhotoforReturnDto>(artistPhoto);

            return photoToReturn;
        }

        public async Task<bool> SetNewMainPhoto(int artistId, int artistPhotoId)
        {
            var photoToSetMain = await _artist.GetArtistPhotoByPhotoId(artistPhotoId);
            var currentMainPhoto = await _artist.GetMainArtistPhotoByArtistId(artistId);
            currentMainPhoto.IsMain = false;
            photoToSetMain.IsMain = true;
            var result = await Save();

            return result;
        }

        public async Task<bool> DeletePhoto(int artistPhotoId)
        {
            var photo = await _artist.GetArtistPhotoByPhotoId(artistPhotoId);
            var result = await Delete(photo);

            return result;
        }

        //
        private async Task<bool> Save()
        {
            var result = await _artist.SaveAll();

            return result;
        }

        private async Task<bool> Delete(ArtistPhoto artistPhoto)
        {
            _artist.Delete(artistPhoto);
            var result = await _artist.SaveAll();

            return result;
        }
    }
}