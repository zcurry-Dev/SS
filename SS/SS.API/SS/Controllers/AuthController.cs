using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Interfaces;
using SS.Business.Models.User;

namespace SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly IUser _user;
        public AuthController(IAuth auth, IUser user)
        {
            _auth = auth;
            _user = user;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _user.GetUserAsync(userForLoginDto.UserName);

            //
            //for testing for now
            if (user.UserName == "z")
            {
                return Ok(new
                {
                    token = _auth.GenerateJwtTokenAsync(user).Result,
                    user
                });
            }
            //

            var result = await _auth.CheckPasswordSignInAsync(user, userForLoginDto.Password);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    token = _auth.GenerateJwtTokenAsync(user).Result,
                    user
                });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = await _user.RegisterUserAsync(userForRegisterDto);

            if (result.Succeeded)
            {
                var user = await _user.GetUserAsync(userForRegisterDto.UserName);
                return CreatedAtRoute(
                    "GetUser",
                    new
                    {
                        controller = "User",
                        id = user.Id
                    },
                    user);
            }

            return BadRequest(result.Errors);
        }
    }
}