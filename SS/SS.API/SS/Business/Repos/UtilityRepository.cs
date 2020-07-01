using System.Collections.Generic;
using System.Threading.Tasks;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Utility;

namespace SS.Business.Repos
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly IUtilityMapping _map;
        private readonly IUtilityDataRepository _utility;

        public UtilityRepository(IUtilityDataRepository utility, IUtilityMapping map)
        {
            _map = map;
            _utility = utility;
        }

        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            var countries = await _utility.GetCountries();
            var countriesToReturn = _map.MapToCountryDto(countries);
            return countriesToReturn;
        }

        public async Task<IEnumerable<UsStateDto>> GetUsStates()
        {
            var usStates = await _utility.GetUsStates();
            var statesToReturn = _map.MapToUsStateDto(usStates);
            return statesToReturn;
        }

        public async Task<IEnumerable<UsCityDto>> GetUsCities(int usStateId)
        {
            var usCities = await _utility.GetUSCities(usStateId);
            var citiesToReturn = _map.MapToUsCityDto(usCities);
            return citiesToReturn;
        }

        public async Task<IEnumerable<ZipCodeDto>> GetZipCodes(int usCityId)
        {
            var zipCodes = await _utility.GetZipCodes(usCityId);
            var zipCodesToReturn = _map.MapToZipCodeDto(zipCodes);
            return zipCodesToReturn;
        }

        public async Task<UsCityDto> CreateCity(CityToCreateDto cityToCreateDto)
        {
            var newCity = _map.MapToCity(cityToCreateDto);
            var created = await _utility.CreateCity(newCity);
            var result = _map.MapToUsCityDto(created);

            return result;
        }

        public async Task<ZipCodeDto> CreateZipCode(ZipCodeToCreateDto zipCodeToCreateDto)
        {
            var newZipCode = _map.MapToZipCode(zipCodeToCreateDto);
            var created = await _utility.CreateZipCode(newZipCode);
            var result = _map.MapToZipCodeDto(created);

            return result;
        }
    }
}