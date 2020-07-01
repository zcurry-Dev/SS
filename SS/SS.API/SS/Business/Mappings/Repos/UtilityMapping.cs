using System.Collections.Generic;
using System.Linq;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Utility;
using SS.Data.Models;

namespace SS.Business.Mappings.Repos
{
    public class UtilityMapping : IUtilityMapping
    {
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
                StateId = c.StateId,
                MajorCity = c.MajorCity
            });

            return cities;
        }

        public IEnumerable<ZipCodeToReturnDto> MapToZipCodeToReturnDto(IEnumerable<ZipCode> zipCodeList)
        {
            var zipCodes = zipCodeList.Select(z => new ZipCodeToReturnDto()
            {
                Id = z.ZipCodeId,
                ZipCode = z.ZipCode1
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
                StateId = c.StateId,
                MajorCity = c.MajorCity
            };

            return city;
        }

        public ZipCode MapToZipCode(ZipCodeToCreateDto z)
        {
            var zipCode = new ZipCode()
            {
                ZipCode1 = z.ZipCode,
                CityId = z.CityId
            };

            return zipCode;
        }

        public ZipCodeDto MapToZipCodeDto(ZipCode z)
        {
            var zipCode = new ZipCodeDto()
            {
                Id = z.ZipCodeId,
                ZipCode = z.ZipCode1,
                CityId = z.CityId
            };

            return zipCode;
        }
    }
}