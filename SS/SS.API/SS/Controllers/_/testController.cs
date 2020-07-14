using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class testController : ControllerBase
    {
        public testController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}