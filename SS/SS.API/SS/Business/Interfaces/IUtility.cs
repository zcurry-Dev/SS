using System.Collections.Generic;
using System.Threading.Tasks;
using SS.Business.Models.Utility;

namespace SS.Business.Interfaces
{
    public interface IUtility
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();
        Task<IEnumerable<UsStateDto>> GetUsStatesAsync();
        Task<IEnumerable<UsCityDto>> GetUsCitiesAsync(int usStateId);
        Task<int> LookForExistingCityInState(string cityName, int stateId);
        Task<int> LookForExistingZipCodeInCity(string zipCode, int cityId);
        Task<IEnumerable<UsZipCodeToReturnDto>> GetZipCodesAsync(int usCityId);
        Task<UsCityDto> CreateCityAsync(CityToCreateDto cityToCreateDto);
        Task<UsZipCodeDto> CreateZipCodeAsync(UsZipCodeToCreateDto zipCodeToCreateDto);
        Task<int> CreateCityAsync(string name, int stateId);
        Task<int> CreateZipCodeAsync(string zipCodeDigits, int cityId);
    }
}