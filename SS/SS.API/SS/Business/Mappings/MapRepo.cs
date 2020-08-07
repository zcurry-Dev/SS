using System.Collections.Generic;
using System.Linq;
using SS.Business.Calculations;
using SS.Business.Models.Artist;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Models.Utility;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Mappings
{
    public class MapRepo : IMap
    {
        // Admin
        public PagedListDto<UserWithRolesDto> MapToUserWithRolesDto(PagedListData<Ssuser> pl)
        {
            var items = pl.Select(
                u => new UserWithRolesDto()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Roles = u.SsuserRole.Select(r => r.Role.ToString()).ToList(), // is this right?? 062820/070620/070920
                }).ToList();

            var pldto = new PagedListDto<UserWithRolesDto>(items)
            {
                TotalItems = pl.TotalItems,
                ItemsPerPage = pl.ItemsPerPage,
                CurrentPage = pl.CurrentPage,
                TotalPages = pl.TotalPages
            };

            return pldto;
        }

        public IEnumerable<RoleDto> MapToRoleDto(IEnumerable<Ssrole> ssroles)
        {
            var roles = ssroles.Select(r => new RoleDto()
            {
                Id = r.Id,
                Name = r.Name,
                NormalizedName = r.NormalizedName,
                ConcurrencyStamp = r.ConcurrencyStamp,
            });

            return roles;
        }

        // Artist
        public PagedListDto<ArtistForListDto> MapToArtistForListDto(PagedListData<Artist> pl)
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
            }).ToList();

            var pldto = new PagedListDto<ArtistForListDto>(artists)
            {
                TotalItems = pl.TotalItems,
                ItemsPerPage = pl.ItemsPerPage,
                CurrentPage = pl.CurrentPage,
                TotalPages = pl.TotalPages
            }; ;

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
                HomeCity = GetHomeCity(a),
                HomeCountryId = a.HomeCountryId,
                HomeUsStateId = a.HomeUscity?.StateId,
                HomeUsCityId = a.HomeUscityId,
                HomeUsZipCodeId = a.HomeUszipCodeId,
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
                if (a.HomeUscity.CityName != "")
                {
                    return a.HomeUscity.CityName + ", " + a.HomeUscity.State.StateAbbreviation;
                }
                return a.HomeUscity.State.StateAbbreviation;
            }
            if (a.HomeWorldCityId.HasValue)
            {
                return a.HomeWorldCity.CityName + ", " + a.HomeWorldCity.WorldRegion.WorldRegionAbbreviation;
            }

            return "";
        }

        // User        
        public UserDto MapToUserForDetailDto(Ssuser u)
        {
            var user = new UserDto()
            {
                Id = u.Id,
                // Id = u.UserId, // "u.UserId is always 0" -z 062820
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                DateOfBirth = u.DateOfBirth,
                CreatedDate = u.CreatedDate,
                LastActive = u.LastActive,
                UserName = u.UserName,
                DisplayName = u.DisplayName,
            };

            return user;
        }

        public Ssuser MapToSsuser(UserForRegisterDto u)
        {
            var user = new Ssuser()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                CreatedDate = u.Created,
                LastActive = u.LastActive, //does this break? 062820
                UserName = u.UserName
            };

            return user;
        }

        // Utility
        public IEnumerable<CountryDto> MapToCountryDto(IEnumerable<Country> countryList)
        {
            var countries = countryList.Select(c => new CountryDto()
            {
                Id = c.CountryId,
                Name = c.CountryName,
                NameShorter = c.CountryNameShorter,
                Abbreviation2 = c.CountryAbbreviation2,
                Abbreviation3 = c.CountryAbbreviation3,
                Iso3166 = c.Iso3166
            });

            return countries;
        }

        public IEnumerable<UsStateDto> MapToUsStateDto(IEnumerable<Usstate> stateList)
        {
            var usStates = stateList.Select(s => new UsStateDto()
            {
                Id = s.StateId,
                Abbreviation = s.StateAbbreviation,
                Name = s.StateName
            });

            return usStates;
        }

        public IEnumerable<UsCityDto> MapToUsCityDto(IEnumerable<City> cityList)
        {
            var cities = cityList.Select(c => new UsCityDto()
            {
                Id = c.CityId,
                Name = c.CityName,
                ClosestMajorCityId = c.ClosestMajorCityId,
                MajorCity = c.MajorCity
            });

            return cities;
        }

        public IEnumerable<UsZipCodeToReturnDto> MapToUsZipCodeDto(IEnumerable<ZipCode> zipCodeList)
        {
            var zipCodes = zipCodeList.Select(z => new UsZipCodeToReturnDto()
            {
                Id = z.ZipCodeId,
                ZipCode = z.Digits
            });

            return zipCodes;
        }

        public City MapToCity(CityToCreateDto c)
        {
            var city = new City()
            {
                CityName = c.CityName,
                ClosestMajorCityId = c.ClosestMajorCityId,
                StateId = c.StateId
            };

            return city;
        }

        public UsCityDto MapToUsCityDto(City c)
        {
            var city = new UsCityDto()
            {
                Id = c.CityId,
                Name = c.CityName,
                ClosestMajorCityId = c.ClosestMajorCityId,
                MajorCity = c.MajorCity
            };

            return city;
        }

        public ZipCode MapToZipCode(UsZipCodeToCreateDto z)
        {
            var zipCode = new ZipCode()
            {
                Digits = z.ZipCode,
                CityId = z.CityId
            };

            return zipCode;
        }

        public UsZipCodeDto MapToUsZipCodeDto(ZipCode z)
        {
            var zipCode = new UsZipCodeDto()
            {
                Id = z.ZipCodeId,
                ZipCode = z.Digits,
                CityId = z.CityId
            };

            return zipCode;
        }
    }
}