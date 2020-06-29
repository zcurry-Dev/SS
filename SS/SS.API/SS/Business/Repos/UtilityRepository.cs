using System.Collections.Generic;
using System.Threading.Tasks;
using SS.Business.Dtos.Accept;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Mappings.Repos;
using SS.Business.Models;

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

        public async Task<IEnumerable<CountryBModel>> GetCountries()
        {
            var countries = await _utility.GetCountries();
            var countriesToReturn = _map.MapToCountryBModel(countries);
            return countriesToReturn;
        }

        public async Task<IEnumerable<UsStateBModel>> GetUsStates()
        {
            var usStates = await _utility.GetUsStates();
            var statesToReturn = _map.MapToUsStateBModel(usStates);
            return statesToReturn;
        }

        public async Task<IEnumerable<UsCityBModel>> GetUsCities(int usStateId)
        {
            var usCities = await _utility.GetUSCities(usStateId);
            var citiesToReturn = _map.MapToUsCityBModel(usCities);
            return citiesToReturn;
        }

        public async Task<IEnumerable<ZipCodeBModel>> GetZipCodes(int usCityId)
        {
            var zipCodes = await _utility.GetZipCodes(usCityId);
            var zipCodesToReturn = _map.MapToZipCodeBModel(zipCodes);
            return zipCodesToReturn;
        }

        public async Task<UsCityBModel> CreateCity(CityToCreateDto cityToCreateDto)
        {
            var newCity = _map.MapToCity(cityToCreateDto);
            var created = await _utility.CreateCity(newCity);
            var result = _map.MapToUsCityBModel(created);

            return result;
        }

        public async Task<ZipCodeBModel> CreateZipCode(ZipCodeToCreateDto zipCodeToCreateDto)
        {
            var newZipCode = _map.MapToZipCode(zipCodeToCreateDto);
            var created = await _utility.CreateZipCode(newZipCode);
            var result = _map.MapToZipCodeBModel(created);

            return result;
        }
    }
}