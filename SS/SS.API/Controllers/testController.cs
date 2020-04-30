using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SS.API.Business.Dtos.Return;
using SS.API.Data;
using SS.API.Data.Models;

namespace SS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class testController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly RoleManager<Ssrole> _roleManager;
        private readonly UserManager<Ssuser> _userManager;
        public testController(
            DataContext context,
            RoleManager<Ssrole> roleManager,
            UserManager<Ssuser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var a = await _userManager.FindByIdAsync("1");

            var users2 = _context.Ssuser
                .Select(x => new UserForAdminReturnDto
                {
                    UserId = x.Id,
                    UserName = x.UserName,
                    Roles = x.SsuserRole.Select(r => r.Role.Name).ToList()
                })
                .ToList()
                .AsQueryable();

            var users = _context.Ssuser
                .Select(user => new UserForAdminReturnDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = (from userRole in user.SsuserRole
                             join role in _context.Roles
                             on userRole.RoleId
                             equals role.Id
                             select role.Name).ToList()
                }).ToList();

            return Ok("works");
        }
    }
}