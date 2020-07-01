using System.Collections.Generic;
using SS.Business.Models.Utility;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IUtilityMapping
    {
        IEnumerable<CountryDto> MapToCountryDto(IEnumerable<Country> countryList);
        IEnumerable<UsStateDto> MapToUsStateDto(IEnumerable<Usstate> stateList);
        City MapToCity(CityToCreateDto c);
        IEnumerable<UsCityDto> MapToUsCityDto(IEnumerable<City> cityList);
        UsCityDto MapToUsCityDto(City c);
        IEnumerable<ZipCodeToReturnDto> MapToZipCodeToReturnDto(IEnumerable<ZipCode> zipCodeList);
        ZipCode MapToZipCode(ZipCodeToCreateDto z);
        ZipCodeDto MapToZipCodeDto(ZipCode z);
    }
}