using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS.API.Business.Interfaces;
using SS.API.Data;
using SS.API.Data.Interfaces;
using SS.API.Data.Repos;
using SS.API.Dtos;
using SS.API.Dtos.User;
using SS.API.Helpers;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;

namespace SS.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<Ssuser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAdminRepository _admin;

        public AdminController(
            DataContext context,
            UserManager<Ssuser> userManager,
            IMapper mapper,
            IAdminRepository admin
            )
        {
            _mapper = mapper;
            _admin = admin;
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("usersWithRoles")]
        public async Task<IActionResult> GetUsersWithRoles([FromQuery] AdminUsersParams adminUsersParams)
        {
            var users = await _admin.GetUsersWithRoles(adminUsersParams);
            var usersToReturn = _mapper.Map<IEnumerable<UsersForAdminReturnDto>>(users);
            Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(usersToReturn);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("editRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName,
         RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var userRoles = await _userManager.GetRolesAsync(user);

            var selectedRoles = roleEditDto.RoleNames;

            selectedRoles = selectedRoles ?? new string[] { };
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded)
            {
                return BadRequest("Failed to add to roles");
            }

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded)
            {
                return BadRequest("Failed to remove the roles");
            }

            return Ok(await _userManager.GetRolesAsync(user));
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _admin.GetRoles();

            return Ok(roles);
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photosForModeration")]
        public IActionResult GetPhotosForModeration()
        {
            return Ok("Admins or moderators can see thas");
        }
    }
}