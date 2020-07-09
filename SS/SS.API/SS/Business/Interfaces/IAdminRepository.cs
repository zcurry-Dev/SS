using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Data;

namespace SS.Business.Interfaces
{
    public interface IAdminRepository
    {
        Task<PagedListDto<UserWithRolesDto>> GetAllUsersWithRoles(AdminUsersParams p);
        Task<IEnumerable<RoleDto>> GetAllAvailibleRoles();
        Task<IdentityResult> UpdateRolesForUser(string userName, string[] rolesToUpdate);
        Task<IEnumerable<string>> GetRolesForUser(string userName);
    }
}