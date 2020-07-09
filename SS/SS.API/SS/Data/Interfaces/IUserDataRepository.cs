
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IUserDataRepository : IDataRepository<Ssuser>
    {
        Task<IdentityResult> CreateUser(Ssuser user, string password);
        Task<IdentityResult> AddUserRoleOnRegister(Ssuser user);
        Task<IdentityResult> UpdateLastActiveForUser(ClaimsPrincipal cp);

        //
        //
        Task<PagedList<Ssuser>> GetUsersForList(int pageIndex, int pageSize = 10, string search = "", string orderBy = "");
        Task<IdentityResult> AddRolesToUser(Ssuser user, IEnumerable<string> roles);
        Task<IdentityResult> RemoveRolesFromUser(Ssuser user, IEnumerable<string> roles);
        Task<IEnumerable<string>> GetRolesForUserByUserName(string userName);
        Task<SignInResult> CheckPasswordSignIn(Ssuser user, string password);
    }
}