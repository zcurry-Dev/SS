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
        PagedListDto<UserForAdminReturnDto> MapToUserListForAdminReturnDto(PagedList<Ssuser> plUsers);
        IEnumerable<RoleDto> MapToRoleDto(IList<Ssrole> ssroles);
    }
}