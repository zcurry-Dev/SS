
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IUserDataRepository : IDataRepository<Ssuser>
    {
        // Task<Ssuser> GetUserById(string userId);
        // Task<Ssuser> GetUserByUserName(string userName);
        Task<IdentityResult> CreateUser(Ssuser user, string password);
        Task<IdentityResult> AddUserRoleOnRegister(Ssuser user);
        Task<IdentityResult> UpdateLastActiveForUser(ClaimsPrincipal cp);

        //
        //

        // 070620
        Task<IEnumerable<Ssuser>> GetUsersForList(int pageIndex, int pageSize = 10, string search = "", string orderBy = "");
        Task<IdentityResult> AddRolesToUser(Ssuser user, IEnumerable<string> roles);
        Task<IdentityResult> RemoveRolesFromUser(Ssuser user, IEnumerable<string> roles);
        Task<IEnumerable<string>> GetRolesForUserByUserName(string userName);
    }
}