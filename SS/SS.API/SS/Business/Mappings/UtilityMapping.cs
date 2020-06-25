using System.Collections.Generic;
using System.Linq;
using SS.Business.Dtos.Return;
using SS.Business.Models;
using SS.Data.Models;

namespace SS.Business.Mappings
{
    public class UtilityMapping
    {
        public CountriesToReturnDto MapToCountriesDto(IEnumerable<Country> countryList)
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

            var countriesToReturnDto = new CountriesToReturnDto()
            {
                Countries = countries,
            };

            return countriesToReturnDto;
        }

        public UsStatesToReturnDto MapToUsStatesDto(IEnumerable<Usstate> stateList)
        {
            var usStates = stateList.Select(s => new UsStateBModel()
            {
                Id = s.StateId,
                Abbreviation = s.StateAbbreviation,
                Name = s.StateName
            });

            var usStatesToReturnDto = new UsStatesToReturnDto()
            {
                UsStates = usStates,
            };

            return usStatesToReturnDto;
        }
    }
}