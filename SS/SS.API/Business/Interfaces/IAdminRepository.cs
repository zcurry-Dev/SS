using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.Role;
using SS.API.Business.Dtos.User;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Business.Interfaces
{
    public interface IAdminRepository
    {
        Task<UserListForAdminReturnDto> GetAllUsersWithRoles(AdminUsersParams adminUsersParams);
        Task<List<RolesToReturnDto>> GetAllAvailibleRoles();
        Task<IdentityResult> UpdateRolesForUser(string userName, RoleEditDto roleEditDto);
        Task<IList<string>> GetRolesForUser(string userName);
    }
}