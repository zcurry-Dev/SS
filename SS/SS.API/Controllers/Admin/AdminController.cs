using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.API.Business.Interfaces;
using SS.API.Dtos.Role;
using SS.API.Helpers;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _admin;

        public AdminController(IAdminRepository admin) { _admin = admin; }

        [HttpGet("usersWithRoles")]
        public async Task<IActionResult> GetUsersWithRoles([FromQuery] AdminUsersParams adminUsersParams)
        {
            var users = await _admin.GetAllUsersWithRoles(adminUsersParams);
            var usersToReturn = _admin.MapToUsersForAdminReturnDto(users);
            Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(usersToReturn);
        }

        [HttpPost("editRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
            var result = await _admin.UpdateRolesForUser(userName, roleEditDto);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(await _admin.GetRolesForUser(userName));
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