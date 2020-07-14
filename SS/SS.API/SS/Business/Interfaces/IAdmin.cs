using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Pagination;

namespace SS.Business.Interfaces
{
    public interface IAdmin
    {
        Task<PagedListDto<UserWithRolesDto>> GetUsersWithRolesAsync(AdminUsersParams p);
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<IdentityResult> UpdateRolesAsync(string userName, string[] rolesToUpdate);
        Task<IEnumerable<string>> GetRolesAsync(string userName);
    }
}