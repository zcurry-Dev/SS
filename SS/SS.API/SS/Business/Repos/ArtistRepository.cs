using System;
using System.Linq;
using System.Threading.Tasks;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Helpers.Pagination;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Repos
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ArtistMapping _map;
        private readonly IArtistDataRepository _artist;

        public ArtistRepository(IArtistDataRepository artist)
        {
            _map = new ArtistMapping();
            _artist = artist;
        }

        public async Task<ArtistBModel> CreateArtist(ArtistToCreateDto artistToCreate)
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

            var artistToReturn = _map.MapToArtistBModel(created);

            if (artistToReturn == null)
            {
                throw new NullReferenceException();
            }

            return artistToReturn;
        }

        public async Task<ArtistListForReturnDto> GetArtists(ArtistParams artistParams)
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
            var artistsToReturn = _map.MapToArtistForListDto(plArtists);
            var artistListForReturnDto = _map.MapToListForReturnDto(artistsToReturn, plArtists);

            return artistListForReturnDto;
        }

        public async Task<ArtistBModel> GetArtistById(int artistId)
        {
            var artist = await _artist.GetArtistById(artistId);
            var artistToReturn = _map.MapToArtistBModel(artist);

            return artistToReturn;
        }

        public async Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = await _artist.GetArtistById(artistId);
            _map.MapToArtist(artistForUpdateDto, artist);

            var result = await _artist.SaveAll();

            return result;
        }
    }
}