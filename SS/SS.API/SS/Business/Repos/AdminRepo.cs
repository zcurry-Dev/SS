using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Data.Interfaces;

namespace SS.Business.Repos
{
    public class AdminRepo : IAdmin
    {
        private readonly IUserRoleData _role;
        private readonly IUserData _user;
        private readonly IMap _map;

        public AdminRepo(
            IUserRoleData role,
            IUserData user,
            IMap map
            )
        {
            _role = role;
            _user = user;
            _map = map;
        }

        public async Task<PagedListDto<UserWithRolesDto>> GetUsersWithRolesAsync(AdminUsersParams p)
        {
            var users = await _user.GetUsersAsync(p.PN, p.IPP, p.Search, p.OrderBy);
            var usersWithRoles = _map.MapToUserWithRolesDto(users);

            return usersWithRoles;
        }

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            var roles = await _role.GetAllAsync();
            var rolesToReturn = _map.MapToRoleDto(roles);

            return rolesToReturn;
        }

        public async Task<IdentityResult> UpdateRolesAsync(string userName, string[] roles)
        {
            var user = await _user.FindAsync(u => u.UserName == userName);
            var assignedRoles = user.SsuserRole.Select(r => r.Role.Name);
            var rolesToAdd = roles.Except(assignedRoles);
            var rolesToRemove = assignedRoles.Except(roles);

            var result = new IdentityResult();

            if (rolesToAdd != null && rolesToAdd.Any())
            {
                result = await _user.AddRolesToUserAsync(user, rolesToAdd);
            }

            if (!result.Succeeded)
            {
                return result;
            }

            if (rolesToRemove != null && rolesToRemove.Any())
            {
                result = await _user.RemoveRolesFromUserAsync(user, rolesToRemove);
            }

            return result;
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string userName)
        {
            var user = await _user.FindAsync(u => u.UserName == userName);
            var roles = user.SsuserRole.Select(r => r.Role.Name);
            return roles;
        }
    }
}