using System.Collections.Generic;
using System.Threading.Tasks;
using SS.API.Business.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;

namespace SS.API.Business.Interfaces
{
    public interface IAdminRepository
    {
        Task<PagedList<UsersWithRoles>> GetUsersWithRoles(AdminUsersParams adminUsersParams);
        Task<List<Role>> GetRoles();
    }
}