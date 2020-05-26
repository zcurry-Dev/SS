using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.API.Business.Dtos.Accept;
using SS.API.Business.Interfaces;
using SS.API.Helpers;

namespace SS.API.Controllers.User
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userToReturn = await _user.GetUserById(id);

            return Ok(userToReturn);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int userId, UserForUpdateDto userForUpdateDto)
        {
            // if (id != int.Parse(Artist.FindFirst(ClaimTypes.NameIdentifier).Vale)) {
            //     return Unauthorized();
            // }
            var userToReturn = await _user.GetUserById(userId);

            return Ok();
        }
    }
}