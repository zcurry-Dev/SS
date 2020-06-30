using System.Collections.Generic;
using System.Threading.Tasks;
using SS.Business.Models;
using SS.Business.Models.Utility;

namespace SS.Business.Interfaces
{
    public interface IUtilityRepository
    {
        Task<IEnumerable<CountryDto>> GetCountries();
        Task<IEnumerable<UsStateDto>> GetUsStates();
        Task<IEnumerable<UsCityDto>> GetUsCities(int usStateId);
        Task<IEnumerable<ZipCodeDto>> GetZipCodes(int usCityId);
        Task<UsCityDto> CreateCity(CityToCreateDto cityToCreateDto);
        Task<ZipCodeDto> CreateZipCode(ZipCodeToCreateDto zipCodeToCreateDto);
    }
}