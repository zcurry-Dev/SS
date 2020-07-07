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
        private readonly IUserRoleDataRepository _role;

        public AdminRepository(IAdminDataRepository admin, IAdminMapping map, IUserDataRepository user, IUserRoleDataRepository role)
        {
            _admin = admin;
            _map = map;
            _role = role;
            _user = user;
        }

        public async Task<PagedListDto<UserForAdminReturnDto>> GetAllUsersWithRoles(AdminUsersParams p) //TODO need better naming of variables
        {
            string orderBy = p.OrderBy;
            string search = p.Search;

            var users = await _user.GetUsersForList(p.PN, p.PS); // what are the values of 2 above values?            
            var dto = _map.MapToAdminReturnAsQueryable(users).AsQueryable(); // wait, this may break either here or in paged list? can't remember
            var pagedList = await PagedList<UserForAdminReturnDto>.CreateAsync(dto, p.PN, p.PS);
            var pagedListDto = _map.MapToPagedListDto(pagedList);

            return pagedListDto;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAvailibleRoles()
        {
            var ssRoles = await _role.GetAll();
            var rolesToReturn = _map.MapToRoleDto(ssRoles);

            return rolesToReturn;
        }

        public async Task<IdentityResult> UpdateRolesForUser(string userName, string[] roles)
        {
            var user = await _user.GetByName(userName); //no idea if this actually works
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
            var user = await _user.GetByName(userName); //no idea if this actually works
            var roles = user.SsuserRole.Select(r => r.Role.Name);
            return roles;
        }
    }
}