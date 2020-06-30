using System.Collections.Generic;
using SS.Business.Models;
using SS.Business.Models.User;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IAdminMapping
    {
        UserListForAdminReturnDto MapToUserListForAdminReturnDto(PagedList<Ssuser> list);
        IEnumerable<RoleDto> MapToRoleDto(IList<Ssrole> ssroles);
    }
}