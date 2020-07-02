using System;
using System.Linq;
using System.Threading.Tasks;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Business.Models.Utility;
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
        private readonly IUtilityRepository _utility;

        public ArtistRepository(IArtistDataRepository artist, IArtistMapping map, IUtilityRepository utility)
        {
            _artist = artist;
            _map = map;
            _utility = utility;
        }

        public async Task<Models.Artist.ArtistDto> CreateArtist(ArtistToCreateDto artistToCreate)
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

            var artistToReturn = _map.MapToArtistDetailDto(created);

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

            var plArtists = await PagedList<Data.Models.Artist>.CreateAsync(artists, artistParams.PN, artistParams.PS);
            var artistsToReturn = _map.MapToListForReturnDto(plArtists);

            return artistsToReturn;
        }

        public async Task<Models.Artist.ArtistDto> GetArtistById(int artistId)
        {
            var artist = await _artist.GetArtistById(artistId);
            var artistToReturn = _map.MapToArtistDetailDto(artist);

            return artistToReturn;
        }

        public async Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto a)
        {
            var result = ArtistAttributesValid(a);
            if (result)
            {
                if (a.HomeUsCityId == null && a.HomeUsCity != null)
                {
                    a.HomeUsCityId = await _utility.GetNewCityId(a.HomeUsCity, a.HomeUsStateId.Value);
                }

                if (a.HomeUsZipCodeId == null && a.HomeUsZipcode != null)
                {
                    a.HomeUsZipCodeId = await _utility.GetNewZipCodeId(a.HomeUsZipcode, a.HomeUsCityId.Value);
                }

                var artist = await _artist.GetArtistById(artistId);
                _map.UpdateArtist(a, artist);

                result = await _artist.SaveAll();
            }

            return result;
        }

        private bool ArtistAttributesValid(ArtistForUpdateDto artistForUpdateDto)
        {
            // check if us, then us attributes

            // if other country, then world attributes
            return true;
        }
    }
}