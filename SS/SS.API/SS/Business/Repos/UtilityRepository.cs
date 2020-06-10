using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Business.Models;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Business.Repos
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly IUtilityDataRepository _utility;

        public UtilityRepository(IUtilityDataRepository utility)
        {
            _utility = utility;
        }

        public async Task<UsStatesToReturnDto> GetUsStates()
        {
            var usStates = await _utility.GetUsStates();
            var usStatesToReturnDto = MapToUsStatesDto(usStates);
            return usStatesToReturnDto;
        }

        private UsStatesToReturnDto MapToUsStatesDto(IEnumerable<Usstate> stateList)
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