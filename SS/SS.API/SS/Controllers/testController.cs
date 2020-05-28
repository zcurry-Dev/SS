using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Data;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class testController : ControllerBase
    {
        private readonly IUserRepository _user;
        public testController(IUserRepository user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int id = 1;
            var userToReturn = await _user.GetUserById(id);

            // return Ok(userToReturn);
            return Ok("works");
        }
    }
}