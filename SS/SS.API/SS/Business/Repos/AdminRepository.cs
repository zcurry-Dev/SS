using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Data.Interfaces;

namespace SS.Business.Repos
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IAdminMapping _map;
        private readonly IUserDataRepository _user;
        private readonly IUserRoleDataRepository _role;

        public AdminRepository(IAdminMapping map,
                                IUserDataRepository user,
                                IUserRoleDataRepository role)
        {
            _map = map;
            _role = role;
            _user = user;
        }

        public async Task<PagedListDto<UserWithRolesDto>> GetAllUsersWithRoles(AdminUsersParams p)
        {
            var users = await _user.GetUsersForList(p.PN, p.IPP, p.Search, p.OrderBy);
            var usersWithRoles = _map.MapToUserWithRolesDto(users);

            return usersWithRoles;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAvailibleRoles()
        {
            var ssRoles = await _role.GetAll();
            var rolesToReturn = _map.MapToRoleDto(ssRoles);

            return rolesToReturn;
        }

        public async Task<IdentityResult> UpdateRolesForUser(string userName, string[] roles)
        {
            var user = await _user.Find(u => u.UserName == userName);
            var assignedRoles = user.SsuserRole.Select(r => r.Role.Name);

            var rolesToAdd = roles.Except(assignedRoles);
            var rolesToRemove = assignedRoles.Except(roles);

            var result = await _user.AddRolesToUser(user, rolesToAdd);

            if (!result.Succeeded)
            {
                return result;
            }

            result = await _user.RemoveRolesFromUser(user, rolesToRemove);

            return result;
        }

        public async Task<IEnumerable<string>> GetRolesForUser(string userName)
        {
            var user = await _user.Find(u => u.UserName == userName);
            var roles = user.SsuserRole.Select(r => r.Role.Name);
            return roles;
        }
    }
}