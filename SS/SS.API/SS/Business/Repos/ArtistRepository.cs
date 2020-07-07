using System;
using System.Linq;
using System.Threading.Tasks;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models;
using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Data.Repos;
using SS.Helpers.Enums;
using SS.Helpers.Pagination;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Repos
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IArtistDataRepository _artist;
        private readonly IArtistMapping _map;
        private readonly IUtilityRepository _utility;

        public ArtistRepository(IArtistMapping map, IUtilityRepository utility, IArtistDataRepository artist)
        {
            _artist = artist;
            _map = map;
            _utility = utility;
        }

        public async Task<ArtistDetailDto> CreateArtist(ArtistToCreateDto artistToCreate)
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

        public async Task<PagedListDto<ArtistForListDto>> GetArtists(ArtistParams p)
        {
            string orderBy = p.OrderBy;
            string search = p.Search;

            var artists = await _artist.GetArtistsForList(p.PN, p.PS); // what are the values of 2 above values?            
                                                                       // var dto = _map.MapToArtistForListDtoAsQueryable(artists); // wait, this may break either here or in paged list? can't remember
                                                                       // var pagedList = await PagedList<ArtistForListDto>.CreateAsync(dto, p.PN, p.PS);
                                                                       // var pagedListDto = _map.MapToPagedListDto(pagedList);


            var pagedList = PagedList<Artist>.CreateAsync(artists, p.PN, p.PS);
            var pagedListDto = _map.MapToListForReturnDto(pagedList);

            return pagedListDto;
        }

        public async Task<ArtistDto> GetArtistById(int artistId)
        {
            var artist = await _artist.GetById(artistId);
            var artistToReturn = _map.MapToArtistDetailDto(artist);

            return artistToReturn;
        }

        public async Task<Result> UpdateArtist(int artistId, ArtistForUpdateDto a)
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

                var artist = await _artist.GetById(artistId);
                _map.Update(a, artist);

                if (_artist.ContextUpdated())
                {
                    if (await _artist.SaveAll())
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
                a.HomeUsCityId = await _utility.GetNewCityId(a.HomeUsCity, a.HomeUsStateId.Value);
            }

            if (a.HomeUsZipCodeId == null && a.HomeUsZipcode != null)
            {
                a.HomeUsZipCodeId = await _utility.GetNewZipCodeId(a.HomeUsZipcode, a.HomeUsCityId.Value);
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