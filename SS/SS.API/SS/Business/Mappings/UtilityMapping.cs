using System.Collections.Generic;
using System.Linq;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Models;
using SS.Data.Models;

namespace SS.Business.Mappings
{
    public class UtilityMapping
    {
        public IEnumerable<CountryBModel> MapToCountriesDto(IEnumerable<Country> countryList)
        {
            var countries = countryList.Select(c => new CountryBModel()
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

        public IEnumerable<UsStateBModel> MapToUsStatesDto(IEnumerable<Usstate> stateList)
        {
            var usStates = stateList.Select(s => new UsStateBModel()
            {
                Id = s.StateId,
                Abbreviation = s.StateAbbreviation,
                Name = s.StateName
            });

            return usStates;
        }

        public IEnumerable<UsCityBModel> MapToUsCitiesDto(IEnumerable<City> cityList)
        {
            var usCities = cityList.Select(c => new UsCityBModel()
            {
                Id = c.CityId,
                Name = c.CityName,
                ClosestMajorCityId = c.ClosestMajorCityId,
                StateId = c.StateId,
                MajorCity = c.MajorCity
            }).ToList();

            return usCities;
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

        public UsCityBModel MapToUsCityBModel(City c)
        {
            var city = new UsCityBModel()
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

        public ZipCodeBModel MapToZipCodeBModel(ZipCode z)
        {
            var zipCode = new ZipCodeBModel()
            {
                Id = z.ZipCodeId,
                ZipCode = z.ZipCode1,
                CityId = z.CityId
            };

            return zipCode;
        }
    }
}