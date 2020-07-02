using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Business.Interfaces;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Repos
{
    public class UtilityDataRepository : IUtilityDataRepository
    {
        private readonly DataContext _context;

        public UtilityDataRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _context.Country.ToListAsync();

            return countries;
        }

        public async Task<IEnumerable<Usstate>> GetUsStates()
        {
            var usStates = await _context.Usstate.ToListAsync();

            return usStates;
        }

        public async Task<IEnumerable<City>> GetUSCities(int usStateId)
        {
            var usCities = await _context.City.Where(c => c.StateId == usStateId).ToListAsync();

            return usCities;
        }

        public async Task<IEnumerable<ZipCode>> GetZipCodes(int usCityId)
        {
            var zipCodes = await _context.ZipCode.Where(z => z.CityId == usCityId).ToListAsync();

            return zipCodes;
        }

        public async Task<City> CreateCity(City city)
        {
            var cityExists = _context.City.Any(c => c.CityName == city.CityName && c.StateId == city.StateId);
            if (!cityExists)
            {
                Add(city);
                await SaveAll();
            }
            else
            {
                city.CityId = -1;
            }

            return city;
        }

        public async Task<ZipCode> CreateZipCode(ZipCode zipCode)
        {
            var zipCodeExists = _context.ZipCode.Any(z => z.CityId == z.CityId && z.Digits == zipCode.Digits);
            if (!zipCodeExists)
            {
                Add(zipCode);
                await SaveAll();
            }
            else
            {
                zipCode.ZipCodeId = -1;
            }

            return zipCode;
        }
    }
}