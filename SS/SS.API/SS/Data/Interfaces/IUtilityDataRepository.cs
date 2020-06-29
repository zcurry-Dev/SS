using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SS.Data.Models;

namespace SS.Business.Interfaces
{
    public interface IUtilityDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Usstate>> GetUsStates();
        Task<IEnumerable<City>> GetUSCities(int usStateId);
        Task<IEnumerable<ZipCode>> GetZipCodes(int usCityId);
        Task<City> CreateCity(City city);
        Task<ZipCode> CreateZipCode(ZipCode zipCode);
    }
}