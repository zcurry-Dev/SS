using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Helpers;
using SS.Business.Interfaces;
using SS.Business.Models.User;

namespace SS.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _user.GetUserAsync(id);

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int userId, UserForUpdateDto userForUpdateDto)
        {
            // if (id != int.Parse(Artist.FindFirst(ClaimTypes.NameIdentifier).Vale)) {
            //     return Unauthorized();
            // }
            var userToReturn = await _user.GetUserAsync(userId);

            return Ok();
        }
    }
}