using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business;
using SS.Business.Interfaces;
using SS.Business.Models.Role;
using SS.Business.Pagination;

namespace SS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin) { _admin = admin; }

        [HttpGet]
        [Route("ListUsers")]
        public async Task<IActionResult> ListUsers([FromQuery] AdminUsersParams adminUsersParams)
        {
            var users = await _admin.GetUsersWithRolesAsync(adminUsersParams);
            Response.AddPagination(users.CurrentPage, users.ItemsPerPage,
                users.TotalItems, users.TotalPages);

            return Ok(users.ToList());
        }

        [HttpPatch]
        [Route("SaveUsers/{userName}")]
        public async Task<IActionResult> SaveUsers(string userName, RoleUpdateDto role)
        {
            var result = await _admin.UpdateRolesAsync(userName, role.Names);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roles = await _admin.GetRolesAsync(userName);

            return Ok(roles);
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _admin.GetRolesAsync();

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