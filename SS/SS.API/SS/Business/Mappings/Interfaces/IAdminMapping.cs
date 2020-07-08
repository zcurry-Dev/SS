using System.Collections.Generic;
using SS.Business.Models.PagedList;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IAdminMapping
    {
        IEnumerable<UserWithRolesDto> MapToAdminReturnAsQueryable(IEnumerable<Ssuser> ssUsers);
        PagedListDto<UserWithRolesDto> MapToPagedListDto(PagedList<UserWithRolesDto> userList);
        IEnumerable<RoleDto> MapToRoleDto(IEnumerable<Ssrole> ssroles);
    }
}