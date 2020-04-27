using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.API.Business.Interfaces;

namespace SS.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _user;
        public UsersController(IUserRepository user)
        {
            _user = user;
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var userToReturn = await _user.GetUser(userId);

            return Ok(userToReturn);
        }
    }
}