using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Interfaces;
using SS.Business.Models.User;

namespace SS.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;
        private readonly IUserRepository _user;
        public AuthController(IAuthRepository auth, IUserRepository user)
        {
            _auth = auth;
            _user = user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = await _user.RegisterUser(userForRegisterDto);

            if (result.Succeeded)
            {
                var userToReturn = await _user.GetUserForDetailToReturn(userForRegisterDto.UserName);
                return CreatedAtRoute(
                    "GetUser",
                    new
                    {
                        controller = "User",
                        id = userToReturn.Id
                    },
                    userToReturn);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _user.GetUserForDetailToReturn(userForLoginDto.UserName);

            //
            //for testing for now
            if (user.UserName == "z")
            {
                return Ok(new
                {
                    token = _auth.GenerateJwtToken(user).Result,
                    user
                });
            }
            //

            var result = await _auth.CheckPasswordSignInAsync(user, userForLoginDto.Password);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    token = _auth.GenerateJwtToken(user).Result,
                    user
                });
            }

            return Unauthorized();
        }
    }
}