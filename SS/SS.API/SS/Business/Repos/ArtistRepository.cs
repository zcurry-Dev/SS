using System;
using System.Linq;
using System.Threading.Tasks;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Helpers.Pagination;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Repos
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IArtistDataRepository _artist;
        private readonly IArtistMapping _map;

        public ArtistRepository(IArtistDataRepository artist, IArtistMapping map)
        {
            _map = map;
            _artist = artist;
        }

        public async Task<ArtistDto> CreateArtist(ArtistToCreateDto artistToCreate)
        {
            var created = _map.MapToArtist(artistToCreate);

            if (created == null)
            {
                throw new NullReferenceException();
            }

            _artist.Add(created);
            var result = await _artist.SaveAll();

            if (!result)
            {
                throw new NullReferenceException();
            }

            var artistToReturn = _map.MapToArtistDto(created);

            if (artistToReturn == null)
            {
                throw new NullReferenceException();
            }

            return artistToReturn;
        }

        public async Task<PagedListDto<ArtistForListDto>> GetArtists(ArtistParams artistParams)
        {
            var artists = _artist.GetArtists().AsQueryable();

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

            var plArtists = await PagedList<Artist>.CreateAsync(artists, artistParams.PN, artistParams.PS);
            var artistsToReturn = _map.MapToListForReturnDto(plArtists);

            return artistsToReturn;
        }

        public async Task<ArtistDto> GetArtistById(int artistId)
        {
            var artist = await _artist.GetArtistById(artistId);
            var artistToReturn = _map.MapToArtistDto(artist);

            return artistToReturn;
        }

        public async Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = await _artist.GetArtistById(artistId);
            _map.MapArtist(artistForUpdateDto, artist);

            var result = await _artist.SaveAll();

            return result;
        }
    }
}