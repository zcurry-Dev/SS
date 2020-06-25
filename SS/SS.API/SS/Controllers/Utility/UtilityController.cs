using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Interfaces;
using SS.Helpers.Pagination.PagedParams;

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
    }
}