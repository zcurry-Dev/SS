using System.Collections.Generic;
using System.Linq;
using SS.Business.Dtos.Accept;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models;
using SS.Data.Models;

namespace SS.Business.Mappings.Repos
{
    public class UtilityMapping : IUtilityMapping
    {
        public IEnumerable<CountryBModel> MapToCountryBModel(IEnumerable<Country> countryList)
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

        public IEnumerable<UsStateBModel> MapToUsStateBModel(IEnumerable<Usstate> stateList)
        {
            var usStates = stateList.Select(s => new UsStateBModel()
            {
                Id = s.StateId,
                Abbreviation = s.StateAbbreviation,
                Name = s.StateName
            });

            return usStates;
        }

        public IEnumerable<UsCityBModel> MapToUsCityBModel(IEnumerable<City> cityList)
        {
            var cities = cityList.Select(c => new UsCityBModel()
            {
                Id = c.CityId,
                Name = c.CityName,
                ClosestMajorCityId = c.ClosestMajorCityId,
                StateId = c.StateId,
                MajorCity = c.MajorCity
            });

            return cities;
        }

        public IEnumerable<ZipCodeBModel> MapToZipCodeBModel(IEnumerable<ZipCode> zipCodeList)
        {
            var zipCodes = zipCodeList.Select(z => new ZipCodeBModel()
            {
                Id = z.ZipCodeId,
                ZipCode = z.ZipCode1,
                CityId = z.CityId
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