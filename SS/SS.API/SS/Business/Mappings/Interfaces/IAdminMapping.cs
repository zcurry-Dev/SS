using System.Collections.Generic;
using SS.Business.Dtos.Return;
using SS.Business.Models;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IAdminMapping
    {
        UserListForAdminReturnDto MapToUserListForAdminReturnDto(PagedList<Ssuser> list);
        IEnumerable<RoleBModel> MapToRoleBModelList(IList<Ssrole> ssroles);
    }
}