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
        public IEnumerable<UserForAdminReturnDto> MapToAdminReturnAsQueryable(IEnumerable<Ssuser> ssUsers)
        {
            var users = ssUsers.Select(u => new UserForAdminReturnDto()
            {
                Id = u.Id,
                UserName = u.UserName,
                Roles = u.SsuserRole.Select(r => r.Role.ToString()).ToList(), // is this right?? 062820/070620
            });

            return users;
        }

        public PagedListDto<UserForAdminReturnDto> MapToPagedListDto(PagedList<UserForAdminReturnDto> userList)
        {
            var toReturn = new PagedListDto<UserForAdminReturnDto>()
            {
                List = userList,
                CurrentPage = userList.CurrentPage,
                TotalPages = userList.TotalPages,
                PageSize = userList.PageSize,
                TotalCount = userList.TotalCount,
            };

            return toReturn;
        }

        public IEnumerable<RoleDto> MapToRoleDto(IEnumerable<Ssrole> ssroles)
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