using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Business.Interfaces;
using SS.Data;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Data.Repos;

namespace SS.Business.Repos
{
    public class UtilityDataRepository : IUtilityDataRepository
    {
        private readonly DataContext _context;
        private readonly IDataRepository<Country> _country;
        private readonly IDataRepository<Usstate> _usState;
        private readonly IDataRepository<City> _usCity;
        private readonly IDataRepository<ZipCode> _usZipCode;
        private readonly IDataRepository<WorldRegion> _worldRegion;
        private readonly IDataRepository<WorldCity> _worldCity;

        public UtilityDataRepository(DataContext context
                                    , IDataRepository<Country> country
                                    , IDataRepository<Usstate> usState
                                    , IDataRepository<City> usCity
                                    , IDataRepository<ZipCode> usZipCode
                                    , IDataRepository<WorldRegion> worldRegion
                                    , IDataRepository<WorldCity> worldCity
                                    )
        {
            _context = context;
            _country = country;
            _usState = usState;
            _usCity = usCity;
            _usZipCode = usZipCode;
            _worldRegion = worldRegion;
            _worldCity = worldCity;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.AddRange(entities);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool ContextUpdated()
        {
            var entityToUpdate = _context.ChangeTracker.Entries()
                        .Where(e => e.State != EntityState.Unchanged)
                        .FirstOrDefault();

            if (entityToUpdate == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _country.GetAll();

            return countries;
        }

        public async Task<IEnumerable<Usstate>> GetUsStates()
        {
            var usStates = await _usState.GetAll();

            return usStates;
        }

        public async Task<IEnumerable<City>> GetUSCities(int usStateId)
        {
            var usCities = await _usCity.FindMany(c => c.StateId == usStateId);

            return usCities;
        }

        public async Task<IEnumerable<ZipCode>> GetZipCodes(int usCityId)
        {
            var zipCodes = await _usZipCode.FindMany(z => z.CityId == usCityId);

            return zipCodes;
        }

        public async Task<bool> CityExists(City city)
        {
            // bad practice? 070620
            var cityExists = (await _usCity.FindMany(c => c.CityName == city.CityName && c.StateId == city.StateId)).FirstOrDefault();

            if (cityExists != null) // or can I just check if Ienum exists?
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ZipCodeExits(ZipCode zipCode)
        {
            var zipCodeExists = await _usZipCode.FindMany(z => z.CityId == zipCode.CityId && z.Digits == zipCode.Digits);

            if (zipCodeExists != null)// or can I just check if Ienum exists? like this
            {
                return false;
            }

            return true;
        }

        public async Task<bool> WorldRegionExists(WorldRegion worldRegion)
        {
            var worldRegionExists = await _worldRegion.FindMany(wr => wr.WorldRegionCountry == worldRegion.WorldRegionCountry
                                                                    && wr.WorldRegionName == worldRegion.WorldRegionName);

            if (worldRegionExists != null)// or can I just check if Ienum exists? like this
            {
                return false;
            }

            return true;
        }
    }
}