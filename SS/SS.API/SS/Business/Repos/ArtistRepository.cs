using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Helpers;
using SS.Helpers.Pagination;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Repos
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

            // var artistForDetailedDto = _mapper.Map<ArtistForDetailedDto>(artist);
            var artistForDetailedDto = MapToDetailedDto(artist);

            if (artistForDetailedDto == null)
            {
                throw new NullReferenceException();
            }

            return artistForDetailedDto;
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
            var artistsToReturn = MapToArtistForListDto(plArtists);
            var artistListForReturnDto = MapToListForReturnDto(artistsToReturn, plArtists);

            return artistListForReturnDto;
        }

        public async Task<ArtistForDetailedDto> GetArtistById(int artistId)
        {
            var artist = await _artist.GetArtistById(artistId);
            var artistToReturn = MapToDetailedDto(artist);

            return artistToReturn;
        }

        public async Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = await _artist.GetArtistById(artistId);
            MapToArtist(artistForUpdateDto, artist);

            var result = await _artist.SaveAll();

            return result;
        }


        private IEnumerable<ArtistForListDto> MapToArtistForListDto(PagedList<Artist> artistList)
        {
            var artistForListDto = artistList.Select(a => new ArtistForListDto
            {
                Id = a.ArtistId,
                Name = a.ArtistName,
                ArtistStatusId = a.ArtistStatusId,
                YearsActive = a.CareerBeginDate.CalculateArtistYearsActive(),
                ArtistGroup = a.ArtistGroup,
                UserId = a.UserId,
                Verified = a.Verified,
                // CurrentCity = a.CurrentCity.CityName,
                HomeCity = GetHomeCity(a)
            });

            return artistForListDto;
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

        private ArtistListForReturnDto MapToListForReturnDto(
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

        private ArtistForDetailedDto MapToDetailedDto(Artist a)
        {
            var artistForUpdateDto = new ArtistForDetailedDto()
            {
                Id = a.ArtistId,
                Name = a.ArtistName,
                StatusId = a.ArtistStatusId,
                CareerBeginDate = a.CareerBeginDate,
                YearsActive = a.CareerBeginDate.CalculateArtistYearsActive(),
                ArtistGroup = a.ArtistGroup,
                UserId = a.UserId,
                Verified = a.Verified,
                HomeCountryId = a.HomeCountryId,
                HomeRegionId = a.HomeUscityId.HasValue
                     ? a.HomeUscity.StateId
                     : a.HomeWorldCity.WorldRegionId,
                HomeCityId = a.HomeUscityId.HasValue
                     ? a.HomeUscityId.Value
                     : a.HomeWorldCityId.Value,
                CurrentCountryId = a.CurrentCountryId,
                CreatedDate = a.CreatedDate
            };

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

        private void MapToArtist(ArtistForUpdateDto artistForUpdateDto, Artist artist)
        {
            artist.ArtistName = artistForUpdateDto.Name;
            artist.CareerBeginDate = artistForUpdateDto.CareerBeginDate;
            artist.ArtistGroup = artistForUpdateDto.Group;
            artist.UserId = artistForUpdateDto.UserId;
            artist.Verified = artistForUpdateDto.Verified;
            artist.HomeCountryId = artistForUpdateDto.HomeCountryId;
            artist.HomeUscityId = artistForUpdateDto.UshomeCityId;
            artist.HomeWorldCityId = artistForUpdateDto.WorldHomeCityId;
            // artist.CurrentCountryId = artistForUpdateDto.
            // artist.CurrentCityId = artistForUpdateDto.CurrentCityId;

            if (artistForUpdateDto.StatusId != null)
            {
                artist.ArtistStatusId = artistForUpdateDto.StatusId;
            }
        }
    }
}