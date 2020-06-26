using System.Collections.Generic;
using System.Linq;
using SS.Business.Calculations;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings
{
    public class ArtistMapping
    {
        public IEnumerable<ArtistForListDto> MapToArtistForListDto(PagedList<Artist> artistList)
        {
            var artistForListDto = artistList.Select(a => new ArtistForListDto
            {
                Id = a.ArtistId,
                Name = a.ArtistName,
                ArtistStatusId = a.ArtistStatusId,
                YearsActive = ArtistCalculations.CalculateArtistYearsActive(a.CareerBeginDate, a.CareerEndDate),
                ArtistGroup = a.ArtistGroup,
                UserId = a.UserId,
                Verified = a.Verified,
                HomeCity = GetHomeCity(a)
            });

            return artistForListDto;
        }

        public ArtistListForReturnDto MapToListForReturnDto(
            IEnumerable<ArtistForListDto> artistsToReturn, PagedList<Artist> plArtists)
        {
            var artistListForReturnDto = new ArtistListForReturnDto()
            {
                Artists = artistsToReturn,
                CurrentPage = plArtists.CurrentPage,
                TotalPages = plArtists.TotalPages,
                PageSize = plArtists.PageSize,
                TotalCount = plArtists.TotalCount
            };

            return artistListForReturnDto;
        }

        public ArtistForDetailedDto MapToDetailedDto(Artist a)
        {
            var artistForUpdateDto = new ArtistForDetailedDto()
            {
                Id = a.ArtistId,
                Name = a.ArtistName,
                StatusId = a.ArtistStatusId,
                CareerBeginDate = a.CareerBeginDate,
                CareerEndDate = a.CareerEndDate,
                ArtistGroup = a.ArtistGroup,
                UserId = a.UserId,
                Verified = a.Verified,
                YearsActive = ArtistCalculations.CalculateArtistYearsActive(a.CareerBeginDate, a.CareerEndDate),
                HomeCountryId = a.HomeCountryId,
                CurrentCountryId = a.CurrentCountryId,
                CreatedDate = a.CreatedDate
            };

            if (a.HomeUscityId.HasValue)
            {
                artistForUpdateDto.HomeRegionId = a.HomeUscity.StateId;
                artistForUpdateDto.HomeCityId = a.HomeUscityId;
            }
            else if (a.HomeWorldCityId.HasValue)
            {
                artistForUpdateDto.HomeRegionId = a.HomeWorldCity.WorldRegionId;
                artistForUpdateDto.HomeCityId = a.HomeWorldCityId;
            }

            if (a.CurrentUscityId.HasValue)
            {
                artistForUpdateDto.CurrentRegionId = a.CurrentUscity.StateId;
                artistForUpdateDto.CurrentCityId = a.CurrentUscityId;
            }
            else if (a.CurrentWorldCityId.HasValue)
            {
                artistForUpdateDto.CurrentRegionId = a.CurrentWorldCity.WorldRegionId;
                artistForUpdateDto.CurrentCityId = a.CurrentWorldCityId;
            }

            return artistForUpdateDto;
        }

        public void MapToArtist(ArtistForUpdateDto a, Artist artist)
        {
            artist.ArtistName = a.Name;
            artist.CareerBeginDate = a.CareerBeginDate;
            artist.ArtistGroup = a.Group;
            artist.UserId = a.UserId;
            artist.Verified = a.Verified;
            artist.HomeCountryId = a.HomeCountryId;
            artist.HomeUscityId = a.UshomeCityId;
            artist.HomeWorldCityId = a.WorldHomeCityId;
            // artist.CurrentCountryId = artistForUpdateDto.
            // artist.CurrentCityId = artistForUpdateDto.CurrentCityId;

            if (a.StatusId != null)
            {
                artist.ArtistStatusId = a.StatusId;
            }
        }

        public Artist MapToArtist(ArtistToCreate a)
        {
            var artist = new Artist()
            {
                ArtistName = a.Name,
                CareerBeginDate = a.CareerBeginDate,
                ArtistGroup = a.ArtistGroup,
                Verified = a.Verified,
                HomeCountryId = a.HomeCountryId,
                CurrentCountryId = a.CurrentCountryId,
                CreatedBy = a.CreatedBy,
                CreatedDate = a.CreatedDate
            };

            return artist;
        }

        private string GetHomeCity(Artist a)
        {
            if (a.HomeUscityId.HasValue)
            {
                return a.HomeUscity.CityName + ", " + a.HomeUscity.State.StateAbbreviation;
            }
            if (a.HomeWorldCityId.HasValue)
            {
                return a.HomeWorldCity.CityName + ", " + a.HomeWorldCity.WorldRegion.WorldRegionAbbreviation;
            }

            return "";
        }
    }
}