using System;
using System.Threading.Tasks;
using SS.Business.Enums;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.Artist;
using SS.Business.Pagination;
using SS.Data.Interfaces;

namespace SS.Business.Repos
{
    public class ArtistRepo : IArtist
    {
        private readonly IArtistData _artist;
        private readonly IUtility _utility;
        private readonly IMap _map;

        public ArtistRepo(
            IArtistData artist,
            IUtility utility,
            IMap map
            )
        {
            _artist = artist;
            _utility = utility;
            _map = map;
        }

        public async Task<ArtistDetailDto> CreateArtistAsync(ArtistToCreateDto artistToCreate)
        {
            var created = _map.MapToArtist(artistToCreate);
            _artist.Add(created);
            var result = await _artist.SaveAllAsync();
            var artistToReturn = _map.MapToArtistDetailDto(created);

            return artistToReturn;
        }

        public async Task<PagedListDto<ArtistForListDto>> GetArtistsAsync(ArtistPageParams p)
        {
            var pagedList = await _artist.GetArtistsAsync(p.PN, p.IPP, p.Search, p.OrderBy);
            var artistsForList = _map.MapToArtistForListDto(pagedList);

            return artistsForList;
        }

        public async Task<ArtistDetailDto> GetArtistAsync(int artistId)
        {
            var artist = await _artist.GetByIdAsync(artistId);
            var artistToReturn = _map.MapToArtistDetailDto(artist);

            return artistToReturn;
        }

        public async Task<Result> UpdateArtistAsync(int artistId, ArtistForUpdateDto a)
        {
            var validValues = ArtistAttributesValid(a);
            if (validValues)
            {
                if (a.HomeCountryId == 1)
                {
                    await USCheckForNewLocations(a);
                }
                else
                {
                    // await UpdateWorldArtist(a);
                }

                var artist = await _artist.GetByIdAsync(artistId);
                _map.Update(a, artist);

                if (_artist.ContextUpdated())
                {
                    if (await _artist.SaveAllAsync())
                    {
                        return Result.Pass;
                    }
                    else return Result.Fail;
                }
                else return Result.NoChange;
            }

            return Result.Fail;
        }

        private async Task USCheckForNewLocations(ArtistForUpdateDto a)
        {
            if (a.HomeUsCityId == null && a.HomeUsCity != null)
            {
                a.HomeUsCityId = await _utility.CreateCityAsync(a.HomeUsCity, a.HomeUsStateId.Value);
            }

            if (a.HomeUsZipCodeId == null && a.HomeUsZipcode != null)
            {
                a.HomeUsZipCodeId = await _utility.CreateZipCodeAsync(a.HomeUsZipcode, a.HomeUsCityId.Value);
            }
        }

        // private async Task UpdateWorldArtist(ArtistForUpdateDto a)
        // {
        //     if (a.HomeWorldRegionId == null && a.HomeWorldRegion != null)
        //     {
        //         // a.HomeWorldRegionId = await _utility.GetNewWorldRegionId(a.HomeWorldRegion, a.HomeCountryId);
        //     }
        //     if (a.HomeWorldCityId == null && a.HomeWorldCity != null)
        //     {
        //         // a.HomeWorldCityId = await _utility.GetNewWorldCityId(a.HomeWorldCity, a.HomeWorldRegionId);
        //     }
        // }

        private bool ArtistAttributesValid(ArtistForUpdateDto a)
        {
            if (a.HomeCountryId == 1)
            {


                a.HomeWorldRegionId = null;
                a.HomeWorldCityId = null;
                return true;
            }

            if (a.HomeCountryId > 1)
            {

                a.HomeUsStateId = null;
                a.HomeUsCityId = null;
                a.HomeUsCity = null;
                a.HomeUsCityId = null;
                a.HomeUsCityId = null;
                a.HomeUsCityId = null;

                return true;
            }

            return false;
        }
    }
}