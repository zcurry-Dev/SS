using System.Threading.Tasks;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Business.Mappings;

namespace SS.Business.Repos
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly UtilityMapping _map;
        private readonly IUtilityDataRepository _utility;

        public UtilityRepository(IUtilityDataRepository utility)
        {
            _map = new UtilityMapping();
            _utility = utility;
        }

        public async Task<CountriesToReturnDto> GetCountries()
        {
            var countries = await _utility.GetCountries();
            var countriesToReturnDto = _map.MapToCountriesDto(countries);
            return countriesToReturnDto;
        }

        public async Task<UsStatesToReturnDto> GetUsStates()
        {
            var usStates = await _utility.GetUsStates();
            var usStatesToReturnDto = _map.MapToUsStatesDto(usStates);
            return usStatesToReturnDto;
        }

        public async Task<UsCitiesToReturnDto> GetUsCities(int usStateId)
        {
            var usCities = await _utility.GetUSCities(usStateId);
            var usCitiesToReturnDto = _map.MapToUsCitiesDto(usCities);
            return usCitiesToReturnDto;
        }
    }
}