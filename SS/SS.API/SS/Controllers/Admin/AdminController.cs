using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SS.Business.Interfaces;
using SS.Business.Models.Role;
using SS.Helpers;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _admin;

        public AdminController(IAdminRepository admin) { _admin = admin; }

        [HttpGet]
        [Route("ListUsers")]
        public async Task<IActionResult> ListUsers([FromQuery] AdminUsersParams adminUsersParams)
        {
            var users = await _admin.GetAllUsersWithRoles(adminUsersParams);
            Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(users.List);
        }

        [HttpPatch]
        [Route("SaveUsers/{userName}")]
        public async Task<IActionResult> SaveUsers(string userName, RoleEditDto selectedRoles)
        {
            var result = await _admin.UpdateRolesForUser(userName, selectedRoles);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roles = await _admin.GetRolesForUser(userName);

            return Ok(roles);
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _admin.GetAllAvailibleRoles();

            return Ok(roles);
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photosForModeration")]
        public IActionResult GetPhotosForModeration()
        {
            return Ok("Admins or moderators can see this");
        }
    }
}