using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.PagedList;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Interfaces
{
    public interface IAdminRepository
    {
        Task<PagedListDto<UserWithRolesDto>> GetAllUsersWithRoles(AdminUsersParams adminUsersParams);
        Task<IEnumerable<RoleDto>> GetAllAvailibleRoles();
        Task<IdentityResult> UpdateRolesForUser(string userName, string[] rolesToUpdate);
        Task<IEnumerable<string>> GetRolesForUser(string userName);
    }
}