using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Models;

namespace SS.Business.Interfaces
{
    public interface IUtilityRepository
    {
        Task<IEnumerable<CountryBModel>> GetCountries();
        Task<IEnumerable<UsStateBModel>> GetUsStates();
        Task<IEnumerable<UsCityBModel>> GetUsCities(int usStateId);
        Task<IEnumerable<ZipCodeBModel>> GetZipCodes(int usCityId);
        Task<UsCityBModel> CreateCity(CityToCreateDto cityToCreateDto);
        Task<ZipCodeBModel> CreateZipCode(ZipCodeToCreateDto zipCodeToCreateDto);
    }
}