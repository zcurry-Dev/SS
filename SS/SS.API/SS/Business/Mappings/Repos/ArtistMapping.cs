using System.Collections.Generic;
using System.Linq;
using SS.Business.Calculations;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Artist;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Mappings.Repos
{
    public class ArtistMapping : IArtistMapping
    {
        public PagedListDto<ArtistForListDto> MapToArtistForListDto(PagedList<Artist> pl)
        {
            var artists = pl.Select(a => new ArtistForListDto
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

            var pldto = new PagedListDto<ArtistForListDto>
            {
                Items = artists,
                CurrentPage = pl.CurrentPage,
                TotalPages = pl.TotalPages,
                ItemsPerPage = pl.ItemsPerPage,
                TotalItems = pl.TotalItems,
            };

            return pldto;
        }

        public ArtistDetailDto MapToArtistDetailDto(Artist a)
        {
            var artist = new ArtistDetailDto()
            {
                Id = a.ArtistId,
                Name = a.ArtistName,
                StatusId = a.ArtistStatusId,
                CareerBeginDate = a.CareerBeginDate,
                CareerEndDate = a.CareerEndDate,
                Group = a.ArtistGroup,
                UserId = a.UserId,
                Verified = a.Verified,
                HomeCountryId = a.HomeCountryId,
                HomeUsStateId = a.HomeUscity?.StateId,
                HomeUsCityId = a.HomeUscityId,
                HomeUsZipCodeId = a.HomeUscity?.ZipCode?.Where(z => z.CityId == a.HomeUscityId).FirstOrDefault()?.ZipCodeId,
                HomeWorldRegionId = a.HomeWorldCity?.WorldRegionId,
                HomeWorldCityId = a.HomeWorldCityId,
                CurrentCountryId = a.CurrentCountryId,
                CurrentUscityId = a.CurrentUscityId,
                CurrentWorldCityId = a.CurrentWorldCityId,
                CreatedBy = a.CreatedBy,
                CreatedDate = a.CreatedDate,
                YearsActive = ArtistCalculations.CalculateArtistYearsActive(a.CareerBeginDate, a.CareerEndDate),
            };

            return artist;
        }

        public void Update(ArtistForUpdateDto a, Artist artist)
        {
            artist.ArtistName = a.Name;
            artist.ArtistStatusId = a.StatusId;
            artist.ArtistGroup = a.Group;
            artist.UserId = a.UserId;
            artist.HomeCountryId = a.HomeCountryId;
            artist.HomeUscityId = a.HomeUsCityId;
            artist.HomeUszipCodeId = a.HomeUsZipCodeId;
            artist.HomeWorldCityId = a.HomeWorldCityId;
        }

        public Artist MapToArtist(ArtistToCreateDto a)
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