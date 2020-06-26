using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Interfaces;

namespace SS.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilityController : ControllerBase
    {
        private readonly IUtilityRepository _utility;

        public UtilityController(IUtilityRepository utility) { _utility = utility; }

        [HttpGet]
        [Route("ListCountries")]
        public async Task<IActionResult> ListCountries()
        {
            var countries = await _utility.GetCountries();
            return Ok(countries.Countries);
        }

        [HttpGet]
        [Route("ListUSStates")]
        public async Task<IActionResult> ListUSStates()
        {
            var states = await _utility.GetUsStates();
            return Ok(states.UsStates);
        }

        [HttpGet]
        [Route("ListUSStateCities/{usStateId}")]
        public async Task<IActionResult> ListUSStateCities(int usStateId)
        {
            var cities = await _utility.GetUsCities(usStateId);
            return Ok(cities.UsCities);
        }
    }
}