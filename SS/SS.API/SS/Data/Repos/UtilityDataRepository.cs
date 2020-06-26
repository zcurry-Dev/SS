using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Data;
using SS.Data.Interfaces;
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
    }
}