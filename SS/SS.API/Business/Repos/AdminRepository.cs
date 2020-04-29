using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.Role;
using SS.API.Business.Dtos.User;
using SS.API.Business.Interfaces;
using SS.API.Business.Models;
using SS.API.Data.Interfaces;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Business.Repos
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IAdminDataRepository _admin;
        private readonly IMapper _mapper;
        private readonly IUserDataRepository _user;

        public AdminRepository(
            IAdminDataRepository admin,
            IUserDataRepository user,
            IMapper mapper)
        {
            _admin = admin;
            _mapper = mapper;
            _user = user;
        }

        public async Task<PagedList<UserForAdminReturnDto>> GetAllUsersWithRoles(AdminUsersParams adminUsersParams)
        {
            var allUsers = await _admin.GetAllUsersWithRoles();
            var users = allUsers.AsQueryable();

            if (!string.IsNullOrEmpty(adminUsersParams.OrderBy))
            {
                switch (adminUsersParams.OrderBy)
                {
                    case "UserName":
                        users = users.OrderByDescending(a => a.UserName);
                        break;
                    default:
                        users = users.OrderByDescending(a => a.UserId);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(adminUsersParams.Search))
            {
                users = users.Where(s => s.UserName.Contains(adminUsersParams.Search));
            }

            var p = await PagedList<UserForAdminReturnDto>.CreateAsync(users, adminUsersParams.PN, adminUsersParams.PS);

            return p;
        }

        public async Task<List<RoleBModel>> GetAllAvailibleRoles()
        {
            var roles = await _admin.GetAllAvailibleRoles();
            var rolesToReturn = roles.Select(r => _mapper.Map<RoleBModel>(r)).ToList();

            return rolesToReturn;
        }

        public async Task<IdentityResult> UpdateRolesForUser(string userName, RoleEditDto roleEditDto)
        {
            var user = await _user.GetUserByUserName(userName);
            var userRoles = await _user.GetRolesForUser(user);
            var selectedRoles = roleEditDto.RoleNames;
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

        public IEnumerable<UserForAdminReturnDto> MapToUsersForAdminReturnDto(PagedList<UserForAdminReturnDto> users)
        {
            var usersToReturn = _mapper.Map<IEnumerable<UserForAdminReturnDto>>(users);
            return usersToReturn;
        }
    }
}