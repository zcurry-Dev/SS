using System.Collections.Generic;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IAdminMapping
    {
        PagedListDto<UserWithRolesDto> MapToUserWithRolesDto(PagedList<Ssuser> pl);
        IEnumerable<RoleDto> MapToRoleDto(IEnumerable<Ssrole> ssroles);
    }
}