using System.Collections.Generic;
using System.Linq;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models;
using SS.Business.Models.User;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Repos
{
    public class AdminMapping : IAdminMapping
    {
        public UserListForAdminReturnDto MapToUserListForAdminReturnDto(PagedList<Ssuser> list)
        {
            var users = list.Select(u => new UserForAdminReturnDto()
            {
                Id = u.Id,
                UserName = u.UserName,
                Roles = u.SsuserRole.Select(r => r.Role.ToString()).ToList(), // is this right?? 062820
            });

            var userList = new UserListForAdminReturnDto()
            {
                Users = users,
                CurrentPage = list.CurrentPage,
                TotalPages = list.TotalPages,
                PageSize = list.PageSize,
                TotalCount = list.TotalCount,
            };

            return userList;
        }

        public IEnumerable<RoleDto> MapToRoleDto(IList<Ssrole> ssroles)
        {
            var roles = ssroles.Select(r => new RoleDto()
            {
                Id = r.Id,
                Name = r.Name,
                NormalizedName = r.NormalizedName,
                ConcurrencyStamp = r.ConcurrencyStamp,
            });

            return roles;
        }
    }
}