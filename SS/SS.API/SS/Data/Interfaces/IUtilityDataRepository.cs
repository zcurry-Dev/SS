using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Business.Interfaces
{
    public interface IUtilityDataRepository
    {
        void Add<T>(T entity) where T : class;
        void AddRange<T>(IEnumerable<T> entities) where T : class;

        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;

        bool ContextUpdated();
        Task<bool> SaveAll();

        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Usstate>> GetUsStates();
        Task<IEnumerable<City>> GetUSCities(int usStateId);
        Task<IEnumerable<ZipCode>> GetZipCodes(int usCityId);
        Task<bool> CityExists(City city);
        Task<bool> ZipCodeExits(ZipCode zipCode);
        Task<bool> WorldRegionExists(WorldRegion worldRegion);
    }
}