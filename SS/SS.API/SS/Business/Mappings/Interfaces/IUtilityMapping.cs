using System.Collections.Generic;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Models;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IUtilityMapping
    {
        IEnumerable<CountryBModel> MapToCountryBModel(IEnumerable<Country> countryList);
        IEnumerable<UsStateBModel> MapToUsStateBModel(IEnumerable<Usstate> stateList);
        IEnumerable<UsCityBModel> MapToUsCityBModel(IEnumerable<City> cityList);
        IEnumerable<ZipCodeBModel> MapToZipCodeBModel(IEnumerable<ZipCode> zipCodeList);
        City MapToCity(CityToCreateDto c);
        UsCityBModel MapToUsCityBModel(City c);
        ZipCode MapToZipCode(ZipCodeToCreateDto z);
        ZipCodeBModel MapToZipCodeBModel(ZipCode z);
    }
}