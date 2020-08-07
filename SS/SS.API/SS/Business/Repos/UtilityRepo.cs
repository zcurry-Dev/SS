using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.Utility;
using SS.Data.Interfaces;
using SS.Data.Repos;

namespace SS.Business.Repos
{
    public class UtilityRepo : IUtility
    {
        private readonly ICountryData _country;
        private readonly IUsStateData _usState;
        private readonly IUsCityData _usCity;
        private readonly IUsZipCodeData _usZipCode;
        private readonly IMap _map;

        public UtilityRepo(
            ICountryData country,
            IUsStateData usState,
            IUsCityData usCity,
            IUsZipCodeData usZipCode,
            IMap map)
        {
            _country = country;
            _usState = usState;
            _usCity = usCity;
            _usZipCode = usZipCode;
            _map = map;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            var countries = await _country.GetAllAsync();
            var countriesToReturn = _map.MapToCountryDto(countries);
            return countriesToReturn;
        }

        public async Task<IEnumerable<UsStateDto>> GetUsStatesAsync()
        {
            var usStates = await _usState.GetAllAsync();
            var statesToReturn = _map.MapToUsStateDto(usStates);
            return statesToReturn;
        }

        public async Task<IEnumerable<UsCityDto>> GetUsCitiesAsync(int usStateId)
        {
            var usCities = await _usCity.FindManyAsync(c => c.StateId == usStateId);
            var citiesToReturn = _map.MapToUsCityDto(usCities);
            return citiesToReturn;
        }

        public async Task<IEnumerable<UsZipCodeToReturnDto>> GetZipCodesAsync(int usCityId)
        {
            var zipCodes = await _usZipCode.FindManyAsync(z => z.CityId == usCityId);
            var zipCodesToReturn = _map.MapToUsZipCodeDto(zipCodes);
            return zipCodesToReturn;
        }

        public async Task<int> LookForExistingCityInState(string cityName, int stateId)
        {
            var foundCity = await _usCity.FindAsync(c => c.StateId == stateId && c.CityName == cityName);
            if (foundCity != null)
            {
                return foundCity.CityId;
            }

            return await CreateCityAsync(cityName, stateId);
        }

        public async Task<int> LookForExistingZipCodeInCity(string zipCode, int cityId)
        {
            var foundZipCode = await _usZipCode.FindAsync(z => z.CityId == cityId && z.Digits == zipCode);
            if (foundZipCode != null)
            {
                return foundZipCode.CityId;
            }

            return await CreateZipCodeAsync(zipCode, cityId);
        }

        public async Task<UsCityDto> CreateCityAsync(CityToCreateDto d)
        {
            var newCity = _map.MapToCity(d);
            var matchingCities = await _usCity.FindManyAsync(c => c.StateId == d.StateId && c.CityName == d.CityName);
            var saved = false;
            if (!matchingCities.Any())
            {
                _usCity.Add(newCity);
                saved = await _usCity.SaveAllAsync();
            }

            if (!saved) { return new UsCityDto { Id = -1 }; }
            var dtoToReturn = _map.MapToUsCityDto(newCity);

            return dtoToReturn;
        }

        public async Task<UsZipCodeDto> CreateZipCodeAsync(UsZipCodeToCreateDto d)
        {
            var newZipCode = _map.MapToZipCode(d);
            var matchingZipCodes = await _usZipCode.FindManyAsync(z => z.CityId == d.CityId && z.Digits == d.ZipCode);
            var saved = false;
            if (!matchingZipCodes.Any())
            {
                _usZipCode.Add(newZipCode);
                saved = await _usZipCode.SaveAllAsync();
            }

            if (!saved) { return new UsZipCodeDto { Id = -1 }; }
            var dtoToReturn = _map.MapToUsZipCodeDto(newZipCode);

            return dtoToReturn;
        }

        // public async Task<ZipCodeDto> CreateWorldRegion(WorldRegionToCreateDto worldRegionToCreateDto)
        // {
        //     // var newZipCode = _map.MapToZipCode(zipCodeToCreateDto);
        //     // var created = await _utility.CreateZipCode(newZipCode);
        //     // var result = _map.MapToZipCodeDto(created);

        //     // return result;
        // }

        public async Task<int> CreateCityAsync(string name, int stateId)
        {
            var city = new CityToCreateDto()
            {
                CityName = name,
                StateId = stateId
            };

            var cityToReturn = await CreateCityAsync(city);

            return cityToReturn.Id;
        }

        public async Task<int> CreateZipCodeAsync(string zipCodeDigits, int cityId)
        {
            var zipCode = new UsZipCodeToCreateDto()
            {
                ZipCode = zipCodeDigits,
                CityId = cityId
            };

            var cityToReturn = await CreateZipCodeAsync(zipCode);

            return cityToReturn.Id;
        }

        public async Task<int> GetNewWorldRegionId(string zipCodeDigits, int cityId)
        {
            var zipCode = new UsZipCodeToCreateDto()
            {
                ZipCode = zipCodeDigits,
                CityId = cityId
            };

            var cityToReturn = await CreateZipCodeAsync(zipCode);

            return cityToReturn.Id;
        }
        // a.HomeWorldRegionId = await _utility.GetNewWorldRegionId(a.HomeWorldRegion, a.HomeCountryId);

    }
}