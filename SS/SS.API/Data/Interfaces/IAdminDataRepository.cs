using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SS.API.Business.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;

namespace SS.API.Data.Interfaces
{
    public interface IAdminDataRepository
    {
        Task<PagedList<UsersWithRoles>> GetUsersWithRoles(AdminUsersParams adminUsersParams);
        Task<List<Ssrole>> GetRoles();
    }
}