using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SS.API.Business.Dtos.Accept;
using SS.API.Business.Dtos.Return;
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

        public async Task<ArtistForDetailedDto> CreateArtist(ArtistToCreate artistToCreate)
        {
            var artist = _mapper.Map<Artist>(artistToCreate);

            if (artist == null)
            {
                throw new NullReferenceException();
            }

            _artist.Add(artist);
            var result = await _artist.SaveAll();

            if (!result)
            {
                throw new NullReferenceException();
            }

            var artistForDetailedDto = _mapper.Map<ArtistForDetailedDto>(artist);

            if (artistForDetailedDto == null)
            {
                throw new NullReferenceException();
            }

            return artistForDetailedDto;
        }

        public async Task<ArtistListForReturnDto> GetArtists(ArtistParams artistParams)
        {
            var artists = _artist.GetArtists().OrderBy(a => a.ArtistName).AsQueryable();

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

            if (!string.IsNullOrEmpty(artistParams.Search))
            {
                artists = artists.Where(s => s.ArtistName.Contains(artistParams.Search));
            }

            var artistsList = await PagedList<Artist>.CreateAsync(artists, artistParams.PN, artistParams.PS);
            var usersToReturn = _mapper.Map<IEnumerable<ArtistForListDto>>(artistsList);

            var artistListForReturnDto = new ArtistListForReturnDto()
            {
                Artists = usersToReturn,
                CurrentPage = artistsList.CurrentPage,
                TotalPages = artistsList.TotalPages,
                PageSize = artistsList.PageSize,
                TotalCount = artistsList.TotalCount
            };

            return artistListForReturnDto;
        }

        public async Task<ArtistForDetailedDto> GetArtistById(int artistId)
        {
            var artist = await _artist.GetArtistById(artistId);
            var artistToReturn = _mapper.Map<ArtistForDetailedDto>(artist);

            return artistToReturn;
        }

        public async Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = await _artist.GetArtistById(artistId);
            _mapper.Map(artistForUpdateDto, artist); //what does this do specifically
            var result = await _artist.SaveAll();

            return result;
        }


        //
        // Photo methods
        //
        public async Task<bool> UploadPhoto(int artistId, PhotoForCreationDto photoForCreationDto)
        {
            var artistPhoto = _mapper.Map<ArtistPhoto>(photoForCreationDto);
            var result = await _artist.UploadArtistPhoto(artistId, artistPhoto, photoForCreationDto.File);

            return result;
        }

        public async Task<PhotoFileForReturnDto> GetArtistPhotoFileByPhotoId(int photoId)
        {
            var artistPhoto = await _artist.GetArtistPhotoByPhotoId(photoId);
            var photo = _mapper.Map<PhotoFileForReturnDto>(artistPhoto);
            var file = await _artist.GetPhotoByteArray(photoId, artistPhoto.ArtistId, artistPhoto.PhotoFileName);
            photo.File = file;

            return photo;
        }

        public async Task<PhotoforReturnDto> GetArtistPhotoByPhotoId(int photoId)
        {
            var artistPhoto = await _artist.GetArtistPhotoByPhotoId(photoId);
            var photoToReturn = _mapper.Map<PhotoforReturnDto>(artistPhoto);

            return photoToReturn;
        }

        public async Task<PhotoforReturnDto> GetMostRecentArtistPhoto(int artistId)
        {
            var artistPhoto = await _artist.GetMostRecentArtistPhoto(artistId);
            var photoToReturn = _mapper.Map<PhotoforReturnDto>(artistPhoto);

            return photoToReturn;
        }

        public async Task<bool> SetNewMainPhoto(PhotoIds photoIds)
        {
            var photoToSetMain = await _artist.GetArtistPhotoByPhotoId(photoIds.PhotoId);
            var currentMainPhoto = await _artist.GetMainArtistPhotoByArtistId(photoIds.ArtistId);
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
        //
        //

        // Private methods
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
        //
    }
}