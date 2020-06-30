using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models;
using SS.Business.Models.User;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Interfaces
{
    public interface IAdminRepository
    {
        Task<UserListForAdminReturnDto> GetAllUsersWithRoles(AdminUsersParams adminUsersParams);
        Task<IEnumerable<RoleDto>> GetAllAvailibleRoles();
        Task<IdentityResult> UpdateRolesForUser(string userName, string[] selectedRoles);
        Task<IList<string>> GetRolesForUser(string userName);
    }
}