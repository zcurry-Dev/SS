using System.Collections.Generic;
using System.Linq;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.PagedList;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Repos
{
    public class AdminMapping : IAdminMapping
    {
        public PagedListDto<UserForAdminReturnDto> MapToUserListForAdminReturnDto(PagedList<Ssuser> plUsers)
        {
            var users = plUsers.Select(u => new UserForAdminReturnDto()
            {
                Id = u.Id,
                UserName = u.UserName,
                Roles = u.SsuserRole.Select(r => r.Role.ToString()).ToList(), // is this right?? 062820
            });

            var userList = new PagedListDto<UserForAdminReturnDto>()
            {
                List = users,
                CurrentPage = plUsers.CurrentPage,
                TotalPages = plUsers.TotalPages,
                PageSize = plUsers.PageSize,
                TotalCount = plUsers.TotalCount,
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