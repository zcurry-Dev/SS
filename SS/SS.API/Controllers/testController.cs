
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS.API.Data.Interfaces;
using SS.API.Business.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;
using Microsoft.AspNetCore.Mvc;
using SS.API.Data;
using Microsoft.AspNetCore.Authorization;

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
            // var u = _context.Ssuser.Include(u => u.SsuserRole);

            // var users = _context.Ssuser
            //     .Select(user => new UsersWithRoles
            //     {
            //         Id = user.Id,
            //         UserName = user.UserName,
            //         Roles = (from userRole in user.SsuserRole
            //                  join role in _context.Roles
            //                  on userRole.RoleId
            //                  equals role.Id
            //                  select role.Name).ToList()
            //     }).AsQueryable();

            var users2 = _context.Ssuser
                .Select(x => new UsersWithRolesDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Roles = x.SsuserRole.Select(r => r.Role.Name).ToList()
                })
                .ToList()
                .AsQueryable();

            var users = _context.Ssuser
                .Select(user => new UsersWithRolesDto
                {
                    Id = user.Id,
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