using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Helpers.Pagination;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Repos
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

        public async Task<UserListForAdminReturnDto> GetAllUsersWithRoles(AdminUsersParams adminUsersParams)
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
            var usersToReturn = _mapper.Map<IEnumerable<UserForAdminReturnDto>>(ssUsersList);

            var userListForAdminReturnDto = new UserListForAdminReturnDto()
            {
                Users = usersToReturn,
                CurrentPage = ssUsersList.CurrentPage,
                TotalPages = ssUsersList.TotalPages,
                PageSize = ssUsersList.PageSize,
                TotalCount = ssUsersList.TotalCount,
            };

            return userListForAdminReturnDto;
        }

        public async Task<List<RolesToReturnDto>> GetAllAvailibleRoles()
        {
            var roles = await _admin.GetAllAvailibleRoles();
            var rolesToReturn = roles.Select(r => _mapper.Map<RolesToReturnDto>(r)).ToList();

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
    }
}