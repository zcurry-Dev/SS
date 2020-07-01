using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.PagedList;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Helpers.Pagination;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Repos
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IAdminDataRepository _admin;
        private readonly IAdminMapping _map;
        private readonly IUserDataRepository _user;

        public AdminRepository(IAdminDataRepository admin, IAdminMapping map, IUserDataRepository user)
        {
            _admin = admin;
            _map = map;
            _user = user;
        }

        public async Task<PagedListDto<UserForAdminReturnDto>> GetAllUsersWithRoles(AdminUsersParams adminUsersParams)
        {
            var usersWithRoles = _admin.GetAllUsers();

            if (!string.IsNullOrEmpty(adminUsersParams.OrderBy))
            {
                switch (adminUsersParams.OrderBy)
                {
                    case "UserName":
                        usersWithRoles = usersWithRoles.OrderByDescending(a => a.UserName);
                        break;
                    default:
                        usersWithRoles = usersWithRoles.OrderByDescending(a => a.UserId);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(adminUsersParams.Search))
            {
                usersWithRoles = usersWithRoles.Where(s => s.UserName.Contains(adminUsersParams.Search));
            }

            var ssUsersList = await PagedList<Ssuser>.CreateAsync(usersWithRoles, adminUsersParams.PN, adminUsersParams.PS);
            var usersToReturn = _map.MapToUserListForAdminReturnDto(ssUsersList);

            return usersToReturn;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAvailibleRoles()
        {
            var ssRoles = await _admin.GetAllAvailibleRoles();
            var rolesToReturn = _map.MapToRoleDto(ssRoles);

            return rolesToReturn;
        }

        public async Task<IdentityResult> UpdateRolesForUser(string userName, RoleEditDto roleEditDto)
        {
            var user = await _user.GetUserByUserName(userName);
            var userRoles = await _user.GetRolesForUser(user);
            var selectedRoles = roleEditDto.Names;
            selectedRoles = selectedRoles ?? new string[] { };

            var result = await _admin.AddRolesToUser(user, selectedRoles, userRoles);

            if (!result.Succeeded)
            {
                return result;
            }

            result = await _admin.RemoveRolesFromUser(user, userRoles, selectedRoles);

            return result;
        }

        public async Task<IList<string>> GetRolesForUser(string userName)
        {
            var roles = await _user.GetRolesForUserByUserName(userName);
            return roles;
        }
    }
}